// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleKO.cs
// Korean (ko-KR) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleKO(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "대중교통" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "산업" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "공원-도로" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "정보" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "교통 노선 (게임 내 슬라이더 범위)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "교통 노선 최소/최대 확장" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "각 노선의 게임 내 교통 노선 슬라이더 **범위**를 확장합니다.\n" +
                    "테스트된 모든 노선에서 **최저 1대**까지 내려갑니다.\n" +
                    "**최대 한도는 가변적**이지만, 테스트된 노선은 바닐라 최대값의 최소 3배까지 허용합니다.\n" +
                    "기술 참고: 게임은 노선 시간(주행 시간 + 정류장 수)을 사용하므로 최대값이 가변적입니다(이 모드는 게임 로직을 따르므로 200 같은 고정 최대값은 설정하지 않습니다).\n" +
                    "모든 교통수단에 적용됩니다: 버스, 페리, 트램, 기차, 지하철, 선박, 비행기.\n\n" +
                    "**---------------**\n" +
                    "팁: 슬라이더의 최대 끝값을 조금 더 올리고 싶다면 노선에 정류장을 몇 개 추가하세요.\n" +
                    "게임은 추가된 정류장 + 여러 요소를 기준으로 최대값을 자동 증가시킵니다. 정류장 추가는 간단한 플레이어 조정입니다.\n" +
                    "<충돌 방지>: 같은 교통 노선 정책을 수정하는 모드는 제거하세요.\n" +
                    "이 기능이 필요 없거나 같은 기능의 다른 모드를 쓰기 위해 꺼야 한다면 비활성화하세요."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "차고 용량 (차고당 최대 차량 수)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "버스 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "각 **버스 차고**가 유지/출고할 수 있는 버스 수를 변경합니다.\n" +
                    "**100%** = 바닐라 (게임 기본값).\n" +
                    "**1000%** = 10배.\n" +
                    "기본 건물에 적용됩니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "페리 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**페리 차고** 건물당 최대 차량 수입니다.\n" +
                    "**100%** = 바닐라 (게임 기본값).\n" +
                    "기본 건물에 적용됩니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "지하철 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "각 **지하철 차고**가 유지할 수 있는 지하철 차량 수를 변경합니다.\n" +
                    "기본 건물에 적용됩니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "택시 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "각 **택시 차고**가 유지할 수 있는 택시 수입니다.\n" +
                    "최대로 설정하면 택시가 과하게 많아져 우스꽝스러울 수 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "트램 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "각 **트램 차고**가 유지할 수 있는 트램 수를 변경합니다.\n" +
                    "기본 건물에 적용됩니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "기차 차고" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "각 **기차 차고**가 유지할 수 있는 기차 수를 변경합니다.\n" +
                    "기본 건물에 적용됩니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "차고 기본값 리셋" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "모든 차고 슬라이더를 **100%** (게임 기본값 / 바닐라)로 되돌립니다." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "승객 수용량 (차량당 최대 인원)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "버스" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "**버스 승객** 수용량을 변경합니다.\n" +
                    "**10%** = 바닐라 좌석 수의 10%.\n" +
                    "**100%** = 바닐라 좌석 수 (게임 기본값).\n" +
                    "**1000%** = 좌석 수 10배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "트램" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "**트램 승객** 수용량을 변경합니다.\n" +
                    "**10%** = 바닐라 좌석 수의 10%.\n" +
                    "**100%** = 바닐라 좌석 수 (게임 기본값).\n" +
                    "**1000%** = 좌석 수 10배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "기차" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "**기차 승객** 수용량을 변경합니다.\n" +
                    "엔진과 객차 구간에 적용됩니다.\n" +
                    "**10%** = 바닐라 좌석 수의 10%.\n" +
                    "**100%** = 바닐라 좌석 수 (게임 기본값).\n" +
                    "**1000%** = 좌석 수 10배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "지하철" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "**지하철 승객** 수용량을 변경합니다.\n" +
                    "**10%** = 바닐라 좌석 수의 10%.\n" +
                    "**100%** = 바닐라 좌석 수 (게임 기본값).\n" +
                    "**1000%** = 좌석 수 10배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "선박" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "**여객선** 수용량을 변경합니다 (화물선 제외).\n" +
                    "**100%** = 바닐라 좌석 수 (게임 기본값)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "페리" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "**페리 승객** 수용량을 변경합니다.\n" +
                    "**10%** = 바닐라 좌석 수의 10%.\n" +
                    "**100%** = 바닐라 좌석 수 (게임 기본값).\n" +
                    "**1000%** = 좌석 수 10배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "비행기" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "**비행기 승객** 수용량을 변경합니다.\n" +
                    "**10%** = 바닐라 좌석 수의 10%.\n" +
                    "**100%** = 바닐라 좌석 수 (게임 기본값).\n" +
                    "**1000%** = 좌석 수 10배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "두 배" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "모든 승객 슬라이더를 **200%**로 설정합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "모든 승객 리셋" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "모든 승객 슬라이더를 **100%**로 되돌립니다\n" +
                    "(게임 기본값 / 바닐라)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "배송 차량 (화물 용량)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "세미트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**세미트럭 용량**.\n" +
                    "**100% = 25t** (바닐라)\n" +
                    "**500% = 125t**.\n" +
                    "포함:\n" +
                    " - 특화 산업 세미트럭 (농장, 어업, 임업 등).\n" +
                    "참고: 화물역으로 우편을 운반하는 세미트럭도 포함됩니다.\n" +
                    "이것은 지역 우편 배달과는 다릅니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "배송 밴" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**배송 밴**\n" +
                    "**100% = 4t** (바닐라)\n" +
                    "**500% = 20t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "원자재 트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**원자재 트럭** (석유, 석탄, 광석, 석재, 산업 폐기물용 덤프트럭 - 같은 공유 트럭 유형)\n" +
                    "**100% = 20t** (바닐라)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "배송 오토바이" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**오토바이 배송**은 보통 약품을 병원/클리닉으로 운반합니다.\n" +
                    "**100% = 0.1t** (바닐라)\n" +
                    "**500% = 0.5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "배송 기본값 리셋" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "배송 슬라이더를 **100%** (게임 기본값 / 바닐라)로 되돌립니다." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "시설당 총 차량 수" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "총 차량 수: 화물역" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "각 **화물 항구, 화물 철도 터미널, 공항**의 최대 활성 화물 차량 수입니다.\n" +
                    "**1×** = 바닐라, **5×** = 5배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "산업: 총 트럭 수 조정" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "ATT가 채취 시설, 창고, 산업 가공 회사의 트럭 한도를 제어합니다.\n" +
                    "아래의 세 회사 트럭 슬라이더를 사용하려면 켜 둡니다.\n" +
                    "끄면 이 세 범주를 한 번 바닐라 값으로 복원하고 슬라이더를 숨기며, ATT가 트럭 수를 변경하지 않습니다.\n" +
                    "다른 모드가 같은 회사 차량을 제어할 때는 끄세요.\n" +
                    "화물역 차량과 배송 차량의 화물 용량에는 영향을 주지 않습니다.\n" +
                    "<[x] 기본값 켜짐>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "총 트럭 수: 채취 시설" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "각 채취 회사의 최대 트럭 수입니다.\n" +
                    "농장, 임업, 어업, 석유, 광석, 석탄, 석재, 면화, 축산, 채소를 포함합니다.\n" +
                    "**1×** = 바닐라, **5×** = 5배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "총 트럭 수: 창고" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "각 창고 회사의 최대 트럭 수입니다.\n" +
                    "자체 차량이 있는 모든 창고 자원 유형을 포함합니다.\n" +
                    "**1×** = 바닐라, **5×** = 5배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "총 트럭 수: 산업" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "산업 가공 회사의 최대 트럭 수입니다.\n" +
                    "채취 시설, 창고, 화물역, 상업 회사 또는 사무실 회사는 포함하지 않습니다.\n" +
                    "**1×** = 바닐라, **5×** = 5배." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "모든 산업 차량 리셋" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "화물역, 채취 시설, 창고, 산업 슬라이더를 **1×** (바닐라 값)로 되돌립니다.\n" +
                    "회사 트럭 제어 토글은 선택한 켜짐 또는 꺼짐 상태를 유지합니다." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "공원 유지관리" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "작업 교대 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "**작업 교대 용량** (차량 용량)에 대한 배수입니다.\n" +
                    "트럭이 건물로 돌아가기 전에 수행할 수 있는 총 작업량입니다.\n" +
                    "쉽게 말해: 보급이 많을수록 더 오래 현장에 머뭅니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "차량 작업률" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "**차량 작업률**에 대한 배수입니다.\n" +
                    "작업률 = 정차 중 시뮬레이션 tick당 수행하는 작업량." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "차고 플릿 크기" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "차고 건물의 **최대 차량 수**에 대한 배수입니다.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "공원 유지관리 리셋" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "모든 값을 **100%** (게임 기본값 / 바닐라)로 되돌립니다." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "도로 유지관리" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "차고 플릿 크기" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "건물당 **차고 최대 차량 수**에 대한 배수입니다.\n" +
                    "높을수록 = 트럭 증가.\n" +
                    "<밸런스 참고: 너무 적거나 너무 많으면 교통에 악영향을 줄 수 있습니다.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "작업 교대 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "**작업 교대 용량**에 대한 배수입니다.\n" +
                    "트럭이 차고로 돌아가기 전에 수행할 수 있는 총 작업량입니다.\n" +
                    "**높을수록 = 복귀 횟수 감소**. 더 효율적입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "수리율" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "작업률 = 정차 중 시뮬레이션 tick당 수행하는 작업량.\n" +
                    "최고 수리율에서도 트럭은 잠깐 멈췄다 가는 동작을 합니다. 단지 한 번 멈출 때 더 많은 작업을 수행합니다.\n" +
                    "바닐라에서는 한 번의 정차로 도로가 반드시 100% 수리되는 것은 아니므로, 이 기능은 시간이 지날수록 더 유용해집니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "도로 마모" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<베타 기능>\n" +
                    "**시간과 교통량** 요인으로 도로가 얼마나 빨리 손상되는지 제어합니다.\n" +
                    "**10%** = 마모 10× 느림 (수리 필요 감소)\n" +
                    "**100%** = 바닐라\n" +
                    "**500%** = 손상 5× 빠름 (더 많은 수리/트럭 필요)\n" +
                    "게임 내 작동 방식:\n" +
                    "m_Wear <= 2.5 이면 감속 없음.\n" +
                    "m_Wear >= 17.5 이면 최대 페널티, 도로 위 차량 속도가 50% 느려집니다.\n" +
                    "도로 인포뷰 참조: 심하게 손상된 도로는 빨간색으로 표시되며 차량을 감속시킵니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "도로 유지관리 리셋" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "모든 값을 **100%** (게임 기본값 / 바닐라)로 되돌립니다." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "정보" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "지원 링크" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "디버그 / 로깅" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "현재 모드 버전입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "작성자의 모드가 있는 Paradox Mods 웹사이트를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "커뮤니티 Discord를 브라우저에서 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "스캔 보고서 (prefab)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "디버깅용 <1회성> 보고서를 생성합니다.\n" +
                    "일반 플레이에는 필요하지 않습니다.\n" +
                    "파일 위치: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "팁: <한 번> 클릭하고, 상태가 완료로 표시되면 <보고서 폴더 열기>를 사용하세요." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Prefab 스캔 상태" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "스캔 상태 표시: 대기 중 / 대기열 / 실행 중 / 완료 / 데이터 없음.\n" +
                    "대기열/실행 중은 경과 시간을 표시하고, 완료는 소요 시간 + 완료 시각을 표시합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "상세 디버그 로그" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "문제 해결용 추가 세부 정보를 <AllTransitTrucks.log> 로 보냅니다.\n" +
                    "일반 플레이에서는 **비활성화**하세요.\n" +
                    "<이 옵션은 로깅만 늘리며 게임플레이 값은 변경하지 않습니다.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "로그 폴더 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "로그 폴더를 엽니다.\n" +
                    "다음: 텍스트 편집기로 <AllTransitTrucks.log> 를 여세요 (Notepad++ 권장)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "보고서 폴더 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "보고서 폴더를 엽니다.\n" +
                    "다음: 텍스트 편집기로 <ScanReport-Prefabs.txt> 를 여세요 (예: Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "대기 중" },
                { "PWP_SCAN_QUEUED_FMT", "대기열 ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "실행 중 ({0})" },
                { "PWP_SCAN_DONE_FMT", "완료 ({0} | {1})" },
                { "PWP_SCAN_FAILED", "실패" },
                { "PWP_SCAN_FAIL_NO_CITY", "먼저 도시 로드" },
                { "PWP_SCAN_UNKNOWN_TIME", "알 수 없는 시간" },

            };
        }

        public void Unload( )
        {
        }
    }
}
