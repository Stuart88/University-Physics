using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPhysics.Astrophysics;
using UniversityPhysics.Enums;
using UniversityPhysics.Helpers;
using UniversityPhysics.Maths;
using static UniversityPhysics.UnitsAndConstants.Constants;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class AstrophysicsTests
    {
        #region Public Methods

        [TestMethod]
        public void TestDayLengthToRotation()
        {
            Vector result = MathsHelpers.DayLengthToRotation(AstrophysicalConstants.Earth_Radius, 24, TimeMeasure.Hour);

            Vector expected = CommonAstroObjects.Earth.AngularVelocity;

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        [TestMethod]
        public void TestEscapeVelocity()
        {
            double result = CommonAstroObjects.Earth.EscapeVelocity;
            double expected = 11186;

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        [TestMethod]
        public void TestGravityAtSurface()
        {
            GravitationalBody earth = new GravitationalBody(
                radius: AstrophysicalConstants.Earth_Radius,
                mass: AstrophysicalConstants.Earth_Mass)
            {
                Position = new Vector()
            };

            double result = earth.GravityAtSurface;
            double expected = 9.81;

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        [TestMethod]
        public void TestGravityBetweenBodies()
        {
            GravitationalBody earth = CommonAstroObjects.Earth;

            GravitationalBody human = TestObjects.Human;
            human.Position = new Vector(AstrophysicalConstants.Earth_Radius + 1.5, 0, 0);

            Vector result = earth.GravitationalForceToward(human);

            Vector expected = new Vector(human.Mass * 9.81, 0, 0);

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        [TestMethod]
        public void TestOrbitPeriodAtDistance()
        {
            //earth orbit period around sun
            double result = CommonAstroObjects.Sol.OrbitPeriodAtDistance(AstrophysicalConstants.AU, TimeMeasure.Year);
            double expected = 1;//year

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));

            //moon orbit period around earth
            double result2 = CommonAstroObjects.Earth.OrbitPeriodAtDistance(384399861, TimeMeasure.Day);
            double expected2 = 27.32;//days

            Assert.IsTrue(Helpers.WithinTolerance(result2, expected2));
        }

        [TestMethod]
        public void TestRotationPeriod()
        {
            double result = CommonAstroObjects.Earth.RotationPeriod(
                axis: Axis_Cartesian.Z,
                timeMeasure: TimeMeasure.Hour);

            double expected = 24;

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        #endregion Public Methods
    }
}