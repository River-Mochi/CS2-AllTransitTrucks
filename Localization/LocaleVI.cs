// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// Vietnamese (vi-VN) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleVI(Setting setting)
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

                // Tabs (match Setting.cs tab ids)
                { m_Setting.GetOptionTabLocaleID(Setting.PublicTransitTab), "Giao thông công cộng" },
                { m_Setting.GetOptionTabLocaleID(Setting.IndustryTab),      "Công nghiệp" },
                { m_Setting.GetOptionTabLocaleID(Setting.ParksRoadsTab),    "Công viên - Đường" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),         "Giới thiệu" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(Setting.LineVehiclesGroup), "Tuyến giao thông (phạm vi thanh trượt trong game)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableLineVehicleCountTuner)), "Mở rộng min/max tuyến" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableLineVehicleCountTuner)),
                    "Tăng **phạm vi** của thanh trượt số xe trên từng tuyến trong game.\n" +
                    "**Có thể thấp tới (1)** trên các tuyến đã thử nghiệm.\n" +
                    "**Giới hạn tối đa thay đổi**; nhưng đều cao hơn vanilla ít nhất 3x.\n" +
                    "Ghi chú kỹ thuật: game dùng thời gian tuyến (thời gian chạy + số điểm dừng); nên mức tối đa thay đổi theo tuyến (mod này theo logic của game, không đặt một giới hạn cố định như 200).\n" +
                    "Hoạt động với mọi loại giao thông công cộng.\n\n" +
                    "**---------------**\n" +
                    "Mẹo: nếu muốn tăng thêm một chút giới hạn tối đa của thanh trượt, hãy thêm vài điểm dừng vào tuyến.\n" +
                    "Game tự tăng mức tối đa dựa trên số điểm dừng + các yếu tố khác; thêm điểm dừng là cách dễ nhất để đẩy giới hạn lên.\n" +
                    "<Tránh xung đột>: gỡ các mod chỉnh cùng Transit Line policy.\n" +
                    "Tắt nếu bạn không cần tính năng này hoặc muốn dùng mod khác cho cùng việc."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(Setting.DepotGroup), "Sức chứa depot (số xe tối đa mỗi depot)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusDepotScalar)), "Depot xe buýt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusDepotScalar)),
                    "Thay đổi số xe buýt mà mỗi **Bus Depot** có thể bảo trì/tạo ra.\n" +
                    "**100%** = vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10×.\n" +
                    "Áp dụng cho tòa nhà chính." },

                 { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryDepotScalar)), "Depot phà" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryDepotScalar)),
                    "Số xe tối đa mỗi **Ferry Depot**.\n" +
                    "**100%** = vanilla (mặc định của game).\n" +
                    "Áp dụng cho tòa nhà chính."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayDepotScalar)), "Depot tàu điện ngầm" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayDepotScalar)),
                    "Thay đổi số xe tàu điện ngầm mà mỗi **Subway Depot** có thể bảo trì.\n" +
                    "Áp dụng cho tòa nhà chính."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxiDepotScalar)), "Depot taxi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxiDepotScalar)),
                    "Số taxi mà mỗi **Taxi Depot** có thể bảo trì.\n" +
                    "Nếu đặt tối đa, có thể tạo ra lượng taxi quá nhiều và khá hài hước."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramDepotScalar)), "Depot tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramDepotScalar)),
                    "Thay đổi số tram mà mỗi **Tram Depot** có thể bảo trì.\n" +
                    "Áp dụng cho tòa nhà chính." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDepotScalar)), "Depot tàu hỏa" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDepotScalar)),
                    "Thay đổi số tàu mà mỗi **Train Depot** có thể bảo trì.\n" +
                    "Áp dụng cho tòa nhà chính." },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDepotToVanillaButton)), "Đặt lại depot mặc định" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDepotToVanillaButton)),
                    "Đưa tất cả thanh trượt depot về **100%** (mặc định của game / vanilla)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(Setting.PassengerGroup), "Sức chứa hành khách (số người tối đa mỗi xe)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BusPassengerScalar)), "Xe buýt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BusPassengerScalar)),
                    "Thay đổi sức chứa **hành khách xe buýt**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TramPassengerScalar)), "Tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TramPassengerScalar)),
                    "Thay đổi sức chứa **hành khách tram**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainPassengerScalar)), "Tàu hỏa" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainPassengerScalar)),
                    "Thay đổi sức chứa **hành khách tàu hỏa**.\n" +
                    "Áp dụng cho đầu máy và các toa/phần.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SubwayPassengerScalar)), "Tàu điện ngầm" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SubwayPassengerScalar)),
                    "Thay đổi sức chứa **hành khách tàu điện ngầm**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipPassengerScalar)), "Tàu thủy" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipPassengerScalar)),
                    "Thay đổi sức chứa **tàu chở khách** (không phải tàu hàng).\n" +
                    "**100%** = số ghế vanilla (mặc định của game)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FerryPassengerScalar)), "Phà" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FerryPassengerScalar)),
                    "Thay đổi sức chứa **hành khách phà**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirplanePassengerScalar)), "Máy bay" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AirplanePassengerScalar)),
                    "Thay đổi sức chứa **hành khách máy bay**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DoublePassengersButton)), "Gấp đôi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DoublePassengersButton)),
                    "Đặt mọi thanh trượt hành khách thành **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetPassengerToVanillaButton)), "Đặt lại tất cả hành khách" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetPassengerToVanillaButton)),
                    "Đưa tất cả thanh trượt hành khách về **100%**\n" +
                    "(mặc định của game / vanilla)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(Setting.DeliveryGroup), "Xe giao hàng (sức chứa hàng hóa)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiTruckCargoScalar)), "Xe tải semi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiTruckCargoScalar)),
                    "Sức chứa **xe tải semi**.\n" +
                    "**100% = 25t** (vanilla)\n" +
                    "**500% = 125t**.\n" +
                    "Bao gồm:\n" +
                    " - Xe tải semi của công nghiệp chuyên biệt (nông trại, cá, lâm nghiệp, v.v.).\n" +
                    "Ghi chú: bao gồm xe tải semi chở thư đến/từ ga hàng hóa.\n" +
                    "Không giống giao thư nội bộ địa phương."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeliveryVanCargoScalar)), "Xe van giao hàng" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DeliveryVanCargoScalar)),
                    "**Xe van giao hàng**\n" +
                    "**100% = 4t** (vanilla)\n" +
                    "**500% = 20t**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CoalTruckScalar)), "Xe tải nguyên liệu thô" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CoalTruckScalar)),
                    "**Xe tải nguyên liệu thô** (dầu, than, quặng, đá, xe ben chở chất thải công nghiệp - dùng chung cùng loại xe tải)\n" +
                    "**100% = 20t** (vanilla)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MotorbikeDeliveryCargoScalar)), "Xe máy giao hàng" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MotorbikeDeliveryCargoScalar)),
                    "**Xe máy giao hàng** thường chở dược phẩm đến bệnh viện/phòng khám.\n" +
                    "**100% = 0.1t** (vanilla)\n" +
                    "**500% = 0.5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetDeliveryToVanillaButton)), "Đặt lại giao hàng mặc định" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetDeliveryToVanillaButton)),
                    "Đưa các thanh trượt giao hàng về **100%** (mặc định của game / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(Setting.CargoStationsGroup), "Đội xe hàng hóa (cảng, tàu, sân bay)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CargoStationMaxTrucksScalar)), "Đội xe tối đa ga hàng hóa" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CargoStationMaxTrucksScalar)),
                    "Thay đổi số phương tiện vận chuyển tối đa đang hoạt động của **ga vận tải hàng hóa**.\n" +
                    "**1×** = vanilla, **5×** = nhiều hơn 5×." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ExtractorMaxTrucksScalar)), "Đội xe khai thác" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ExtractorMaxTrucksScalar)),
                    "Thay đổi **số xe tải tối đa** cho cơ sở khai thác.\n" +
                    "(nông trại, đánh cá, lâm nghiệp, quặng, dầu, than, đá).\n" +
                    "**1×** = vanilla\n" +
                    "**5×** = nhiều hơn 5 lần.\n" +
                    "Vanilla thường cho phép 5 xe tải mỗi cơ sở khai thác."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetCargoStationsToVanillaButton)), "Đặt lại đội xe hàng + khai thác" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetCargoStationsToVanillaButton)),
                    "Đưa hệ số ga hàng hóa + cơ sở khai thác về **1×** (mặc định của game / vanilla)." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(Setting.ParkMaintenanceGroup), "Bảo trì công viên" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceVehicleCapacityScalar)), "Sức chứa ca làm" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkMaintenanceVehicleCapacityScalar)),
                    "Tăng/giảm **sức chứa ca làm** (sức chứa xe).\n" +
                    "Tổng lượng việc xe có thể làm trước khi quay về tòa nhà.\n" +
                    "Hiểu đơn giản: nhiều vật tư hơn = ở ngoài lâu hơn." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceVehicleRateScalar)), "Tốc độ làm việc" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkMaintenanceVehicleRateScalar)),
                    "Tăng/giảm **tốc độ làm việc của xe**.\n" +
                    "**Rate** = lượng việc xe làm mỗi tick mô phỏng khi đang dừng." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceDepotScalar)), "Kích thước đội xe depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkMaintenanceDepotScalar)),
                    "Số **xe tối đa** mà depot cho phép.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetParkMaintenanceToVanillaButton)), "Đặt lại bảo trì công viên" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetParkMaintenanceToVanillaButton)),
                    "Đưa tất cả giá trị về **100%** (mặc định của game / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(Setting.RoadMaintenanceGroup), "Bảo trì đường" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceDepotScalar)), "Kích thước đội xe depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadMaintenanceDepotScalar)),
                    "Hệ số cho **số xe tối đa của depot** trên mỗi tòa nhà.\n" +
                    "Cao hơn = nhiều xe tải hơn.\n" +
                    "<Ghi chú cân bằng: quá ít hoặc quá nhiều đều có thể làm giao thông tệ hơn.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceVehicleCapacityScalar)), "Sức chứa ca làm" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadMaintenanceVehicleCapacityScalar)),
                    "Tăng/giảm **sức chứa ca làm**.\n" +
                    "Tổng lượng việc xe có thể làm trước khi quay về depot.\n" +
                    "**Cao hơn = ít quay về** tòa nhà chính hơn, hiệu quả hơn." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceVehicleRateScalar)), "Tốc độ sửa chữa" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadMaintenanceVehicleRateScalar)),
                    "**Rate** = lượng việc xe làm mỗi tick mô phỏng khi đang dừng.\n" +
                    "Xe vẫn dừng-rồi-đi rất nhanh ngay cả ở mức cao nhất; chỉ là mỗi lần dừng làm được nhiều việc hơn.\n" +
                    "Trong vanilla, một lần dừng không nhất thiết sửa đường về 100%; vì vậy tính năng này hiệu quả hơn theo thời gian.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadWearScalar)), "Độ mòn đường" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadWearScalar)),
                    "<Tính năng beta>\n" +
                    "Điều khiển tốc độ đường xuống cấp do **thời gian và giao thông**.\n" +
                    "**10%** = mòn chậm hơn 10× (ít cần sửa hơn)\n" +
                    "**100%** = vanilla\n" +
                    "**500%** = hư hại nhanh hơn 5× (cần nhiều sửa chữa/xe tải hơn)\n" +
                    "Cách hoạt động trong game:\n" +
                    "Nếu m_Wear <= 2.5 factor, không bị chậm.\n" +
                    "Nếu m_Wear >= 17.5, phạt tối đa, xe chạy chậm hơn 50% trên đường.\n" +
                    "Xem Roads Infoview: hiển thị màu đỏ trên đường hư nặng làm xe chạy chậm."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetRoadMaintenanceToVanillaButton)), "Đặt lại bảo trì đường" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetRoadMaintenanceToVanillaButton)),
                    "Đưa tất cả giá trị về **100%** (mặc định của game / vanilla)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup), "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Liên kết hỗ trợ" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup), "Gỡ lỗi / Ghi log" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Phiên bản mod hiện tại." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)), "Mở trang Paradox Mods của tác giả." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Mở Discord cộng đồng trong trình duyệt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RunPrefabScanButton)), "Báo cáo quét prefab" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RunPrefabScanButton)),
                    "Tạo báo cáo <một lần> để gỡ lỗi.\n" +
                    "Không cần cho gameplay bình thường.\n" +
                    "Vị trí file: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Mẹo: bấm <một lần>; nếu trạng thái hiện Done, dùng <Mở thư mục báo cáo>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrefabScanStatus)), "Trạng thái quét prefab" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrefabScanStatus)),
                    "Hiển thị trạng thái quét: Idle / Queued / Running / Done / No Data.\n" +
                    "Queued/Running hiển thị thời gian đã chạy; Done hiển thị thời lượng + thời điểm hoàn tất." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Log gỡ lỗi chi tiết" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Ghi thêm chi tiết vào <AllTransitTrucks.log> để xử lý sự cố.\n" +
                    "**Tắt** khi chơi bình thường.\n" +
                    "<Tùy chọn này chỉ tăng ghi log và không thay đổi giá trị gameplay.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "Mở thư mục log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "Mở thư mục logs.\n" +
                    "Tiếp theo: mở <AllTransitTrucks.log> bằng trình soạn thảo văn bản (khuyên dùng Notepad++)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenReportButton)), "Mở thư mục báo cáo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenReportButton)),
                    "Mở thư mục báo cáo.\n" +
                    "Tiếp theo: mở <ScanReport-Prefabs.txt> bằng trình soạn thảo văn bản (ví dụ Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Idle" },
                { "PWP_SCAN_QUEUED_FMT", "Queued ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Running ({0})" },
                { "PWP_SCAN_DONE_FMT", "Done ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Thất bại" },
                { "PWP_SCAN_FAIL_NO_CITY", "Hãy tải thành phố trước" },
                { "PWP_SCAN_UNKNOWN_TIME", "không rõ thời gian" },

            };
        }

        public void Unload( )
        {
        }
    }
}
