using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityPhysics.Helpers
{
    public static class ExtensionMethods
    {
        public static Int64 ConvertUp(this Int64 val)
        {
            return val * (Int64)Math.Pow(1, 34);
        }
        public static decimal ConvertBack(this Int64 val)
        {
            return (decimal)val * (decimal)Math.Pow(1, -34);
        }
    }

}
