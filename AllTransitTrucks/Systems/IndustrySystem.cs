// <copyright file="IndustrySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/IndustrySystem.cs
// Purpose: Apply industry fleet and delivery-capacity settings.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Common;
    using Game.Economy;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class IndustrySystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;

        // Cache vanilla values so repeated slider changes never stack.
        private Dictionary<Entity, int> m_CargoStationBaseMaxTransports = null!;
        private Dictionary<Entity, int> m_DeliveryTruckBaseCargoCapacity = null!;
        private Dictionary<Entity, int> m_ExtractorCompanyBaseMaxTransports = null!;
        private Dictionary<Entity, int> m_RawMaterialFacilityBaseMaxTransports = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            m_CargoStationBaseMaxTransports = new Dictionary<Entity, int>();
            m_DeliveryTruckBaseCargoCapacity = new Dictionary<Entity, int>();
            m_ExtractorCompanyBaseMaxTransports = new Dictionary<Entity, int>();
            m_RawMaterialFacilityBaseMaxTransports = new Dictionary<Entity, int>();

            EntityQuery anyRelevantPrefabQuery = SystemAPI.QueryBuilder()
                .WithAll<Game.Prefabs.PrefabData>()
                .WithAny<Game.Prefabs.TransportCompanyData, Game.Prefabs.DeliveryTruckData>()
                .Build();

            RequireForUpdate(anyRelevantPrefabQuery);

            // One-shot system. Loading or settings changes re-enable it.
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            bool isRealGame =
                mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);

            if (!isRealGame)
            {
                return;
            }

            // New city means new prefab entities and new vanilla bases.
            m_CargoStationBaseMaxTransports.Clear();
            m_DeliveryTruckBaseCargoCapacity.Clear();
            m_ExtractorCompanyBaseMaxTransports.Clear();
            m_RawMaterialFacilityBaseMaxTransports.Clear();

#if DEBUG
            LogUtils.Info(Mod.s_Log, () => $"{Mod.ModTag} City Loading Complete -> applying Industry settings");
