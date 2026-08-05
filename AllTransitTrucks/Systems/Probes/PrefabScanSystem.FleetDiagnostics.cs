// <copyright file="PrefabScanSystem.FleetDiagnostics.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Probes/PrefabScanSystem.FleetDiagnostics.cs
// Purpose: Settings snapshot and company-fleet discovery for Scan Report.

namespace PublicWorksPlus
{
    using System.Text;
    using Game.Companies;
    using Game.Economy;
    using Game.Prefabs;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class PrefabScanSystem
    {
        private void AppendATTSettingsSnapshot(
            StringBuilder sb,
            ref int lines,
            ref bool truncated)
        {
            AppendSectionHeader(
                sb,
                ref lines,
                ref truncated,
                "ATT settings at scan time");

            if (Mod.Settings is not ATTSettings settings)
            {
                AppendCapped(
                    sb,
                    ref lines,
                    ref truncated,
                    "ATT settings are not available.");
                AppendCapped(sb, ref lines, ref truncated, string.Empty);
                return;
            }

            string helperToggle =
                settings.EnableFullLoadDispatchHelper ? "ON" : "OFF";
            string helperEffective =
                settings.ShouldRunFullLoadDispatchHelper ? "ACTIVE" : "INACTIVE";
            string extractorControl =
                settings.EnableExtractorTruckControl ? "ON" : "OFF";

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Full-load dispatch helper: Toggle={helperToggle} Effective={helperEffective}");

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Delivery sliders: Semi={settings.SemiTruckCargoScalar:0.#}% " +
                $"Van={settings.DeliveryVanCargoScalar:0.#}% " +
                $"Raw={settings.CoalTruckScalar:0.#}% " +
                $"Motorbike={settings.MotorbikeDeliveryCargoScalar:0.#}%");

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Fleet sliders: CargoStations={settings.CargoStationMaxTrucksScalar:0.##}x " +
                $"Extractors={settings.ExtractorMaxTrucksScalar:0.##}x " +
                $"Warehouses={settings.WarehouseMaxTrucksScalar:0.##}x " +
                $"Industry={settings.IndustryMaxTrucksScalar:0.##}x");

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Extractor control: {extractorControl}");

            AppendCapped(sb, ref lines, ref truncated, string.Empty);
        }

        private void AppendCompanyFleetCandidates(
            StringBuilder sb,
            ref int lines,
            ref bool truncated,
            ref int extractorCompanies)
        {
            AppendExtractorCompanies(
                sb,
                ref lines,
                ref truncated,
                ref extractorCompanies);

            AppendWarehouseCandidates(
                sb,
                ref lines,
                ref truncated);

            AppendIndustryCandidates(
                sb,
                ref lines,
                ref truncated);
        }

        private void AppendExtractorCompanies(
            StringBuilder sb,
            ref int lines,
            ref bool truncated,
            ref int extractorCompanies)
        {
            AppendSectionHeader(
                sb,
                ref lines,
                ref truncated,
                "Extractor companies matched by ATT");

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                "Filter: TransportCompanyData + ExtractorCompanyData + PrefabData. No prefab-name list.");

            EntityQuery query = SystemAPI.QueryBuilder()
                .WithAll<
                    Game.Companies.TransportCompanyData,
                    Game.Prefabs.ExtractorCompanyData,
                    Game.Prefabs.PrefabData>()
                .Build();

            using NativeArray<Entity> entities =
                query.ToEntityArray(Allocator.Temp);

            for (int i = 0; i < entities.Length; i++)
            {
                if (truncated)
                    break;

                Entity entity = entities[i];
                TransportCompanyData company =
                    EntityManager.GetComponentData<TransportCompanyData>(entity);

                int vanillaMax = company.m_MaxTransports;
                if (PrefabComponentUtil.TryGetComponent(
                        m_PrefabSystem,
                        entity,
                        out Game.Prefabs.ProcessingCompany processingCompany))
                {
                    vanillaMax = processingCompany.transports;
                }

                extractorCompanies++;

                AppendCapped(
                    sb,
                    ref lines,
                    ref truncated,
                    $"- {PrefabNameUtil.GetNameSafe(m_PrefabSystem, entity)} " +
                    $"({entity.Index}:{entity.Version}) " +
                    $"VanillaMax={vanillaMax} CurMax={company.m_MaxTransports}");
            }

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Extractor summary: Total={extractorCompanies}");

            AppendCapped(sb, ref lines, ref truncated, string.Empty);
        }

