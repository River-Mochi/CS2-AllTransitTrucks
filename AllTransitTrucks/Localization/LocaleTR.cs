// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// Turkish (tr-TR) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleTR : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleTR(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "Toplu Taşıma" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Sanayi" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Parklar-Yollar" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "Hakkında" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Toplu taşıma hatları (oyun içi kaydırıcı aralığı)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Hat min./maks. aralığını genişlet" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Her rota için oyun içindeki toplu taşıma hattı kaydırıcısının **aralığını** genişletir.\n" +
                    "Test edilen tüm rotalarda **(1) araca kadar düşebilir**.\n" +
                    "**Azami sınır değişkendir**, ancak temel oyundan en az 3× daha yüksektir.\n" +
                    "Teknik not: Oyun rota süresini (seyahat süresi + durak sayısı) kullanır; bu nedenle azami değer değişkendir. Bu mod oyun mantığını izler ve 200 gibi sabit bir sınır koymaz.\n" +
                    "Tüm toplu taşıma türlerinde çalışır.\n\n" +
                    "**---------------**\n" +
                    "İpucu: Kaydırıcının azami değerini biraz daha artırmak için rotaya birkaç durak ekleyin.\n" +
                    "Oyun, eklenen duraklara ve diğer etkenlere göre azami değeri otomatik artırır; durak eklemek kolay bir ayardır.\n" +
                    "<Çakışmaları önleyin>: Aynı toplu taşıma hattı politikasını değiştiren diğer modları kaldırın.\n" +
                    "Gerekmiyorsa veya aynı iş için başka bir mod kullanıyorsanız devre dışı bırakın."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Depo kapasitesi (depo başına azami araç)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Otobüs deposu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Her **Otobüs Deposunun** bakımını yapabileceği/oluşturabileceği otobüs sayısını değiştirir.\n" +
                    "**100%** = temel oyun (varsayılan).\n" +
                    "**1000%** = 10× daha fazla.\n" +
                    "Ana binaya uygulanır." },

                 { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Feribot deposu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "Her **Feribot Deposu** binası için azami araç sayısı.\n" +
                    "**100%** = temel oyun (varsayılan).\n" +
                    "Ana binaya uygulanır."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Metro deposu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Her **Metro Deposunun** bakımını yapabileceği metro aracı sayısını değiştirir.\n" +
                    "Ana binaya uygulanır."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Taksi deposu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Her **Taksi Deposunun** bakımını yapabileceği taksi sayısı.\n" +
                    "Azami değerde aşırı ve komik sayıda taksi oluşabilir."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Tramvay deposu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Her **Tramvay Deposunun** bakımını yapabileceği tramvay sayısını değiştirir.\n" +
                    "Ana binaya uygulanır." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Tren deposu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Her **Tren Deposunun** bakımını yapabileceği tren sayısını değiştirir.\n" +
                    "Ana binaya uygulanır." },


                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Depoları varsayılana döndür" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Tüm depo kaydırıcılarını **100%** değerine (temel oyun varsayılanına) döndürür." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Yolcu kapasitesi (araç başına azami kişi)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Otobüs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "**Otobüs yolcu** kapasitesini değiştirir.\n" +
                    "**10%** = temel oyundaki koltukların %10’u.\n" +
                    "**100%** = temel oyun koltuk sayısı (varsayılan).\n" +
                    "**1000%** = 10× daha fazla koltuk." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Tramvay" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "**Tramvay yolcu** kapasitesini değiştirir.\n" +
                    "**10%** = temel oyundaki koltukların %10’u.\n" +
                    "**100%** = temel oyun koltuk sayısı (varsayılan).\n" +
                    "**1000%** = 10× daha fazla koltuk." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Tren" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "**Tren yolcu** kapasitesini değiştirir.\n" +
                    "Lokomotiflere ve vagon bölümlerine uygulanır.\n" +
                    "**10%** = temel oyundaki koltukların %10’u.\n" +
                    "**100%** = temel oyun koltuk sayısı (varsayılan).\n" +
                    "**1000%** = 10× daha fazla koltuk." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "**Metro yolcu** kapasitesini değiştirir.\n" +
                    "**10%** = temel oyundaki koltukların %10’u.\n" +
                    "**100%** = temel oyun koltuk sayısı (varsayılan).\n" +
                    "**1000%** = 10× daha fazla koltuk." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Gemi" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "**Yolcu gemisi** kapasitesini değiştirir (yük gemilerini etkilemez).\n" +
                    "**100%** = temel oyun koltuk sayısı (varsayılan)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Feribot" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "**Feribot yolcu** kapasitesini değiştirir.\n" +
                    "**10%** = temel oyundaki koltukların %10’u.\n" +
                    "**100%** = temel oyun koltuk sayısı (varsayılan).\n" +
                    "**1000%** = 10× daha fazla koltuk." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Uçak" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "**Uçak yolcu** kapasitesini değiştirir.\n" +
                    "**10%** = temel oyundaki koltukların %10’u.\n" +
                    "**100%** = temel oyun koltuk sayısı (varsayılan).\n" +
                    "**1000%** = 10× daha fazla koltuk." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "İkiye katla" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Tüm yolcu kaydırıcılarını **200%** değerine ayarlar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Tüm yolcu değerlerini sıfırla" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Tüm yolcu kaydırıcılarını **100%** değerine döndürür\n" +
                    "(temel oyun varsayılanı)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Teslimat araçları (yük kapasitesi)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Tırlar" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**Tırların** kapasitesi.\n" +
                    "**100% = 25 t** (temel oyun)\n" +
                    "**500% = 125 t**.\n" +
                    "Kapsar:\n" +
                    " - Özel sanayi tırları (çiftlikler, balıkçılık, ormancılık vb.).\n" +
                    "Not: Yük istasyonlarına/istasyonlarından posta taşıyan tırları da kapsar.\n" +
                    "Bu, yerel posta teslimatıyla aynı değildir."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Teslimat kamyonetleri" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Teslimat kamyonetleri**\n" +
                    "**100% = 4 t** (temel oyun)\n" +
                    "**500% = 20 t**" },
                
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Hammadde kamyonları" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Hammadde kamyonları** (petrol, kömür, maden cevheri, taş ve sanayi atığı damperli kamyonları — aynı ortak kamyon türünü kullanır)\n" +
                    "**100% = 20 t** (temel oyun)\n" +
                    "**500% = 100 t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Teslimat motosikleti" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**Teslimat motosikleti** genellikle eczane ürünlerini hastane veya kliniğe taşır.\n" +
                    "**100% = 0,1 t** (temel oyun)\n" +
                    "**500% = 0,5 t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Teslimat değerlerini sıfırla" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Teslimat kaydırıcılarını **100%** değerine (temel oyun varsayılanına) döndürür." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Tesis başına toplam araç" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Toplam araç: yük istasyonları" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Her **yük limanı, yük tren terminali ve havaalanı** için azami aktif yük aracı.\n" +
                    "**1×** = temel oyun, **5×** = 5 kat daha fazla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "Sanayi: toplam kamyonları ayarla" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "ATT’nin kaynak çıkarma, depo ve sanayi işleme şirketleri için kamyon sınırlarını kontrol eder.\n" +
                    "Aşağıdaki üç şirket kamyonu kaydırıcısını kullanmak için AÇIK bırakın.\n" +
                    "KAPALI yapıldığında bu üç kategori bir kez temel oyun değerlerine döner, kaydırıcıları gizlenir ve ATT kamyon sayılarını değiştirmeyi bırakır.\n" +
                    "Aynı şirket filolarını başka bir mod kontrol ediyorsa KAPALI kullanın.\n" +
                    "Yük istasyonu araçları ve teslimat yük kapasiteleri etkilenmez.\n" +
                    "<[x] Varsayılan AÇIK>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Toplam kamyon: kaynak çıkarma" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Her kaynak çıkarma şirketi için azami kamyon sayısı.\n" +
                    "Çiftlikler, ormancılık, balıkçılık, petrol, maden cevheri, kömür, taş, pamuk, hayvancılık ve sebze üretimini kapsar.\n" +
                    "**1×** = temel oyun, **5×** = 5 kat daha fazla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "Toplam kamyon: depolar" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "Her depo şirketi için azami kamyon sayısı.\n" +
                    "Kendi araçlarına sahip tüm depo kaynak türlerini kapsar.\n" +
                    "**1×** = temel oyun, **5×** = 5 kat daha fazla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "Toplam kamyon: sanayi" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "Sanayi işleme şirketleri için azami kamyon sayısı.\n" +
                    "Kaynak çıkarma şirketlerini, depoları, yük istasyonlarını, ticari şirketleri veya ofis şirketlerini kapsamaz.\n" +
                    "**1×** = temel oyun, **5×** = 5 kat daha fazla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Tüm sanayi araçlarını sıfırla" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Yük istasyonu, kaynak çıkarma, depo ve sanayi kaydırıcılarını **1×** değerine (temel oyun değerlerine) döndürür.\n" +
                    "Şirket kamyonu kontrol seçeneği seçildiği gibi AÇIK veya KAPALI kalır." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Park bakımı" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Çalışma vardiyası kapasitesi" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "**Çalışma vardiyası kapasitesini** (araç kapasitesini) ölçeklendirir.\n" +
                    "Bir kamyonun binaya dönmeden önce yapabileceği toplam iş.\n" +
                    "Ek malzeme = daha uzun süre görevde kalır." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Araç çalışma hızı" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "**Araç çalışma hızını** ölçeklendirir.\n" +
                    "**Hız** = araç dururken her simülasyon adımında yaptığı iş miktarı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Depo filo büyüklüğü" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Depo binasında izin verilen **azami araç** sayısı.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Park bakımını sıfırla" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Tüm değerleri **100%** değerine (temel oyun varsayılanına) döndürür." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Yol bakımı" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Depo filo büyüklüğü" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Bina başına **depo azami araç** sayısı çarpanı.\n" +
                    "Daha yüksek = daha fazla kamyon.\n" +
                    "<Denge notu: Çok az veya çok fazla kamyon trafiği kötüleştirebilir.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Çalışma vardiyası kapasitesi" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "**Çalışma vardiyası kapasitesini** ölçeklendirir.\n" +
                    "Bir kamyonun depoya dönmeden önce yapabileceği toplam iş.\n" +
                    "**Daha yüksek = ana binaya daha az dönüş** ve daha yüksek verim." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Onarım hızı" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "**Hız** = araç dururken her simülasyon adımında yaptığı iş miktarı.\n" +
                    "Kamyonlar en yüksek hızda bile kısa süre durup devam eder; yalnızca her durakta daha fazla iş yapar.\n" +
                    "Temel oyunda tek bir durak yolu mutlaka %100 onarmaz; bu nedenle özellik zaman içinde daha iyi sonuç verir.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Yol aşınması" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Beta özellik>\n" +
                    "Yolların **zaman ve trafik** etkileriyle ne kadar hızlı bozulacağını kontrol eder.\n" +
                    "**10%** = 10× daha yavaş aşınma (daha az onarım gerekir)\n" +
                    "**100%** = temel oyun\n" +
                    "**500%** = 5× daha hızlı hasar (daha fazla onarım/kamyon gerekir)\n" +
                    "Oyunda nasıl çalışır:\n" +
                    "m_Wear <= 2.5 ise yavaşlama olmaz.\n" +
                    "m_Wear >= 17.5 ise azami ceza uygulanır ve araçlar yollarda %50 daha yavaş gider.\n" +
                    "Yollar bilgi görünümüne bakın: Araçları yavaşlatan ağır hasarlı yollar kırmızı görünür."

                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Yol bakımını sıfırla" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Tüm değerleri **100%** değerine (temel oyun varsayılanına) döndürür." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Bilgi" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Destek bağlantıları" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Hata ayıklama / Günlük" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Bu modun görünen adı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Sürüm" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Geçerli mod sürümü." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Yazarın modları için Paradox Mods sayfasını açar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Topluluk Discord sayfasını tarayıcıda açar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Tarama raporu (prefablar)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Hata ayıklama için <tek seferlik> bir rapor oluşturur.\n" +
                    "Normal oyun için gerekli değildir.\n" +
                    "Dosya konumu: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "İpucu: <Bir kez> tıklayın; durum Tamamlandı olduğunda <Rapor klasörünü aç> seçeneğini kullanın." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Prefab tarama durumu" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Tarama durumunu gösterir: Boşta / Sırada / Çalışıyor / Tamamlandı / Veri Yok.\n" +
                    "Sırada/Çalışıyor geçen süreyi; Tamamlandı ise süreyi ve bitiş zamanını gösterir." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Ayrıntılı hata ayıklama günlükleri" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Sorun giderme için <AllTransitTrucks.log> dosyasına ek ayrıntılar yazar.\n" +
                    "Normal oyun sırasında **devre dışı bırakın**.\n" +
                    "<Yalnızca günlük ayrıntısını artırır; oyun değerlerini değiştirmez.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Günlük klasörünü aç" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Günlük klasörünü açar.\n" +
                    "Ardından <AllTransitTrucks.log> dosyasını bir metin düzenleyiciyle açın (Notepad++ önerilir)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Rapor klasörünü aç" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Rapor klasörünü açar.\n" +
                    "Ardından <ScanReport-Prefabs.txt> dosyasını bir metin düzenleyiciyle açın (ör. Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Boşta" },
                { "PWP_SCAN_QUEUED_FMT", "Sırada ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Çalışıyor ({0})" },
                { "PWP_SCAN_DONE_FMT", "Tamamlandı ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Başarısız" },
                { "PWP_SCAN_FAIL_NO_CITY", "Önce bir şehir yükleyin" },
                { "PWP_SCAN_UNKNOWN_TIME", "bilinmeyen zaman" },

            };
        }

        public void Unload( )
        {
        }
    }
}