#endif
            Enabled = true;
        }

        protected override void OnUpdate()
        {
            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
            {
                Enabled = false;
                return;
            }

            if (Mod.Settings is not ATTSettings settings)
            {
                Enabled = false;
                return;
            }

#if DEBUG
            bool verbose = settings.EnableDebugLogging;
#endif

            ComponentLookup<CarTractorData> tractorLookup =
                SystemAPI.GetComponentLookup<CarTractorData>(isReadOnly: true);
            ComponentLookup<CarTrailerData> trailerLookup =
                SystemAPI.GetComponentLookup<CarTrailerData>(isReadOnly: true);

            EntityCommandBuffer ecb = new(Allocator.Temp);
            bool anyPrefabTaggedUpdated = false;

            // Cargo station fleet.
            {
                float scalar = ScalarMath.ClampScalar(
                    settings.CargoStationMaxTrucksScalar,
                    ATTSettings.CargoStationMinScalar,
                    ATTSettings.CargoStationMaxScalar);

                foreach ((RefRW<Game.Prefabs.TransportCompanyData> companyRef, Entity prefabEntity) in SystemAPI
                             .Query<RefRW<Game.Prefabs.TransportCompanyData>>()
                             .WithAll<Game.Prefabs.CargoTransportStationData, Game.Prefabs.PrefabData>()
                             .WithEntityAccess())
                {
                    ref Game.Prefabs.TransportCompanyData company = ref companyRef.ValueRW;

                    int baseMax = GetOrCacheCargoStationBase(prefabEntity, company.m_MaxTransports);

                    if (baseMax <= 0 && company.m_MaxTransports <= 0)
                    {
                        continue;
                    }

                    int newMax = ScalarMath.ScaleIntRoundedAllowZeroMin1(baseMax, scalar);

                    if (newMax != company.m_MaxTransports)
                    {
#if DEBUG
                        if (verbose)
                        {
                            string prefabName = PrefabNameUtil.GetNameSafe(m_PrefabSystem, prefabEntity);
                            LogUtils.Info(
                                Mod.s_Log,
                                () => $"{Mod.ModTag} Cargo station fleet: '{prefabName}' Base={baseMax} x{scalar:0.##} -> {newMax}");
                        }
#endif
                        company.m_MaxTransports = newMax;
                        TagPrefabUpdatedIfMissing(prefabEntity, ref ecb, ref anyPrefabTaggedUpdated);
                    }
                }
            }

            // Delivery cargo capacities.
            {
                // Settings store percent; prefab math uses scalar.
                float semiScalar = ScalarMath.PercentToScalarClamped(
                    settings.SemiTruckCargoScalar,
                    ATTSettings.DeliveryMinPercent,
                    ATTSettings.DeliveryMaxPercent);
                float vanScalar = ScalarMath.PercentToScalarClamped(
                    settings.DeliveryVanCargoScalar,
                    ATTSettings.DeliveryMinPercent,
                    ATTSettings.DeliveryMaxPercent);
                float rawScalar = ScalarMath.PercentToScalarClamped(
                    settings.CoalTruckScalar,
                    ATTSettings.DeliveryMinPercent,
                    ATTSettings.DeliveryMaxPercent);
                float mbikeScalar = ScalarMath.PercentToScalarClamped(
                    settings.MotorbikeDeliveryCargoScalar,
                    ATTSettings.DeliveryMinPercent,
                    ATTSettings.DeliveryMaxPercent);

                foreach ((RefRW<Game.Prefabs.DeliveryTruckData> truckRef, Entity prefabEntity) in SystemAPI
                             .Query<RefRW<Game.Prefabs.DeliveryTruckData>>()
                             .WithAll<Game.Prefabs.PrefabData>()
                             .WithEntityAccess())
                {
                    ref Game.Prefabs.DeliveryTruckData data = ref truckRef.ValueRW;

                    int baseCap = GetOrCacheDeliveryTruckBase(prefabEntity, data.m_CargoCapacity);

                    if (baseCap <= 0 && data.m_CargoCapacity <= 0)
                    {
                        continue;
                    }

                    string prefabName = PrefabNameUtil.GetNameSafe(m_PrefabSystem, prefabEntity);

                    VehicleHelpers.GetTrailerTypeInfo(
                        in tractorLookup,
                        in trailerLookup,
                        prefabEntity,
                        out bool hasTractor,
                        out CarTrailerType tractorType,
                        out bool hasTrailer,
                        out CarTrailerType trailerType);

                    VehicleHelpers.DeliveryBucket bucket = VehicleHelpers.ClassifyDeliveryTruckPrefab(
                        prefabName,
                        baseCap,
                        data.m_TransportedResources,
                        hasTractor,
                        tractorType,
                        hasTrailer,
                        trailerType);

                    if (bucket == VehicleHelpers.DeliveryBucket.Other)
                    {
                        continue;
                    }

                    float scalar =
                        bucket == VehicleHelpers.DeliveryBucket.Semi ? semiScalar :
                        bucket == VehicleHelpers.DeliveryBucket.Van ? vanScalar :
                        bucket == VehicleHelpers.DeliveryBucket.RawMaterials ? rawScalar :
                        mbikeScalar;

                    int newCap = ScalarMath.ScaleIntRoundedAllowZeroMin1(baseCap, scalar);

                    if (newCap != data.m_CargoCapacity)
                    {
#if DEBUG
                        if (verbose)
                        {
                            string resources = data.m_TransportedResources.ToString();
                            LogUtils.Info(
                                Mod.s_Log,
                                () => $"{Mod.ModTag} Delivery cargo: '{prefabName}' Bucket={bucket} Base={baseCap} x{scalar:0.##} -> {newCap} Resources={resources}");
                        }
#endif
                        data.m_CargoCapacity = newCap;
                        TagPrefabUpdatedIfMissing(prefabEntity, ref ecb, ref anyPrefabTaggedUpdated);
                    }
                }
            }

            // True extractor facilities only.
            {
                float scalar = ScalarMath.ClampScalar(
                    settings.ExtractorMaxTrucksScalar,
                    ATTSettings.CargoStationMinScalar,
                    ATTSettings.CargoStationMaxScalar);

#if DEBUG
                int matched = 0;
                int changed = 0;
                int skippedZero = 0;
#endif

                foreach ((RefRW<Game.Prefabs.TransportCompanyData> companyRef, Entity prefabEntity) in SystemAPI
                             .Query<RefRW<Game.Prefabs.TransportCompanyData>>()
                             .WithAll<Game.Prefabs.ExtractorCompanyData, Game.Prefabs.PrefabData>()
                             .WithEntityAccess())
                {
                    ref Game.Prefabs.TransportCompanyData company = ref companyRef.ValueRW;

                    int baseMax = GetOrCacheIndustryCompanyBase(
                        m_ExtractorCompanyBaseMaxTransports,
                        prefabEntity,
                        company.m_MaxTransports);

                    if (baseMax <= 0 && company.m_MaxTransports <= 0)
                    {
#if DEBUG
                        skippedZero++;
#endif
                        continue;
                    }

#if DEBUG
                    matched++;
#endif
                    int desired = ScalarMath.ScaleIntRoundedAllowZeroMin1(baseMax, scalar);

                    if (company.m_MaxTransports != desired)
                    {
                        company.m_MaxTransports = desired;

#if DEBUG
                        changed++;

                        if (verbose)
                        {
                            string prefabName = PrefabNameUtil.GetNameSafe(m_PrefabSystem, prefabEntity);
                            LogUtils.Info(
                                Mod.s_Log,
                                () => $"{Mod.ModTag} Extractor fleet: '{prefabName}' Base={baseMax} x{scalar:0.##} -> {desired}");
                        }
#endif
                        TagPrefabUpdatedIfMissing(prefabEntity, ref ecb, ref anyPrefabTaggedUpdated);
                    }
                }

#if DEBUG
                if (verbose)
                {
                    LogUtils.Info(
                        Mod.s_Log,
                        () => $"{Mod.ModTag} Extractor fleet: scalar={scalar:0.##} matched={matched} changed={changed} skippedZero={skippedZero}");
                }
#endif
            }

            // Non-extractor mineral plants and raw-material warehouses.
            {
                float scalar = ScalarMath.ClampScalar(
                    settings.RawMaterialFacilityMaxTrucksScalar,
                    ATTSettings.CargoStationMinScalar,
                    ATTSettings.CargoStationMaxScalar);

#if DEBUG
                int matched = 0;
                int changed = 0;
                int skippedZero = 0;
#endif

                foreach ((RefRW<Game.Prefabs.TransportCompanyData> companyRef,
                          RefRO<Game.Prefabs.IndustrialProcessData> processRef,
                          Entity prefabEntity) in SystemAPI
                             .Query<
                                 RefRW<Game.Prefabs.TransportCompanyData>,
                                 RefRO<Game.Prefabs.IndustrialProcessData>>()
                             .WithAll<Game.Prefabs.PrefabData>()
                             .WithNone<Game.Prefabs.ExtractorCompanyData>()
                             .WithNone<Game.Prefabs.CargoTransportStationData>()
                             .WithNone<Game.Prefabs.OutsideConnectionData>()
                             .WithEntityAccess())
                {
                    Resource output = processRef.ValueRO.m_Output.m_Resource;
                    if (!IsRawMaterialFacilityResource(output))
                    {
                        continue;
                    }

                    ref Game.Prefabs.TransportCompanyData company = ref companyRef.ValueRW;

                    int baseMax = GetOrCacheIndustryCompanyBase(
                        m_RawMaterialFacilityBaseMaxTransports,
                        prefabEntity,
                        company.m_MaxTransports);

                    if (baseMax <= 0 && company.m_MaxTransports <= 0)
                    {
#if DEBUG
                        skippedZero++;
#endif
                        continue;
                    }

#if DEBUG
                    matched++;
#endif
                    int desired = ScalarMath.ScaleIntRoundedAllowZeroMin1(baseMax, scalar);

                    if (company.m_MaxTransports != desired)
                    {
                        company.m_MaxTransports = desired;

#if DEBUG
                        changed++;

                        if (verbose)
                        {
                            string prefabName = PrefabNameUtil.GetNameSafe(m_PrefabSystem, prefabEntity);
                            LogUtils.Info(
                                Mod.s_Log,
                                () => $"{Mod.ModTag} Raw-material facility fleet: '{prefabName}' Output={output} Base={baseMax} x{scalar:0.##} -> {desired}");
                        }
#endif
                        TagPrefabUpdatedIfMissing(prefabEntity, ref ecb, ref anyPrefabTaggedUpdated);
                    }
                }

#if DEBUG
                if (verbose)
                {
                    LogUtils.Info(
                        Mod.s_Log,
                        () => $"{Mod.ModTag} Raw-material facility fleet: scalar={scalar:0.##} matched={matched} changed={changed} skippedZero={skippedZero}");
                }
#endif
            }

            if (anyPrefabTaggedUpdated)
            {
                ecb.Playback(EntityManager);
            }

            ecb.Dispose();
            Enabled = false;
        }

        private void TagPrefabUpdatedIfMissing(
            Entity prefabEntity,
            ref EntityCommandBuffer ecb,
            ref bool anyPrefabTaggedUpdated)
        {
            // Updated tells the prefab pipeline to rebuild changed data.
            if (!SystemAPI.HasComponent<Updated>(prefabEntity))
            {
                ecb.AddComponent<Updated>(prefabEntity);
                anyPrefabTaggedUpdated = true;
            }
        }

        private static bool IsRawMaterialFacilityResource(Resource resource)
        {
            // Extractors are excluded by component; this catches their storage/processing partners.
            return resource == Resource.Ore ||
                   resource == Resource.Coal ||
                   resource == Resource.Stone ||
                   resource == Resource.Minerals;
        }

        private int GetOrCacheCargoStationBase(Entity prefabEntity, int currentValue)
        {
            if (m_CargoStationBaseMaxTransports.TryGetValue(prefabEntity, out int baseMax))
            {
                return baseMax;
            }

            if (TryGetCargoStationVanillaMax(prefabEntity, out int vanilla) && vanilla > 0)
            {
                baseMax = vanilla;
            }
            else
            {
                baseMax = currentValue;
            }

            m_CargoStationBaseMaxTransports[prefabEntity] = baseMax;
            return baseMax;
        }

        private bool TryGetCargoStationVanillaMax(Entity prefabEntity, out int baseMax)
        {
            baseMax = 0;

            if (!PrefabComponentUtil.TryGetComponent(
                    m_PrefabSystem,
                    prefabEntity,
                    out Game.Prefabs.CargoTransportStation station))
            {
                return false;
            }

            baseMax = station.transports;
            return true;
        }

        private int GetOrCacheDeliveryTruckBase(Entity prefabEntity, int currentValue)
        {
            if (m_DeliveryTruckBaseCargoCapacity.TryGetValue(prefabEntity, out int baseCap))
            {
                return baseCap;
            }

            if (TryGetDeliveryTruckVanillaCargo(prefabEntity, out int vanilla) && vanilla >= 0)
            {
                baseCap = vanilla;
            }
            else
            {
                baseCap = currentValue;
            }

            m_DeliveryTruckBaseCargoCapacity[prefabEntity] = baseCap;
            return baseCap;
        }

        private bool TryGetDeliveryTruckVanillaCargo(Entity prefabEntity, out int baseCap)
        {
            baseCap = 0;

            if (!PrefabComponentUtil.TryGetComponent(
                    m_PrefabSystem,
                    prefabEntity,
                    out Game.Prefabs.DeliveryTruck truck))
            {
                return false;
            }

            baseCap = truck.m_CargoCapacity;
            return true;
        }

        private int GetOrCacheIndustryCompanyBase(
            Dictionary<Entity, int> cache,
            Entity prefabEntity,
            int currentValue)
        {
            if (cache.TryGetValue(prefabEntity, out int baseMax))
            {
                return baseMax;
            }

            // Managed prefab authoring keeps the unscaled transport count.
            if (TryGetIndustryCompanyVanillaMax(prefabEntity, out int vanilla) && vanilla >= 0)
            {
                baseMax = vanilla;
            }
            else
            {
                baseMax = currentValue;
            }

            cache[prefabEntity] = baseMax;
            return baseMax;
        }

        private bool TryGetIndustryCompanyVanillaMax(Entity prefabEntity, out int baseMax)
        {
            baseMax = 0;

            if (PrefabComponentUtil.TryGetComponent(
                    m_PrefabSystem,
                    prefabEntity,
                    out Game.Prefabs.ProcessingCompany processingCompany))
            {
                baseMax = processingCompany.transports;
                return true;
            }

            if (PrefabComponentUtil.TryGetComponent(
                    m_PrefabSystem,
                    prefabEntity,
                    out Game.Prefabs.StorageCompany storageCompany))
            {
                baseMax = storageCompany.transports;
                return true;
            }

            return false;
        }
    }
}
