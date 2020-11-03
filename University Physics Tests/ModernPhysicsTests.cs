using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPhysics.Maths;
using UniversityPhysics.ModernPhysics;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class ModernPhysicsTests
    {
        [TestMethod]
        public void TestComptonScatter()
        {
            ComptonScatter scatter = new ComptonScatter(0.24E-9);

            var result = scatter.PerformScatter(MathsHelpers.ToRadians(60));

            Assert.IsTrue(MathsHelpers.WithinTolerance(result.ResultantPhotonWavelength, 0.2412E-9));
            Assert.IsTrue(MathsHelpers.WithinTolerance(result.ResultantPhotonEnergy.ElectronVolts, 5141));
            Assert.IsTrue(MathsHelpers.WithinTolerance(result.IncidentPhotonEnergy.ElectronVolts, 5167));
            Assert.IsTrue(MathsHelpers.WithinTolerance(result.ElectronEnergy.ElectronVolts, 26));
            Assert.IsTrue(MathsHelpers.WithinTolerance(result.ElectronAngle, MathsHelpers.ToRadians(59.7)));
        }
    }
}
