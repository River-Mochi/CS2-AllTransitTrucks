// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTH.cs
// Thai (th-TH) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleTH : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleTH(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "ขนส่งสาธารณะ" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "อุตสาหกรรม" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "เกี่ยวกับ" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "เส้นทางขนส่ง (ช่วงตัวเลื่อนในเกม)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "ขยายค่าต่ำสุด/สูงสุดของจำนวนรถในเส้นทาง" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "ขยาย **ช่วง** ของตัวเลื่อนจำนวนรถในเส้นทางสำหรับแต่ละเส้นทาง\n" +
                    "ลดได้ถึง **1 คัน** ในทุกเส้นทางที่ทดสอบ\n" +
                    "**ค่าสูงสุดแตกต่างกัน** แต่เส้นทางที่ทดสอบเพิ่มได้อย่างน้อย 3 เท่าของค่าสูงสุดเดิมของเกม\n" +
                    "ข้อมูลเทคนิค: เกมใช้เวลาของเส้นทาง (เวลาขับ + จำนวนป้าย) จึงทำให้ค่าสูงสุดเปลี่ยนได้ ม็อดนี้ใช้ตรรกะเดียวกับเกมและไม่ตั้งค่าสูงสุดตายตัว เช่น 200\n" +
                    "ใช้ได้กับขนส่งสาธารณะทุกประเภท\n\n" +
                    "**---------------**\n" +
                    "เคล็ดลับ: ถ้าต้องการเพิ่มค่าสูงสุดของตัวเลื่อนอีกเล็กน้อย ให้เพิ่มป้ายในเส้นทาง\n" +
                    "เกมจะเพิ่มค่าสูงสุดอัตโนมัติตามจำนวนป้ายและปัจจัยอื่น การเพิ่มป้ายจึงเป็นวิธีง่าย ๆ\n" +
                    "<หลีกเลี่ยงม็อดชนกัน>: เอาม็อดอื่นที่แก้นโยบายเส้นทางขนส่งเดียวกันออก\n" +
                    "ปิดได้ถ้าไม่ต้องใช้ หรือถ้าต้องการใช้ม็อดอื่นที่ทำงานแบบเดียวกัน"
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "ความจุศูนย์ (จำนวนรถสูงสุดต่อศูนย์)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "ศูนย์รถบัส" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "เปลี่ยนจำนวนรถบัสที่แต่ละ **ศูนย์รถบัส** สามารถดูแล/ปล่อยออกมาได้\n" +
                    "**100%** = ค่าเริ่มต้นของเกม\n" +
                    "**1000%** = มากขึ้น 10 เท่า\n" +
                    "ใช้กับอาคารหลัก" },

                 { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "ศูนย์เรือเฟอร์รี" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "จำนวนเรือสูงสุดต่อ **ศูนย์เรือเฟอร์รี**\n" +
                    "**100%** = ค่าเริ่มต้นของเกม\n" +
                    "ใช้กับอาคารหลัก"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "ศูนย์รถไฟใต้ดิน" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "เปลี่ยนจำนวนรถไฟใต้ดินที่แต่ละ **ศูนย์รถไฟใต้ดิน** สามารถดูแลได้\n" +
                    "ใช้กับอาคารหลัก"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "ศูนย์แท็กซี่" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "จำนวนแท็กซี่ที่แต่ละ **ศูนย์แท็กซี่** สามารถดูแลได้\n" +
                    "ถ้าตั้งสูงสุด อาจมีแท็กซี่เยอะจนดูตลก"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "ศูนย์รถราง" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "เปลี่ยนจำนวนรถรางที่แต่ละ **ศูนย์รถราง** สามารถดูแลได้\n" +
                    "ใช้กับอาคารหลัก" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "ศูนย์รถไฟ" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "เปลี่ยนจำนวนรถไฟที่แต่ละ **ศูนย์รถไฟ** สามารถดูแลได้\n" +
                    "ใช้กับอาคารหลัก" },


                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "รีเซ็ตศูนย์เป็นค่าเริ่มต้น" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "ตั้งตัวเลื่อนศูนย์ทั้งหมดกลับเป็น **100%** (ค่าเริ่มต้นของเกม)" },

                // Service / Fuel Range
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ServiceFuelRangeGroup), "ระยะบริการ / เชื้อเพลิง" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShowServiceFuelRange)), "แสดงระยะบริการ/เติมเชื้อเพลิง" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShowServiceFuelRange)),
                    "แสดงตัวเลื่อนระยะทั้งสี่ด้านล่าง การซ่อนไม่ได้รีเซ็ตค่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusServiceFuelRangeScalar)), "รถบัส" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusServiceFuelRangeScalar)),
                    "ระยะทางก่อนที่รถบัสต้องเข้าบริการ/เติมเชื้อเพลิง\n" +
                    "**50%** = ระยะลดครึ่งหนึ่ง ต้องกลับเข้าบริการบ่อยขึ้น\n" +
                    "**100%** = ค่าเริ่มต้นของเกม\n" +
                    "**500%** = ระยะไกลขึ้น 5 เท่า\n" +
                    "รถบัสเชื้อเพลิงและรถบัสไฟฟ้ายังคงใช้ระยะพื้นฐานของตัวเอง" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramServiceFuelRangeScalar)), "รถราง" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramServiceFuelRangeScalar)),
                    "ระยะทางก่อนที่รถรางต้องเข้าบริการ\n" +
                    "**50%** = ระยะลดครึ่งหนึ่ง ต้องกลับเข้าบริการบ่อยขึ้น\n" +
                    "**100%** = ค่าเริ่มต้นของเกม\n" +
                    "**500%** = ระยะไกลขึ้น 5 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainServiceFuelRangeScalar)), "รถไฟ" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainServiceFuelRangeScalar)),
                    "ระยะทางก่อนที่รถไฟต้องเข้าบริการ/เติมเชื้อเพลิง\n" +
                    "**50%** = ระยะลดครึ่งหนึ่ง ต้องกลับเข้าบริการบ่อยขึ้น\n" +
                    "**100%** = ค่าเริ่มต้นของเกม\n" +
                    "**500%** = ระยะไกลขึ้น 5 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayServiceFuelRangeScalar)), "รถไฟใต้ดิน" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayServiceFuelRangeScalar)),
                    "ระยะทางก่อนที่รถไฟใต้ดินต้องเข้าบริการ\n" +
                    "**50%** = ระยะลดครึ่งหนึ่ง ต้องกลับเข้าบริการบ่อยขึ้น\n" +
                    "**100%** = ค่าเริ่มต้นของเกม\n" +
                    "**500%** = ระยะไกลขึ้น 5 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetServiceFuelRangeToVanillaButton)), "รีเซ็ตระยะบริการ/เชื้อเพลิง" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetServiceFuelRangeToVanillaButton)),
                    "ตั้งตัวเลื่อนระยะทั้งสี่กลับเป็น **100%** (ค่าเริ่มต้นของเกม)" },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "ความจุผู้โดยสาร (สูงสุดต่อคัน)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "รถบัส" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "เปลี่ยนความจุ **ผู้โดยสารรถบัส**\n" +
                    "**10%** = 10% ของจำนวนที่นั่งเดิม\n" +
                    "**100%** = จำนวนที่นั่งเดิมของเกม\n" +
                    "**1000%** = ที่นั่งมากขึ้น 10 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "รถราง" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "เปลี่ยนความจุ **ผู้โดยสารรถราง**\n" +
                    "**10%** = 10% ของจำนวนที่นั่งเดิม\n" +
                    "**100%** = จำนวนที่นั่งเดิมของเกม\n" +
                    "**1000%** = ที่นั่งมากขึ้น 10 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "รถไฟ" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "เปลี่ยนความจุ **ผู้โดยสารรถไฟ**\n" +
                    "ใช้กับหัวรถจักรและตู้รถไฟ\n" +
                    "**10%** = 10% ของจำนวนที่นั่งเดิม\n" +
                    "**100%** = จำนวนที่นั่งเดิมของเกม\n" +
                    "**1000%** = ที่นั่งมากขึ้น 10 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "รถไฟใต้ดิน" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "เปลี่ยนความจุ **ผู้โดยสารรถไฟใต้ดิน**\n" +
                    "**10%** = 10% ของจำนวนที่นั่งเดิม\n" +
                    "**100%** = จำนวนที่นั่งเดิมของเกม\n" +
                    "**1000%** = ที่นั่งมากขึ้น 10 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "เรือ" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "เปลี่ยนความจุ **เรือโดยสาร** (ไม่รวมเรือสินค้า)\n" +
                    "**100%** = จำนวนที่นั่งเดิมของเกม" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "เรือเฟอร์รี" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "เปลี่ยนความจุ **ผู้โดยสารเรือเฟอร์รี**\n" +
                    "**10%** = 10% ของจำนวนที่นั่งเดิม\n" +
                    "**100%** = จำนวนที่นั่งเดิมของเกม\n" +
                    "**1000%** = ที่นั่งมากขึ้น 10 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "เครื่องบิน" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "เปลี่ยนความจุ **ผู้โดยสารเครื่องบิน**\n" +
                    "**10%** = 10% ของจำนวนที่นั่งเดิม\n" +
                    "**100%** = จำนวนที่นั่งเดิมของเกม\n" +
                    "**1000%** = ที่นั่งมากขึ้น 10 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "เพิ่มเป็นสองเท่า" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "ตั้งตัวเลื่อนผู้โดยสารทั้งหมดเป็น **200%**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "รีเซ็ตผู้โดยสารทั้งหมด" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "ตั้งตัวเลื่อนผู้โดยสารทั้งหมดกลับเป็น **100%**\n" +
                    "(ค่าเริ่มต้นของเกม)" },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "รถขนส่งสินค้า (ความจุสินค้า)" },


                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "รถบรรทุกกึ่งพ่วง" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**ความจุรถบรรทุกกึ่งพ่วง**\n" +
                    "**100% = 25 ตัน** (ค่าเริ่มต้นของเกม)\n" +
                    "**500% = 125 ตัน**\n" +
                    "รวมถึง:\n" +
                    " - รถบรรทุกกึ่งพ่วงของอุตสาหกรรมเฉพาะทาง (ฟาร์ม ประมง ป่าไม้ ฯลฯ)\n" +
                    "หมายเหตุ: รวมรถบรรทุกกึ่งพ่วงที่ขนจดหมายไป/กลับสถานีขนส่งสินค้า\n" +
                    "ไม่ใช่การส่งจดหมายภายในเมือง"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "รถตู้ส่งสินค้า" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**รถตู้ส่งสินค้า**\n" +
                    "**100% = 4 ตัน** (ค่าเริ่มต้นของเกม)\n" +
                    "**500% = 20 ตัน**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "รถบรรทุกวัตถุดิบ" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**รถบรรทุกวัตถุดิบ** (น้ำมัน ถ่านหิน แร่ หิน และรถดั๊มพ์ขยะอุตสาหกรรม ใช้ประเภทรถเดียวกัน)\n" +
                    "**100% = 20 ตัน** (ค่าเริ่มต้นของเกม)\n" +
                    "**500% = 100 ตัน**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "มอเตอร์ไซค์ส่งสินค้า" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**มอเตอร์ไซค์ส่งสินค้า** มักขนเวชภัณฑ์ไปโรงพยาบาล/คลินิก\n" +
                    "**100% = 0.1 ตัน** (ค่าเริ่มต้นของเกม)\n" +
                    "**500% = 0.5 ตัน**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "รีเซ็ตการขนส่งเป็นค่าเริ่มต้น" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "ตั้งตัวเลื่อนการขนส่งกลับเป็น **100%** (ค่าเริ่มต้นของเกม)" },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "จำนวนรถบรรทุกทั้งหมด" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "สถานีขนส่งสินค้า: รถบรรทุกทั้งหมด" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "จำนวนรถขนส่งสินค้าที่ใช้งานได้สูงสุดสำหรับแต่ละ **ท่าเรือสินค้า สถานีรถไฟสินค้า และสนามบิน**\n" +
                    "**1×** = ค่าเริ่มต้นของเกม, **5×** = มากขึ้น 5 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "แสดงรถบรรทุกอุตสาหกรรม" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "<[x] ค่าเริ่มต้น ON> เพื่อปรับจำนวนรถบรรทุกทั้งหมด\n" +
                    "เพื่อให้ทำงานร่วมกับม็อดอื่นได้\n" +
                    "- ใช้ OFF หากต้องการให้ม็อดอื่นควบคุมจำนวนรถบรรทุกอุตสาหกรรม/บริษัทเดียวกัน\n" +
                    "เปิด ON เพื่อใช้ตัวเลื่อนรถบรรทุกบริษัทอุตสาหกรรมทั้งสามในการปรับจำนวนรถทั้งหมด\n" +
                    "ปิด OFF เพื่อคืนตัวเลื่อนทั้ง 3 เป็นค่าเริ่มต้นของเกมและซ่อนตัวเลื่อน\n" +
                    "หากต้องการใช้ตัวเลื่อนของม็อดนี้ ให้ตรวจว่าม็อดอื่นมีตัวเลือกปิดการปรับจำนวนรถของตัวเองหรือไม่"
                     },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "รถบรรทุกแหล่งผลิต" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "จำนวนรถบรรทุกสูงสุดของแต่ละบริษัทแหล่งผลิต\n" +
                    "รวมฟาร์ม ป่าไม้ ประมง น้ำมัน แร่ ถ่านหิน หิน ฝ้าย ปศุสัตว์ และผัก\n" +
                    "**1×** = ค่าเริ่มต้นของเกม, **5×** = มากขึ้น 5 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "รถบรรทุกคลังสินค้า" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "จำนวนรถบรรทุกสูงสุดของแต่ละบริษัทคลังสินค้า\n" +
                    "รวมคลังสินค้าทุกประเภทที่มีรถของตัวเอง\n" +
                    "**1×** = ค่าเริ่มต้นของเกม, **5×** = มากขึ้น 5 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "รถบรรทุกอุตสาหกรรม" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "จำนวนรถบรรทุกสูงสุดของบริษัทแปรรูปอุตสาหกรรม\n" +
                    "ไม่รวมแหล่งผลิต คลังสินค้า สถานีขนส่งสินค้า บริษัทพาณิชย์ หรือสำนักงาน\n" +
                    "**1×** = ค่าเริ่มต้นของเกม, **5×** = มากขึ้น 5 เท่า" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "รีเซ็ตรถอุตสาหกรรมทั้งหมด" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "รีเซ็ตตัวเลื่อนสถานีขนส่งสินค้า แหล่งผลิต คลังสินค้า และอุตสาหกรรมเป็น **1×** (ค่าเริ่มต้นของเกม)\n" +
                    "สวิตช์ควบคุมรถบรรทุกบริษัทยังคง ON หรือ OFF ตามที่เลือก" },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "ข้อมูล" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "ลิงก์ช่วยเหลือ" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "ดีบัก / บันทึก" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "ม็อด" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "ชื่อที่แสดงของม็อดนี้" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "เวอร์ชัน" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "เวอร์ชันปัจจุบันของม็อดและประเภทบิลด์" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "เปิดหน้า Paradox Mods ของผู้สร้างม็อด" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "เปิด Discord ของชุมชนในเบราว์เซอร์" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "รายงานการสแกน (prefab)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "สร้างรายงาน <ครั้งเดียว> สำหรับการดีบัก\n" +
                    "ไม่จำเป็นสำหรับการเล่นตามปกติ\n" +
                    "ตำแหน่งไฟล์: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "เคล็ดลับ: คลิก <ครั้งเดียว> ถ้าสถานะแสดงว่าเสร็จแล้ว ให้ใช้ <เปิดโฟลเดอร์รายงาน>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "สถานะการสแกน prefab" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "แสดงสถานะการสแกน: ว่าง / อยู่ในคิว / กำลังทำงาน / เสร็จ / ไม่มีข้อมูล\n" +
                    "อยู่ในคิว/กำลังทำงานจะแสดงเวลาที่ผ่านไป; เสร็จแล้วจะแสดงระยะเวลา + เวลาที่เสร็จ" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "บันทึกดีบักแบบละเอียด" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "เขียนรายละเอียดเพิ่มเติมลงใน <AllTransitTrucks.log> เพื่อช่วยแก้ปัญหา\n" +
                    "**ปิด** สำหรับการเล่นตามปกติ\n" +
                    "<ตัวเลือกนี้เพิ่มเฉพาะการบันทึก และไม่เปลี่ยนค่าการเล่น>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "เปิดบันทึก" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "เปิด <Logs/AllTransitTrucks.log> หรือโฟลเดอร์ Logs หากยังไม่มีไฟล์\n" +
                    "สามารถใช้ Notepad++ เพื่อดูไฟล์บันทึกได้"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "เปิดโฟลเดอร์รายงาน" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "เปิดโฟลเดอร์รายงาน\n" +
                    "จากนั้นเปิด <ScanReport-Prefabs.txt> ด้วยโปรแกรมแก้ไขข้อความ (เช่น Notepad++)" },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "ว่าง" },
                { "PWP_SCAN_QUEUED_FMT", "อยู่ในคิว ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "กำลังทำงาน ({0})" },
                { "PWP_SCAN_DONE_FMT", "เสร็จ ({0} | {1})" },
                { "PWP_SCAN_FAILED", "ล้มเหลว" },
                { "PWP_SCAN_FAIL_NO_CITY", "โหลดเมืองก่อน" },
                { "PWP_SCAN_UNKNOWN_TIME", "ไม่ทราบเวลา" },

            };
        }

        public void Unload()
        {
        }
    }
}
