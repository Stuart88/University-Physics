using System;

namespace UniversityPhysics.Helpers
{
    public static class ExtensionMethods
    {
        #region Public Methods

        public static double DecimalPoints(this double d, int points)
        {
            double scale = Math.Pow(10, points);
            d = d * scale;
            d = Math.Round(d);

            return d / scale;
        }

        #endregion Public Methods

    }
}