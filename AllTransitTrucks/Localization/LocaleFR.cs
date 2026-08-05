// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
// French (fr-FR) strings for Options UI.

namespace PublicWorksPlus
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly ATTSettings m_Setting;

        public LocaleFR(ATTSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(ATTSettings.PublicTransitTab), "Transports publics" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.IndustryTab),      "Industrie" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.ParksRoadsTab),    "Parcs-Routes" },
                { m_Setting.GetOptionTabLocaleID(ATTSettings.AboutTab),         "À propos" },

                // --------------------
                // Public-Transit tab
                // --------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.LineVehiclesGroup), "Lignes de transport (plage du curseur en jeu)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)), "Étendre le min/max des lignes de transport" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableLineVehicleCountTuner)),
                    "Augmente la **plage** du curseur des lignes de transport en jeu pour chaque itinéraire.\n" +
                    "**Jusqu’à (1)** sur tous les itinéraires testés.\n" +
                    "La **limite maximale varie** ; mais toutes sont 3× ou plus au-dessus du vanilla.\n" +
                    "Note technique : le jeu utilise le temps d’itinéraire (temps de conduite + nombre d’arrêts) ; cela crée un maximum variable (ce mod suit la logique du jeu et ne définit donc pas de limite maximale statique comme 200).\n" +
                    "Fonctionne pour tous les transports : bus, ferry, tram, train, métro, navire, avion.\n\n" +
                    "**---------------**\n" +
                    "Astuce : si le maximum du curseur doit être encore un peu plus élevé, ajouter quelques arrêts à l’itinéraire.\n" +
                    "Le jeu augmente automatiquement le maximum selon les arrêts ajoutés + des facteurs ; ajouter des arrêts est un ajustement simple pour le joueur.\n" +
                    "<Éviter les conflits> : retirer les mods qui modifient la même politique des lignes de transport.\n" +
                    "Désactiver si la fonctionnalité n’est pas nécessaire ou si elle doit être désactivée pour utiliser un autre mod pour la même chose."
                },

                // Depot Capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DepotGroup), "Capacité des dépôts (véhicules max par dépôt)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusDepotScalar)), "Dépôt de bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusDepotScalar)),
                    "Modifie combien de bus chaque **dépôt de bus** peut entretenir/générer.\n" +
                    "**100%** = vanilla (valeur par défaut du jeu).\n" +
                    "**1000%** = 10× plus.\n" +
                    "S’applique au bâtiment de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryDepotScalar)), "Dépôt de ferry" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryDepotScalar)),
                    "**Dépôt de ferry** : véhicules max par bâtiment.\n" +
                    "**100%** = vanilla (valeur par défaut du jeu).\n" +
                    "S’applique au bâtiment de base."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayDepotScalar)), "Dépôt de métro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayDepotScalar)),
                    "Modifie combien de véhicules de métro chaque **dépôt de métro** peut entretenir.\n" +
                    "S’applique au bâtiment de base."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TaxiDepotScalar)), "Dépôt de taxis" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TaxiDepotScalar)),
                    "Combien de taxis chaque **dépôt de taxis** peut entretenir.\n" +
                    "Si réglé au maximum, cela pourrait provoquer une quantité excessive et comique de taxis."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramDepotScalar)), "Dépôt de tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramDepotScalar)),
                    "Modifie combien de trams chaque **dépôt de tram** peut entretenir.\n" +
                    "S’applique au bâtiment de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainDepotScalar)), "Dépôt de train" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainDepotScalar)),
                    "Modifie combien de trains chaque **dépôt de train** peut entretenir.\n" +
                    "S’applique au bâtiment de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)), "Réinitialiser les dépôts" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDepotToVanillaButton)),
                    "Remet tous les curseurs des dépôts à **100%** (valeur par défaut du jeu / vanilla)." },

                // Passenger capacity sliders
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.PassengerGroup), "Capacité passagers (max personnes par véhicule)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.BusPassengerScalar)), "Bus" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.BusPassengerScalar)),
                    "Modifie la capacité de **passagers des bus**.\n" +
                    "**10%** = 10% des places vanilla.\n" +
                    "**100%** = places vanilla (valeur par défaut du jeu).\n" +
                    "**1000%** = 10× plus de places." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TramPassengerScalar)), "Tram" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TramPassengerScalar)),
                    "Modifie la capacité de **passagers des trams**.\n" +
                    "**10%** = 10% des places vanilla.\n" +
                    "**100%** = places vanilla (valeur par défaut du jeu).\n" +
                    "**1000%** = 10× plus de places." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.TrainPassengerScalar)), "Train" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.TrainPassengerScalar)),
                    "Modifie la capacité de **passagers des trains**.\n" +
                    "S’applique aux locomotives et aux sections.\n" +
                    "**10%** = 10% des places vanilla.\n" +
                    "**100%** = places vanilla (valeur par défaut du jeu).\n" +
                    "**1000%** = 10× plus de places." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SubwayPassengerScalar)), "Métro" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SubwayPassengerScalar)),
                    "Modifie la capacité de **passagers du métro**.\n" +
                    "**10%** = 10% des places vanilla.\n" +
                    "**100%** = places vanilla (valeur par défaut du jeu).\n" +
                    "**1000%** = 10× plus de places." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ShipPassengerScalar)), "Navire" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ShipPassengerScalar)),
                    "Modifie la capacité des **navires à passagers** (pas des cargos).\n" +
                    "**100%** = places vanilla (valeur par défaut du jeu)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.FerryPassengerScalar)), "Ferry" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.FerryPassengerScalar)),
                    "Modifie la capacité de **passagers des ferries**.\n" +
                    "**10%** = 10% des places vanilla.\n" +
                    "**100%** = places vanilla (valeur par défaut du jeu).\n" +
                    "**1000%** = 10× plus de places." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.AirplanePassengerScalar)), "Avion" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.AirplanePassengerScalar)),
                    "Modifie la capacité de **passagers des avions**.\n" +
                    "**10%** = 10% des places vanilla.\n" +
                    "**100%** = places vanilla (valeur par défaut du jeu).\n" +
                    "**1000%** = 10× plus de places." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DoublePassengersButton)), "Doubler" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DoublePassengersButton)),
                    "Règle chaque curseur passagers sur **200%**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)), "Réinitialiser tous les passagers" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetPassengerToVanillaButton)),
                    "Remet tous les curseurs passagers à **100%**\n" +
                    "(valeur par défaut du jeu / vanilla)." },

                // ----------------
                // INDUSTRY tab
                // ----------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DeliveryGroup), "Véhicules de livraison (capacité de charge)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)), "Semi-remorques" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.SemiTruckCargoScalar)),
                    "Capacité des **semi-remorques**.\n" +
                    "**100% = 25t** (vanilla)\n" +
                    "**500% = 125t**.\n" +
                    "Comprend :\n" +
                    " - Semi-remorques d’industrie spécialisée (fermes, pêche, foresterie, etc.).\n" +
                    "Remarque : inclut les semi-remorques transportant du courrier vers/depuis les gares de fret.\n" +
                    "Ce n’est pas la même chose que la distribution locale du courrier."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)), "Fourgonnettes de livraison" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.DeliveryVanCargoScalar)),
                    "**Fourgonnettes de livraison**\n" +
                    "**100% = 4t** (vanilla)\n" +
                    "**500% = 20t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CoalTruckScalar)), "Camions de matières premières" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CoalTruckScalar)),
                    "**Camions de matières premières** (pétrole, charbon, minerai, pierre, camions-bennes pour déchets industriels - même type de camion partagé)\n" +
                    "**100% = 20t** (vanilla)\n" +
                    "**500% = 100t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)), "Moto de livraison" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.MotorbikeDeliveryCargoScalar)),
                    "**La livraison à moto** transporte généralement des produits pharmaceutiques vers un hôpital/une clinique.\n" +
                    "**100% = 0.1t** (vanilla)\n" +
                    "**500% = 0.5t**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)), "Réinitialiser les livraisons" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetDeliveryToVanillaButton)),
                    "Remet les curseurs de livraison à **100%** (valeur par défaut du jeu / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.CargoStationsGroup), "Flotte de fret (port, train, aéroport)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)), "Flotte max des gares de fret" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.CargoStationMaxTrucksScalar)),
                    "Modifie le maximum de transporteurs actifs des **stations de transport de fret**.\n" +
                    "**1×** = vanilla, **5×** = 5× plus." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)), "Flotte des extracteurs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ExtractorMaxTrucksScalar)),
                    "Modifie le **nombre max de camions** des extracteurs industriels.\n" +
                    "(fermes, pêche, foresterie, minerai, pétrole, charbon, pierre).\n" +
                    "**1×** = vanilla\n" +
                    "**5×** = 5 fois plus.\n" +
                    "Le vanilla autorise généralement 5 camions par bâtiment extracteur."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)), "Réinitialiser fret + extracteurs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetCargoStationsToVanillaButton)),
                    "Remet les multiplicateurs des gares de fret + extracteurs à **1×** (valeur par défaut du jeu / vanilla)." },

                // -------------------
                // Parks-Roads
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.ParkMaintenanceGroup), "Entretien des parcs" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)), "Capacité du quart de travail" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Multiplicateur pour la **capacité du quart de travail** (capacité du véhicule).\n" +
                    "Travail total qu’un camion peut effectuer avant de retourner au bâtiment.\n" +
                    "En clair : plus de fournitures = reste dehors plus longtemps." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)), "Cadence du véhicule" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceVehicleRateScalar)),
                    "Multiplicateur pour la **cadence de travail du véhicule**.\n" +
                    "Cadence = quantité de travail effectuée par tick de simulation à l’arrêt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)), "Taille de flotte du dépôt" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ParkMaintenanceDepotScalar)),
                    "Multiplicateur pour les **véhicules maximum** du bâtiment dépôt.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)), "Réinitialiser l’entretien des parcs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetParkMaintenanceToVanillaButton)),
                    "Remet toutes les valeurs à **100%** (valeur par défaut du jeu / vanilla)." },

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.RoadMaintenanceGroup), "Entretien des routes" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)), "Taille de flotte du dépôt" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceDepotScalar)),
                    "Multiplicateur pour les **véhicules maximum du dépôt** par bâtiment.\n" +
                    "Plus élevé = plus de camions.\n" +
                    "<Note d’équilibrage : trop peu ou trop peuvent nuire au trafic.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)), "Capacité du quart de travail" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Multiplicateur pour la **capacité du quart de travail**.\n" +
                    "Travail total qu’un camion peut effectuer avant de retourner au dépôt.\n" +
                    "**Plus élevé = moins de retours** nécessaires vers le bâtiment principal. Plus efficace." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)), "Cadence de réparation" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadMaintenanceVehicleRateScalar)),
                    "Cadence = quantité de travail effectuée par tick de simulation à l’arrêt.\n" +
                    "Les camions font quand même un arrêt+repart rapide même avec la cadence la plus élevée ; ils effectuent simplement plus de travail par arrêt.\n" +
                    "En vanilla, un seul arrêt ne ramène pas forcément la route à 100% de réparation, donc cette fonctionnalité devient meilleure avec le temps.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RoadWearScalar)), "Usure des routes" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RoadWearScalar)),
                    "<Beta feature>\n" +
                    "Contrôle la vitesse de détérioration des routes selon des facteurs de **temps et de trafic**.\n" +
                    "**10%** = 10× plus lente (moins de réparations nécessaires)\n" +
                    "**100%** = vanilla\n" +
                    "**500%** = dégâts 5× plus rapides (plus de réparations/camions nécessaires)\n" +
                    "Comment cela fonctionne en jeu :\n" +
                    "Si le facteur m_Wear <= 2.5, pas de ralentissement.\n" +
                    "Si m_Wear >= 17.5, pénalité maximale, les véhicules sont 50% plus lents sur les routes.\n" +
                    "Voir l’infovue Routes : les routes très endommagées apparaissent en rouge et ralentissent les véhicules."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)), "Réinitialiser l’entretien des routes" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Remet toutes les valeurs à **100%** (valeur par défaut du jeu / vanilla)." },

                // -------------------
                // About tab
                // -------------------

                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.AboutLinksGroup), "Liens de support" },
                { m_Setting.GetOptionGroupLocaleID(ATTSettings.DebugGroup), "Débogage / Journalisation" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModNameDisplay)), "Nom d’affichage de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.ModVersionDisplay)), "Version actuelle du mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenParadoxMods)), "Ouvre le site Paradox Mods pour les mods de l’auteur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenDiscord)), "Ouvre le Discord de la communauté dans un navigateur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.RunPrefabScanButton)), "Rapport d’analyse (prefabs)" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.RunPrefabScanButton)),
                    "Crée un rapport <ponctuel> pour le débogage.\n" +
                    "Inutile pour une partie normale.\n" +
                    "Emplacement du fichier : <ModsData/AllTransitTrucks/ScanReport-Prefabs.txt>\n" +
                    "Astuce : cliquer <une fois>, puis si l’état affiche Terminé, utiliser <Ouvrir le dossier du rapport>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.PrefabScanStatus)), "État de l’analyse des prefabs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.PrefabScanStatus)),
                    "Affiche l’état de l’analyse : Idle / Queued / Running / Done / No Data.\n" +
                    "Queued/Running shows elapsed time; Done shows duration + finish time." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.EnableDebugLogging)), "Journaux debug détaillés" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.EnableDebugLogging)),
                    "Envoie des détails supplémentaires dans <AllTransitTrucks.log> pour le dépannage.\n" +
                    "**Désactiver** pour une partie normale.\n" +
                    "<Cela augmente seulement la journalisation et ne change pas les valeurs de gameplay.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenLogButton)), "Ouvrir le dossier des logs" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenLogButton)),
                    "Ouvre le dossier des logs.\n" +
                    "Ensuite : ouvrir <AllTransitTrucks.log> avec un éditeur de texte (Notepad++ recommandé)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ATTSettings.OpenReportButton)), "Ouvrir le dossier du rapport" },
                { m_Setting.GetOptionDescLocaleID(nameof(ATTSettings.OpenReportButton)),
                    "Ouvre le dossier du rapport.\n" +
                    "Ensuite : ouvrir <ScanReport-Prefabs.txt> avec un éditeur de texte (par ex. Notepad++)." },

                // ---- Scan Report Status Text (format string templates) ----
                { "PWP_SCAN_IDLE", "Idle" },
                { "PWP_SCAN_QUEUED_FMT", "Queued ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Running ({0})" },
                { "PWP_SCAN_DONE_FMT", "Done ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Échec" },
                { "PWP_SCAN_FAIL_NO_CITY", "Charger d’abord une ville" },
                { "PWP_SCAN_UNKNOWN_TIME", "heure inconnue" },

            };
        }

        public void Unload( )
        {
        }
    }
}
