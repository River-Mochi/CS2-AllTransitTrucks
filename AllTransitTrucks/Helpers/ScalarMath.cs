// <copyright file="ScalarMath.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Helpers/ScalarMath.cs
// Purpose: Centralized clamping + scaling helpers to keep math consistent across systems.
// Notes:
// - Rounds to int (AwayFromZero) so slider results feel stable.
// - AllowZero scaling returns 0 only when base value is <= 0.

namespace PublicWorksPlus
{
    using System;
    using Unity.Mathematics;

    internal static class ScalarMath
    {
        internal static float PercentToScalarClamped(float percent, float minPercent, float maxPercent)
        {
            percent = SanitizeFinite(percent);
            percent = math.clamp(percent, minPercent, maxPercent);
            return percent / 100f;
        }

        internal static float ClampScalar(float scalar, float minScalar, float maxScalar)
        {
            scalar = SanitizeFinite(scalar);
            return math.clamp(scalar, minScalar, maxScalar);
        }

        internal static int ScaleIntRoundedMin1(int baseValue, float scalar)
        {
            int basePositive = math.max(baseValue, 1);

            float s = SanitizeFinite(scalar);
            if (s < 0f) s = 0f;

            double raw = basePositive * (double)s;
            if (raw >= int.MaxValue)
                return int.MaxValue;

            int v = (int)Math.Round(raw, MidpointRounding.AwayFromZero);
            if (v < 1) v = 1;

            return v;
        }

        internal static int ScaleIntRoundedAllowZeroMin1(int baseValue, float scalar)
        {
            if (baseValue <= 0)
                return 0;

            float s = SanitizeFinite(scalar);
            if (s < 0f) s = 0f;

            double raw = baseValue * (double)s;
            if (raw >= int.MaxValue)
                return int.MaxValue;

            int v = (int)Math.Round(raw, MidpointRounding.AwayFromZero);
            if (v < 1) v = 1;

            return v;
        }

        private static float SanitizeFinite(float v)
        {
            if (math.isnan(v) || math.isinf(v))
                return 0f;

            return v;
        }
    }
}
