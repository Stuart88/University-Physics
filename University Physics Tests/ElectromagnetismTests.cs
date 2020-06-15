using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniversityPhysics.Electromagnetism;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class ElectromagnetismTests
    {
        #region Public Methods

        [TestMethod]
        public void TestElectricField()
        {
            PointCharge p = new PointCharge(-8.0E-9);

            Vector result = p.ElectricFieldAtPoint(new Vector(1.2, -1.6)).DecimalPoints(0);

            //University Physics page 702
            Vector expected = new Vector(-11, 14);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestElectricForce()
        {
            PointCharge p = new PointCharge(-8.0E-9);
            PointCharge q = new PointCharge(-6.0E-9, new Vector(1.2, -1.6));

            Vector result = p.ElectricForceOn(q).DecimalPoints(0);

            //Based on TestElectricField() above.
            Vector expected = new Vector(-11, 14) * (-6.0E-9) * Math.Sign(q.Charge);

            Assert.AreEqual(expected, result);
        }

        #endregion Public Methods
    }
}