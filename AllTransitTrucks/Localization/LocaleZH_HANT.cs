// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANT.cs
// Traditional Chinese (zh-HANT) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleZH_HANT(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "大眾運輸" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "工業" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "公園-道路" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "關於" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "交通路線（遊戲內滑桿範圍）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "擴充交通路線最小/最大值" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "擴充每條路線的遊戲內交通路線滑桿**範圍**。\n" +
                    "在所有已測試路線上，**最低可到 1 輛車**。\n" +
                    "**最大上限會變動**，但已測試路線至少可達原版最大值的 3 倍。\n" +
                    "技術說明：遊戲使用路線時間（行駛時間 + 站點數量）；這會形成可變的最大值（本模組遵循遊戲邏輯，因此不會設定像 200 這樣的固定上限）。\n" +
                    "適用於所有大眾運輸：公車、渡輪、電車、火車、地鐵、客船、飛機。\n\n" +
                    "**---------------**\n" +
                    "提示：如果想把滑桿上限再稍微提高一些，可以替路線增加幾個站點。\n" +
                    "遊戲會依照新增站點 + 各種因素自動提高最大值；增加站點是玩家很容易做到的調整。\n" +
                    "<避免衝突>：移除修改同一交通路線政策的模組。\n" +
                    "如果不需要此功能，或需要關閉它以使用其他實作相同功能的模組，請停用。"
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "車庫容量（每個車庫最大車輛數）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "公車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "修改每個**公車車庫**可維護/生成的公車數量。\n" +
                    "**100%** = 原版（遊戲預設值）。\n" +
                    "**1000%** = 10× 更多。\n" +
                    "適用於基礎建築。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "渡輪車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**渡輪車庫**每棟建築的最大車輛數。\n" +
                    "**100%** = 原版（遊戲預設值）。\n" +
                    "適用於基礎建築。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "地鐵車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "修改每個**地鐵車庫**可維護的地鐵車輛數量。\n" +
                    "適用於基礎建築。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "計程車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "每個**計程車車庫**可維護的計程車數量。\n" +
                    "若設到最大，可能會出現數量過多、甚至有點滑稽的計程車。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "電車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "修改每個**電車車庫**可維護的電車數量。\n" +
                    "適用於基礎建築。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "火車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "修改每個**火車車庫**可維護的火車數量。\n" +
                    "適用於基礎建築。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "重設車庫預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "將所有車庫滑桿恢復到 **100%**（遊戲預設值 / 原版）。" },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "載客量（每輛車最大人數）" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "公車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "修改**公車乘客**容量。\n" +
                    "**10%** = 原版座位數的 10%。\n" +
                    "**100%** = 原版座位數（遊戲預設值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "電車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "修改**電車乘客**容量。\n" +
                    "**10%** = 原版座位數的 10%。\n" +
                    "**100%** = 原版座位數（遊戲預設值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "火車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "修改**火車乘客**容量。\n" +
                    "適用於車頭與車廂段。\n" +
                    "**10%** = 原版座位數的 10%。\n" +
                    "**100%** = 原版座位數（遊戲預設值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "地鐵" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "修改**地鐵乘客**容量。\n" +
                    "**10%** = 原版座位數的 10%。\n" +
                    "**100%** = 原版座位數（遊戲預設值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "船" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "修改**客船**容量（不包含貨船）。\n" +
                    "**100%** = 原版座位數（遊戲預設值）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "渡輪" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "修改**渡輪乘客**容量。\n" +
                    "**10%** = 原版座位數的 10%。\n" +
                    "**100%** = 原版座位數（遊戲預設值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "飛機" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "修改**飛機乘客**容量。\n" +
                    "**10%** = 原版座位數的 10%。\n" +
                    "**100%** = 原版座位數（遊戲預設值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "雙倍" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "將所有乘客滑桿設為 **200%**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "重設所有乘客設定" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "將所有乘客滑桿恢復到 **100%**\n" +
                    "（遊戲預設值 / 原版）。" },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "配送車輛（貨物容量）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "半掛卡車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**半掛卡車容量**。\n" +
                    "**100% = 25t**（原版）\n" +
                    "**500% = 125t**。\n" +
                    "包括：\n" +
                    " - 專業工業半掛（農場、漁業、林業等）。\n" +
                    "備註：也包括往返貨運站運送郵件的半掛卡車。\n" +
                    "這與本地郵件投遞不同。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "配送廂型車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**配送廂型車**\n" +
                    "**100% = 4t**（原版）\n" +
                    "**500% = 20t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "原材料卡車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**原材料卡車**（石油、煤炭、礦石、石材，以及用於工業廢棄物的傾卸卡車 - 屬於同一種共用卡車類型）\n" +
                    "**100% = 20t**（原版）\n" +
                    "**500% = 100t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "配送機車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**機車配送**通常會把藥品送到醫院/診所。\n" +
                    "**100% = 0.1t**（原版）\n" +
                    "**500% = 0.5t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "重設配送預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "將配送滑桿恢復到 **100%**（遊戲預設值 / 原版）。" },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "每個設施的車輛總數" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "車輛總數：貨運站" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "每個**貨運港、貨運鐵路終端與機場**的最大活躍貨運車輛數。\n" +
                    "**1×** = 原版，**5×** = 5 倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "調整工業卡車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "用於相容其他模組：\n" +
                    "- 如果想讓其他模組控制相同工業公司的卡車總數，請關閉此項。\n" +
                    "<[x] 預設開啟>。\n" +
                    "保持開啟可使用下方三個滑桿調整公司卡車總數。\n" +
                    "關閉後會將這三類恢復為遊戲預設值，並隱藏滑桿。\n" +
                    "如果想使用本模組的滑桿，請檢查其他模組是否可以關閉其卡車數量調整。"
                     },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "卡車總數：採集設施" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "每個採集公司的最大卡車數。\n" +
                    "包括農場、林業、漁業、石油、礦石、煤炭、石材、棉花、畜牧與蔬菜。\n" +
                    "**1×** = 原版，**5×** = 5 倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "卡車總數：倉庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "每個倉庫公司的最大卡車數。\n" +
                    "包括所有擁有自有車輛的倉庫資源類型。\n" +
                    "**1×** = 原版，**5×** = 5 倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "卡車總數：工業" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "工業加工公司的最大卡車數。\n" +
                    "不包括採集設施、倉庫、貨運站、商業公司或辦公公司。\n" +
                    "**1×** = 原版，**5×** = 5 倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "重設所有工業車輛" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "將貨運站、採集設施、倉庫與工業滑桿重設為 **1×**（原版值）。\n" +
                    "公司卡車控制開關會保持所選的開啟或關閉狀態。" },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "公園維護" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "工作班次容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "**工作班次容量**（車輛容量）的倍率。\n" +
                    "卡車在返回建築前可完成的總工作量。\n" +
                    "可以理解為：補給更多 = 在外工作更久。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "車輛工作速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "**車輛工作速率**的倍率。\n" +
                    "速率 = 車輛停下時每個模擬 tick 完成的工作量。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "車庫車隊規模" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "車庫建築**最大車輛數**的倍率。\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "重設公園維護" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "將所有數值重設回 **100%**（遊戲預設值 / 原版）。" },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "道路維護" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "車庫車隊規模" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "每棟建築**車庫最大車輛數**的倍率。\n" +
                    "越高 = 卡車越多。\n" +
                    "<平衡說明：太少或太多都可能傷害交通。>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "工作班次容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "**工作班次容量**的倍率。\n" +
                    "卡車在返回車庫前可完成的總工作量。\n" +
                    "**越高 = 返回主建築次數越少。** 效率更高。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "修理速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "速率 = 車輛停下時每個模擬 tick 完成的工作量。\n" +
                    "即使在最高速率下，卡車仍會短暫停車再前進；只是每次停車完成更多工作。\n" +
                    "原版中，一次停車不一定能把道路修到 100%，所以這個功能會隨時間推移變得更有幫助。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "道路磨損" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<測試功能>\n" +
                    "控制道路因**時間與交通**因素而劣化的速度。\n" +
                    "**10%** = 磨損速度慢 10×（所需維修更少）\n" +
                    "**100%** = 原版\n" +
                    "**500%** = 損壞速度快 5×（需要更多維修/卡車）\n" +
                    "遊戲內運作方式：\n" +
                    "如果 m_Wear <= 2.5，則無減速。\n" +
                    "如果 m_Wear >= 17.5，則達到最大懲罰，車輛在道路上速度會降低 50%。\n" +
                    "查看道路資訊檢視：嚴重損壞的道路會顯示為紅色，並減慢車輛速度。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "重設道路維護" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "將所有數值恢復到 **100%**（遊戲預設值 / 原版）。" },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "資訊" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "支援連結" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "除錯 / 日誌" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "此模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "目前模組版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "開啟作者模組的 Paradox Mods 網站。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "在瀏覽器中開啟社群 Discord。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "掃描報告（prefab）" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "建立用於除錯的<一次性>報告。\n" +
                    "正常遊玩不需要。\n" +
                    "檔案位置：<ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "提示：點擊<一次>；當狀態顯示為完成時，使用 <開啟報告資料夾>。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Prefab 掃描狀態" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "顯示掃描狀態：閒置 / 排隊中 / 執行中 / 完成 / 無資料。\n" +
                    "排隊中/執行中會顯示已用時間；完成會顯示耗時 + 完成時間。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "詳細除錯日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "將額外細節寫入 <AllTransitTrucks.log> 以便排查問題。\n" +
                    "正常遊玩請**停用**。\n" +
                    "<這只會增加日誌記錄，不會改變遊戲數值。>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "開啟日誌資料夾" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "開啟日誌資料夾。\n" +
                    "下一步：用文字編輯器開啟 <AllTransitTrucks.log>（推薦 Notepad++）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "開啟報告資料夾" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "開啟報告資料夾。\n" +
                    "下一步：用文字編輯器開啟 <ScanReport-Prefabs.txt>（例如 Notepad++）。" },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "閒置" },
                { "PWP_SCAN_QUEUED_FMT", "排隊中 ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "執行中 ({0})" },
                { "PWP_SCAN_DONE_FMT", "完成 ({0} | {1})" },
                { "PWP_SCAN_FAILED", "失敗" },
                { "PWP_SCAN_FAIL_NO_CITY", "請先載入城市" },
                { "PWP_SCAN_UNKNOWN_TIME", "未知時間" },

            };
        }

        public void Unload( )
        {
        }
    }
}
