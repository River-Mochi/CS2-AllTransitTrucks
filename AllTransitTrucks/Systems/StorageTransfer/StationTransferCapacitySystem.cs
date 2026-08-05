// <copyright file="StationTransferCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/StorageTransfer/StationTransferCapacitySystem.cs
// Purpose: Fill one storage-company or outside-connection car request per source.

namespace PublicWorksPlus
{
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Companies;
    using Game.Economy;
    using Game.Prefabs;
    using Game.Tools;
    using Game.Vehicles;
    using Unity.Burst;
    using Unity.Burst.Intrinsics;
    using Unity.Collections;
    using Unity.Collections.LowLevel.Unsafe;
    using Unity.Entities;
    using Unity.Jobs;

    public sealed partial class StationTransferCapacitySystem : GameSystemBase
    {
        private VehicleCapacitySystem m_VehicleCapacitySystem = null!;
        private EntityQuery m_RequestQuery;

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            // Match CarStorageTransferRequestSystem.
            return 16;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            m_VehicleCapacitySystem = World.GetOrCreateSystemManaged<VehicleCapacitySystem>();

            // Game.Objects.OutsideConnection is the live entity marker.
            m_RequestQuery = SystemAPI.QueryBuilder()
                .WithAll<StorageTransferRequest, Resources>()
                .WithAny<Game.Companies.StorageCompany, Game.Objects.OutsideConnection>()
                .WithNone<Deleted, Temp>()
                .Build();

            RequireForUpdate(m_RequestQuery);
        }

        protected override void OnUpdate()
        {
            if (Mod.Settings is not ATTSettings settings ||
                !settings.ShouldRunFullLoadDispatchHelper)
            {
                return;
            }

            NativeQueue<MirrorChange> mirrors = new(Allocator.TempJob);

            JobHandle promoteHandle = new PromoteRequestsJob
            {
                m_EntityType = SystemAPI.GetEntityTypeHandle(),
                m_RequestType = SystemAPI.GetBufferTypeHandle<StorageTransferRequest>(isReadOnly: false),
                m_ResourceType = SystemAPI.GetBufferTypeHandle<Resources>(isReadOnly: true),

                m_PropertyLookup = SystemAPI.GetComponentLookup<PropertyRenter>(isReadOnly: true),
                m_OutsideConnectionLookup =
                    SystemAPI.GetComponentLookup<Game.Objects.OutsideConnection>(isReadOnly: true),
                m_TruckLookup =
                    SystemAPI.GetComponentLookup<Game.Vehicles.DeliveryTruck>(isReadOnly: true),

                m_GuestVehicleLookup = SystemAPI.GetBufferLookup<GuestVehicle>(isReadOnly: true),
                m_LayoutLookup = SystemAPI.GetBufferLookup<LayoutElement>(isReadOnly: true),

                m_TruckSelectData = m_VehicleCapacitySystem.GetDeliveryTruckSelectData(),
                m_Mirrors = mirrors.AsParallelWriter(),
            }.ScheduleParallel(m_RequestQuery, Dependency);

            JobHandle mirrorHandle = new ApplyMirrorsJob
            {
                m_Mirrors = mirrors,
                m_RequestLookup = SystemAPI.GetBufferLookup<StorageTransferRequest>(isReadOnly: false),
            }.Schedule(promoteHandle);

            // Disposal waits for both jobs and keeps vanilla ordered after us.
            Dependency = mirrors.Dispose(mirrorHandle);
        }

        private struct MirrorChange
        {
            public Entity Source;
            public Entity Target;
            public Resource Resource;
            public StorageTransferFlags ExpectedIncomingFlags;
            public int Amount;
        }

        [BurstCompile]
        private struct PromoteRequestsJob : IJobChunk
        {
            [ReadOnly] public EntityTypeHandle m_EntityType;
            public BufferTypeHandle<StorageTransferRequest> m_RequestType;
            [ReadOnly] public BufferTypeHandle<Resources> m_ResourceType;

            [ReadOnly] public ComponentLookup<PropertyRenter> m_PropertyLookup;
            [ReadOnly] public ComponentLookup<Game.Objects.OutsideConnection> m_OutsideConnectionLookup;
            [ReadOnly] public ComponentLookup<Game.Vehicles.DeliveryTruck> m_TruckLookup;

