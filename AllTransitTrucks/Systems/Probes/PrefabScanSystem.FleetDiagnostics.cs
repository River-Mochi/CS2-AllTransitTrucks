// <copyright file="PrefabScanSystem.FleetDiagnostics.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Probes/PrefabScanSystem.FleetDiagnostics.cs
// Purpose: Settings snapshot and company-fleet discovery for Scan Report.

namespace PublicWorksPlus
{
    using System.Text;
    using Game.Prefabs;
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


            string companyTruckControl =
                settings.EnableCompanyTruckControl ? "ON" : "OFF";

            string serviceFuelRangeVisible =
                settings.ShowServiceFuelRange ? "ON" : "OFF";


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
                $"Company truck control: {companyTruckControl}");

            AppendCapped(
                sb,
                ref lines,
                ref truncated,
                $"Service/fuel range: Show={serviceFuelRangeVisible} " +
                $"Bus={settings.BusServiceFuelRangeScalar:0.#}% " +
                $"Tram={settings.TramServiceFuelRangeScalar:0.#}% " +
                $"Train={settings.TrainServiceFuelRangeScalar:0.#}% " +
                $"Subway={settings.SubwayServiceFuelRangeScalar:0.#}%");

            AppendCapped(sb, ref lines, ref truncated, string.Empty);

            AppendPublicTransportMaintenanceRanges(sb, ref lines, ref truncated);
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

            using global::Unity.Collections.NativeArray<Entity> entities =
                query.ToEntityArray(global::Unity.Collections.Allocator.Temp);

            for (int i = 0; i < entities.Length; i++)
            {
                if (truncated)
                    break;

                Entity entity = entities[i];
                global::Game.Companies.TransportCompanyData company =
                    EntityManager.GetComponentData<global::Game.Companies.TransportCompanyData>(entity);

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

            using global::Unity.Collections.NativeArray<Entity> entities =
                query.ToEntityArray(global::Unity.Collections.Allocator.Temp);

            for (int i = 0; i < entities.Length; i++)
            {
                if (truncated)
                    break;

                Entity entity = entities[i];
                global::Game.Companies.TransportCompanyData company =
                    EntityManager.GetComponentData<global::Game.Companies.TransportCompanyData>(entity);
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

            using global::Unity.Collections.NativeArray<Entity> entities =
                query.ToEntityArray(global::Unity.Collections.Allocator.Temp);

            int included = 0;
            int skippedOffice = 0;

            for (int i = 0; i < entities.Length; i++)
            {
                if (truncated)
                    break;

                Entity entity = entities[i];
                global::Game.Companies.TransportCompanyData company =
                    EntityManager.GetComponentData<global::Game.Companies.TransportCompanyData>(entity);
                IndustrialProcessData process =
                    EntityManager.GetComponentData<IndustrialProcessData>(entity);

                if (IsOfficeResource(process.m_Output.m_Resource))
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

        private static bool IsOfficeResource(Game.Economy.Resource resource)
        {
            return resource == Game.Economy.Resource.Software ||
                   resource == Game.Economy.Resource.Telecom ||
                   resource == Game.Economy.Resource.Financial ||
                   resource == Game.Economy.Resource.Media;
        }
    }
}
