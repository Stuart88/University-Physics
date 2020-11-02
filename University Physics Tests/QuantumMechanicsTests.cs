using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPhysics.QuantumMechanics;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class QuantumMechanicsTests
    {
        [TestMethod]
        public void TestQuantumTunnel()
        {
            // NOTE - this fails due to floating point innacuracy with very small numbers...

            //Taken from University Physics example 40.7

            QuantumTunnel tunnel = new QuantumTunnel(new Energy(5, UniversityPhysics.Enums.EnergyMeasure.eV), new Energy(2, UniversityPhysics.Enums.EnergyMeasure.eV), 1E-9, Constants.Common.M_e);

            Assert.IsTrue(UniversityPhysics.Maths.MathsHelpers.WithinTolerance(tunnel.TunnelProbability, 7.1E-8));

            tunnel.BarrierWidth = 0.5E-9;

            Assert.IsTrue(UniversityPhysics.Maths.MathsHelpers.WithinTolerance(tunnel.TunnelProbability, 5.2E-4));
        }
    }
}
