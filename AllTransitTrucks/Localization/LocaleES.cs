// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// Spanish (es-ES) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleES : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleES(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Industria" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Parques-Carreteras" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "Acerca de" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Líneas de transporte (rango del deslizador en juego)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Ampliar mín/máx de líneas de transporte" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Amplía el **rango** del deslizador de líneas de transporte en juego para cada ruta.\n" +
                    "**Hasta 1 vehículo** en todas las rutas probadas.\n" +
                    "El **límite máximo varía**, pero las rutas probadas permiten al menos 3× el máximo de vanilla.\n" +
                    "Nota técnica: el juego usa el tiempo de ruta (tiempo de conducción + número de paradas); esto crea un máximo variable (este mod sigue la lógica del juego y por eso no fija un máximo estático como 200).\n" +
                    "Funciona para todo el transporte: autobús, ferry, tranvía, tren, metro, barco, avión.\n\n" +
                    "**---------------**\n" +
                    "Consejo: si quieres aumentar un poco más el máximo del deslizador, añade algunas paradas a la ruta.\n" +
                    "El juego aumenta automáticamente el máximo según las paradas añadidas + factores; añadir paradas es un ajuste sencillo para el jugador.\n" +
                    "<Evitar conflictos>: quitar mods que editen la misma política de líneas de transporte.\n" +
                    "Desactivar si la función no es necesaria o si debe desactivarse para usar otro mod para lo mismo."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Capacidad de depósitos (vehículos máx por depósito)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Depósito de autobuses" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Cambia cuántos autobuses puede mantener/generar cada **depósito de autobuses**.\n" +
                    "**100%** = vanilla (valor predeterminado del juego).\n" +
                    "**1000%** = 10× más.\n" +
                    "Se aplica al edificio base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Depósito de ferris" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**Depósito de ferris**: vehículos máximos por edificio.\n" +
                    "**100%** = vanilla (valor predeterminado del juego).\n" +
                    "Se aplica al edificio base."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Depósito de metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Cambia cuántos vehículos de metro puede mantener cada **depósito de metro**.\n" +
                    "Se aplica al edificio base."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Depósito de taxis" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Cuántos taxis puede mantener cada **depósito de taxis**.\n" +
                    "Si se pone al máximo, podría causar una cantidad excesiva y cómica de taxis."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Depósito de tranvías" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Cambia cuántos tranvías puede mantener cada **depósito de tranvías**.\n" +
                    "Se aplica al edificio base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Depósito de trenes" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Cambia cuántos trenes puede mantener cada **depósito de trenes**.\n" +
                    "Se aplica al edificio base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Restablecer depósitos" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Devuelve todos los deslizadores de depósitos a **100%** (valor predeterminado del juego / vanilla)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Capacidad de pasajeros (máx personas por vehículo)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Autobús" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Cambia la capacidad de **pasajeros del autobús**.\n" +
                    "**10%** = 10% de los asientos vanilla.\n" +
                    "**100%** = asientos vanilla (valor predeterminado del juego).\n" +
                    "**1000%** = 10× más asientos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Tranvía" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Cambia la capacidad de **pasajeros del tranvía**.\n" +
                    "**10%** = 10% de los asientos vanilla.\n" +
                    "**100%** = asientos vanilla (valor predeterminado del juego).\n" +
                    "**1000%** = 10× más asientos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Tren" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Cambia la capacidad de **pasajeros del tren**.\n" +
                    "Se aplica a locomotoras y secciones.\n" +
                    "**10%** = 10% de los asientos vanilla.\n" +
                    "**100%** = asientos vanilla (valor predeterminado del juego).\n" +
                    "**1000%** = 10× más asientos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Metro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Cambia la capacidad de **pasajeros del metro**.\n" +
                    "**10%** = 10% de los asientos vanilla.\n" +
                    "**100%** = asientos vanilla (valor predeterminado del juego).\n" +
                    "**1000%** = 10× más asientos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Barco" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Cambia la capacidad de **barcos de pasajeros** (no barcos de carga).\n" +
                    "**100%** = asientos vanilla (valor predeterminado del juego)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Ferri" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Cambia la capacidad de **pasajeros del ferri**.\n" +
                    "**10%** = 10% de los asientos vanilla.\n" +
                    "**100%** = asientos vanilla (valor predeterminado del juego).\n" +
                    "**1000%** = 10× más asientos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Avión" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Cambia la capacidad de **pasajeros del avión**.\n" +
                    "**10%** = 10% de los asientos vanilla.\n" +
                    "**100%** = asientos vanilla (valor predeterminado del juego).\n" +
                    "**1000%** = 10× más asientos." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Duplicar" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Ajusta todos los deslizadores de pasajeros a **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Restablecer todos los pasajeros" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Devuelve todos los deslizadores de pasajeros a **100%**\n" +
                    "(valor predeterminado del juego / vanilla)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Vehículos de reparto (capacidad de carga)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Camiones articulados" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "**Capacidad de los camiones articulados**.\n" +
                    "**100% = 25t** (vanilla)\n" +
                    "**500% = 125t**.\n" +
                    "Incluye:\n" +
                    " - Camiones articulados de industria especializada (granjas, pesca, silvicultura, etc.).\n" +
                    "Nota: incluye camiones articulados que llevan correo hacia/desde estaciones de carga.\n" +
                    "No es lo mismo que el reparto local de correo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Furgonetas de reparto" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Furgonetas de reparto**\n" +
                    "**100% = 4t** (vanilla)\n" +
                    "**500% = 20t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Camiones de materias primas" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Camiones de materias primas** (petróleo, carbón, mineral, piedra, camiones volquete para residuos industriales - mismo tipo de camión compartido)\n" +
                    "**100% = 20t** (vanilla)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Moto de reparto" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**El reparto en moto** normalmente lleva productos farmacéuticos a un hospital/una clínica.\n" +
                    "**100% = 0.1t** (vanilla)\n" +
                    "**500% = 0.5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Restablecer reparto" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Devuelve los deslizadores de reparto a **100%** (valor predeterminado del juego / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Vehículos totales por instalación" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Vehículos totales: estaciones de carga" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Máximo de vehículos de carga activos para cada **puerto de carga, terminal ferroviaria y aeropuerto**.\n" +
                    "**1×** = vanilla, **5×** = 5 veces más." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)), "Ajustar camiones industriales" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableCompanyTruckControl)),
                    "Para compatibilidad con otros mods,\n" +
                    "- usa DESACTIVADO si prefieres que otro mod controle el total de camiones de las mismas empresas industriales.\n" +
                    "<[x] ACTIVADO por defecto>.\n" +
                    "Déjalo ACTIVADO para usar los tres deslizadores siguientes y ajustar el total de camiones.\n" +
                    "DESACTIVAR restaura esas tres categorías a los valores del juego y oculta los deslizadores.\n" +
                    "Si prefieres los deslizadores de este mod, comprueba si el otro mod puede desactivar sus propios números de camiones."
                     },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Camiones totales: extractores" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Máximo de camiones para cada empresa extractora.\n" +
                    "Incluye agricultura, silvicultura, pesca, petróleo, mineral, carbón, piedra, algodón, ganado y verduras.\n" +
                    "**1×** = vanilla, **5×** = 5 veces más." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)), "Camiones totales: almacenes" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.WarehouseMaxTrucksScalar)),
                    "Máximo de camiones para cada empresa de almacén.\n" +
                    "Incluye todos los tipos de recursos de almacén que tienen vehículos propios.\n" +
                    "**1×** = vanilla, **5×** = 5 veces más." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)), "Camiones totales: industria" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.IndustryMaxTrucksScalar)),
                    "Máximo de camiones para empresas de procesamiento industrial.\n" +
                    "No incluye extractores, almacenes, estaciones de carga, empresas comerciales ni empresas de oficinas.\n" +
                    "**1×** = vanilla, **5×** = 5 veces más." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Restablecer todos los vehículos industriales" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Restablece los deslizadores de estaciones de carga, extractores, almacenes e industria a **1×** (valores vanilla).\n" +
                    "El interruptor de control de camiones de empresa permanece ACTIVADO o DESACTIVADO según lo elegido." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Mantenimiento de parques" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Capacidad del turno de trabajo" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Multiplicador para la **capacidad del turno de trabajo** (capacidad del vehículo).\n" +
                    "Trabajo total que puede hacer un camión antes de volver al edificio.\n" +
                    "Piénsalo así: más suministros = permanece fuera más tiempo." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Ritmo del vehículo" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "Multiplicador para la **tasa de trabajo del vehículo**.\n" +
                    "Tasa = cuánto trabajo hace por tick de simulación mientras está parado." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Tamaño de flota del depósito" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Multiplicador para los **vehículos máximos** del edificio depósito.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Restablecer mantenimiento de parques" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Restablece todos los valores a **100%** (valor predeterminado del juego / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Mantenimiento de carreteras" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Tamaño de flota del depósito" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Multiplicador para los **vehículos máximos del depósito** por edificio.\n" +
                    "Más alto = más camiones.\n" +
                    "<Nota de equilibrio: demasiado pocos o demasiados pueden perjudicar el tráfico.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Capacidad del turno de trabajo" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Multiplicador para la **capacidad del turno de trabajo**.\n" +
                    "Trabajo total que puede hacer un camión antes de volver al depósito.\n" +
                    "**Más alto = menos regresos** necesarios al edificio principal. Más eficiente." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Tasa de reparación" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "Tasa = cuánto trabajo hace por tick de simulación mientras está parado.\n" +
                    "Los camiones aún hacen una parada+avance rápido incluso con la tasa más alta; simplemente hacen más trabajo por parada.\n" +
                    "En vanilla, una sola parada no necesariamente deja la carretera al 100% de reparación, así que esta función mejora con el tiempo.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Desgaste de carreteras" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Función beta>\n" +
                    "Controla qué tan rápido se deterioran las carreteras por factores de **tiempo y tráfico**.\n" +
                    "**10%** = desgaste 10× más lento (se necesitan menos reparaciones)\n" +
                    "**100%** = vanilla\n" +
                    "**500%** = daño 5× más rápido (se necesitan más reparaciones/camiones)\n" +
                    "Cómo funciona en el juego:\n" +
                    "Si el factor m_Wear <= 2.5, no hay ralentización.\n" +
                    "Si m_Wear >= 17.5, penalización máxima, los vehículos son 50% más lentos en las carreteras.\n" +
                    "Ver infovista de carreteras: muestra en rojo las carreteras muy dañadas que ralentizan a los vehículos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Restablecer mantenimiento de carreteras" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Devuelve todos los valores a **100%** (valor predeterminado del juego / vanilla)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Enlaces de soporte" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Depuración / Registro" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Nombre mostrado de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Versión actual del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Abre el sitio web de Paradox Mods para los mods del autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Abre el Discord de la comunidad en un navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Informe de escaneo (prefabs)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Crea un informe <único> para depuración.\n" +
                    "No es necesario para una partida normal.\n" +
                    "Ubicación del archivo: <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Consejo: haz clic <una vez>; si el estado muestra Hecho, usa <Abrir carpeta de informes>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "Estado del escaneo de prefabs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Muestra el estado del escaneo: Inactivo / En cola / En curso / Hecho / Sin datos.\n" +
                    "En cola/En curso muestra el tiempo transcurrido; Hecho muestra la duración y la hora de finalización." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Registros debug detallados" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Envía detalles adicionales a <AllTransitTrucks.log> para solucionar problemas.\n" +
                    "**Desactivar** para una partida normal.\n" +
                    "<Esto solo aumenta el registro y no cambia los valores de juego.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Abrir carpeta de logs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Abre la carpeta de logs.\n" +
                    "Siguiente: abrir <AllTransitTrucks.log> con el editor de texto (se recomienda Notepad++)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Abrir carpeta de informes" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Abre la carpeta de informes.\n" +
                    "Siguiente: abrir <ScanReport-Prefabs.txt> con el editor de texto (por ejemplo, Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Inactivo" },
                { "PWP_SCAN_QUEUED_FMT", "En cola ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "En curso ({0})" },
                { "PWP_SCAN_DONE_FMT", "Hecho ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Falló" },
                { "PWP_SCAN_FAIL_NO_CITY", "Cargar ciudad primero" },
                { "PWP_SCAN_UNKNOWN_TIME", "hora desconocida" },

            };
        }

        public void Unload( )
        {
        }
    }
}
