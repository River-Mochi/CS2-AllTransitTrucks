// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_PT.cs
// Portuguese-Portugal (pt-PT) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePT_PT : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocalePT_PT(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "Transporte público" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Indústria" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Parques-Estradas" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "Sobre" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Linhas de transporte (intervalo do seletor no jogo)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Expandir mín./máx. das linhas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Expande o **intervalo** do seletor de veículos de cada linha de transporte no jogo.\n" +
                    "**Pode chegar a 1 veículo** em todas as rotas testadas.\n" +
                    "O **limite máximo varia**, mas as rotas testadas permitem pelo menos 3× o máximo do jogo base.\n" +
                    "Nota técnica: o jogo usa o tempo da rota (tempo de viagem + número de paragens), por isso o máximo é variável. Este mod segue a lógica do jogo e não define um limite fixo, como 200.\n" +
                    "Funciona com todos os transportes públicos.\n\n" +
                    "**---------------**\n" +
                    "Dica: para aumentar um pouco mais o máximo do seletor, adicione algumas paragens à rota.\n" +
                    "O jogo aumenta automaticamente o máximo com base nas paragens e noutros fatores; adicionar paragens é um ajuste simples.\n" +
                    "<Evitar conflitos>: remova outros mods que alterem a mesma política das linhas de transporte.\n" +
                    "Desative se não precisar desta função ou se utilizar outro mod para o mesmo efeito."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Capacidade dos depósitos (máx. de veículos por depósito)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Depósito de autocarros" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Altera quantos autocarros cada **Depósito de Autocarros** pode manter/gerar.\n" +
                    "**100%** = jogo base (predefinição).\n" +
                    "**1000%** = 10× mais.\n" +
                    "Aplica-se ao edifício base." },

                 { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Depósito de ferries" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "Máximo de veículos por edifício do **Depósito de Ferries**.\n" +
                    "**100%** = jogo base (predefinição).\n" +
                    "Aplica-se ao edifício base."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Depósito de metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Altera quantos veículos cada **Depósito de Metro** pode manter.\n" +
                    "Aplica-se ao edifício base."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Depósito de táxis" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Número de táxis que cada **Depósito de Táxis** pode manter.\n" +
                    "No máximo, pode criar uma quantidade excessiva e cómica de táxis."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Depósito de elétricos" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Altera quantos elétricos cada **Depósito de Elétricos** pode manter.\n" +
                    "Aplica-se ao edifício base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Depósito de comboios" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Altera quantos comboios cada **Depósito de Comboios** pode manter.\n" +
                    "Aplica-se ao edifício base." },


                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Repor depósitos" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Repõe todos os seletores dos depósitos em **100%** (predefinição do jogo base)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Capacidade de passageiros (máx. de pessoas por veículo)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Autocarro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Altera a capacidade de **passageiros dos autocarros**.\n" +
                    "**10%** = 10% dos lugares do jogo base.\n" +
                    "**100%** = lugares do jogo base (predefinição).\n" +
                    "**1000%** = 10× mais lugares." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Elétrico" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Altera a capacidade de **passageiros dos elétricos**.\n" +
                    "**10%** = 10% dos lugares do jogo base.\n" +
                    "**100%** = lugares do jogo base (predefinição).\n" +
                    "**1000%** = 10× mais lugares." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Comboio" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Altera a capacidade de **passageiros dos comboios**.\n" +
                    "Aplica-se a locomotivas e carruagens.\n" +
                    "**10%** = 10% dos lugares do jogo base.\n" +
                    "**100%** = lugares do jogo base (predefinição).\n" +
                    "**1000%** = 10× mais lugares." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Altera a capacidade de **passageiros do metro**.\n" +
                    "**10%** = 10% dos lugares do jogo base.\n" +
                    "**100%** = lugares do jogo base (predefinição).\n" +
                    "**1000%** = 10× mais lugares." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Navio" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Altera a capacidade dos **navios de passageiros** (não dos navios de carga).\n" +
                    "**100%** = lugares do jogo base (predefinição)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Ferry" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Altera a capacidade de **passageiros dos ferries**.\n" +
                    "**10%** = 10% dos lugares do jogo base.\n" +
                    "**100%** = lugares do jogo base (predefinição).\n" +
                    "**1000%** = 10× mais lugares." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Avião" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Altera a capacidade de **passageiros dos aviões**.\n" +
                    "**10%** = 10% dos lugares do jogo base.\n" +
                    "**100%** = lugares do jogo base (predefinição).\n" +
                    "**1000%** = 10× mais lugares." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Duplicar" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Define todos os seletores de passageiros para **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Repor todos os passageiros" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Repõe todos os seletores de passageiros em **100%**\n" +
                    "(predefinição do jogo base)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Veículos de entrega (capacidade de carga)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Camiões semirreboque" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**Capacidade dos camiões semirreboque**.\n" +
                    "**100% = 25 t** (jogo base)\n" +
                    "**500% = 125 t**.\n" +
                    "Inclui:\n" +
                    " - Camiões semirreboque da indústria especializada (agricultura, pesca, silvicultura, etc.).\n" +
                    "Nota: inclui camiões semirreboque que transportam correio de/para estações de carga.\n" +
                    "Não é o mesmo que a distribuição local de correio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Carrinhas de entrega" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Carrinhas de entrega**\n" +
                    "**100% = 4 t** (jogo base)\n" +
                    "**500% = 20 t**" },
                
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Camiões de matérias-primas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Camiões de matérias-primas** (petróleo, carvão, minério, pedra e camiões basculantes para resíduos industriais — utilizam o mesmo tipo de camião)\n" +
                    "**100% = 20 t** (jogo base)\n" +
                    "**500% = 100 t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Mota de entregas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "A **mota de entregas** transporta normalmente produtos farmacêuticos para hospitais ou clínicas.\n" +
                    "**100% = 0,1 t** (jogo base)\n" +
                    "**500% = 0,5 t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Repor entregas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Repõe os seletores de entrega em **100%** (predefinição do jogo base)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Total de veículos por instalação" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Total de veículos: estações de carga" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Máximo de veículos de carga ativos em cada **porto de carga, terminal ferroviário e aeroporto**.\n" +
                    "**1×** = jogo base, **5×** = 5 vezes mais." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "Indústria: ajustar total de camiões" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "Controla os limites de camiões da ATT para empresas extratoras, armazéns e empresas de processamento industrial.\n" +
                    "Deixe ATIVADO para utilizar os três seletores de camiões das empresas abaixo.\n" +
                    "Desative para repor estas três categorias no jogo base uma vez, ocultar os seletores e impedir a ATT de alterar os respetivos totais de camiões.\n" +
                    "Utilize DESATIVADO quando outro mod controlar as mesmas frotas.\n" +
                    "Os veículos das estações de carga e as capacidades de carga das entregas não são afetados.\n" +
                    "<[x] Predefinição: ATIVADO>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Total de camiões: extração" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Máximo de camiões para cada empresa extratora.\n" +
                    "Inclui agricultura, silvicultura, pesca, petróleo, minério, carvão, pedra, algodão, pecuária e legumes.\n" +
                    "**1×** = jogo base, **5×** = 5 vezes mais." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "Total de camiões: armazéns" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "Máximo de camiões para cada empresa de armazenagem.\n" +
                    "Inclui todos os tipos de recursos armazenados que tenham veículos próprios.\n" +
                    "**1×** = jogo base, **5×** = 5 vezes mais." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "Total de camiões: indústria" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "Máximo de camiões para empresas de processamento industrial.\n" +
                    "Não inclui empresas extratoras, armazéns, estações de carga, empresas comerciais ou escritórios.\n" +
                    "**1×** = jogo base, **5×** = 5 vezes mais." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Repor todos os veículos da indústria" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Repõe os seletores das estações de carga, empresas extratoras, armazéns e indústria em **1×** (valores do jogo base).\n" +
                    "A opção de controlo dos camiões das empresas mantém o estado ATIVADO ou DESATIVADO selecionado." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Manutenção de parques" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Capacidade do turno de trabalho" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Ajusta a **capacidade do turno de trabalho** (capacidade do veículo).\n" +
                    "Trabalho total que um camião pode realizar antes de regressar ao edifício.\n" +
                    "Mais provisões = permanece em serviço durante mais tempo." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Ritmo de trabalho do veículo" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "Ajusta o **ritmo de trabalho do veículo**.\n" +
                    "**Ritmo** = quantidade de trabalho realizada por ciclo de simulação enquanto está parado." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Tamanho da frota do depósito" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Número **máximo de veículos** permitido no edifício do depósito.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Repor manutenção dos parques" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Repõe todos os valores em **100%** (predefinição do jogo base)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Manutenção das estradas" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Tamanho da frota do depósito" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Multiplicador do **máximo de veículos do depósito** por edifício.\n" +
                    "Mais alto = mais camiões.\n" +
                    "<Nota de equilíbrio: camiões a menos ou a mais podem prejudicar o trânsito.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Capacidade do turno de trabalho" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Ajusta a **capacidade do turno de trabalho**.\n" +
                    "Trabalho total que um camião pode realizar antes de regressar ao depósito.\n" +
                    "**Mais alto = menos regressos** ao edifício principal e maior eficiência." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Taxa de reparação" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "**Taxa** = quantidade de trabalho realizada por ciclo de simulação enquanto está parado.\n" +
                    "Os camiões continuam a fazer uma paragem rápida mesmo com a taxa máxima; apenas realizam mais trabalho em cada paragem.\n" +
                    "No jogo base, uma paragem não repara necessariamente a estrada a 100%; por isso, esta função produz melhores resultados ao longo do tempo.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Desgaste das estradas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Funcionalidade beta>\n" +
                    "Controla a velocidade de deterioração das estradas devido ao **tempo e ao trânsito**.\n" +
                    "**10%** = desgaste 10× mais lento (menos reparações)\n" +
                    "**100%** = jogo base\n" +
                    "**500%** = danos 5× mais rápidos (mais reparações/camiões)\n" +
                    "Funcionamento no jogo:\n" +
                    "Se m_Wear <= 2.5, não existe redução de velocidade.\n" +
                    "Se m_Wear >= 17.5, aplica-se a penalização máxima e os veículos circulam 50% mais devagar.\n" +
                    "Consulte a vista de informação Estradas: as estradas muito danificadas que abrandam os veículos aparecem a vermelho."

                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Repor manutenção das estradas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Repõe todos os valores em **100%** (predefinição do jogo base)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Informação" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Ligações de suporte" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Depuração / Registo" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Nome apresentado para este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Versão atual do mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Abre a página dos mods do autor no Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Abre o Discord da comunidade no navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Relatório de análise (prefabs)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Cria um relatório <único> para diagnóstico.\n" +
                    "Não é necessário durante o jogo normal.\n" +
                    "Local do ficheiro: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Dica: clique <uma vez>; quando o estado indicar Concluído, utilize <Abrir pasta do relatório>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Estado da análise de prefabs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Mostra o estado: Inativo / Em fila / A executar / Concluído / Sem dados.\n" +
                    "Em fila/A executar mostra o tempo decorrido; Concluído mostra a duração e a hora de conclusão." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Registos de diagnóstico detalhados" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Envia detalhes adicionais para <AllTransitTrucks.log> para ajudar no diagnóstico.\n" +
                    "**Desative** durante o jogo normal.\n" +
                    "<Apenas aumenta o registo; não altera os valores do jogo.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Abrir pasta dos registos" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Abre a pasta dos registos.\n" +
                    "Depois, abra <AllTransitTrucks.log> num editor de texto (recomenda-se o Notepad++)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Abrir pasta do relatório" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Abre a pasta do relatório.\n" +
                    "Depois, abra <ScanReport-Prefabs.txt> num editor de texto (por exemplo, Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Inativo" },
                { "PWP_SCAN_QUEUED_FMT", "Em fila ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "A executar ({0})" },
                { "PWP_SCAN_DONE_FMT", "Concluído ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Falhou" },
                { "PWP_SCAN_FAIL_NO_CITY", "Carregue primeiro uma cidade" },
                { "PWP_SCAN_UNKNOWN_TIME", "hora desconhecida" },

            };
        }

        public void Unload( )
        {
        }
    }
}
