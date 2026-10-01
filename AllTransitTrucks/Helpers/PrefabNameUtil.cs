// <copyright file="PrefabNameUtil.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Helpers/PrefabNameUtil.cs
// Purpose: name lookup (string). One place for safe prefab name lookup.
// Notes:
// - Logs exception only once (rare, but keeps logs clean).
// - Returns a stable fallback string if name can't be resolved.

namespace PublicWorksPlus
{
    using CS2Shared.RiverMochi;
    using Game.Prefabs;
    using System;
    using Unity.Entities;

    internal static class PrefabNameUtil
    {
        private static bool s_LoggedOnce;

        internal static string GetNameSafe(PrefabSystem prefabSystem, Entity prefabEntity)
        {
            if (prefabEntity == Entity.Null)
                return "(null prefab)";

            if (prefabSystem == null)
                return $"PrefabEntity={prefabEntity.Index}:{prefabEntity.Version}";

            try
            {
                if (prefabSystem.TryGetPrefab(prefabEntity, out PrefabBase prefabBase))
                {
                    return prefabBase.name ?? "(unnamed)";
                }
            }
            catch (Exception ex)
            {
                if (!s_LoggedOnce)
                {
                    s_LoggedOnce = true;
                    LogUtils.Warn(Mod.s_Log, () => $"{Mod.ModTag} PrefabNameUtil.GetNameSafe failed once: {ex.GetType().Name}: {ex.Message}");
                }
            }

            return $"PrefabEntity={prefabEntity.Index}:{prefabEntity.Version}";
        }
    }
}
