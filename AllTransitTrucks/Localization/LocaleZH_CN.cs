// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleZH_CN(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "公共交通" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "工业" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "公园-道路" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "关于" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "交通线路（游戏内滑块范围）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "扩展交通线路最小/最大值" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "扩展每条线路的游戏内交通线路滑块**范围**。\n" +
                    "在所有已测试线路上，**最低可到 1 辆车**。\n" +
                    "**最大上限会变化**，但已测试线路至少可达到原版最大值的 3 倍。\n" +
                    "技术说明：游戏使用线路时间（行驶时间 + 站点数量）；这会形成可变的最大值（本模组遵循游戏逻辑，因此不会设置像 200 这样的固定上限）。\n" +
                    "适用于所有公共交通：公交、渡轮、电车、火车、地铁、客船、飞机。\n\n" +
                    "**---------------**\n" +
                    "提示：如果想把滑块上限再稍微提高一些，可以给线路增加几个站点。\n" +
                    "游戏会根据新增站点 + 各种因素自动提高最大值；增加站点是玩家很容易做到的调整。\n" +
                    "<避免冲突>：移除修改同一交通线路策略的模组。\n" +
                    "如果不需要此功能，或需要关闭它以使用其他实现相同功能的模组，请禁用。"
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "车库容量（每个车库最大车辆数）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "公交车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "修改每个**公交车库**可维护/生成的公交数量。\n" +
                    "**100%** = 原版（游戏默认值）。\n" +
                    "**1000%** = 10× 更多。\n" +
                    "适用于基础建筑。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "渡轮车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**渡轮车库**每栋建筑的最大车辆数。\n" +
                    "**100%** = 原版（游戏默认值）。\n" +
                    "适用于基础建筑。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "地铁车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "修改每个**地铁车库**可维护的地铁车辆数量。\n" +
                    "适用于基础建筑。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "出租车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "每个**出租车车库**可维护的出租车数量。\n" +
                    "如果设到最大，可能会出现数量过多、甚至有点搞笑的出租车。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "电车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "修改每个**电车车库**可维护的电车数量。\n" +
                    "适用于基础建筑。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "火车车库" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "修改每个**火车车库**可维护的火车数量。\n" +
                    "适用于基础建筑。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "重置车库默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "将所有车库滑块恢复到 **100%**（游戏默认值 / 原版）。" },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "载客量（每辆车最大人数）" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "公交" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "修改**公交乘客**容量。\n" +
                    "**10%** = 原版座位数的 10%。\n" +
                    "**100%** = 原版座位数（游戏默认值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "电车" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "修改**电车乘客**容量。\n" +
                    "**10%** = 原版座位数的 10%。\n" +
                    "**100%** = 原版座位数（游戏默认值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "火车" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "修改**火车乘客**容量。\n" +
                    "适用于车头和车厢段。\n" +
                    "**10%** = 原版座位数的 10%。\n" +
                    "**100%** = 原版座位数（游戏默认值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "地铁" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "修改**地铁乘客**容量。\n" +
                    "**10%** = 原版座位数的 10%。\n" +
                    "**100%** = 原版座位数（游戏默认值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "船" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "修改**客船**容量（不包括货船）。\n" +
                    "**100%** = 原版座位数（游戏默认值）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "渡轮" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "修改**渡轮乘客**容量。\n" +
                    "**10%** = 原版座位数的 10%。\n" +
                    "**100%** = 原版座位数（游戏默认值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "飞机" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "修改**飞机乘客**容量。\n" +
                    "**10%** = 原版座位数的 10%。\n" +
                    "**100%** = 原版座位数（游戏默认值）。\n" +
                    "**1000%** = 10× 更多座位。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "双倍" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "将所有乘客滑块设为 **200%**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "重置所有乘客设置" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "将所有乘客滑块恢复到 **100%**\n" +
                    "（游戏默认值 / 原版）。" },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "配送车辆（货物容量）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "半挂卡车" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**半挂卡车容量**。\n" +
                    "**100% = 25t**（原版）\n" +
                    "**500% = 125t**。\n" +
                    "包括：\n" +
                    " - 专业工业半挂（农场、渔业、林业等）。\n" +
                    "备注：也包括往返货运站运输邮件的半挂卡车。\n" +
                    "这与本地邮件投递不同。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "配送面包车" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**配送面包车**\n" +
                    "**100% = 4t**（原版）\n" +
                    "**500% = 20t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "原材料卡车" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**原材料卡车**（石油、煤炭、矿石、石材，以及用于工业废弃物的自卸卡车 - 属于同一种共享卡车类型）\n" +
                    "**100% = 20t**（原版）\n" +
                    "**500% = 100t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "配送摩托车" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**摩托车配送**通常会把药品送到医院/诊所。\n" +
                    "**100% = 0.1t**（原版）\n" +
                    "**500% = 0.5t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "重置配送默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "将配送滑块恢复到 **100%**（游戏默认值 / 原版）。" },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "每个设施的车辆总数" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "车辆总数：货运站" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "每个**货运港、货运铁路终端和机场**的最大活跃货运车辆数。\n" +
                    "**1×** = 原版，**5×** = 5 倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "工业：调整卡车总数" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "控制 ATT 对采集设施、仓库和工业加工公司的卡车上限。\n" +
                    "保持开启以使用下方三个公司卡车滑块。\n" +
                    "关闭后会将这三类一次性恢复为原版值、隐藏滑块，并停止 ATT 写入其卡车数量。\n" +
                    "当其他模组控制相同公司车队时，请关闭。\n" +
                    "货运站车辆和配送车辆货物容量不受影响。\n" +
                    "<[x] 默认开启>。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "卡车总数：采集设施" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "每个采集公司的最大卡车数。\n" +
                    "包括农场、林业、渔业、石油、矿石、煤炭、石材、棉花、畜牧和蔬菜。\n" +
                    "**1×** = 原版，**5×** = 5 倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "卡车总数：仓库" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "每个仓库公司的最大卡车数。\n" +
                    "包括所有拥有自有车辆的仓库资源类型。\n" +
                    "**1×** = 原版，**5×** = 5 倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "卡车总数：工业" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "工业加工公司的最大卡车数。\n" +
                    "不包括采集设施、仓库、货运站、商业公司或办公公司。\n" +
                    "**1×** = 原版，**5×** = 5 倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "重置所有工业车辆" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "将货运站、采集设施、仓库和工业滑块重置为 **1×**（原版值）。\n" +
                    "公司卡车控制开关会保持所选的开启或关闭状态。" },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "公园维护" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "工作班次容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "**工作班次容量**（车辆容量）的倍率。\n" +
                    "卡车在返回建筑前可完成的总工作量。\n" +
                    "可以理解为：补给更多 = 在外工作更久。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "车辆工作速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "**车辆工作速率**的倍率。\n" +
                    "速率 = 车辆停下时每个模拟 tick 完成的工作量。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "车库车队规模" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "车库建筑**最大车辆数**的倍率。\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "重置公园维护" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "将所有数值重置回 **100%**（游戏默认值 / 原版）。" },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "道路维护" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "车库车队规模" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "每栋建筑**车库最大车辆数**的倍率。\n" +
                    "越高 = 卡车越多。\n" +
                    "<平衡说明：太少或太多都可能损害交通。>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "工作班次容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "**工作班次容量**的倍率。\n" +
                    "卡车在返回车库前可完成的总工作量。\n" +
                    "**越高 = 返回主建筑次数越少。** 效率更高。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "修理速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "速率 = 车辆停下时每个模拟 tick 完成的工作量。\n" +
                    "即使在最高速率下，卡车仍会短暂停车+再前进；只是每次停车完成更多工作。\n" +
                    "原版中，一次停车不一定能把道路修到 100%，所以这个功能会随着时间推移变得更有帮助。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "道路磨损" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<测试功能>\n" +
                    "控制道路因**时间和交通**因素而劣化的速度。\n" +
                    "**10%** = 磨损速度慢 10×（所需维修更少）\n" +
                    "**100%** = 原版\n" +
                    "**500%** = 损坏速度快 5×（需要更多维修/卡车）\n" +
                    "游戏内工作方式：\n" +
                    "如果 m_Wear <= 2.5，则无减速。\n" +
                    "如果 m_Wear >= 17.5，则达到最大惩罚，车辆在道路上速度会降低 50%。\n" +
                    "查看道路信息视图：严重损坏的道路会显示为红色，并减慢车辆速度。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "重置道路维护" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "将所有数值恢复到 **100%**（游戏默认值 / 原版）。" },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "支持链接" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "调试 / 日志" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "当前模组版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "打开作者模组的 Paradox Mods 网站。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "在浏览器中打开社区 Discord。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "扫描报告（prefab）" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "创建用于调试的<一次性>报告。\n" +
                    "正常游玩不需要。\n" +
                    "文件位置：<ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "提示：点击<一次>；当状态显示为完成时，使用 <打开报告文件夹>。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Prefab 扫描状态" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "显示扫描状态：空闲 / 排队中 / 运行中 / 完成 / 无数据。\n" +
                    "排队中/运行中显示已用时间；完成显示耗时 + 完成时间。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "详细调试日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "将额外细节发送到 <AllTransitTrucks.log> 以便排查问题。\n" +
                    "正常游玩请**禁用**。\n" +
                    "<这只会增加日志记录，不会改变游戏数值。>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "打开日志文件夹" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "打开日志文件夹。\n" +
                    "下一步：用文本编辑器打开 <AllTransitTrucks.log>（推荐 Notepad++）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "打开报告文件夹" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "打开报告文件夹。\n" +
                    "下一步：用文本编辑器打开 <ScanReport-Prefabs.txt>（例如 Notepad++）。" },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "空闲" },
                { "PWP_SCAN_QUEUED_FMT", "排队中 ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "运行中 ({0})" },
                { "PWP_SCAN_DONE_FMT", "完成 ({0} | {1})" },
                { "PWP_SCAN_FAILED", "失败" },
                { "PWP_SCAN_FAIL_NO_CITY", "请先加载城市" },
                { "PWP_SCAN_UNKNOWN_TIME", "未知时间" },

            };
        }

        public void Unload( )
        {
        }
    }
}
