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
            /// Taken from University Physics example 40.7
            ///
            /// Q: A 2.0-eV electron encounters a barrier 5.0 eV high. What is the
            /// probability that it will tunnel through the barrier if the barrier
            /// width is 
            /// (a) 1.00 nm
            /// (b) 0.50 nm
            ///
            /// A: 
            /// (a): 7.1E-8
            /// (b): 5.2E-4

            // NOTE the assertions below appear off from the textbook answers above because the textbook uses heavy rounding throughout, whereas
            // here more precision is used, which results in a different but MORE CORRECT result.

            double expectedProbability;

            QuantumTunnel tunnel = new QuantumTunnel(new Energy(5, UniversityPhysics.Enums.EnergyMeasure.eV), new Energy(2, UniversityPhysics.Enums.EnergyMeasure.eV), 1E-9, Constants.Common.M_e);

            tunnel.BarrierWidth = 1E-9; // 1.00 nm
            expectedProbability = 7.5869404246261792E-08;

            Assert.AreEqual(expectedProbability, tunnel.TunnelProbability);

            tunnel.BarrierWidth = 0.5E-9; // 0.50 nm
            expectedProbability = 0.00053975782746120988;

            Assert.AreEqual(expectedProbability, tunnel.TunnelProbability);

        }
    }
}
