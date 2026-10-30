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
        public const double Tolerance = 0.5;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Compares two double values and returns true if they are within 0.5% of each other
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool WithinTolerance(double a, double b)
        {
            //basic check.
            if (a == b)
                return true;

            double diff = Math.Abs(a - b);

            double highest = Math.Max(Math.Abs(a), Math.Abs(b));

            double percentOff = (diff / highest) * 100;

            return percentOff < Tolerance;
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