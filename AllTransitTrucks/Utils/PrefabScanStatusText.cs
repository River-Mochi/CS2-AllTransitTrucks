// <copyright file="PrefabScanStatusText.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Utils/PrefabScanStatusText.cs
// Purpose: Builds the localized prefab scan status text.

namespace PublicWorksPlus
{
    using System;
    using Colossal.Localization;
    using Game.SceneFlow;

    public static class PrefabScanStatusText
    {
        private const string KeyIdle = "PWP_SCAN_IDLE";
        private const string KeyQueuedFmt = "PWP_SCAN_QUEUED_FMT";
        private const string KeyRunningFmt = "PWP_SCAN_RUNNING_FMT";
        private const string KeyDoneFmt = "PWP_SCAN_DONE_FMT";
        private const string KeyFailed = "PWP_SCAN_FAILED";
        private const string KeyFailNoCity = "PWP_SCAN_FAIL_NO_CITY";
        private const string KeyUnknownTime = "PWP_SCAN_UNKNOWN_TIME";

        public static string Format(PrefabScanState.Snapshot snapshot)
        {
            switch (snapshot.Phase)
            {
                case PrefabScanState.Phase.Idle:
                    return Localize(KeyIdle, "Idle");

                case PrefabScanState.Phase.Requested:
                {
                    TimeSpan elapsed = PrefabScanState.GetElapsedSinceTick(snapshot.RequestTick);
                    return string.Format(Localize(KeyQueuedFmt, "Queued ({0})"), FormatDuration(elapsed));
                }

                case PrefabScanState.Phase.Running:
                {
                    TimeSpan elapsed = PrefabScanState.GetElapsedSinceTick(snapshot.RunStartTick);
                    return string.Format(Localize(KeyRunningFmt, "Running ({0})"), FormatDuration(elapsed));
                }

                case PrefabScanState.Phase.Done:
                {
                    string duration = FormatDuration(snapshot.LastDuration);
                    string finished = snapshot.LastRunFinishedLocal == default
                        ? Localize(KeyUnknownTime, "unknown time")
                        : snapshot.LastRunFinishedLocal.ToString("yyyy-MM-dd HH:mm:ss");

                    return string.Format(Localize(KeyDoneFmt, "Done ({0} | {1})"), duration, finished);
                }

                case PrefabScanState.Phase.Failed:
                default:
                {
                    string failed = Localize(KeyFailed, "Failed");
                    string reason = snapshot.FailCode == PrefabScanState.FailCode.NoCityLoaded
                        ? Localize(KeyFailNoCity, "LOAD CITY FIRST")
                        : string.Empty;

                    if (!string.IsNullOrEmpty(snapshot.FailDetails))
                    {
                        return string.IsNullOrEmpty(reason)
                            ? $"{failed} ({snapshot.FailDetails})"
                            : $"{failed} ({reason} {snapshot.FailDetails})";
                    }

                    return string.IsNullOrEmpty(reason)
                        ? failed
                        : $"{failed} - {reason}";
                }
            }
        }

        private static string Localize(string id, string fallback)
        {
            try
            {
                LocalizationManager? manager = GameManager.instance?.localizationManager;

                if (manager?.activeDictionary != null &&
                    manager.activeDictionary.TryGetValue(id, out string result))
                {
                    return result;
                }
            }
            catch
            {
                // Status text still has an English fallback.
            }

            return fallback;
        }

        private static string FormatDuration(TimeSpan duration)
        {
            return duration.TotalHours >= 1
                ? duration.ToString(@"hh\:mm\:ss")
                : duration.ToString(@"mm\:ss");
        }
    }
}
