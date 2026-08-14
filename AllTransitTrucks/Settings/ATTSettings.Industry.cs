// <copyright file="ATTSettings.Industry.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/ATTSettings.Industry.cs
// Purpose: Industry settings for delivery vehicles and company fleets.

namespace PublicWorksPlus
{
    using Game;              // IsGame
    using Game.SceneFlow;    // GameManager
    using Game.Settings;     // Settings UI attributes
    using Game.UI;           // Unit
    using Unity.Entities;    // World

    public sealed partial class ATTSettings
    {
        private bool m_EnableCompanyTruckControl = true;
        private bool m_ResetCompanyTrucksToVanillaRequested;

        // Delivery vehicles are stored as percent values.
        private float m_SemiTruckCargoScalar = kVanillaPercent;
        private float m_DeliveryVanCargoScalar = kVanillaPercent;
        private float m_CoalTruckScalar = kVanillaPercent;
        private float m_MotorbikeDeliveryCargoScalar = kVanillaPercent;

        // Fleet limits use simple scalar values (1x..5x).
        private float m_CargoStationMaxTrucksScalar = kVanillaScalar;
        private float m_ExtractorMaxTrucksScalar = kVanillaScalar;
        private float m_WarehouseMaxTrucksScalar = kVanillaScalar;
        private float m_IndustryMaxTrucksScalar = kVanillaScalar;

        // Hidden compatibility key for old .coc files and untranslated locale sources.
        // The full-load helper no longer exists and this value has no runtime effect.
        [SettingsUIHidden]
        public bool EnableFullLoadDispatchHelper
        {
            get => false;
            set { }
        }

        internal bool ConsumeCompanyTruckResetRequest()
        {
            if (!m_ResetCompanyTrucksToVanillaRequested)
                return false;

            m_ResetCompanyTrucksToVanillaRequested = false;
            return true;
        }