            [ReadOnly] public BufferLookup<GuestVehicle> m_GuestVehicleLookup;
            [ReadOnly] public BufferLookup<LayoutElement> m_LayoutLookup;

            [ReadOnly] public DeliveryTruckSelectData m_TruckSelectData;
            public NativeQueue<MirrorChange>.ParallelWriter m_Mirrors;

            public void Execute(
                in ArchetypeChunk chunk,
                int unfilteredChunkIndex,
                bool useEnabledMask,
                in v128 chunkEnabledMask)
            {
                _ = unfilteredChunkIndex;
                _ = useEnabledMask;
                _ = chunkEnabledMask;

                NativeArray<Entity> entities = chunk.GetNativeArray(m_EntityType);
                BufferAccessor<StorageTransferRequest> requestBuffers =
                    chunk.GetBufferAccessor(ref m_RequestType);
                BufferAccessor<Resources> resourceBuffers =
                    chunk.GetBufferAccessor(ref m_ResourceType);

                for (int entityIndex = 0; entityIndex < chunk.Count; entityIndex++)
                {
                    Entity source = entities[entityIndex];
                    DynamicBuffer<StorageTransferRequest> requests = requestBuffers[entityIndex];
                    DynamicBuffer<Resources> resources = resourceBuffers[entityIndex];

                    for (int requestIndex = 0; requestIndex < requests.Length; requestIndex++)
                    {
                        StorageTransferRequest request = requests[requestIndex];

                        if (!StationTransferAmountUtil.IsEligibleOutgoingCarRequest(request.m_Flags))
                        {
                            continue;
                        }

                        // Match the targets vanilla accepts for car transfers.
                        if (!m_PropertyLookup.HasComponent(request.m_Target) &&
                            !m_OutsideConnectionLookup.HasComponent(request.m_Target))
                        {
                            break;
                        }

                        int available = EconomyUtils.GetResources(request.m_Resource, resources);

                        available -= VehicleUtils.GetAllBuyingResourcesTrucks(
                            source,
                            request.m_Resource,
                            ref m_TruckLookup,
                            ref m_GuestVehicleLookup,
                            ref m_LayoutLookup);

                        if (available < request.m_Amount)
                        {
                            continue;
                        }

                        if (StationTransferAmountUtil.TryPromoteToAtLeastOneFullTruck(
                                m_TruckSelectData,
                                request.m_Resource,
                                request.m_Amount,
                                out int adjustedAmount) &&
                            adjustedAmount <= available)
                        {
                            request.m_Amount = adjustedAmount;
                            requests[requestIndex] = request;

                            m_Mirrors.Enqueue(new MirrorChange
                            {
                                Source = source,
                                Target = request.m_Target,
                                Resource = request.m_Resource,
                                ExpectedIncomingFlags =
                                    request.m_Flags | StorageTransferFlags.Incoming,
                                Amount = adjustedAmount,
                            });
                        }

                        // Vanilla handles one actionable request per source per pass.
                        break;
                    }
                }
            }
        }

        [BurstCompile]
        private struct ApplyMirrorsJob : IJob
        {
            public NativeQueue<MirrorChange> m_Mirrors;

            // Targets are arbitrary entities, so mirror in one serial job.
            [NativeDisableParallelForRestriction]
            public BufferLookup<StorageTransferRequest> m_RequestLookup;

            public void Execute()
            {
                while (m_Mirrors.TryDequeue(out MirrorChange change))
                {
                    if (!m_RequestLookup.HasBuffer(change.Target))
                    {
                        continue;
                    }

                    DynamicBuffer<StorageTransferRequest> requests =
                        m_RequestLookup[change.Target];

                    for (int requestIndex = 0; requestIndex < requests.Length; requestIndex++)
                    {
                        StorageTransferRequest incoming = requests[requestIndex];

                        if (incoming.m_Target != change.Source ||
                            incoming.m_Resource != change.Resource ||
                            incoming.m_Flags != change.ExpectedIncomingFlags)
                        {
                            continue;
                        }

                        if (incoming.m_Amount < change.Amount)
                        {
                            incoming.m_Amount = change.Amount;
                            requests[requestIndex] = incoming;
                        }

                        break;
                    }
                }
            }
        }
    }
}
