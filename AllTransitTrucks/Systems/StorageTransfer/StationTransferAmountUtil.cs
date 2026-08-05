// <copyright file="StationTransferAmountUtil.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/StorageTransfer/StationTransferAmountUtil.cs
// Purpose: Find a safe selectable truck capacity for live requests.

namespace PublicWorksPlus
{
    using Game.Economy;
    using Game.Prefabs;

    internal static class StationTransferAmountUtil
    {
        internal static bool IsEligibleOutgoingCarRequest(Game.Companies.StorageTransferFlags flags)
        {
            return (flags & Game.Companies.StorageTransferFlags.Incoming) == 0 &&
                   (flags & Game.Companies.StorageTransferFlags.Car) != 0;
        }

        internal static bool TryGetSafeSelectedTruckCapacity(
            DeliveryTruckSelectData truckSelectData,
            Resource resource,
            int requestedAmount,
            out int selectedCapacity)
        {
            selectedCapacity = 0;

            if (resource == Resource.NoResource || requestedAmount <= 0)
            {
                return false;
            }

            truckSelectData.GetCapacityRange(resource, out int minCapacity, out int maxCapacity);
            if (maxCapacity <= 0)
            {
                return false;
            }

            Unity.Mathematics.Random random = CreateProbeRandom(resource, requestedAmount);

            if (truckSelectData.TrySelectItem(
                    ref random,
                    resource,
                    requestedAmount,
                    out DeliveryTruckSelectItem item) &&
                item.m_Capacity > 0)
            {
                selectedCapacity = item.m_Capacity;
                return true;
            }

            // Better to under-promote than exceed a selectable truck.
            selectedCapacity = minCapacity;
            return selectedCapacity > 0;
        }

        internal static bool TryPromoteToAtLeastOneFullTruck(
            DeliveryTruckSelectData truckSelectData,
            Resource resource,
            int originalAmount,
            out int adjustedAmount)
        {
            adjustedAmount = originalAmount;

            if (originalAmount <= 0 || resource == Resource.NoResource)
            {
                return false;
            }

            if (!TryGetSafeSelectedTruckCapacity(
                    truckSelectData,
                    resource,
                    originalAmount,
                    out int safeCapacity))
            {
                return false;
            }

            if (originalAmount >= safeCapacity)
            {
                return false;
            }

            adjustedAmount = safeCapacity;
            return true;
        }

        private static Unity.Mathematics.Random CreateProbeRandom(
            Resource resource,
            int requestedAmount)
        {
            // Resource uses ulong underneath; direct cast avoids boxing.
            ulong raw = (ulong)resource;
            uint seed =
                (uint)raw ^
                (uint)(raw >> 32) ^
                (uint)requestedAmount ^
                0x9E3779B9u;

            seed ^= seed << 13;
            seed ^= seed >> 17;
            seed ^= seed << 5;

            return new Unity.Mathematics.Random(seed == 0 ? 1u : seed);
        }
    }
}
