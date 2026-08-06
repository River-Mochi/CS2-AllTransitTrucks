// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.cs
// Entrypoint: registers settings, locales, and ECS systems.

namespace PublicWorksPlus
{
    using System;                         // Exception
    using System.Reflection;              // Assembly
    using Colossal.IO.AssetDatabase;      // LoadSettings
    using Colossal.Localization;          // LocalizationManager
    using Colossal.Logging;               // ILog
    using CS2Shared.RiverMochi;           // LogUtils, ShellOpen
    using Game;                           // UpdateSystem, SystemUpdatePhase
    using Game.Modding;                   // IMod
    using Game.Prefabs;                   // VehicleCapacitySystem
    using Game.SceneFlow;                 // GameManager

    public sealed class Mod : IMod
    {
        public const string ModName = "All Transit + Trucks";
        public const string ShortName = "All Transit + Trucks";
        public const string ModId = "AllTransitTrucks";
        public const string ModTag = "[ATT]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        private static bool s_BannerLogged;

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static ATTSettings? Settings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            ShellOpen.Configure(s_Log, ModId, ModTag);

            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                LogUtils.Info(s_Log, () => $"{ModName} v{ModVersion} Loaded.");
            }

            // Locales need the same settings instance used by Options.
            ATTSettings setting = new(this);
            Settings = setting;

            try
            {
                LocalizationManager? localizationManager = GameManager.instance?.localizationManager;

                if (localizationManager == null)
                {
                    LogUtils.Warn(s_Log, () => $"{ModTag} LocalizationManager is null; locale sources were not registered.");
                }
                else
                {
                    localizationManager.AddSource("en-US", new LocaleEN(setting));
                    localizationManager.AddSource("fr-FR", new LocaleFR(setting));
                    localizationManager.AddSource("es-ES", new LocaleES(setting));
                    localizationManager.AddSource("de-DE", new LocaleDE(setting));
                    localizationManager.AddSource("it-IT", new LocaleIT(setting));
                    localizationManager.AddSource("ja-JP", new LocaleJA(setting));
                    localizationManager.AddSource("ko-KR", new LocaleKO(setting));
                    localizationManager.AddSource("pl-PL", new LocalePL(setting));
                    localizationManager.AddSource("pt-BR", new LocalePT_BR(setting));
                    // localizationManager.AddSource("pt-PT", new LocalePT_PT(setting)); // for future use
                    localizationManager.AddSource("vi-VN", new LocaleVI(setting));
                    localizationManager.AddSource("zh-HANS", new LocaleZH_CN(setting));
                    localizationManager.AddSource("zh-HANT", new LocaleZH_HANT(setting));
                }
            }
            catch (Exception ex)
            {
                LogUtils.Warn(s_Log, () => $"{ModTag} Localization registration failed: {ex.GetType().Name}: {ex.Message}");
            }

            AssetDatabase.global.LoadSettings(ModId, setting, new ATTSettings(this));
            setting.SanitizeAfterLoad();
            setting.RegisterInOptionsUI();

            updateSystem.UpdateAfter<TransitSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAfter<MaintenanceSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAfter<LaneWearSystem>(SystemUpdatePhase.PrefabUpdate);


            // Rebuild DeliveryTruckSelectData from ATT's updated prefab capacities.
            updateSystem.UpdateAfter<IndustrySystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateBefore<IndustrySystem, VehicleCapacitySystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateBefore<IndustrySystem>(SystemUpdatePhase.PrefabReferences);

            updateSystem.UpdateAfter<VehicleCountPolicyTunerSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAt<PrefabScanSystem>(SystemUpdatePhase.PrefabUpdate);

#if DEBUG
            updateSystem.UpdateAt<DeliveryCargoProbeSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAt<LaneWearProbeSystem>(SystemUpdatePhase.GameSimulation);
#endif
        }

        public void OnDispose()
        {
            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
        }
    }
}
