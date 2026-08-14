// <copyright file="LocaleNL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleNL.cs
// Dutch (nl-NL) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleNL : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleNL(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "Openbaar vervoer" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Industrie" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Parken-Wegen" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "Over" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Vervoerslijnen (bereik schuifregelaar)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Min/max van vervoerslijnen uitbreiden" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Vergroot het **bereik** van de schuifregelaar voor elke vervoerslijn.\n" +
                    "**Tot 1 voertuig** op alle geteste lijnen.\n" +
                    "De **maximumlimiet varieert**, maar geteste lijnen laten minstens 3× het vanilla maximum toe.\n" +
                    "Technische noot: de game gebruikt routetijd (rijtijd + aantal haltes), dus het maximum is variabel. Deze mod volgt de gamelogica en zet geen vaste limiet zoals 200.\n" +
                    "Werkt voor al het openbaar vervoer.\n\n" +
                    "**---------------**\n" +
                    "Tip: wil je het maximum iets verhogen, voeg dan wat haltes toe aan de route.\n" +
                    "De game verhoogt het maximum automatisch op basis van haltes en andere factoren; extra haltes zijn een makkelijke tweak.\n" +
                    "<Voorkom conflicten>: verwijder mods die hetzelfde beleid voor vervoerslijnen aanpassen.\n" +
                    "Schakel dit uit als je het niet nodig hebt of een andere mod hiervoor wilt gebruiken."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Depotcapaciteit (max. voertuigen per depot)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Busdepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Wijzig hoeveel bussen elk **busdepot** kan onderhouden/uitsturen.\n" +
                    "**100%** = vanilla (gamestandaard).\n" +
                    "**1000%** = 10× meer.\n" +
                    "Geldt voor het basisgebouw." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Veerbootdepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "Maximaal aantal voertuigen per **veerbootdepot**.\n" +
                    "**100%** = vanilla (gamestandaard).\n" +
                    "Geldt voor het basisgebouw."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Metrodepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Wijzig hoeveel metrovoertuigen elk **metrodepot** kan onderhouden.\n" +
                    "Geldt voor het basisgebouw."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Taxidepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Hoeveel taxi's elk **taxidepot** kan onderhouden.\n" +
                    "Op maximaal kan dit een overdreven, komische hoeveelheid taxi's geven."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Tramdepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Wijzig hoeveel trams elk **tramdepot** kan onderhouden.\n" +
                    "Geldt voor het basisgebouw." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Treindepot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Wijzig hoeveel treinen elk **treindepot** kan onderhouden.\n" +
                    "Geldt voor het basisgebouw." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Depotwaarden resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Zet alle depotschuifregelaars terug op **100%** (gamestandaard / vanilla)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Passagierscapaciteit (max. personen per voertuig)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Wijzig de **passagierscapaciteit van bussen**.\n" +
                    "**10%** = 10% van de vanilla zitplaatsen.\n" +
                    "**100%** = vanilla zitplaatsen (gamestandaard).\n" +
                    "**1000%** = 10× meer zitplaatsen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Wijzig de **passagierscapaciteit van trams**.\n" +
                    "**10%** = 10% van de vanilla zitplaatsen.\n" +
                    "**100%** = vanilla zitplaatsen (gamestandaard).\n" +
                    "**1000%** = 10× meer zitplaatsen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Trein" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Wijzig de **passagierscapaciteit van treinen**.\n" +
                    "Geldt voor locomotieven en rijtuigen.\n" +
                    "**10%** = 10% van de vanilla zitplaatsen.\n" +
                    "**100%** = vanilla zitplaatsen (gamestandaard).\n" +
                    "**1000%** = 10× meer zitplaatsen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Wijzig de **passagierscapaciteit van metro's**.\n" +
                    "**10%** = 10% van de vanilla zitplaatsen.\n" +
                    "**100%** = vanilla zitplaatsen (gamestandaard).\n" +
                    "**1000%** = 10× meer zitplaatsen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Schip" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Wijzig de capaciteit van **passagiersschepen** (niet vrachtschepen).\n" +
                    "**100%** = vanilla zitplaatsen (gamestandaard)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Veerboot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Wijzig de **passagierscapaciteit van veerboten**.\n" +
                    "**10%** = 10% van de vanilla zitplaatsen.\n" +
                    "**100%** = vanilla zitplaatsen (gamestandaard).\n" +
                    "**1000%** = 10× meer zitplaatsen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Vliegtuig" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Wijzig de **passagierscapaciteit van vliegtuigen**.\n" +
                    "**10%** = 10% van de vanilla zitplaatsen.\n" +
                    "**100%** = vanilla zitplaatsen (gamestandaard).\n" +
                    "**1000%** = 10× meer zitplaatsen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Verdubbelen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Zet alle passagiersschuifregelaars op **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Alle passagiers resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Zet alle passagiersschuifregelaars terug op **100%**\n" +
                    "(gamestandaard / vanilla)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Bezorgvoertuigen (vrachtcapaciteit)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Vrachtwagens" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**Capaciteit van vrachtwagens**.\n" +
                    "**100% = 25t** (vanilla)\n" +
                    "**500% = 125t**.\n" +
                    "Inclusief:\n" +
                    " - Vrachtwagens van gespecialiseerde industrie (boerderijen, visserij, bosbouw, enz.).\n" +
                    "Terzijde: ook vrachtwagens die post naar/van vrachtstations vervoeren.\n" +
                    "Dit is niet hetzelfde als lokale postbezorging."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Bestelwagens" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Bestelwagens**\n" +
                    "**100% = 4t** (vanilla)\n" +
                    "**500% = 20t**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Grondstoftrucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Grondstoftrucks** (olie, kolen, erts, steen en dumptrucks voor industrieel afval - hetzelfde gedeelde trucktype)\n" +
                    "**100% = 20t** (vanilla)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Bezorgmotor" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**Bezorgmotoren** brengen meestal medicijnen naar een ziekenhuis/kliniek.\n" +
                    "**100% = 0,1t** (vanilla)\n" +
                    "**500% = 0,5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Bezorgwaarden resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Zet de bezorgschuifregelaars terug op **100%** (gamestandaard / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Totaal aantal trucks" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Vrachtstations, totaal trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Maximaal aantal actieve vrachtvoertuigen voor elke **vrachthaven, goederentreinterminal en luchthaven**.\n" +
                    "**1×** = vanilla, **5×** = 5 keer zoveel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "Industrietrucks aanpassen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "Voor compatibiliteit met andere mods,\n" +
                    "- gebruik UIT als je liever een andere mod het totale aantal trucks van dezelfde industriebedrijven laat regelen.\n" +
                    "<[x] Standaard AAN>.\n" +
                    "Laat AAN om met de drie schuifregelaars hieronder het totale aantal bedrijfstrucks aan te passen.\n" +
                    "UIT zet die drie categorieën terug naar de gamestandaard en verbergt de schuifregelaars.\n" +
                    "Wil je de schuifregelaars van deze mod gebruiken, kijk dan of de andere mod zijn eigen truckaantallen kan uitschakelen."
                     },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Trucks voor winning" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Maximaal aantal trucks per winningsbedrijf.\n" +
                    "Inclusief boerderijen, bosbouw, visserij, olie, erts, kolen, steen, katoen, veeteelt en groenten.\n" +
                    "**1×** = vanilla, **5×** = 5 keer zoveel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "Magazijntrucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "Maximaal aantal trucks per magazijnbedrijf.\n" +
                    "Inclusief alle magazijntypen met eigen voertuigen.\n" +
                    "**1×** = vanilla, **5×** = 5 keer zoveel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "Industrietrucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "Maximaal aantal trucks voor industriële verwerkingsbedrijven.\n" +
                    "Exclusief winningsbedrijven, magazijnen, vrachtstations, commerciële bedrijven en kantoren.\n" +
                    "**1×** = vanilla, **5×** = 5 keer zoveel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Alle industrievoertuigen resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Zet vrachtstations, winningsbedrijven, magazijnen en industrie terug op **1×** (vanilla waarden).\n" +
                    "De schakelaar voor bedrijfstrucks blijft AAN of UIT zoals gekozen." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Parkonderhoud" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Werkcapaciteit" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Schaalt de **werkcapaciteit** van het voertuig.\n" +
                    "Totale hoeveelheid werk die een truck kan doen voordat hij terugkeert naar het gebouw.\n" +
                    "Denk aan: extra voorraden = langer op pad." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Werksnelheid" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "Schaalt de **werksnelheid van het voertuig**.\n" +
                    "**Snelheid** = hoeveel werk het per simulatietick doet terwijl het stilstaat." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Depotvloot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Maximaal toegestaan aantal voertuigen in het **depotgebouw**.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Parkonderhoud resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Zet alle waarden terug op **100%** (gamestandaard / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Wegenonderhoud" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Depotvloot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Vermenigvuldigt het **maximum aantal depotvoertuigen** per gebouw.\n" +
                    "Hoger = meer trucks.\n" +
                    "<Balans: te weinig of te veel trucks kan het verkeer verslechteren.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Werkcapaciteit" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Schaalt de **werkcapaciteit**.\n" +
                    "Totale hoeveelheid werk die een truck kan doen voordat hij terugkeert naar het depot.\n" +
                    "**Hoger = minder terugritten** naar het hoofdgebouw en efficiënter." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Reparatiesnelheid" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "**Snelheid** = hoeveel werk het voertuig per simulatietick doet terwijl het stilstaat.\n" +
                    "Trucks stoppen nog steeds kort, zelfs op de hoogste waarde; ze doen gewoon meer werk per stop.\n" +
                    "In vanilla herstelt één stop de weg niet altijd tot 100%; daarom wordt het effect duidelijker na verloop van tijd.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Wegslijtage" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Bètafunctie>\n" +
                    "Bepaalt hoe snel wegen slijten door **tijd en verkeer**.\n" +
                    "**10%** = 10× langzamere slijtage (minder reparaties nodig)\n" +
                    "**100%** = vanilla\n" +
                    "**500%** = 5× snellere schade (meer reparaties/trucks nodig)\n" +
                    "Zo werkt het in de game:\n" +
                    "Als m_Wear <= 2.5, geen vertraging.\n" +
                    "Als m_Wear >= 17.5, maximale straf: voertuigen rijden 50% langzamer op wegen.\n" +
                    "Bekijk de wegen-infoweergave: zwaar beschadigde wegen die voertuigen vertragen worden rood weergegeven."

                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Wegenonderhoud resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Zet alle waarden terug op **100%** (gamestandaard / vanilla)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Supportlinks" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Debug / logging" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Weergavenaam van deze mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Versie" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Huidige modversie." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Open de Paradox Mods-pagina van de auteur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Open de community-Discord in je browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Scanrapport (prefabs)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Maakt een <eenmalig> rapport voor debugging.\n" +
                    "Niet nodig voor normaal spelen.\n" +
                    "Bestandslocatie: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Tip: klik <één keer>; als de status Klaar is, gebruik dan <Rapportmap openen>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Status prefabscan" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Toont de scanstatus: Inactief / In wachtrij / Bezig / Klaar / Geen gegevens.\n" +
                    "In wachtrij/Bezig toont verstreken tijd; Klaar toont duur + eindtijd." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Uitgebreide debuglogs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Schrijft extra details naar <AllTransitTrucks.log> voor probleemoplossing.\n" +
                    "**Uitschakelen** tijdens normaal spelen.\n" +
                    "<Dit verhoogt alleen de logging en verandert geen gameplaywaarden.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Logmap openen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Open de logmap.\n" +
                    "Open daarna <AllTransitTrucks.log> met een teksteditor (Notepad++ aanbevolen)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Rapportmap openen" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Open de rapportmap.\n" +
                    "Open daarna <ScanReport-Prefabs.txt> met een teksteditor (bijv. Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Inactief" },
                { "PWP_SCAN_QUEUED_FMT", "In wachtrij ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Bezig ({0})" },
                { "PWP_SCAN_DONE_FMT", "Klaar ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Mislukt" },
                { "PWP_SCAN_FAIL_NO_CITY", "Laad eerst een stad" },
                { "PWP_SCAN_UNKNOWN_TIME", "onbekende tijd" },

            };
        }

        public void Unload()
        {
        }
    }
}
