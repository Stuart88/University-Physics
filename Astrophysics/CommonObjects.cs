using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;
using UniversityPhysics.UnitsAndConstants;
using static UniversityPhysics.UnitsAndConstants.Constants;

namespace UniversityPhysics.Astrophysics
{
    public static class CommonObjects
    {
        public static GravitationalBody Earth = new GravitationalBody()
        {
            Mass = AstrophysicalConstants.Earth_Mass,
            Radius = AstrophysicalConstants.Earth_Radius,
            Charge = 0,
            Rotation = new Vector(0, 0, 7.292E-5),
        };

        public static GravitationalBody Sol = new GravitationalBody()
        {
            Mass = AstrophysicalConstants.Sun_Mass,
            Radius = AstrophysicalConstants.Sun_Radius,
            Charge = 0,
            Rotation = MathsHelpers.DayLengthToRotation(AstrophysicalConstants.Sun_Radius, 25.38, Enums.TimeMeasure.Day)
        };



    }
}
