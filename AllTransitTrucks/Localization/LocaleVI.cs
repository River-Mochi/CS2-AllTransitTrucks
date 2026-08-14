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
        private readonly ATTSettings m_Setting;

        public LocaleVI(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "Giao thông công cộng" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Công nghiệp" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Công viên - Đường" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "Giới thiệu" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Tuyến giao thông (phạm vi thanh trượt trong game)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Mở rộng min/max tuyến" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Mở rộng **phạm vi** của thanh trượt số xe trên từng tuyến trong game.\n" +
                    "Các tuyến đã thử nghiệm đều có thể giảm xuống **1 xe**.\n" +
                    "**Giới hạn tối đa thay đổi**, nhưng các tuyến đã thử nghiệm cho phép ít nhất gấp 3 lần mức tối đa vanilla.\n" +
                    "Ghi chú kỹ thuật: game dùng thời gian tuyến (thời gian chạy + số điểm dừng); nên mức tối đa thay đổi theo tuyến (mod này theo logic của game, không đặt một giới hạn cố định như 200).\n" +
                    "Hoạt động với mọi loại giao thông công cộng.\n\n" +
                    "**---------------**\n" +
                    "Mẹo: nếu muốn tăng thêm một chút giới hạn tối đa của thanh trượt, hãy thêm vài điểm dừng vào tuyến.\n" +
                    "Game tự tăng mức tối đa dựa trên số điểm dừng + các yếu tố khác; thêm điểm dừng là cách dễ nhất để đẩy giới hạn lên.\n" +
                    "<Tránh xung đột>: gỡ các mod chỉnh cùng chính sách Tuyến giao thông.\n" +
                    "Tắt nếu bạn không cần tính năng này hoặc muốn dùng mod khác cho cùng việc."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Sức chứa depot (số xe tối đa mỗi depot)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Depot xe buýt" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Thay đổi số xe buýt mà mỗi **Bus Depot** có thể bảo trì/tạo ra.\n" +
                    "**100%** = vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10×.\n" +
                    "Áp dụng cho tòa nhà chính." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Depot phà" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "Số xe tối đa mỗi **Ferry Depot**.\n" +
                    "**100%** = vanilla (mặc định của game).\n" +
                    "Áp dụng cho tòa nhà chính."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Depot tàu điện ngầm" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Thay đổi số xe tàu điện ngầm mà mỗi **Subway Depot** có thể bảo trì.\n" +
                    "Áp dụng cho tòa nhà chính."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Depot taxi" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Số taxi mà mỗi **Taxi Depot** có thể bảo trì.\n" +
                    "Nếu đặt tối đa, có thể tạo ra lượng taxi quá nhiều và khá hài hước."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Depot tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Thay đổi số tram mà mỗi **Tram Depot** có thể bảo trì.\n" +
                    "Áp dụng cho tòa nhà chính." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Depot tàu hỏa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Thay đổi số tàu mà mỗi **Train Depot** có thể bảo trì.\n" +
                    "Áp dụng cho tòa nhà chính." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Đặt lại depot mặc định" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Đưa tất cả thanh trượt depot về **100%** (mặc định của game / vanilla)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Sức chứa hành khách (số người tối đa mỗi xe)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Xe buýt" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Thay đổi sức chứa **hành khách xe buýt**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Thay đổi sức chứa **hành khách tram**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Tàu hỏa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Thay đổi sức chứa **hành khách tàu hỏa**.\n" +
                    "Áp dụng cho đầu máy và các toa/phần.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Tàu điện ngầm" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Thay đổi sức chứa **hành khách tàu điện ngầm**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Tàu thủy" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Thay đổi sức chứa **tàu chở khách** (không phải tàu hàng).\n" +
                    "**100%** = số ghế vanilla (mặc định của game)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Phà" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Thay đổi sức chứa **hành khách phà**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Máy bay" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Thay đổi sức chứa **hành khách máy bay**.\n" +
                    "**10%** = 10% số ghế vanilla.\n" +
                    "**100%** = số ghế vanilla (mặc định của game).\n" +
                    "**1000%** = nhiều hơn 10× số ghế." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Gấp đôi" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Đặt mọi thanh trượt hành khách thành **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Đặt lại tất cả hành khách" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Đưa tất cả thanh trượt hành khách về **100%**\n" +
                    "(mặc định của game / vanilla)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Xe giao hàng (sức chứa hàng hóa)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Xe tải semi" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**Sức chứa xe tải semi**.\n" +
                    "**100% = 25t** (vanilla)\n" +
                    "**500% = 125t**.\n" +
                    "Bao gồm:\n" +
                    " - Xe tải semi của công nghiệp chuyên biệt (nông trại, cá, lâm nghiệp, v.v.).\n" +
                    "Ghi chú: bao gồm xe tải semi chở thư đến/từ ga hàng hóa.\n" +
                    "Không giống giao thư nội bộ địa phương."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Xe van giao hàng" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Xe van giao hàng**\n" +
                    "**100% = 4t** (vanilla)\n" +
                    "**500% = 20t**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Xe tải nguyên liệu thô" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Xe tải nguyên liệu thô** (dầu, than, quặng, đá, xe ben chở chất thải công nghiệp - dùng chung cùng loại xe tải)\n" +
                    "**100% = 20t** (vanilla)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Xe máy giao hàng" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**Xe máy giao hàng** thường chở dược phẩm đến bệnh viện/phòng khám.\n" +
                    "**100% = 0.1t** (vanilla)\n" +
                    "**500% = 0.5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Đặt lại giao hàng mặc định" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Đưa các thanh trượt giao hàng về **100%** (mặc định của game / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Tổng số xe trên mỗi cơ sở" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Tổng số xe: ga hàng hóa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Số xe hàng hóa đang hoạt động tối đa cho mỗi **cảng hàng hóa, ga tàu hàng và sân bay**.\n" +
                    "**1×** = vanilla, **5×** = nhiều hơn 5 lần." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "Điều chỉnh xe tải công nghiệp" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "Để tương thích với mod khác,\n" +
                    "- dùng TẮT nếu bạn muốn mod khác kiểm soát tổng số xe tải của cùng các công ty công nghiệp.\n" +
                    "<[x] Mặc định BẬT>.\n" +
                    "Để BẬT để dùng ba thanh trượt bên dưới và chỉnh tổng số xe tải của công ty.\n" +
                    "TẮT sẽ khôi phục ba nhóm này về mặc định của game và ẩn các thanh trượt.\n" +
                    "Nếu muốn dùng thanh trượt của mod này, hãy kiểm tra xem mod kia có tùy chọn tắt số lượng xe tải riêng không."
                     },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Tổng xe tải: khai thác" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Số xe tải tối đa cho mỗi công ty khai thác.\n" +
                    "Bao gồm nông trại, lâm nghiệp, đánh cá, dầu, quặng, than, đá, bông, chăn nuôi và rau.\n" +
                    "**1×** = vanilla, **5×** = nhiều hơn 5 lần." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "Tổng xe tải: kho" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "Số xe tải tối đa cho mỗi công ty kho.\n" +
                    "Bao gồm mọi loại tài nguyên kho có xe riêng.\n" +
                    "**1×** = vanilla, **5×** = nhiều hơn 5 lần." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "Tổng xe tải: công nghiệp" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "Số xe tải tối đa cho các công ty chế biến công nghiệp.\n" +
                    "Không bao gồm cơ sở khai thác, kho, ga hàng hóa, công ty thương mại hoặc công ty văn phòng.\n" +
                    "**1×** = vanilla, **5×** = nhiều hơn 5 lần." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Đặt lại tất cả xe công nghiệp" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Đưa các thanh trượt ga hàng hóa, khai thác, kho và công nghiệp về **1×** (giá trị vanilla).\n" +
                    "Nút điều khiển xe tải công ty giữ nguyên BẬT hoặc TẮT như đã chọn." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Bảo trì công viên" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Sức chứa ca làm" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Tăng/giảm **sức chứa ca làm** (sức chứa xe).\n" +
                    "Tổng lượng việc xe có thể làm trước khi quay về tòa nhà.\n" +
                    "Hiểu đơn giản: nhiều vật tư hơn = ở ngoài lâu hơn." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Tốc độ làm việc" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "Tăng/giảm **tốc độ làm việc của xe**.\n" +
                    "**Tốc độ** = lượng việc xe làm mỗi tick mô phỏng khi đang dừng." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Kích thước đội xe depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Số **xe tối đa** mà depot cho phép.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Đặt lại bảo trì công viên" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Đưa tất cả giá trị về **100%** (mặc định của game / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Bảo trì đường" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Kích thước đội xe depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Hệ số cho **số xe tối đa của depot** trên mỗi tòa nhà.\n" +
                    "Cao hơn = nhiều xe tải hơn.\n" +
                    "<Ghi chú cân bằng: quá ít hoặc quá nhiều đều có thể làm giao thông tệ hơn.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Sức chứa ca làm" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Tăng/giảm **sức chứa ca làm**.\n" +
                    "Tổng lượng việc xe có thể làm trước khi quay về depot.\n" +
                    "**Cao hơn = ít quay về** tòa nhà chính hơn, hiệu quả hơn." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Tốc độ sửa chữa" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "**Tốc độ** = lượng việc xe làm mỗi tick mô phỏng khi đang dừng.\n" +
                    "Xe vẫn dừng-rồi-đi rất nhanh ngay cả ở mức cao nhất; chỉ là mỗi lần dừng làm được nhiều việc hơn.\n" +
                    "Trong vanilla, một lần dừng không nhất thiết sửa đường về 100%; vì vậy tính năng này hiệu quả hơn theo thời gian.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Độ mòn đường" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Tính năng beta>\n" +
                    "Điều khiển tốc độ đường xuống cấp do **thời gian và giao thông**.\n" +
                    "**10%** = mòn chậm hơn 10× (ít cần sửa hơn)\n" +
                    "**100%** = vanilla\n" +
                    "**500%** = hư hại nhanh hơn 5× (cần nhiều sửa chữa/xe tải hơn)\n" +
                    "Cách hoạt động trong game:\n" +
                    "Nếu m_Wear <= 2.5, không bị chậm.\n" +
                    "Nếu m_Wear >= 17.5, phạt tối đa, xe chạy chậm hơn 50% trên đường.\n" +
                    "Xem Roads Infoview: hiển thị màu đỏ trên đường hư nặng làm xe chạy chậm."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Đặt lại bảo trì đường" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Đưa tất cả giá trị về **100%** (mặc định của game / vanilla)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Liên kết hỗ trợ" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Gỡ lỗi / Ghi log" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Phiên bản mod hiện tại." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Mở trang Paradox Mods của tác giả." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Mở Discord cộng đồng trong trình duyệt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Báo cáo quét prefab" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Tạo báo cáo <một lần> để gỡ lỗi.\n" +
                    "Không cần cho gameplay bình thường.\n" +
                    "Vị trí file: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Mẹo: bấm <một lần>; nếu trạng thái hiện Hoàn tất, dùng <Mở thư mục báo cáo>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Trạng thái quét prefab" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Hiển thị trạng thái quét: Đang chờ / Đã xếp hàng / Đang chạy / Hoàn tất / Không có dữ liệu.\n" +
                    "Đã xếp hàng/Đang chạy hiển thị thời gian đã trôi qua; Hoàn tất hiển thị thời lượng + thời điểm hoàn tất." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Log gỡ lỗi chi tiết" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Ghi thêm chi tiết vào <AllTransitTrucks.log> để xử lý sự cố.\n" +
                    "**Tắt** khi chơi bình thường.\n" +
                    "<Tùy chọn này chỉ tăng ghi log và không thay đổi giá trị gameplay.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Mở thư mục log" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Mở thư mục logs.\n" +
                    "Tiếp theo: mở <AllTransitTrucks.log> bằng trình soạn thảo văn bản (khuyên dùng Notepad++)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Mở thư mục báo cáo" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Mở thư mục báo cáo.\n" +
                    "Tiếp theo: mở <ScanReport-Prefabs.txt> bằng trình soạn thảo văn bản (ví dụ Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Đang chờ" },
                { "PWP_SCAN_QUEUED_FMT", "Đã xếp hàng ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Đang chạy ({0})" },
                { "PWP_SCAN_DONE_FMT", "Hoàn tất ({0} | {1})" },
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
