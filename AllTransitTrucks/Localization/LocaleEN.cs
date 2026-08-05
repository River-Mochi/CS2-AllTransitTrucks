// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
// English (en-US) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleEN(ATTSettings setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ShortName;

            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // --------------------------
                // Mod title / tabs / groups
                // --------------------------

                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs (match ATTSettings.cs tab ids)
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "Public-Transit" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Industry" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Parks-Roads" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "About" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Transit Lines (in-game slider range)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Expand transit line min/max" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Increases the **range** of in-game Transit Line Slider per each route.\n" +
                    "**As low as (1)** on all routes tested.\n" +
                    "**Maximum limit varies**; but all are 3x or more higher than vanilla.\n" +
                    "Tech note: game uses route time (driving time + stop count); this creates a variable max (this mod follows game logic so does not set a static max limit like 200).\n" +
                    "Works for all public transit.\n\n" +
                    "**---------------**\n" +
                    "Tip: if you want to increase maximum end of the slider a little more, add some stops to the route.\n" +
                    "Game auto-increases the max based on added stops + factors; adding stops is an easy player tweak.\n" +
                    "<Avoid Conflicts>: remove mods that edit the same Transit Line policy.\n" +
                    "Disable if you don't need it or you need it off to use a different mod for the same thing."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Depot capacity (max vehicles per depot)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Bus depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Change how many buses each **Bus Depot** can maintain/spawn.\n" +
                    "**100%** = vanilla (game default).\n" +
                    "**1000%** = 10× more.\n" +
                    "Applies to base building." },

                 { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Ferry depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**Ferry Depot** max vehicles per building.\n" +
                    "**100%** = vanilla (game default).\n" +
                    "Applies to base building."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Subway depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Change how many subway vehicles each **Subway Depot** can maintain.\n" +
                    "Applies to the base building."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Taxi depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "How many taxis each **Taxi Depot** can maintain.\n" +
                    "If set to max, could cause excessive, comical amount of taxis."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Tram depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Change how many trams each **Tram Depot** can maintain.\n" +
                    "Applies to the base building." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Train depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Change how many trains each **Train Depot** can maintain.\n" +
                    "Applies to the base building." },


                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Reset depots defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Set all depot sliders back to **100%** (game default / vanilla)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Passenger capacity (max people per vehicle)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Change **bus passenger** capacity.\n" +
                    "**10%** = 10% of vanilla seats.\n" +
                    "**100%** = vanilla seats (game default).\n" +
                    "**1000%** = 10× more seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Change **tram passenger** capacity.\n" +
                    "**10%** = 10% of vanilla seats.\n" +
                    "**100%** = vanilla seats (game default).\n" +
                    "**1000%** = 10× more seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Train" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Change **train passenger** capacity.\n" +
                    "Applies to engines and sections.\n" +
                    "**10%** = 10% of vanilla seats.\n" +
                    "**100%** = vanilla seats (game default).\n" +
                    "**1000%** = 10× more seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Subway" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Change **subway passenger** capacity.\n" +
                    "**10%** = 10% of vanilla seats.\n" +
                    "**100%** = vanilla seats (game default).\n" +
                    "**1000%** = 10× more seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Ship" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Change **passenger ship** capacity (not cargo ships).\n" +
                    "**100%** = vanilla seats (game default)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Ferry" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Change **ferry passenger** capacity.\n" +
                    "**10%** = 10% of vanilla seats.\n" +
                    "**100%** = vanilla seats (game default).\n" +
                    "**1000%** = 10× more seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Airplane" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Change **airplane passenger** capacity.\n" +
                    "**10%** = 10% of vanilla seats.\n" +
                    "**100%** = vanilla seats (game default).\n" +
                    "**1000%** = 10× more seats." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Double up" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Set every passenger slider to **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Reset all passengers" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Set all passenger sliders back to **100%**\n" +
                    "(game default / vanilla)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Delivery vehicles (cargo capacity)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableFullLoadDispatchHelper)), "Full-load dispatch helper" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableFullLoadDispatchHelper)),
                    "Raises company and storage requests toward one full truck load.\n" +
                    "May use extra CPU in large cities.\n" +
                    "<[ ] Default OFF>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Semi trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**Semi trucks** capacity.\n" +
                    "**100% = 25t** (vanilla)\n" +
                    "**500% = 125t**.\n" +
                    "Includes:\n" +
                    " - Specialized industry Semi trucks (farms, fish, forestry, etc.).\n" +
                    "Side Note: includes semi trucks carrying mail to/from Cargo stations.\n" +
                    "This is not the same as local mail delivery."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Delivery vans" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Delivery vans**\n" +
                    "**100% = 4t** (vanilla)\n" +
                    "**500% = 20t**" },
                
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Raw material trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Raw material trucks** (oil, coal, ore, stone, dump trucks for industrial waste - same shared truck type)\n" +
                    "**100% = 20t** (vanilla)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Delivery motorbike" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**Motorbike delivery** typically takes pharmacy to a hospital/clinic.\n" +
                    "**100% = 0.1t** (vanilla)\n" +
                    "**500% = 0.5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Reset delivery defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Set delivery sliders back to **100%** (game default / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Cargo fleet (harbor, train, airport)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Cargo station max fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Change **cargo transport stations** maximum active transporters.\n" +
                    "**1×** = vanilla, **5×** = 5× more." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Extractor fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Change **max trucks** for Extractor facilities.\n" +
                    "(farms, fishing, forestry, ore, oil, coal, stone).\n" +
                    "**1×** = vanilla\n" +
                    "**5×** = 5 times more.\n" +
                    "Vanilla usually allows 5 trucks per extractor facility."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Reset cargo + extractors fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Set cargo station + extractor multipliers back to **1×** (game default / vanilla)." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Park maintenance" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Work shift capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Scales **work shift capacity** (vehicle capacity).\n" +
                    "Total work a truck can do before it returns to the building.\n" +
                    "Think: extra supplies = stays out longer." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Vehicle rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "Scales **vehicle work rate**.\n" +
                    "**Rate** = how much work it does per simulation tick while stopped." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Depot fleet size" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Depot building **maximum vehicles** allowed.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Reset park maintenance" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Reset all values back to **100%** (game default / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Road maintenance" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Depot fleet size" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Multiplier for **depot maximum vehicles** per building.\n" +
                    "Higher = more trucks.\n" +
                    "<Balance note: too few or too many can hurt traffic.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Work shift capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Scales **work shift capacity**.\n" +
                    "Total work a truck can do before it returns to the depot.\n" +
                    "**Higher = fewer returns** back to the main building, more efficient." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Repair rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "**Rate** = how much work it does per simulation tick while stopped.\n" +
                    "Trucks still do a quick stop+go even with highest rate; they just do more work per stop.\n" +
                    "In vanilla, one stop does not necessarily bring the road to 100% repaired; that is why this feature gets better over time.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Road wear" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Beta feature>\n" +
                    "Controls how fast roads deteriorate from **time and traffic** factors.\n" +
                    "**10%** = 10× slower wear (fewer repairs needed)\n" +
                    "**100%** = vanilla\n" +
                    "**500%** = 5× faster damage (more repairs/trucks needed)\n" +
                    "How it works in game:\n" +
                    "If m_Wear <= 2.5 factor, no slowdown.\n" +
                    "If m_Wear >= 17.5, max penalty, vehicles are 50% slower on roads.\n" +
                    "See Roads Infoview: shows red over badly damaged roads that slow vehicles down."

                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Reset road maintenance" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Set all values back to **100%** (game default / vanilla)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Support links" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Debug / Logging" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Open Paradox Mods website for the author's mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Open the community Discord in a browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Scan Report (prefabs)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Creates a <one-time> report for debugging.\n" +
                    "Not needed for normal gameplay.\n" +
                    "File location: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Tip: click <once>, if status shows Done, then use <Open report folder>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Prefab scan status" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Shows scan state: Idle / Queued / Running / Done / No Data.\n" +
                    "Queued/Running shows elapsed time; Done shows duration + finish time." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Verbose debug logs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Sends extra details to <AllTransitTrucks.log> for troubleshooting.\n" +
                    "**Disable** for normal gameplay.\n" +
                    "<This only increases logging and does not change gameplay values.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Open log folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Open the logs folder.\n" +
                    "Next: open <AllTransitTrucks.log> with your text editor (Notepad++ recommended)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Open report folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Open the report folder.\n" +
                    "Next: open <ScanReport-Prefabs.txt> with your text editor (e.g., Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Idle" },
                { "PWP_SCAN_QUEUED_FMT", "Queued ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Running ({0})" },
                { "PWP_SCAN_DONE_FMT", "Done ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Failed" },
                { "PWP_SCAN_FAIL_NO_CITY", "Load city first" },
                { "PWP_SCAN_UNKNOWN_TIME", "unknown time" },

            };
        }

        public void Unload( )
        {
        }
    }
}
