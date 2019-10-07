using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.PhysicsObjects;
using static UniversityPhysics.UnitsAndConstants.Constants;
using UniversityPhysics.Maths;
using UniversityPhysics.Astrophysics;

namespace UniversityPhysics.Helpers
{
    public static class TestObjects
    {
        public static GravitationalBody Human = new GravitationalBody(1, 85);
        public static GravitationalBody KilogramBlock = new GravitationalBody(0.1, 1);
    }
}
