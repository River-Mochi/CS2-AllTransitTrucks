// <copyright file="CompanyShoppingCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/StorageTransfer/CompanyShoppingCapacitySystem.cs
// Purpose: Raise company input requests toward one truck load.

namespace PublicWorksPlus
{
    using Game;
    using Game.Citizens;
    using Game.Common;
    using Game.Companies;
    using Game.Economy;
    using Game.Prefabs;
    using Game.Tools;
    using Game.Vehicles;
    using Unity.Burst;
    using Unity.Burst.Intrinsics;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Jobs;
    using Unity.Mathematics;

    public sealed partial class CompanyShoppingCapacitySystem : GameSystemBase
    {
        private ResourceSystem m_ResourceSystem = null!;
        private VehicleCapacitySystem m_VehicleCapacitySystem = null!;
        private EntityQuery m_BuyerQuery;

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            // ResourceBuyer is short-lived, so catch it before the vanilla buyer system.
            return 16;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            m_ResourceSystem = World.GetOrCreateSystemManaged<ResourceSystem>();
            m_VehicleCapacitySystem = World.GetOrCreateSystemManaged<VehicleCapacitySystem>();

            m_BuyerQuery = SystemAPI.QueryBuilder()
                .WithAll<ResourceBuyer, BuyingCompany, PrefabRef>()
                .WithNone<Deleted, Temp>()
                .Build();

            RequireForUpdate(m_BuyerQuery);
        }

        protected override void OnUpdate()
        {
            if (Mod.Settings is not ATTSettings settings ||
                !settings.ShouldRunFullLoadDispatchHelper)
            {
                return;
            }

            JobHandle handle = new CompanyShoppingJob
            {
                m_EntityType = SystemAPI.GetEntityTypeHandle(),
                m_BuyerType = SystemAPI.GetComponentTypeHandle<ResourceBuyer>(isReadOnly: false),
                m_PrefabType = SystemAPI.GetComponentTypeHandle<PrefabRef>(isReadOnly: true),

                m_ProcessLookup =
                    SystemAPI.GetComponentLookup<IndustrialProcessData>(isReadOnly: true),
                m_LimitLookup =
                    SystemAPI.GetComponentLookup<StorageLimitData>(isReadOnly: true),
                m_ResourceDataLookup =
                    SystemAPI.GetComponentLookup<ResourceData>(isReadOnly: true),
                m_TruckLookup =
                    SystemAPI.GetComponentLookup<Game.Vehicles.DeliveryTruck>(isReadOnly: true),

                m_ResourcesLookup =
                    SystemAPI.GetBufferLookup<Resources>(isReadOnly: true),
                m_OwnedVehicleLookup =
                    SystemAPI.GetBufferLookup<OwnedVehicle>(isReadOnly: true),
                m_TripLookup =
                    SystemAPI.GetBufferLookup<TripNeeded>(isReadOnly: true),
                m_LayoutLookup =
                    SystemAPI.GetBufferLookup<LayoutElement>(isReadOnly: true),

                m_ResourcePrefabs = m_ResourceSystem.GetPrefabs(),
                m_TruckSelectData = m_VehicleCapacitySystem.GetDeliveryTruckSelectData(),
            }.ScheduleParallel(m_BuyerQuery, Dependency);

            // ResourcePrefabs stays valid until this reader finishes.
            m_ResourceSystem.AddPrefabsReader(handle);
            Dependency = handle;
        }

        [BurstCompile]
        private struct CompanyShoppingJob : IJobChunk
        {
            [ReadOnly] public EntityTypeHandle m_EntityType;
            public ComponentTypeHandle<ResourceBuyer> m_BuyerType;
            [ReadOnly] public ComponentTypeHandle<PrefabRef> m_PrefabType;

            [ReadOnly] public ComponentLookup<IndustrialProcessData> m_ProcessLookup;
            [ReadOnly] public ComponentLookup<StorageLimitData> m_LimitLookup;
            [ReadOnly] public ComponentLookup<ResourceData> m_ResourceDataLookup;
            [ReadOnly] public ComponentLookup<Game.Vehicles.DeliveryTruck> m_TruckLookup;

            [ReadOnly] public BufferLookup<Resources> m_ResourcesLookup;
            [ReadOnly] public BufferLookup<OwnedVehicle> m_OwnedVehicleLookup;
            [ReadOnly] public BufferLookup<TripNeeded> m_TripLookup;
            [ReadOnly] public BufferLookup<LayoutElement> m_LayoutLookup;

            [ReadOnly] public ResourcePrefabs m_ResourcePrefabs;
            [ReadOnly] public DeliveryTruckSelectData m_TruckSelectData;

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
                NativeArray<ResourceBuyer> buyers =
                    chunk.GetNativeArray(ref m_BuyerType);
                NativeArray<PrefabRef> prefabs =
                    chunk.GetNativeArray(ref m_PrefabType);

