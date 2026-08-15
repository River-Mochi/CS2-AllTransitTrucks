// <copyright file="TransitServiceRangeSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/TransitServiceRangeSystem.cs
// Purpose: Apply Bus/Tram/Train/Subway service/refuel range percentages to public-transport prefabs.
// Notes:
// - Uses the authored PublicTransport prefab value as the vanilla base so changes never stack.
// - Runs once on city load or settings Apply, then disables itself.

namespace PublicWorksPlus
{
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Entities;

    public sealed partial class TransitServiceRangeSystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            EntityQuery vehicleQuery = SystemAPI.QueryBuilder()
                .WithAll<PrefabData, PublicTransportVehicleData>()
                .Build();

            RequireForUpdate(vehicleQuery);
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            bool isRealGame =
                mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);

            if (isRealGame)
            {
                Enabled = true;
            }
        }

        protected override void OnUpdate()
        {
            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame() || Mod.Settings == null)
            {
                Enabled = false;
                return;
            }

            ATTSettings settings = Mod.Settings;

            foreach ((RefRW<PublicTransportVehicleData> vehicleRef, Entity entity) in SystemAPI
                         .Query<RefRW<PublicTransportVehicleData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref PublicTransportVehicleData vehicleData = ref vehicleRef.ValueRW;

                if (!IsHandledServiceRangeType(vehicleData.m_TransportType))
                {
                    continue;
                }

                if ((vehicleData.m_PurposeMask & PublicTransportPurpose.TransportLine) == 0)
                {
                    continue;
                }

                if (!PrefabComponentUtil.TryGetComponent(
                        m_PrefabSystem,
                        entity,
                        out PublicTransport publicTransport))
                {
                    continue;
                }

                // PublicTransport authoring value is in km; runtime PublicTransportVehicleData stores x1000.
                float vanillaRange = publicTransport.m_MaintenanceRange * 1000f;
                if (vanillaRange <= 0.1f)
                {
                    continue;
                }

                float scalar = GetServiceRangeScalar(settings, vehicleData.m_TransportType);
                float newRange = vanillaRange * scalar;

                if (vehicleData.m_MaintenanceRange != newRange)
                {
                    vehicleData.m_MaintenanceRange = newRange;
                }
            }

            Enabled = false;
        }

        private static bool IsHandledServiceRangeType(TransportType type)
        {
            switch (type)
            {
                case TransportType.Bus:
                case TransportType.Tram:
                case TransportType.Train:
                case TransportType.Subway:
                    return true;
                default:
                    return false;
            }
        }

        private static float GetServiceRangeScalar(ATTSettings settings, TransportType type)
        {
            float percent;

            switch (type)
            {
                case TransportType.Bus:
                    percent = settings.BusServiceFuelRangeScalar;
                    break;
                case TransportType.Tram:
                    percent = settings.TramServiceFuelRangeScalar;
                    break;
                case TransportType.Train:
                    percent = settings.TrainServiceFuelRangeScalar;
                    break;
                case TransportType.Subway:
                    percent = settings.SubwayServiceFuelRangeScalar;
                    break;
                default:
                    return 1f;
            }

            return ScalarMath.PercentToScalarClamped(
                percent,
                ATTSettings.ServiceFuelRangeMinPercent,
                ATTSettings.ServiceFuelRangeMaxPercent);
        }
    }
}
