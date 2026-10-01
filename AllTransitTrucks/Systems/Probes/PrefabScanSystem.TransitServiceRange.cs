// <copyright file="PrefabScanSystem.TransitServiceRange.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Probes/PrefabScanSystem.TransitServiceRange.cs
// Purpose: Report vanilla/current public-transport maintenance ranges and energy types.

namespace PublicWorksPlus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Companies;
    using Game.Prefabs;
    using Game.Routes;
    using Game.SceneFlow;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class PrefabScanSystem
    {
        private void AppendPublicTransportMaintenanceRanges(
            StringBuilder sb,
            ref int lines,
            ref bool truncated)
        {
            if (truncated)
            {
                return;
            }

            AppendSectionHeader(
                sb,
                ref lines,
                ref truncated,
                "PUBLIC TRANSPORT MAINTENANCE RANGE");

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                "Prefab | Type | Energy | VanillaRangeKm | CurrentRangeKm");

            int bus = 0;
            int tram = 0;
            int train = 0;
            int subway = 0;

            foreach ((RefRO<PublicTransportVehicleData> vehicleRef, Entity entity) in SystemAPI
                         .Query<RefRO<PublicTransportVehicleData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                if (truncated)
                {
                    break;
                }

                PublicTransportVehicleData vehicleData = vehicleRef.ValueRO;
                if (!IsServiceRangeReportType(vehicleData.m_TransportType))
                {
                    continue;
                }

                if ((vehicleData.m_PurposeMask & PublicTransportPurpose.TransportLine) == 0)
                {
                    continue;
                }

                string vanillaRangeKm = "n/a";
                if (PrefabComponentUtil.TryGetComponent(
                        m_PrefabSystem,
                        entity,
                        out PublicTransport publicTransport))
                {
                    vanillaRangeKm = publicTransport.m_MaintenanceRange.ToString("0.###");
                }

                string energy = GetTransportEnergyForReport(entity);
                float currentRangeKm = vehicleData.m_MaintenanceRange / 1000f;

                AppendCapped(
                    sb,
                    ref lines,
                    ref truncated,
                    $"{PrefabNameUtil.GetNameSafe(m_PrefabSystem, entity)} | " +
                    $"{vehicleData.m_TransportType} | {energy} | " +
                    $"{vanillaRangeKm} | {currentRangeKm:0.###}");

                switch (vehicleData.m_TransportType)
                {
                    case TransportType.Bus:
                        bus++;
                        break;
                    case TransportType.Tram:
                        tram++;
                        break;
                    case TransportType.Train:
                        train++;
                        break;
                    case TransportType.Subway:
                        subway++;
                        break;
                }
            }

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Summary: Bus={bus} Tram={tram} Train={train} Subway={subway}");

            AppendCapped(sb, ref lines, ref truncated, string.Empty);
        }

        private string GetTransportEnergyForReport(Entity entity)
        {
            if (EntityManager.HasComponent<CarData>(entity))
            {
                return EntityManager.GetComponentData<CarData>(entity).m_EnergyType.ToString();
            }

            if (EntityManager.HasComponent<TrainData>(entity))
            {
                return EntityManager.GetComponentData<TrainData>(entity).m_EnergyType.ToString();
            }

            return "n/a";
        }

        private static bool IsServiceRangeReportType(TransportType type)
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
    }
}
