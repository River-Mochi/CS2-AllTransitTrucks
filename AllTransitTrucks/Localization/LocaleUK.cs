// <copyright file="LocaleUK.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleUK.cs
// Ukrainian (uk-UA) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleUK : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleUK(ATTSettings setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // --------------------------
                // Mod title / tabs / groups
                // --------------------------

                { m_Setting.GetSettingsLocaleID(), Mod.ShortName },

                // Tabs (match ATTSettings.cs tab ids)
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "Громадський транспорт" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Промисловість" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "Про мод" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Маршрути транспорту (діапазон повзунка в грі)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Розширити мін./макс. кількість транспорту на маршруті" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Розширює **діапазон** ігрового повзунка кількості транспорту для кожного маршруту.\n" +
                    "До **1 транспортного засобу** на всіх протестованих маршрутах.\n" +
                    "**Максимальна межа змінюється**, але протестовані маршрути дозволяють щонайменше у 3× більше за стандартний максимум гри.\n" +
                    "Технічна примітка: гра враховує час маршруту (час руху + кількість зупинок), тому максимум змінюється. Мод дотримується логіки гри й не задає фіксовану межу, наприклад 200.\n" +
                    "Працює для всього громадського транспорту.\n\n" +
                    "**---------------**\n" +
                    "Порада: щоб трохи збільшити верхню межу повзунка, додайте зупинки до маршруту.\n" +
                    "Гра автоматично збільшує максимум залежно від доданих зупинок та інших факторів; додати зупинки — простий спосіб вплинути на це.\n" +
                    "<Уникайте конфліктів>: приберіть інші моди, які змінюють ту саму політику транспортних маршрутів.\n" +
                    "Вимкніть, якщо ця функція не потрібна або якщо хочете використовувати інший мод для того самого."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Місткість депо (макс. транспорту на депо)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Автобусне депо" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Змінює кількість автобусів, які кожне **автобусне депо** може обслуговувати/випускати.\n" +
                    "**100%** = стандарт гри.\n" +
                    "**1000%** = у 10× більше.\n" +
                    "Застосовується до базової будівлі." },

                 { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Поромне депо" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "Максимальна кількість транспорту для кожного **поромного депо**.\n" +
                    "**100%** = стандарт гри.\n" +
                    "Застосовується до базової будівлі."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Депо метро" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Змінює кількість поїздів метро, які кожне **депо метро** може обслуговувати.\n" +
                    "Застосовується до базової будівлі."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Таксопарк" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Кількість таксі, які кожен **таксопарк** може обслуговувати.\n" +
                    "На максимумі таксі може стати смішно багато."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Трамвайне депо" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Змінює кількість трамваїв, які кожне **трамвайне депо** може обслуговувати.\n" +
                    "Застосовується до базової будівлі." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Залізничне депо" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Змінює кількість потягів, які кожне **залізничне депо** може обслуговувати.\n" +
                    "Застосовується до базової будівлі." },


                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Скинути налаштування депо" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Повернути всі повзунки депо до **100%** (стандарт гри)." },

                // Service / Fuel Range
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ServiceFuelRangeGroup), "Дальність обслуговування / запас ходу" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShowServiceFuelRange)), "Показати дальність обслуговування/заправки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShowServiceFuelRange)),
                    "Показує чотири повзунки дальності нижче. Приховування не скидає їхні значення." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusServiceFuelRangeScalar)), "Автобус" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusServiceFuelRangeScalar)),
                    "Відстань до потреби автобуса в обслуговуванні/заправці.\n" +
                    "**50%** = удвічі менша дальність, частіше потрібне обслуговування.\n" +
                    "**100%** = стандарт гри.\n" +
                    "**500%** = дальність у 5× більша\n" +
                    "Паливні та електричні автобуси зберігають власну базову дальність." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramServiceFuelRangeScalar)), "Трамвай" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramServiceFuelRangeScalar)),
                    "Відстань до потреби трамвая в обслуговуванні.\n" +
                    "**50%** = удвічі менша дальність, частіше потрібне обслуговування.\n" +
                    "**100%** = стандарт гри.\n" +
                    "**500%** = дальність у 5× більша" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainServiceFuelRangeScalar)), "Потяг" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainServiceFuelRangeScalar)),
                    "Відстань до потреби потяга в обслуговуванні/заправці.\n" +
                    "**50%** = удвічі менша дальність, частіше потрібне обслуговування.\n" +
                    "**100%** = стандарт гри.\n" +
                    "**500%** = дальність у 5× більша" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayServiceFuelRangeScalar)), "Метро" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayServiceFuelRangeScalar)),
                    "Відстань до потреби метро в обслуговуванні.\n" +
                    "**50%** = удвічі менша дальність, частіше потрібне обслуговування.\n" +
                    "**100%** = стандарт гри.\n" +
                    "**500%** = дальність у 5× більша" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetServiceFuelRangeToVanillaButton)), "Скинути дальність обслуговування/заправки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetServiceFuelRangeToVanillaButton)),
                    "Повернути всі чотири повзунки дальності до **100%** (стандарт гри)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Місткість пасажирів (макс. людей на транспорт)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Автобус" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Змінює місткість **пасажирів автобуса**.\n" +
                    "**10%** = 10% стандартної кількості місць.\n" +
                    "**100%** = стандартна кількість місць.\n" +
                    "**1000%** = у 10× більше місць." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Трамвай" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Змінює місткість **пасажирів трамвая**.\n" +
                    "**10%** = 10% стандартної кількості місць.\n" +
                    "**100%** = стандартна кількість місць.\n" +
                    "**1000%** = у 10× більше місць." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Потяг" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Змінює місткість **пасажирів потяга**.\n" +
                    "Застосовується до локомотивів і секцій.\n" +
                    "**10%** = 10% стандартної кількості місць.\n" +
                    "**100%** = стандартна кількість місць.\n" +
                    "**1000%** = у 10× більше місць." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Метро" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Змінює місткість **пасажирів метро**.\n" +
                    "**10%** = 10% стандартної кількості місць.\n" +
                    "**100%** = стандартна кількість місць.\n" +
                    "**1000%** = у 10× більше місць." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Корабель" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Змінює місткість **пасажирського корабля** (не вантажного).\n" +
                    "**100%** = стандартна кількість місць." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Пором" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Змінює місткість **пасажирів порома**.\n" +
                    "**10%** = 10% стандартної кількості місць.\n" +
                    "**100%** = стандартна кількість місць.\n" +
                    "**1000%** = у 10× більше місць." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Літак" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Змінює місткість **пасажирів літака**.\n" +
                    "**10%** = 10% стандартної кількості місць.\n" +
                    "**100%** = стандартна кількість місць.\n" +
                    "**1000%** = у 10× більше місць." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Подвоїти" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Встановити всі повзунки пасажирів на **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Скинути всіх пасажирів" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Повернути всі повзунки пасажирів до **100%**\n" +
                    "(стандарт гри)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Транспорт доставки (місткість вантажу)" },


                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Сідельні вантажівки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**Місткість сідельної вантажівки**.\n" +
                    "**100% = 25 т** (стандарт гри)\n" +
                    "**500% = 125 т**.\n" +
                    "Включає:\n" +
                    " - Сідельні вантажівки спеціалізованої промисловості (ферми, рибальство, лісове господарство тощо).\n" +
                    "Примітка: також включає сідельні вантажівки, що перевозять пошту до/з вантажних станцій.\n" +
                    "Це не те саме, що місцева доставка пошти."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Фургони доставки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Фургони доставки**\n" +
                    "**100% = 4 т** (стандарт гри)\n" +
                    "**500% = 20 т**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Вантажівки сировини" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Вантажівки сировини** (нафта, вугілля, руда, камінь і самоскиди промислових відходів — це спільний тип вантажівки)\n" +
                    "**100% = 20 т** (стандарт гри)\n" +
                    "**500% = 100 т**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Мотоцикл доставки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**Мотоцикл доставки** зазвичай перевозить аптечні товари до лікарні/клініки.\n" +
                    "**100% = 0,1 т** (стандарт гри)\n" +
                    "**500% = 0,5 т**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Скинути налаштування доставки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Повернути повзунки доставки до **100%** (стандарт гри)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Загальна кількість вантажівок" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Вантажні станції, усього вантажівок" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Максимальна кількість активного вантажного транспорту для кожного **вантажного порту, залізничного термінала й аеропорту**.\n" +
                    "**1×** = стандарт гри, **5×** = у 5 разів більше." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "Показати промислові вантажівки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "<[x] За замовчуванням УВІМК.> для зміни загальної кількості вантажівок.\n" +
                    "Для сумісності з іншими модами:\n" +
                    "- вимкніть, якщо хочете, щоб інший мод керував тією самою кількістю вантажівок промисловості/компаній.\n" +
                    "Залиште УВІМК., щоб використовувати три повзунки вантажівок промислових компаній.\n" +
                    "Вимкніть, щоб повернути ці 3 повзунки до стандарту гри й приховати їх.\n" +
                    "Якщо хочете використовувати повзунки цього мода, перевірте, чи інший мод має перемикач для вимкнення власного керування кількістю вантажівок."
                     },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Вантажівки видобувних компаній" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Максимальна кількість вантажівок для кожної видобувної компанії.\n" +
                    "Включає ферми, лісове господарство, рибальство, нафту, руду, вугілля, камінь, бавовну, тваринництво й овочі.\n" +
                    "**1×** = стандарт гри, **5×** = у 5 разів більше." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "Складські вантажівки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "Максимальна кількість вантажівок для кожної складської компанії.\n" +
                    "Включає всі типи складських ресурсів, що мають власний транспорт.\n" +
                    "**1×** = стандарт гри, **5×** = у 5 разів більше." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "Промислові вантажівки" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "Максимальна кількість вантажівок для промислових переробних компаній.\n" +
                    "Не включає видобувні компанії, склади, вантажні станції, комерційні або офісні компанії.\n" +
                    "**1×** = стандарт гри, **5×** = у 5 разів більше." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Скинути весь промисловий транспорт" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Повернути повзунки вантажних станцій, видобувних компаній, складів і промисловості до **1×** (стандарт гри).\n" +
                    "Перемикач керування вантажівками компаній залишається у вибраному стані." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Інформація" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Посилання підтримки" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Налагодження / журнал" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Мод" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Відображувана назва цього мода." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Версія" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Поточна версія мода та тип збірки." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Відкрити сторінку модів автора на Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Відкрити Discord спільноти у браузері." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Звіт сканування (prefab)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Створює <одноразовий> звіт для налагодження.\n" +
                    "Не потрібен для звичайної гри.\n" +
                    "Розташування файла: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Порада: натисніть <один раз>; коли стан буде «Готово», використайте <Відкрити папку звіту>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Стан сканування prefab" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Показує стан сканування: Очікування / У черзі / Виконується / Готово / Немає даних.\n" +
                    "Для черги/виконання показується минулий час; для готового звіту — тривалість і час завершення." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Докладний журнал налагодження" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Записує додаткові подробиці в <AllTransitTrucks.log> для пошуку проблем.\n" +
                    "**Вимкніть** для звичайної гри.\n" +
                    "<Це лише збільшує обсяг журналу й не змінює ігрові значення.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Відкрити журнал" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Відкрити <Logs/AllTransitTrucks.log> або папку Logs, якщо файла ще немає.\n" +
                    "Для перегляду журналів можна використовувати Notepad++."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Відкрити папку звіту" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Відкрити папку звіту.\n" +
                    "Потім відкрийте <ScanReport-Prefabs.txt> у текстовому редакторі (наприклад, Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Очікування" },
                { "PWP_SCAN_QUEUED_FMT", "У черзі ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Виконується ({0})" },
                { "PWP_SCAN_DONE_FMT", "Готово ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Помилка" },
                { "PWP_SCAN_FAIL_NO_CITY", "Спочатку завантажте місто" },
                { "PWP_SCAN_UNKNOWN_TIME", "невідомий час" },

            };
        }

        public void Unload()
        {
        }
    }
}
