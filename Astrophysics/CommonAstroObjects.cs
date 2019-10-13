using UniversityPhysics.Maths;
using static UniversityPhysics.UnitsAndConstants.Constants;

namespace UniversityPhysics.Astrophysics
{
    public static class CommonAstroObjects
    {
        #region Public Fields

        public static GravitationalBody Earth = new GravitationalBody(AstrophysicalConstants.Earth_Radius, AstrophysicalConstants.Earth_Mass)
        {
            Rotation = new Vector(0, 0, 7.292E-5),
        };

        public static GravitationalBody Sol = new GravitationalBody(AstrophysicalConstants.Solar_Radius, AstrophysicalConstants.Solar_Mass)
        {
            Rotation = MathsHelpers.DayLengthToRotation(AstrophysicalConstants.Solar_Radius, 25.38, Enums.TimeMeasure.Day)
        };

        #endregion Public Fields
    }
}