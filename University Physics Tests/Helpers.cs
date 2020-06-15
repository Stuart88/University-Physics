using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics_Tests
{
    public static class Helpers
    {
        #region Public Fields

        /// <summary>
        /// Percentage of allowed difference when accounting for floating point errors
        /// </summary>
        public const double tolerance = 0.5;

        #endregion Public Fields

        // percent

        #region Public Methods

        public static bool WithinTolerance(double result, double expected)
        {
            //basic check. Necessary for case where result == expected == 0
            if (result == expected)
                return true;

            //force both into positive values, so 'highest' (below) is not 0;
            //necessary to prevent DivideByZero issue when dividing be 'highest'
            result = Math.Abs(result);
            expected = Math.Abs(expected);

            double highest = Math.Max(result, expected);

            double diff = Math.Abs(result - expected);

            double percentOff = ((diff / highest) * 100);

            return percentOff < tolerance;
        }

        public static bool WithinTolerance(Vector result, Vector expected)
        {
            return WithinTolerance(result.X, expected.X)
                && WithinTolerance(result.Y, expected.Y)
                && WithinTolerance(result.Z, expected.Z);
        }

        #endregion Public Methods
    }
}