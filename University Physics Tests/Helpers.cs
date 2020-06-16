using UniversityPhysics.Maths;

namespace UniversityPhysics_Tests
{
    public static class Helpers
    {

        #region Public Methods

        public static bool WithinTolerance(double a, double b)
        {
            return MathsHelpers.WithinTolerance(a, b);
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