        [SettingsUISlider(min = DeliveryMinPercent, max = DeliveryMaxPercent, step = DeliveryStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(IndustryTab, DeliveryGroup)]
        public float SemiTruckCargoScalar
        {
            get => m_SemiTruckCargoScalar;
            set
            {
                float v = NormalizeDeliveryPercentOrVanilla(value);
                if (m_SemiTruckCargoScalar == v) return;

                m_SemiTruckCargoScalar = v;
                OnIndustryChanged();
            }
        }

        [SettingsUISlider(min = DeliveryMinPercent, max = DeliveryMaxPercent, step = DeliveryStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(IndustryTab, DeliveryGroup)]
        public float DeliveryVanCargoScalar
        {
            get => m_DeliveryVanCargoScalar;
            set
            {
                float v = NormalizeDeliveryPercentOrVanilla(value);
                if (m_DeliveryVanCargoScalar == v) return;

                m_DeliveryVanCargoScalar = v;
                OnIndustryChanged();
            }
        }

        [SettingsUISlider(min = DeliveryMinPercent, max = DeliveryMaxPercent, step = DeliveryStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(IndustryTab, DeliveryGroup)]
        public float CoalTruckScalar
        {
            get => m_CoalTruckScalar;
            set
            {
                float v = NormalizeDeliveryPercentOrVanilla(value);
                if (m_CoalTruckScalar == v) return;

                m_CoalTruckScalar = v;
                OnIndustryChanged();
            }
        }

        [SettingsUISlider(min = DeliveryMinPercent, max = DeliveryMaxPercent, step = DeliveryStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(IndustryTab, DeliveryGroup)]
        public float MotorbikeDeliveryCargoScalar
        {
            get => m_MotorbikeDeliveryCargoScalar;
            set
            {
                float v = NormalizeDeliveryPercentOrVanilla(value);
                if (m_MotorbikeDeliveryCargoScalar == v) return;

                m_MotorbikeDeliveryCargoScalar = v;
                OnIndustryChanged();
            }
        }

        [SettingsUISlider(min = CargoStationMinScalar, max = CargoStationMaxScalar, step = CargoStationStepScalar)]
        [SettingsUISection(IndustryTab, CargoStationsGroup)]
        public float CargoStationMaxTrucksScalar
        {
            get => m_CargoStationMaxTrucksScalar;
            set
            {
                float v = ScalarMath.ClampScalar(value, CargoStationMinScalar, CargoStationMaxScalar);
                if (m_CargoStationMaxTrucksScalar == v) return;

                m_CargoStationMaxTrucksScalar = v;
                OnIndustryChanged();
            }
        }

        [SettingsUISection(IndustryTab, CargoStationsGroup)]
        public bool EnableCompanyTruckControl
        {
            get => m_EnableCompanyTruckControl;
            set
            {
                if (m_EnableCompanyTruckControl == value) return;

                m_EnableCompanyTruckControl = value;

                // Turning control off restores all ATT-managed company fleets once.
                if (!value)
                {
                    m_ResetCompanyTrucksToVanillaRequested = true;
                }

                OnIndustryChanged();
            }
        }

        [SettingsUISlider(min = CargoStationMinScalar, max = CargoStationMaxScalar, step = CargoStationStepScalar)]
        [SettingsUISection(IndustryTab, CargoStationsGroup)]
        [SettingsUIHideByCondition(typeof(ATTSettings), nameof(EnableCompanyTruckControl), true)]
        public float ExtractorMaxTrucksScalar
        {
            get => m_ExtractorMaxTrucksScalar;
            set
            {
                float v = ScalarMath.ClampScalar(value, CargoStationMinScalar, CargoStationMaxScalar);
                if (m_ExtractorMaxTrucksScalar == v) return;

                m_ExtractorMaxTrucksScalar = v;
                OnIndustryChanged();
            }
        }

        [SettingsUISlider(min = CargoStationMinScalar, max = CargoStationMaxScalar, step = CargoStationStepScalar)]
        [SettingsUISection(IndustryTab, CargoStationsGroup)]
        [SettingsUIHideByCondition(typeof(ATTSettings), nameof(EnableCompanyTruckControl), true)]
        public float IndustryMaxTrucksScalar
        {
            get => m_IndustryMaxTrucksScalar;
            set
            {
                float v = ScalarMath.ClampScalar(value, CargoStationMinScalar, CargoStationMaxScalar);
                if (m_IndustryMaxTrucksScalar == v) return;

                m_IndustryMaxTrucksScalar = v;
                OnIndustryChanged();
            }
        }


        [SettingsUISlider(min = CargoStationMinScalar, max = CargoStationMaxScalar, step = CargoStationStepScalar)]
        [SettingsUISection(IndustryTab, CargoStationsGroup)]
        [SettingsUIHideByCondition(typeof(ATTSettings), nameof(EnableCompanyTruckControl), true)]
        public float WarehouseMaxTrucksScalar
        {
            get => m_WarehouseMaxTrucksScalar;
            set
            {
                float v = ScalarMath.ClampScalar(value, CargoStationMinScalar, CargoStationMaxScalar);
                if (m_WarehouseMaxTrucksScalar == v) return;

                m_WarehouseMaxTrucksScalar = v;
                OnIndustryChanged();
            }
        }

        [SettingsUIButtonGroup(DeliveryGroup)]
        [SettingsUIButton]
        [SettingsUISection(IndustryTab, DeliveryGroup)]
        public bool ResetDeliveryToVanillaButton
        {
            set
            {
                if (!value) return;

                m_SemiTruckCargoScalar = kVanillaPercent;
                m_DeliveryVanCargoScalar = kVanillaPercent;
                m_CoalTruckScalar = kVanillaPercent;
                m_MotorbikeDeliveryCargoScalar = kVanillaPercent;

                ApplyAndSave();
            }
        }

        [SettingsUIButtonGroup(CargoStationsGroup)]
        [SettingsUIButton]
        [SettingsUISection(IndustryTab, CargoStationsGroup)]
        public bool ResetCargoStationsToVanillaButton
        {
            set
            {
                if (!value) return;

                m_CargoStationMaxTrucksScalar = kVanillaScalar;
                m_ExtractorMaxTrucksScalar = kVanillaScalar;
                m_WarehouseMaxTrucksScalar = kVanillaScalar;
                m_IndustryMaxTrucksScalar = kVanillaScalar;

                ApplyAndSave();
            }
        }

        private void OnIndustryChanged()
        {
            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
                return;

            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
                return;

            TryEnableOnce<IndustrySystem>(world, "IndustrySystem");
        }

        partial void SetDefaults_Industry()
        {
            m_EnableCompanyTruckControl = true;
            m_ResetCompanyTrucksToVanillaRequested = false;

            m_SemiTruckCargoScalar = kVanillaPercent;
            m_DeliveryVanCargoScalar = kVanillaPercent;
            m_CoalTruckScalar = kVanillaPercent;
            m_MotorbikeDeliveryCargoScalar = kVanillaPercent;

            m_CargoStationMaxTrucksScalar = kVanillaScalar;
            m_ExtractorMaxTrucksScalar = kVanillaScalar;
            m_WarehouseMaxTrucksScalar = kVanillaScalar;
            m_IndustryMaxTrucksScalar = kVanillaScalar;
        }

        partial void RepairAndClamp_Industry()
        {
            // Delivery sliders support migration from older scalar saves.
            m_SemiTruckCargoScalar = NormalizeDeliveryPercentOrVanilla(m_SemiTruckCargoScalar);
            m_DeliveryVanCargoScalar = NormalizeDeliveryPercentOrVanilla(m_DeliveryVanCargoScalar);
            m_CoalTruckScalar = NormalizeDeliveryPercentOrVanilla(m_CoalTruckScalar);
            m_MotorbikeDeliveryCargoScalar = NormalizeDeliveryPercentOrVanilla(m_MotorbikeDeliveryCargoScalar);

            m_CargoStationMaxTrucksScalar = ClampScalarOrDefault(
                m_CargoStationMaxTrucksScalar,
                CargoStationMinScalar,
                CargoStationMaxScalar,
                kVanillaScalar);

            m_ExtractorMaxTrucksScalar = ClampScalarOrDefault(
                m_ExtractorMaxTrucksScalar,
                CargoStationMinScalar,
                CargoStationMaxScalar,
                kVanillaScalar);

            m_WarehouseMaxTrucksScalar = ClampScalarOrDefault(
                m_WarehouseMaxTrucksScalar,
                CargoStationMinScalar,
                CargoStationMaxScalar,
                kVanillaScalar);

            m_IndustryMaxTrucksScalar = ClampScalarOrDefault(
                m_IndustryMaxTrucksScalar,
                CargoStationMinScalar,
                CargoStationMaxScalar,
                kVanillaScalar);
        }
    }
}
