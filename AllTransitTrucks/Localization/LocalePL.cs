// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// Polish (pl-PL) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePL : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocalePL(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "Transport publiczny" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Przemysł" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Parki-Drogi" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "O modzie" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Linie transportu (zakres suwaka w grze)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Rozszerz min/max linii transportu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Rozszerza **zakres** suwaka linii transportu w grze dla każdej trasy.\n" +
                    "Na wszystkich testowanych trasach można zejść **nawet do 1 pojazdu**.\n" +
                    "**Maksymalny limit jest zmienny**, ale testowane trasy pozwalają na co najmniej 3× większe maksimum niż w vanilli.\n" +
                    "Uwaga techniczna: gra używa czasu trasy (czas jazdy + liczba przystanków); to tworzy zmienne maksimum (ten mod trzyma się logiki gry, więc nie ustawia stałego maksimum jak 200).\n" +
                    "Działa dla całego transportu: autobus, prom, tramwaj, pociąg, metro, statek, samolot.\n\n" +
                    "**---------------**\n" +
                    "Wskazówka: jeśli chcesz trochę bardziej zwiększyć górny koniec suwaka, dodaj kilka przystanków do trasy.\n" +
                    "Gra automatycznie zwiększa maksimum na podstawie dodanych przystanków + czynników; dodanie przystanków to łatwa korekta dla gracza.\n" +
                    "<Unikaj konfliktów>: usuń mody, które edytują tę samą politykę linii transportu.\n" +
                    "Wyłącz, jeśli ta funkcja nie jest potrzebna albo jeśli musi być wyłączona, by użyć innego moda robiącego to samo."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Pojemność zajezdni (maks. pojazdów na zajezdnię)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Zajezdnia autobusowa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Zmieniaj liczbę autobusów, które każda **zajezdnia autobusowa** może utrzymać/wypuścić.\n" +
                    "**100%** = vanilla (domyślna wartość gry).\n" +
                    "**1000%** = 10× więcej.\n" +
                    "Dotyczy podstawowego budynku." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Zajezdnia promowa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**Zajezdnia promowa**: maks. pojazdów na budynek.\n" +
                    "**100%** = vanilla (domyślna wartość gry).\n" +
                    "Dotyczy podstawowego budynku."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Zajezdnia metra" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Zmieniaj liczbę pojazdów metra, które każda **zajezdnia metra** może utrzymać.\n" +
                    "Dotyczy podstawowego budynku."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Zajezdnia taksówek" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Ile taksówek może utrzymać każda **zajezdnia taksówek**.\n" +
                    "Ustawienie na maksimum może spowodować przesadnie dużą, wręcz komiczną liczbę taksówek."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Zajezdnia tramwajowa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Zmieniaj liczbę tramwajów, które każda **zajezdnia tramwajowa** może utrzymać.\n" +
                    "Dotyczy podstawowego budynku." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Zajezdnia kolejowa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Zmieniaj liczbę pociągów, które każda **zajezdnia kolejowa** może utrzymać.\n" +
                    "Dotyczy podstawowego budynku." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Resetuj ustawienia zajezdni" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Ustaw wszystkie suwaki zajezdni z powrotem na **100%** (domyślna wartość gry / vanilla)." },

                // Service / Fuel Range
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ServiceFuelRangeGroup), "Zasięg serwisu / paliwa" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShowServiceFuelRange)), "Pokaż zasięg serwisu/tankowania" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShowServiceFuelRange)), "Pokazuje cztery suwaki zasięgu poniżej. Ukrycie ich nie resetuje wartości." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusServiceFuelRangeScalar)), "Autobus" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusServiceFuelRangeScalar)),
                    "Dystans, po którym autobus wymaga serwisu/tankowania.\n" +
                    "**50%** = połowa zasięgu, więcej powrotów.\n" +
                    "**100%** = ustawienie gry.\n" +
                    "**500%** = 5× większy zasięg.\n" +
                    "Autobusy spalinowe i elektryczne zachowują własny zasięg bazowy." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramServiceFuelRangeScalar)), "Tramwaj" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramServiceFuelRangeScalar)),
                    "Dystans, po którym tramwaj wymaga serwisu.\n" +
                    "**50%** = połowa zasięgu, więcej wizyt w serwisie.\n" +
                    "**100%** = ustawienie gry.\n" +
                    "**500%** = 5× większy zasięg." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainServiceFuelRangeScalar)), "Pociąg" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainServiceFuelRangeScalar)),
                    "Dystans, po którym pociąg wymaga serwisu/tankowania.\n" +
                    "**50%** = połowa zasięgu, więcej wizyt w serwisie.\n" +
                    "**100%** = ustawienie gry.\n" +
                    "**500%** = 5× większy zasięg." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayServiceFuelRangeScalar)), "Metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayServiceFuelRangeScalar)),
                    "Dystans, po którym metro wymaga serwisu.\n" +
                    "**50%** = połowa zasięgu, więcej wizyt w serwisie.\n" +
                    "**100%** = ustawienie gry.\n" +
                    "**500%** = 5× większy zasięg." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetServiceFuelRangeToVanillaButton)), "Reset serwisu/paliwa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetServiceFuelRangeToVanillaButton)), "Ustaw wszystkie cztery suwaki zasięgu z powrotem na **100%** (ustawienie gry)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Pojemność pasażerska (maks. osób na pojazd)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Autobus" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Zmieniaj pojemność **pasażerów autobusów**.\n" +
                    "**10%** = 10% miejsc vanilla.\n" +
                    "**100%** = miejsca vanilla (domyślna wartość gry).\n" +
                    "**1000%** = 10× więcej miejsc." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Tramwaj" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Zmieniaj pojemność **pasażerów tramwajów**.\n" +
                    "**10%** = 10% miejsc vanilla.\n" +
                    "**100%** = miejsca vanilla (domyślna wartość gry).\n" +
                    "**1000%** = 10× więcej miejsc." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Pociąg" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Zmieniaj pojemność **pasażerów pociągów**.\n" +
                    "Dotyczy lokomotyw i sekcji.\n" +
                    "**10%** = 10% miejsc vanilla.\n" +
                    "**100%** = miejsca vanilla (domyślna wartość gry).\n" +
                    "**1000%** = 10× więcej miejsc." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Zmieniaj pojemność **pasażerów metra**.\n" +
                    "**10%** = 10% miejsc vanilla.\n" +
                    "**100%** = miejsca vanilla (domyślna wartość gry).\n" +
                    "**1000%** = 10× więcej miejsc." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Statek" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Zmieniaj pojemność **statków pasażerskich** (nie statków towarowych).\n" +
                    "**100%** = miejsca vanilla (domyślna wartość gry)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Prom" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Zmieniaj pojemność **pasażerów promów**.\n" +
                    "**10%** = 10% miejsc vanilla.\n" +
                    "**100%** = miejsca vanilla (domyślna wartość gry).\n" +
                    "**1000%** = 10× więcej miejsc." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Samolot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Zmieniaj pojemność **pasażerów samolotów**.\n" +
                    "**10%** = 10% miejsc vanilla.\n" +
                    "**100%** = miejsca vanilla (domyślna wartość gry).\n" +
                    "**1000%** = 10× więcej miejsc." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Podwój" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Ustaw każdy suwak pasażerów na **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Resetuj wszystkich pasażerów" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Ustaw wszystkie suwaki pasażerów z powrotem na **100%**\n" +
                    "(domyślna wartość gry / vanilla)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Pojazdy dostawcze (pojemność ładunku)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Ciągniki siodłowe" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**Pojemność ciągników siodłowych**.\n" +
                    "**100% = 25t** (vanilla)\n" +
                    "**500% = 125t**.\n" +
                    "Obejmuje:\n" +
                    " - Naczepy specjalistycznego przemysłu (farmy, rybołówstwo, leśnictwo itp.).\n" +
                    "Uwaga: obejmuje też ciągniki siodłowe przewożące pocztę do/z terminali cargo.\n" +
                    "To nie to samo co lokalne dostawy poczty."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Furgonetki dostawcze" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Furgonetki dostawcze**\n" +
                    "**100% = 4t** (vanilla)\n" +
                    "**500% = 20t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Ciężarówki surowcowe" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Ciężarówki surowcowe** (ropa, węgiel, ruda, kamień, wywrotki do odpadów przemysłowych - ten sam współdzielony typ ciężarówki)\n" +
                    "**100% = 20t** (vanilla)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Motocykl dostawczy" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**Dostawa motocyklem** zwykle przewozi farmaceutyki do szpitala/kliniki.\n" +
                    "**100% = 0.1t** (vanilla)\n" +
                    "**500% = 0.5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Resetuj ustawienia dostaw" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Ustaw suwaki dostaw z powrotem na **100%** (domyślna wartość gry / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Łączna liczba ciężarówek" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Terminale cargo, łączna liczba ciężarówek" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Maksymalna liczba aktywnych pojazdów cargo dla każdego **portu cargo, terminalu kolejowego i lotniska**.\n" +
                    "**1×** = vanilla, **5×** = 5 razy więcej." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "Pokaż ciężarówki przemysłowe" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "<[x] Domyślnie WŁĄCZONE> — pozwala zmieniać łączną liczbę ciężarówek.\n" +
                    "Dla zgodności z innymi modami,\n" +
                    "- użyj WYŁĄCZONE, jeśli inny mod ma kontrolować łączną liczbę ciężarówek tych samych firm przemysłowych.\n" +
                    "Pozostaw WŁĄCZONE, aby używać trzech suwaków ciężarówek przemysłowych.\n" +
                    "WYŁĄCZENIE przywraca te 3 suwaki do wartości gry i je ukrywa.\n" +
                    "Jeśli używasz suwaków tego moda, sprawdź, czy drugi mod pozwala wyłączyć własne ustawienia liczby ciężarówek." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Ciężarówki wydobywcze" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Maksymalna liczba ciężarówek dla każdej firmy wydobywczej.\n" +
                    "Obejmuje farmy, leśnictwo, rybołówstwo, ropę, rudę, węgiel, kamień, bawełnę, hodowlę i warzywa.\n" +
                    "**1×** = vanilla, **5×** = 5 razy więcej." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "Ciężarówki magazynowe" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "Maksymalna liczba ciężarówek dla każdej firmy magazynowej.\n" +
                    "Obejmuje wszystkie typy zasobów magazynowych, które mają własne pojazdy.\n" +
                    "**1×** = vanilla, **5×** = 5 razy więcej." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "Ciężarówki przemysłowe" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "Maksymalna liczba ciężarówek dla zakładów przetwórstwa przemysłowego.\n" +
                    "Nie obejmuje zakładów wydobywczych, magazynów, stacji cargo, firm handlowych ani biurowych.\n" +
                    "**1×** = vanilla, **5×** = 5 razy więcej." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Resetuj wszystkie pojazdy przemysłowe" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Ustaw suwaki stacji cargo, wydobycia, magazynów i przemysłu na **1×** (wartości vanilla).\n" +
                    "Przełącznik sterowania ciężarówkami firmowymi pozostaje WŁĄCZONY lub WYŁĄCZONY zgodnie z wyborem." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Utrzymanie parków" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Pojemność zmiany roboczej" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Mnożnik **pojemności zmiany roboczej** (pojemności pojazdu).\n" +
                    "Całkowita ilość pracy, jaką ciężarówka może wykonać, zanim wróci do budynku.\n" +
                    "Pomyśl: więcej zapasów = dłuższa praca w terenie." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Tempo pojazdu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "Mnożnik **tempa pracy pojazdu**.\n" +
                    "Tempo = ile pracy wykonuje w jednym ticku symulacji podczas postoju." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Rozmiar floty zajezdni" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Mnożnik dla **maksymalnej liczby pojazdów** budynku zajezdni.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Resetuj utrzymanie parków" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Resetuj wszystkie wartości do **100%** (domyślna wartość gry / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Utrzymanie dróg" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Rozmiar floty zajezdni" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Mnożnik dla **maksymalnej liczby pojazdów zajezdni** na budynek.\n" +
                    "Wyżej = więcej ciężarówek.\n" +
                    "<Uwaga dot. balansu: zbyt mało lub zbyt dużo może szkodzić ruchowi.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Pojemność zmiany roboczej" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Mnożnik **pojemności zmiany roboczej**.\n" +
                    "Całkowita ilość pracy, jaką ciężarówka może wykonać, zanim wróci do zajezdni.\n" +
                    "**Wyżej = mniej powrotów** do głównego budynku. Większa wydajność." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Tempo napraw" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "Tempo = ile pracy wykonuje w jednym ticku symulacji podczas postoju.\n" +
                    "Ciężarówki nadal robią szybkie stop+ruszenie nawet przy najwyższym tempie; po prostu wykonują więcej pracy na jeden postój.\n" +
                    "W vanilli jeden postój niekoniecznie przywraca drogę do 100% naprawy, więc ta funkcja z czasem daje coraz lepszy efekt.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Zużycie dróg" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Funkcja beta>\n" +
                    "Kontroluje, jak szybko drogi niszczeją od czynników **czasu i ruchu**.\n" +
                    "**10%** = 10× wolniejsze zużycie (mniej potrzebnych napraw)\n" +
                    "**100%** = vanilla\n" +
                    "**500%** = 5× szybsze uszkodzenia (więcej potrzebnych napraw/ciężarówek)\n" +
                    "Jak to działa w grze:\n" +
                    "Jeśli współczynnik m_Wear <= 2.5, brak spowolnienia.\n" +
                    "Jeśli m_Wear >= 17.5, maksymalna kara, pojazdy są o 50% wolniejsze na drogach.\n" +
                    "Zobacz widok informacji o drogach: mocno uszkodzone drogi są zaznaczone na czerwono i spowalniają pojazdy."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Resetuj utrzymanie dróg" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Ustaw wszystkie wartości z powrotem na **100%** (domyślna wartość gry / vanilla)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Linki wsparcia" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Debug / Logowanie" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Wyświetlana nazwa tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Aktualna wersja moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Otwiera stronę Paradox Mods z modami autora." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Otwiera społecznościowy Discord w przeglądarce." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Raport skanowania (prefaby)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Tworzy <jednorazowy> raport do debugowania.\n" +
                    "Nie jest potrzebny do normalnej rozgrywki.\n" +
                    "Lokalizacja pliku: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Wskazówka: kliknij <raz>; gdy status pokaże Gotowe, użyj <Otwórz folder raportów>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Status skanowania prefabów" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Pokazuje stan skanowania: Bezczynny / W kolejce / Uruchomione / Gotowe / Brak danych.\n" +
                    "W kolejce/Uruchomione pokazuje upływ czasu; Gotowe pokazuje czas trwania + godzinę zakończenia." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Szczegółowe logi debug" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Wysyła dodatkowe szczegóły do <AllTransitTrucks.log> do rozwiązywania problemów.\n" +
                    "Do normalnej rozgrywki **wyłącz**.\n" +
                    "<To tylko zwiększa logowanie i nie zmienia wartości rozgrywki.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Otwórz folder logów" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Otwiera folder logów.\n" +
                    "Następnie: otwórz <AllTransitTrucks.log> w edytorze tekstu (zalecany Notepad++)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Otwórz folder raportów" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Otwiera folder raportów.\n" +
                    "Następnie: otwórz <ScanReport-Prefabs.txt> w edytorze tekstu (np. Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Bezczynny" },
                { "PWP_SCAN_QUEUED_FMT", "W kolejce ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Uruchomione ({0})" },
                { "PWP_SCAN_DONE_FMT", "Gotowe ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Niepowodzenie" },
                { "PWP_SCAN_FAIL_NO_CITY", "Najpierw wczytaj miasto" },
                { "PWP_SCAN_UNKNOWN_TIME", "nieznany czas" },

            };
        }

        public void Unload( )
        {
        }
    }
}
