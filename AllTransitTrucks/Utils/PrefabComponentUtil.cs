// <copyright file="PrefabComponentUtil.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Utils/PrefabComponentUtil.cs
// Purpose: Prefab components lookup (TransportDepot, PublicTransport, etc.).
// Notes:
// - Centralizes PrefabSystem.TryGetPrefab + PrefabBase.TryGet.
// - PrefabBase.TryGet<T> requires T : ComponentBase.

namespace PublicWorksPlus
{
    using Game.Prefabs;
    using Unity.Entities;

    internal static class PrefabComponentUtil
    {
        internal static bool TryGetPrefabBase(PrefabSystem prefabSystem, Entity prefabEntity, out PrefabBase prefabBase)
        {
            prefabBase = null!;

            if (prefabSystem == null)
                return false;

            if (prefabEntity == Entity.Null)
                return false;

            return prefabSystem.TryGetPrefab(prefabEntity, out prefabBase);
        }

        internal static bool TryGetComponent<T>(PrefabSystem prefabSystem, Entity prefabEntity, out T component)
            where T : ComponentBase
        {
            component = null!;

            if (!TryGetPrefabBase(prefabSystem, prefabEntity, out PrefabBase prefabBase))
                return false;

            return prefabBase.TryGet(out component);
        }
    }
}
