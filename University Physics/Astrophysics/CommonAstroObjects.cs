using UniversityPhysics.Maths;
using static UniversityPhysics.UnitsAndConstants.Constants;

namespace UniversityPhysics.Astrophysics
{
    public static class CommonAstroObjects
    {
        #region Public Fields

        public static GravitationalBody Earth = new GravitationalBody(AstrophysicalConstants.Earth_Radius, AstrophysicalConstants.Earth_Mass)
        {
            AngularVelocity = new Vector(0, 0, 7.292E-5),
        };

        public static GravitationalBody Sol = new GravitationalBody(AstrophysicalConstants.Solar_Radius, AstrophysicalConstants.Solar_Mass)
        {
            AngularVelocity = MathsHelpers.DayLengthToRotation(AstrophysicalConstants.Solar_Radius, 25.38, Enums.TimeMeasure.Day)
        };

        public static GravitationalBody TheMoon = new GravitationalBody(AstrophysicalConstants.Lunar_Radius, AstrophysicalConstants.Lunar_Mass)
        {
            AngularVelocity = new Vector(0, 0, 2.7E-6),
        };

        #endregion Public Fields
    }
}