        private void AppendWarehouseCandidates(
            StringBuilder sb,
            ref int lines,
            ref bool truncated)
        {
            AppendSectionHeader(
                sb,
                ref lines,
                ref truncated,
                "Warehouse companies matched by ATT");

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                "Filter: vehicle-owning StorageCompanyData prefabs; cargo stations and outside connections excluded.");

            EntityQuery query = SystemAPI.QueryBuilder()
                .WithAll<
                    Game.Companies.TransportCompanyData,
                    Game.Prefabs.StorageCompanyData,
                    Game.Prefabs.PrefabData>()
                .WithNone<Game.Prefabs.CargoTransportStationData>()
                .WithNone<Game.Prefabs.OutsideConnectionData>()
                .Build();

            using NativeArray<Entity> entities =
                query.ToEntityArray(Allocator.Temp);

            for (int i = 0; i < entities.Length; i++)
            {
                if (truncated)
                    break;

                Entity entity = entities[i];
                TransportCompanyData company =
                    EntityManager.GetComponentData<TransportCompanyData>(entity);
                StorageCompanyData storage =
                    EntityManager.GetComponentData<StorageCompanyData>(entity);

                int vanillaMax = company.m_MaxTransports;
                if (PrefabComponentUtil.TryGetComponent(
                        m_PrefabSystem,
                        entity,
                        out Game.Prefabs.StorageCompany storageCompany))
                {
                    vanillaMax = storageCompany.transports;
                }

                AppendCapped(
                    sb,
                    ref lines,
                    ref truncated,
                    $"- {PrefabNameUtil.GetNameSafe(m_PrefabSystem, entity)} " +
                    $"({entity.Index}:{entity.Version}) " +
                    $"Stored={storage.m_StoredResources} " +
                    $"VanillaMax={vanillaMax} CurMax={company.m_MaxTransports}");
            }

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Warehouse summary: Total={entities.Length}");

            AppendCapped(sb, ref lines, ref truncated, string.Empty);
        }

        private void AppendIndustryCandidates(
            StringBuilder sb,
            ref int lines,
            ref bool truncated)
        {
            AppendSectionHeader(
                sb,
                ref lines,
                ref truncated,
                "Industrial companies matched by ATT");

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                "Filter: vehicle-owning IndustrialProcessData prefabs; extractors, warehouses, cargo stations, outside connections, services, and office outputs excluded.");

            EntityQuery query = SystemAPI.QueryBuilder()
                .WithAll<
                    Game.Companies.TransportCompanyData,
                    Game.Prefabs.IndustrialProcessData,
                    Game.Prefabs.PrefabData>()
                .WithNone<Game.Prefabs.ExtractorCompanyData>()
                .WithNone<Game.Prefabs.StorageCompanyData>()
                .WithNone<Game.Prefabs.CargoTransportStationData>()
                .WithNone<Game.Prefabs.OutsideConnectionData>()
                .WithNone<Game.Companies.ServiceCompanyData>()
                .Build();

            using NativeArray<Entity> entities =
                query.ToEntityArray(Allocator.Temp);

            int included = 0;
            int skippedOffice = 0;

            for (int i = 0; i < entities.Length; i++)
            {
                if (truncated)
                    break;

                Entity entity = entities[i];
                TransportCompanyData company =
                    EntityManager.GetComponentData<TransportCompanyData>(entity);
                IndustrialProcessData process =
                    EntityManager.GetComponentData<IndustrialProcessData>(entity);

                if (EconomyUtils.IsOfficeResource(process.m_Output.m_Resource))
                {
                    skippedOffice++;
                    continue;
                }

                int vanillaMax = company.m_MaxTransports;
                if (PrefabComponentUtil.TryGetComponent(
                        m_PrefabSystem,
                        entity,
                        out Game.Prefabs.ProcessingCompany processingCompany))
                {
                    vanillaMax = processingCompany.transports;
                }

                included++;

                AppendCapped(
                    sb,
                    ref lines,
                    ref truncated,
                    $"- {PrefabNameUtil.GetNameSafe(m_PrefabSystem, entity)} " +
                    $"({entity.Index}:{entity.Version}) " +
                    $"Input1={process.m_Input1.m_Resource} " +
                    $"Input2={process.m_Input2.m_Resource} " +
                    $"Output={process.m_Output.m_Resource} " +
                    $"VanillaMax={vanillaMax} CurMax={company.m_MaxTransports}");
            }

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Industry summary: Total={included} OfficeSkipped={skippedOffice}");

            AppendCapped(sb, ref lines, ref truncated, string.Empty);
        }
    }
}
