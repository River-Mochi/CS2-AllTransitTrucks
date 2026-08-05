// <copyright file="DispatchHelperLocales.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/DispatchHelperLocales.cs
// Purpose: Locales for the temporary opt-in full-load helper.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;
    using Colossal.Localization;

    internal static class DispatchHelperLocales
    {
        internal static void Register(
            LocalizationManager localizationManager,
            ATTSettings setting)
        {
            Add(localizationManager, "en-US", setting,
                "Full-load dispatch helper",
                "Raises company and storage requests toward one full truck load.\n" +
                "May use extra CPU in large cities.\n" +
                "<[ ] Default OFF>.");

            Add(localizationManager, "fr-FR", setting,
                "Assistant de chargement complet",
                "Augmente les demandes des entreprises et entrepôts vers un chargement complet.\n" +
                "Peut utiliser plus de processeur dans les grandes villes.\n" +
                "<[ ] Désactivé par défaut>.");

            Add(localizationManager, "es-ES", setting,
                "Ayuda de despacho con carga completa",
                "Aumenta las solicitudes de empresas y almacenes hacia una carga completa.\n" +
                "Puede usar más CPU en ciudades grandes.\n" +
                "<[ ] Desactivado por defecto>.");

            Add(localizationManager, "de-DE", setting,
                "Vollladungs-Dispatchhilfe",
                "Erhöht Firmen- und Lageranfragen auf ungefähr eine volle Lkw-Ladung.\n" +
                "Kann in großen Städten mehr CPU benötigen.\n" +
                "<[ ] Standardmäßig AUS>.");

            Add(localizationManager, "it-IT", setting,
                "Aiuto consegne a pieno carico",
                "Aumenta le richieste di aziende e depositi verso un carico completo.\n" +
                "Può usare più CPU nelle città grandi.\n" +
                "<[ ] Disattivato per impostazione predefinita>.");

            Add(localizationManager, "ja-JP", setting,
                "満載配送ヘルパー",
                "会社と倉庫の要求量を配送車1台分に近づけます。\n" +
                "大都市ではCPU負荷が増える場合があります。\n" +
                "<[ ] 初期設定はオフ>。");

            Add(localizationManager, "ko-KR", setting,
                "완전 적재 배송 도우미",
                "회사와 창고 요청량을 배송 차량 한 대의 적재량에 가깝게 늘립니다.\n" +
                "대도시에서는 CPU 사용량이 늘 수 있습니다.\n" +
                "<[ ] 기본값 꺼짐>.");

            Add(localizationManager, "pl-PL", setting,
                "Pomoc pełnego załadunku",
                "Zwiększa żądania firm i magazynów do około jednego pełnego ładunku.\n" +
                "W dużych miastach może używać więcej CPU.\n" +
                "<[ ] Domyślnie WYŁ.>.");

            Add(localizationManager, "pt-BR", setting,
                "Auxílio de despacho com carga cheia",
                "Aumenta pedidos de empresas e depósitos para perto de uma carga completa.\n" +
                "Pode usar mais CPU em cidades grandes.\n" +
                "<[ ] Desativado por padrão>.");

            Add(localizationManager, "vi-VN", setting,
                "Hỗ trợ điều phối đầy tải",
                "Tăng yêu cầu của công ty và kho lên gần một xe đầy tải.\n" +
                "Có thể dùng thêm CPU trong thành phố lớn.\n" +
                "<[ ] Mặc định TẮT>.");

            Add(localizationManager, "zh-HANS", setting,
                "满载调度辅助",
                "将公司和仓储请求提高到接近一辆车的满载量。\n" +
                "在大型城市中可能会增加 CPU 使用量。\n" +
                "<[ ] 默认关闭>。");

            Add(localizationManager, "zh-HANT", setting,
                "滿載調度輔助",
                "將公司和倉儲請求提高到接近一輛車的滿載量。\n" +
                "在大型城市中可能會增加 CPU 使用量。\n" +
                "<[ ] 預設關閉>。");
        }

        private static void Add(
            LocalizationManager localizationManager,
            string localeId,
            ATTSettings setting,
            string label,
            string description)
        {
            localizationManager.AddSource(
                localeId,
                new Source(setting, label, description));
        }

        private sealed class Source : IDictionarySource
        {
            private readonly ATTSettings m_Setting;
            private readonly string m_Label;
            private readonly string m_Description;

            internal Source(
                ATTSettings setting,
                string label,
                string description)
            {
                m_Setting = setting;
                m_Label = label;
                m_Description = description;
            }

            public IEnumerable<KeyValuePair<string, string>> ReadEntries(
                IList<IDictionaryEntryError> errors,
                Dictionary<string, int> indexCounts)
            {
                return new Dictionary<string, string>
                {
                    {
                        m_Setting.GetOptionLabelLocaleID(
                            nameof(ATTSettings.EnableFullLoadDispatchHelper)),
                        m_Label
                    },
                    {
                        m_Setting.GetOptionDescLocaleID(
                            nameof(ATTSettings.EnableFullLoadDispatchHelper)),
                        m_Description
                    },
                };
            }

            public void Unload()
            {
            }
        }
    }
}
