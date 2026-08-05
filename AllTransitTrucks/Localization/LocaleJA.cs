// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleJA.cs
// Japanese (ja-JP) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleJA(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "産業" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "公園・道路" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "情報" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "交通路線（ゲーム内スライダー範囲）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "交通路線の最小/最大を拡張" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "各路線ごとのゲーム内交通路線スライダーの**範囲**を広げます。\n" +
                    "テストしたすべての路線で**最小 (1)** まで下げられます。\n" +
                    "**最大上限は可変**ですが、すべてバニラより3×以上高くなります。\n" +
                    "技術メモ: ゲームは路線時間（走行時間 + 停留所数）を使用するため、最大値は可変になります（このMODはゲームロジックに従うため、200のような固定上限は設定しません）。\n" +
                    "すべての交通機関で動作します: バス、フェリー、トラム、列車、地下鉄、船、飛行機。\n\n" +
                    "**---------------**\n" +
                    "ヒント: スライダー最大値をもう少し上げたい場合は、路線に停留所をいくつか追加してください。\n" +
                    "ゲームは追加された停留所 + 各種要素に応じて最大値を自動で増やします。停留所追加は簡単にできる調整です。\n" +
                    "<競合回避>: 同じ交通路線ポリシーを編集するMODは外してください。\n" +
                    "この機能が不要な場合、または同じ用途の別MODを使うために無効化が必要な場合はオフにしてください。"
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "車庫容量（車庫ごとの最大車両数）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "バス車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "各**バス車庫**が維持/出庫できるバスの数を変更します。\n" +
                    "**100%** = バニラ（ゲーム既定値）。\n" +
                    "**1000%** = 10倍。\n" +
                    "ベース建物に適用されます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "フェリー車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**フェリー車庫**の建物ごとの最大車両数です。\n" +
                    "**100%** = バニラ（ゲーム既定値）。\n" +
                    "ベース建物に適用されます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "地下鉄車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "各**地下鉄車庫**が維持できる地下鉄車両数を変更します。\n" +
                    "ベース建物に適用されます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "タクシー車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "各**タクシー車庫**が維持できるタクシー台数です。\n" +
                    "最大にすると、タクシーが過剰でコミカルな量になる可能性があります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "トラム車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "各**トラム車庫**が維持できるトラム数を変更します。\n" +
                    "ベース建物に適用されます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "列車車庫" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "各**列車車庫**が維持できる列車数を変更します。\n" +
                    "ベース建物に適用されます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "車庫設定をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "すべての車庫スライダーを**100%**（ゲーム既定値 / バニラ）に戻します。" },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "乗客容量（車両ごとの最大人数）" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "バス" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "**バス乗客**容量を変更します。\n" +
                    "**10%** = バニラ座席数の10%。\n" +
                    "**100%** = バニラ座席数（ゲーム既定値）。\n" +
                    "**1000%** = 座席数10倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "トラム" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "**トラム乗客**容量を変更します。\n" +
                    "**10%** = バニラ座席数の10%。\n" +
                    "**100%** = バニラ座席数（ゲーム既定値）。\n" +
                    "**1000%** = 座席数10倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "列車" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "**列車乗客**容量を変更します。\n" +
                    "機関車と各セクションに適用されます。\n" +
                    "**10%** = バニラ座席数の10%。\n" +
                    "**100%** = バニラ座席数（ゲーム既定値）。\n" +
                    "**1000%** = 座席数10倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "地下鉄" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "**地下鉄乗客**容量を変更します。\n" +
                    "**10%** = バニラ座席数の10%。\n" +
                    "**100%** = バニラ座席数（ゲーム既定値）。\n" +
                    "**1000%** = 座席数10倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "船" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "**旅客船**の容量を変更します（貨物船は対象外）。\n" +
                    "**100%** = バニラ座席数（ゲーム既定値）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "フェリー" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "**フェリー乗客**容量を変更します。\n" +
                    "**10%** = バニラ座席数の10%。\n" +
                    "**100%** = バニラ座席数（ゲーム既定値）。\n" +
                    "**1000%** = 座席数10倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "飛行機" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "**飛行機乗客**容量を変更します。\n" +
                    "**10%** = バニラ座席数の10%。\n" +
                    "**100%** = バニラ座席数（ゲーム既定値）。\n" +
                    "**1000%** = 座席数10倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "2倍にする" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "すべての乗客スライダーを**200%**に設定します。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "全乗客をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "すべての乗客スライダーを**100%**に戻します\n" +
                    "（ゲーム既定値 / バニラ）。" },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "配送車両（貨物容量）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "セミトラック" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**セミトラック**容量です。\n" +
                    "**100% = 25t**（バニラ）\n" +
                    "**500% = 125t**。\n" +
                    "対象:\n" +
                    " - 特化産業のセミトラック（農業、漁業、林業など）。\n" +
                    "補足: 貨物駅との間で郵便を運ぶセミトラックも含まれます。\n" +
                    "これは地域の郵便配達とは別です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "配送バン" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**配送バン**\n" +
                    "**100% = 4t**（バニラ）\n" +
                    "**500% = 20t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "原材料トラック" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**原材料トラック**（石油、石炭、鉱石、石材、産業廃棄物用ダンプトラック - 同じ共有トラック種別）\n" +
                    "**100% = 20t**（バニラ）\n" +
                    "**500% = 100t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "配送バイク" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**バイク配送**は通常、薬品を病院/診療所へ運びます。\n" +
                    "**100% = 0.1t**（バニラ）\n" +
                    "**500% = 0.5t**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "配送設定をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "配送スライダーを**100%**（ゲーム既定値 / バニラ）に戻します。" },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "貨物フリート（港、鉄道、空港）" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "貨物駅最大フリート" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "**貨物輸送駅**のアクティブ輸送車両最大数を変更します。\n" +
                    "**1×** = バニラ、**5×** = 5倍。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "採取施設フリート" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "産業用**採取施設の最大トラック数**を変更します。\n" +
                    "（農業、漁業、林業、鉱石、石油、石炭、石材）。\n" +
                    "**1×** = バニラ\n" +
                    "**5×** = 5倍。\n" +
                    "バニラでは通常、採取施設1棟あたり5台のトラックが使えます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "貨物 + 採取施設フリートをリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "貨物駅 + 採取施設の倍率を**1×**（ゲーム既定値 / バニラ）に戻します。" },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "公園メンテナンス" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "作業シフト容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "**作業シフト容量**（車両容量）への倍率です。\n" +
                    "トラックが建物へ戻るまでにこなせる総作業量です。\n" +
                    "イメージ: 補給が多い = より長く外で作業できる。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "車両作業率" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "**車両作業率**への倍率です。\n" +
                    "作業率 = 停車中にシミュレーションtickごとにこなす作業量。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "車庫フリートサイズ" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "車庫建物の**最大車両数**への倍率です。\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "公園メンテナンスをリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "すべての値を**100%**（ゲーム既定値 / バニラ）に戻します。" },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "道路メンテナンス" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "車庫フリートサイズ" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "建物ごとの**車庫最大車両数**への倍率です。\n" +
                    "高いほど = トラックが増える。\n" +
                    "<バランス注記: 少なすぎても多すぎても交通に悪影響があります。>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "作業シフト容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "**作業シフト容量**への倍率です。\n" +
                    "トラックが車庫へ戻るまでにこなせる総作業量です。\n" +
                    "**高いほど = 戻る回数が減る。** より効率的になります。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "修理率" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "作業率 = 停車中にシミュレーションtickごとにこなす作業量。\n" +
                    "最高レートでもトラックは短い停止+発進を行います（1回の停止でこなす作業量が増えます）。\n" +
                    "バニラでは1回の停止で道路が必ず100%修理されるわけではないため、この機能は時間とともに効果が増します。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "道路摩耗" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Beta feature>\n" +
                    "**時間と交通量**の要因によって道路がどれだけ速く劣化するかを制御します。\n" +
                    "**10%** = 摩耗が10×遅い（修理回数減少）\n" +
                    "**100%** = バニラ\n" +
                    "**500%** = ダメージが5×速い（より多くの修理/トラックが必要）\n" +
                    "ゲーム内での仕組み:\n" +
                    "m_Wear <= 2.5 の場合、減速なし。\n" +
                    "m_Wear >= 17.5 の場合、最大ペナルティで車両は道路上で50%遅くなります。\n" +
                    "道路インフォビュー参照: ひどく損傷した道路は赤く表示され、車両を減速させます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "道路メンテナンスをリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "すべての値を**100%**（ゲーム既定値 / バニラ）に戻します。" },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "情報" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "サポートリンク" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "デバッグ / ログ" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "MOD" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "このMODの表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "現在のMODバージョンです。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "作者のMODがある Paradox Mods のWebサイトを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "コミュニティDiscordをブラウザで開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "スキャンレポート（prefab）" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "デバッグ用の<一回限り>レポートを作成します。\n" +
                    "通常プレイには不要です。\n" +
                    "ファイル場所: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "ヒント: <一度>クリックし、状態が完了になったら <レポートフォルダーを開く> を使ってください。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Prefabスキャン状態" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "スキャン状態を表示します: 待機中 / 待機列 / 実行中 / 完了 / データなし.\n" +
                    "待機列/実行中 は経過時間を表示し、完了 は所要時間 + 完了時刻を表示します。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "詳細デバッグログ" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "トラブルシュート用に <AllTransitTrucks.log> へ追加詳細を書き込みます。\n" +
                    "通常プレイでは**無効化**してください。\n" +
                    "<これはログ量を増やすだけで、ゲームプレイ値は変更しません。>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "ログフォルダーを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "ログフォルダーを開きます。\n" +
                    "次に: テキストエディタで <AllTransitTrucks.log> を開きます（Notepad++ 推奨）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "レポートフォルダーを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "レポートフォルダーを開きます。\n" +
                    "次に: テキストエディタで <ScanReport-Prefabs.txt> を開きます（例: Notepad++）。" },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "待機中" },
                { "PWP_SCAN_QUEUED_FMT", "待機列 ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "実行中 ({0})" },
                { "PWP_SCAN_DONE_FMT", "完了 ({0} | {1})" },
                { "PWP_SCAN_FAILED", "失敗" },
                { "PWP_SCAN_FAIL_NO_CITY", "先に都市をロード" },
                { "PWP_SCAN_UNKNOWN_TIME", "時刻不明" },

            };
        }

        public void Unload( )
        {
        }
    }
}