                for (int i = 0; i < chunk.Count; i++)
                {
                    ResourceBuyer buyer = buyers[i];
                    if (buyer.m_AmountNeeded <= 0)
                    {
                        continue;
                    }

                    Resource resource = buyer.m_ResourceNeeded;
                    if (!IsWeightedResource(resource))
                    {
                        continue;
                    }

                    Entity prefab = prefabs[i].m_Prefab;
                    if (!m_ProcessLookup.HasComponent(prefab))
                    {
                        continue;
                    }

                    IndustrialProcessData process = m_ProcessLookup[prefab];
                    if (resource != process.m_Input1.m_Resource &&
                        resource != process.m_Input2.m_Resource)
                    {
                        continue;
                    }

                    m_TruckSelectData.GetCapacityRange(
                        resource,
                        out _,
                        out int maxTruckCapacity);

                    if (maxTruckCapacity <= buyer.m_AmountNeeded)
                    {
                        continue;
                    }

                    int storageLimit = m_LimitLookup.HasComponent(prefab)
                        ? m_LimitLookup[prefab].m_Limit
                        : int.MaxValue;

                    int storageUsed =
                        GetTotalKnownWeightedStorageUsed(entities[i], process);

                    int storageLeft = storageLimit == int.MaxValue
                        ? int.MaxValue
                        : math.max(0, storageLimit - storageUsed);

                    int desiredRequest = storageLeft == int.MaxValue
                        ? maxTruckCapacity
                        : math.min(maxTruckCapacity, storageLeft);

                    if (desiredRequest <= buyer.m_AmountNeeded)
                    {
                        continue;
                    }

                    if (!StationTransferAmountUtil.TryGetSafeSelectedTruckCapacity(
                            m_TruckSelectData,
                            resource,
                            desiredRequest,
                            out int safeTruckCapacity))
                    {
                        continue;
                    }

                    desiredRequest = math.min(desiredRequest, safeTruckCapacity);
                    if (desiredRequest <= buyer.m_AmountNeeded)
                    {
                        continue;
                    }

                    buyer.m_AmountNeeded = desiredRequest;
                    buyers[i] = buyer;
                }
            }

            private bool IsWeightedResource(Resource resource)
            {
                if (resource == Resource.NoResource)
                {
                    return false;
                }

                Entity resourcePrefab = m_ResourcePrefabs[resource];
                return resourcePrefab != Entity.Null &&
                       m_ResourceDataLookup.HasComponent(resourcePrefab) &&
                       m_ResourceDataLookup[resourcePrefab].m_Weight > 0f;
            }

            private int GetKnownInputAmount(Entity company, Resource resource)
            {
                int amount = 0;

                if (m_ResourcesLookup.HasBuffer(company))
                {
                    amount += EconomyUtils.GetResources(
                        resource,
                        m_ResourcesLookup[company]);
                }

                if (m_OwnedVehicleLookup.HasBuffer(company))
                {
                    DynamicBuffer<OwnedVehicle> vehicles =
                        m_OwnedVehicleLookup[company];

                    for (int i = 0; i < vehicles.Length; i++)
                    {
                        amount += VehicleUtils.GetBuyingTrucksLoad(
                            vehicles[i].m_Vehicle,
                            resource,
                            ref m_TruckLookup,
                            ref m_LayoutLookup);
                    }
                }

                if (m_TripLookup.HasBuffer(company))
                {
                    DynamicBuffer<TripNeeded> trips = m_TripLookup[company];

                    for (int i = 0; i < trips.Length; i++)
                    {
                        TripNeeded trip = trips[i];
                        if (trip.m_Resource == resource &&
                            (trip.m_Purpose == Purpose.Shopping ||
                             trip.m_Purpose == Purpose.CompanyShopping))
                        {
                            amount += trip.m_Data;
                        }
                    }
                }

                return amount;
            }

            private int GetKnownOutputAmount(Entity company, Resource resource)
            {
                if (!m_ResourcesLookup.HasBuffer(company))
                {
                    return 0;
                }

                return EconomyUtils.GetResources(
                    resource,
                    m_ResourcesLookup[company]);
            }

            private int GetTotalKnownWeightedStorageUsed(
                Entity company,
                IndustrialProcessData process)
            {
                int used = 0;

                Resource input1 = process.m_Input1.m_Resource;
                Resource input2 = process.m_Input2.m_Resource;
                Resource output = process.m_Output.m_Resource;

                if (IsWeightedResource(input1))
                {
                    used += GetKnownInputAmount(company, input1);
                }

                if (input2 != Resource.NoResource &&
                    input2 != input1 &&
                    IsWeightedResource(input2))
                {
                    used += GetKnownInputAmount(company, input2);
                }

                if (output != Resource.NoResource &&
                    output != input1 &&
                    output != input2 &&
                    IsWeightedResource(output))
                {
                    used += GetKnownOutputAmount(company, output);
                }

                return used;
            }
        }
    }
}
