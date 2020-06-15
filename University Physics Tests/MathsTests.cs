using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class MathsTests
    {
      
        #region Public Methods

        [TestMethod]
        public void TestToDegrees()
        {
            double angleRads = Math.PI;
            double result = MathsHelpers.ToDegrees(angleRads);
            double expected = 180;

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        [TestMethod]
        public void TestToRadians()
        {
            double angleDegrees = 45;
            double result = MathsHelpers.ToRadians(angleDegrees);
            double expected = Math.PI / 4;

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        #endregion Public Methods
    }
}