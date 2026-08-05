// <copyright file="StationTransferCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/StorageTransfer/StationTransferCapacitySystem.cs
// Purpose: Fill storage-company and OC car requests to one truck load.

namespace PublicWorksPlus
{
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Common;
    using Game.Prefabs;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class StationTransferCapacitySystem : GameSystemBase
    {
        private VehicleCapacitySystem m_VehicleCapacitySystem = null!;
        private EntityQuery m_RequestQuery;

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            if (phase == SystemUpdatePhase.GameSimulation)
            {
                // Match the game's car transfer request system.
                return 16;
            }

            return 1;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            m_VehicleCapacitySystem = World.GetOrCreateSystemManaged<VehicleCapacitySystem>();

            // Only storage companies and OCs. Broader scans hurt large cities.
            m_RequestQuery = SystemAPI.QueryBuilder()
                .WithAll<Game.Companies.StorageTransferRequest>()
                .WithAny<Game.Companies.StorageCompany, Game.Objects.OutsideConnection>()
                .WithNone<Deleted, Temp>()
                .Build();

            RequireForUpdate(m_RequestQuery);
        }

        protected override void OnUpdate()
        {
            // Vanilla delivery settings should cost almost nothing.
            if (Mod.Settings is not ATTSettings settings)
            {
                return;
            }

            if (!settings.HasCustomDeliveryCapacity)
            {
                return;
            }

            DeliveryTruckSelectData truckSelectData = m_VehicleCapacitySystem.GetDeliveryTruckSelectData();

            ComponentLookup<Game.Objects.OutsideConnection> ocLookup =
                SystemAPI.GetComponentLookup<Game.Objects.OutsideConnection>(isReadOnly: true);

            BufferLookup<Game.Companies.StorageTransferRequest> requestLookup =
                SystemAPI.GetBufferLookup<Game.Companies.StorageTransferRequest>(isReadOnly: false);

            bool verbose = settings.EnableDebugLogging;

            using NativeArray<Entity> entities = m_RequestQuery.ToEntityArray(Allocator.Temp);

            int changed = 0;
            int mirrored = 0;

            for (int e = 0; e < entities.Length; e++)
            {
                Entity entity = entities[e];
                bool isOC = ocLookup.HasComponent(entity);
                DynamicBuffer<Game.Companies.StorageTransferRequest> requests = requestLookup[entity];

                for (int i = 0; i < requests.Length; i++)
                {
                    Game.Companies.StorageTransferRequest request = requests[i];

                    if (!StationTransferAmountUtil.IsEligibleOutgoingCarRequest(request.m_Flags))
                    {
                        continue;
                    }

                    if (!StationTransferAmountUtil.TryPromoteToAtLeastOneFullTruck(
                            truckSelectData,
                            request.m_Resource,
                            request.m_Amount,
                            out int adjustedAmount))
                    {
                        continue;
                    }

                    request.m_Amount = adjustedAmount;
                    requests[i] = request;
                    changed++;

                    // Keep both sides of the transfer request in sync.
                    bool mirroredThisOne = TryPromoteMatchingIncomingRequest(
                        requestLookup,
                        entity,
                        request.m_Target,
                        request.m_Resource,
                        request.m_Flags,
                        adjustedAmount);

                    if (mirroredThisOne)
                    {
                        mirrored++;
                    }

                    if (verbose)
                    {
                        string kind = isOC ? "OC-Transfer" : "StorageTransfer";

                        LogUtils.Info(
                            Mod.s_Log,
                            () =>
                            $"{Mod.ModTag} [DISPATCH][StorageTransfer] SOURCE ENTITY ID {entity.Index}:{entity.Version} " +
                            $"TARGET ENTITY ID {request.m_Target.Index}:{request.m_Target.Version} " +
                            $"kind={kind} Resource={request.m_Resource} Request={adjustedAmount} Flags={request.m_Flags} Mirrored={mirroredThisOne}");
                    }
                }
            }

            if (changed > 0 && verbose)
            {
                LogUtils.Info(
                    Mod.s_Log,
                    () =>
                    $"{Mod.ModTag} StationTransferCapacity: promoted {changed} storage-company/OC outbound car request(s) to full truck size; mirrored {mirrored} matching incoming request(s).");
            }
        }

        private static bool TryPromoteMatchingIncomingRequest(
            BufferLookup<Game.Companies.StorageTransferRequest> requestLookup,
            Entity sourceEntity,
            Entity targetEntity,
            Game.Economy.Resource resource,
            Game.Companies.StorageTransferFlags outgoingFlags,
            int adjustedAmount)
        {
            if (!requestLookup.HasBuffer(targetEntity))
            {
                return false;
            }

            DynamicBuffer<Game.Companies.StorageTransferRequest> targetRequests = requestLookup[targetEntity];

            // The target copy keeps the same flags plus Incoming.
            Game.Companies.StorageTransferFlags expectedIncomingFlags =
                outgoingFlags | Game.Companies.StorageTransferFlags.Incoming;

            for (int i = 0; i < targetRequests.Length; i++)
            {
                Game.Companies.StorageTransferRequest incoming = targetRequests[i];

                if (incoming.m_Target != sourceEntity)
                {
                    continue;
                }

                if (incoming.m_Resource != resource)
                {
                    continue;
                }

                if (incoming.m_Flags != expectedIncomingFlags)
                {
                    continue;
                }

                if (incoming.m_Amount >= adjustedAmount)
                {
                    return false;
                }

                incoming.m_Amount = adjustedAmount;
                targetRequests[i] = incoming;
                return true;
            }

            return false;
        }
    }
}
