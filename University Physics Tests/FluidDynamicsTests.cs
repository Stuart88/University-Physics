using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPhysics.UnitsAndConstants;
using UniversityPhysics.FluidDynamics;
using UniversityPhysics.PhysicsObjects;
using UniversityPhysics.Maths;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class FluidDynamicsTests
    {
        #region Public Methods

        [TestMethod]
        public void TestVelocityField()
        {
            ///Shear Flow
            ///(-U(y - height) ,0)

            VelocityField stream = CommonVelocityFields.UniformStream;
            CommonVelocityFields.FlowStrength = 3;

            Particle p = new Particle(5, new Vector(5, 5));

            p.ApplyVelocityField(stream);

            p.Move(5);
            Vector result = p.Position;

            //flow strength 3, so should move 15 in x direction
            Vector expected = new Vector(20, 5);

            Assert.AreEqual(expected, result);
        }

        #endregion Public Methods
    }
}