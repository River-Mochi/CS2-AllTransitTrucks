// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// German (de-DE) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleDE(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "ÖPNV" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Industrie" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Parks-Straßen" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "Info" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Transitlinien (Schiebereglerbereich im Spiel)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Min./Max. der Transitlinien erweitern" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Erhöht den **Bereich** des Transitlinien-Schiebereglers im Spiel für jede Route.\n" +
                    "**Bis auf (1)** bei allen getesteten Routen.\n" +
                    "Das **Maximallimit variiert**; aber alle liegen 3× oder mehr über Vanilla.\n" +
                    "Technischer Hinweis: Das Spiel nutzt die Routenzeit (Fahrzeit + Haltestellenanzahl); dadurch entsteht ein variables Maximum (dieser Mod folgt der Spiellogik und setzt daher kein statisches Maximum wie 200).\n" +
                    "Funktioniert für alle Verkehrsmittel: Bus, Fähre, Straßenbahn, Zug, U-Bahn, Schiff, Flugzeug.\n\n" +
                    "**---------------**\n" +
                    "Tipp: Wenn das obere Ende des Schiebereglers noch etwas höher sein soll, der Route einige Haltestellen hinzufügen.\n" +
                    "Das Spiel erhöht das Maximum automatisch anhand zusätzlicher Haltestellen + Faktoren; zusätzliche Haltestellen sind eine einfache Anpassung für Spielende.\n" +
                    "<Konflikte vermeiden>: Mods entfernen, die dieselbe Transitlinien-Richtlinie bearbeiten.\n" +
                    "Deaktivieren, wenn die Funktion nicht benötigt wird oder wenn sie ausgeschaltet sein muss, um einen anderen Mod für dasselbe zu verwenden."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Depotkapazität (max. Fahrzeuge pro Depot)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Busdepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Ändert, wie viele Busse jedes **Busdepot** warten/spawnen kann.\n" +
                    "**100%** = Vanilla (Spielstandard).\n" +
                    "**1000%** = 10× mehr.\n" +
                    "Gilt für das Basisgebäude." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Fährdepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**Fährdepot** max. Fahrzeuge pro Gebäude.\n" +
                    "**100%** = Vanilla (Spielstandard).\n" +
                    "Gilt für das Basisgebäude."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "U-Bahn-Depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Ändert, wie viele U-Bahn-Fahrzeuge jedes **U-Bahn-Depot** warten kann.\n" +
                    "Gilt für das Basisgebäude."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Taxidepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Wie viele Taxis jedes **Taxidepot** warten kann.\n" +
                    "Bei maximaler Einstellung könnte das eine übertriebene, fast komische Menge an Taxis verursachen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Straßenbahndepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Ändert, wie viele Straßenbahnen jedes **Straßenbahndepot** warten kann.\n" +
                    "Gilt für das Basisgebäude." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Zugdepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Ändert, wie viele Züge jedes **Zugdepot** warten kann.\n" +
                    "Gilt für das Basisgebäude." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Depot-Standardwerte zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Alle Depot-Schieberegler wieder auf **100%** setzen (Spielstandard / Vanilla)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Passagierkapazität (max. Personen pro Fahrzeug)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Ändert die **Bus-Passagier**kapazität.\n" +
                    "**10%** = 10% der Vanilla-Sitzplätze.\n" +
                    "**100%** = Vanilla-Sitzplätze (Spielstandard).\n" +
                    "**1000%** = 10× mehr Sitzplätze." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Straßenbahn" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Ändert die **Straßenbahn-Passagier**kapazität.\n" +
                    "**10%** = 10% der Vanilla-Sitzplätze.\n" +
                    "**100%** = Vanilla-Sitzplätze (Spielstandard).\n" +
                    "**1000%** = 10× mehr Sitzplätze." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Zug" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Ändert die **Zug-Passagier**kapazität.\n" +
                    "Gilt für Lokomotiven und Abschnitte.\n" +
                    "**10%** = 10% der Vanilla-Sitzplätze.\n" +
                    "**100%** = Vanilla-Sitzplätze (Spielstandard).\n" +
                    "**1000%** = 10× mehr Sitzplätze." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "U-Bahn" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Ändert die **U-Bahn-Passagier**kapazität.\n" +
                    "**10%** = 10% der Vanilla-Sitzplätze.\n" +
                    "**100%** = Vanilla-Sitzplätze (Spielstandard).\n" +
                    "**1000%** = 10× mehr Sitzplätze." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Schiff" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Ändert die Kapazität von **Passagierschiffen** (keine Frachtschiffe).\n" +
                    "**100%** = Vanilla-Sitzplätze (Spielstandard)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Fähre" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Ändert die **Fähr-Passagier**kapazität.\n" +
                    "**10%** = 10% der Vanilla-Sitzplätze.\n" +
                    "**100%** = Vanilla-Sitzplätze (Spielstandard).\n" +
                    "**1000%** = 10× mehr Sitzplätze." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Flugzeug" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Ändert die **Flugzeug-Passagier**kapazität.\n" +
                    "**10%** = 10% der Vanilla-Sitzplätze.\n" +
                    "**100%** = Vanilla-Sitzplätze (Spielstandard).\n" +
                    "**1000%** = 10× mehr Sitzplätze." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Verdoppeln" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Setzt jeden Passagier-Schieberegler auf **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Alle Passagiere zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Alle Passagier-Schieberegler wieder auf **100%** setzen\n" +
                    "(Spielstandard / Vanilla)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Lieferfahrzeuge (Frachtkapazität)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Sattelzüge" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "Kapazität der **Sattelzüge**.\n" +
                    "**100% = 25t** (Vanilla)\n" +
                    "**500% = 125t**.\n" +
                    "Enthält:\n" +
                    " - Spezialindustrie-Sattelzüge (Farmen, Fischerei, Forstwirtschaft usw.).\n" +
                    "Hinweis: Enthält auch Sattelzüge, die Post zu/von Frachtstationen transportieren.\n" +
                    "Das ist nicht dasselbe wie die lokale Postzustellung."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Lieferwagen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Lieferwagen**\n" +
                    "**100% = 4t** (Vanilla)\n" +
                    "**500% = 20t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Rohstoff-LKW" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Rohstoff-LKW** (Öl, Kohle, Erz, Stein, Kipper für Industrieabfälle - derselbe gemeinsam genutzte LKW-Typ)\n" +
                    "**100% = 20t** (Vanilla)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Liefermotorrad" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**Motorradlieferung** bringt typischerweise Medikamente zu einem Krankenhaus/einer Klinik.\n" +
                    "**100% = 0.1t** (Vanilla)\n" +
                    "**500% = 0.5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Liefer-Standardwerte zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Liefer-Schieberegler wieder auf **100%** setzen (Spielstandard / Vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Frachtflotte (Hafen, Zug, Flughafen)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Max. Frachtstationsflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Ändert die maximale Anzahl aktiver Transporter von **Frachttransportstationen**.\n" +
                    "**1×** = Vanilla, **5×** = 5× mehr." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Fördererflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Ändert die **maximale LKW-Anzahl** industrieller Förderer.\n" +
                    "(Farmen, Fischerei, Forstwirtschaft, Erz, Öl, Kohle, Stein).\n" +
                    "**1×** = Vanilla\n" +
                    "**5×** = 5-mal mehr.\n" +
                    "Vanilla erlaubt pro Fördergebäude normalerweise 5 LKW."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Fracht + Förderer zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Frachtstations- + Förderer-Multiplikatoren wieder auf **1×** setzen (Spielstandard / Vanilla)." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Parkwartung" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Arbeitsschichtkapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Multiplikator für die **Arbeitsschichtkapazität** (Fahrzeugkapazität).\n" +
                    "Gesamtarbeit, die ein LKW leisten kann, bevor er zum Gebäude zurückkehrt.\n" +
                    "Einfach gesagt: mehr Vorräte = länger unterwegs." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Fahrzeugrate" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "Multiplikator für die **Fahrzeugarbeitsrate**.\n" +
                    "Rate = wie viel Arbeit es pro Simulationstick im Stand erledigt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Depotflottengröße" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Multiplikator für die **maximalen Fahrzeuge** des Depotgebäudes.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Parkwartung zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Alle Werte wieder auf **100%** setzen (Spielstandard / Vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Straßenwartung" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Depotflottengröße" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Multiplikator für die **maximalen Depotfahrzeuge** pro Gebäude.\n" +
                    "Höher = mehr LKWs.\n" +
                    "<Balance-Hinweis: zu wenige oder zu viele können dem Verkehr schaden.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Arbeitsschichtkapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Multiplikator für die **Arbeitsschichtkapazität**.\n" +
                    "Gesamtarbeit, die ein LKW leisten kann, bevor er zum Depot zurückkehrt.\n" +
                    "**Höher = weniger Rückfahrten** zum Hauptgebäude nötig. Effizienter." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Reparaturrate" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "Rate = wie viel Arbeit es pro Simulationstick im Stand erledigt.\n" +
                    "LKWs machen selbst bei höchster Rate noch einen kurzen Stopp+Losfahr-Moment; sie erledigen einfach mehr Arbeit pro Stopp.\n" +
                    "In Vanilla bringt ein einzelner Stopp die Straße nicht unbedingt auf 100% Reparatur, daher wird diese Funktion mit der Zeit besser.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Straßenverschleiß" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Beta feature>\n" +
                    "Steuert, wie schnell Straßen durch **Zeit- und Verkehrs**faktoren verschleißen.\n" +
                    "**10%** = 10× langsamerer Verschleiß (weniger Reparaturen nötig)\n" +
                    "**100%** = Vanilla\n" +
                    "**500%** = 5× schnellerer Schaden (mehr Reparaturen/LKWs nötig)\n" +
                    "So funktioniert es im Spiel:\n" +
                    "Wenn Faktor m_Wear <= 2.5, keine Verlangsamung.\n" +
                    "Wenn m_Wear >= 17.5, maximale Strafe, Fahrzeuge sind auf Straßen 50% langsamer.\n" +
                    "Siehe Straßen-Infoview: stark beschädigte Straßen werden rot angezeigt und verlangsamen Fahrzeuge."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Straßenwartung zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Alle Werte wieder auf **100%** setzen (Spielstandard / Vanilla)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Support-Links" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Debug / Protokollierung" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Aktuelle Mod-Version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Öffnet die Paradox-Mods-Website für die Mods des Autors." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Öffnet den Community-Discord im Browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Scan-Bericht (Prefabs)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Erstellt einen <einmaligen> Bericht zum Debuggen.\n" +
                    "Für normales Spielen nicht erforderlich.\n" +
                    "Dateispeicherort: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Tipp: <einmal> klicken; wenn der Status Fertig anzeigt, dann <Berichtsordner öffnen> verwenden." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Prefab-Scanstatus" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Zeigt den Scanstatus: Idle / Queued / Running / Done / No Data.\n" +
                    "Queued/Running shows elapsed time; Done shows duration + finish time." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Ausführliche Debug-Logs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Sendet zusätzliche Details zur Fehlersuche an <AllTransitTrucks.log>.\n" +
                    "Für normales Spielen **deaktivieren**.\n" +
                    "<Dies erhöht nur die Protokollierung und ändert keine Gameplay-Werte.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Log-Ordner öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Öffnet den Log-Ordner.\n" +
                    "Danach: <AllTransitTrucks.log> mit einem Texteditor öffnen (Notepad++ empfohlen)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Berichtsordner öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Öffnet den Berichtsordner.\n" +
                    "Danach: <ScanReport-Prefabs.txt> mit einem Texteditor öffnen (z. B. Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Idle" },
                { "PWP_SCAN_QUEUED_FMT", "Queued ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Running ({0})" },
                { "PWP_SCAN_DONE_FMT", "Done ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Fehlgeschlagen" },
                { "PWP_SCAN_FAIL_NO_CITY", "Zuerst Stadt laden" },
                { "PWP_SCAN_UNKNOWN_TIME", "unbekannte Zeit" },

            };
        }

        public void Unload( )
        {
        }
    }
}
