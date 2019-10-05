using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UniversityPhysics.Helpers
{
    public static class ExtensionMethods
    {
        public static double DecimalPoints(this double d, int points)
        {
            double scale = Math.Pow(10, points);
            d = d * scale;
            d = Math.Round(d);

            return d / scale;

        }  
    }
}
