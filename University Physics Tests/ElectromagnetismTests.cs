using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniversityPhysics.Electromagnetism;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;
using UniversityPhysics.UnitsAndConstants;

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

            Vector result = p.ElectricForceOn(q);

            // Calculate expected result independently using Coulomb's law, derived independently of PointCharge objects under test:
            // F = k * q_p * q_q / r^2
            double r = p.Position.DistanceTo(q.Position);
            Vector direction = (q.Position - p.Position).Normalised();
            Vector expected = (Constants.Common.K_Coulomb * p.Charge * q.Charge / Math.Pow(r, 2)) * direction;


            Assert.AreEqual(expected, result);
        }

        #endregion Public Methods
    }
}