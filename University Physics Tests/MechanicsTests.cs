using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UniversityPhysics.Maths;
using UniversityPhysics.Mechanics;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class MechanicsTests
    {
        #region Methods

        [TestMethod]
        public void TestAccelerate()
        {
            Vector startVel = new Vector(1, 1, 1);
            Vector acceleration = new Vector(1, 0, 0);

            Particle test = new Particle(mass: 1)
            {
                Velocity = startVel
            };

            test.Accelerate(acceleration, 5);

            Vector result = test.Velocity;
            Vector expected = new Vector(6, 1, 1);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAddForce()
        {
            Particle test = new Particle(mass: 10)
            {
                Acceleration = new Vector(1, 1, 1)
            };

            test.AddForce_Translational(new Vector(5, 5, 5));

            // F = ma
            // a = m/F
            //   = 5/10
            //   = 0.5

            // original acceleration + new force = 1 + 0.5 = 1.5

            Vector result = test.Acceleration;
            Vector expected = new Vector(1.5, 1.5, 1.5);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCentreOfGravity()
        {
            Particle[] P_Array = new Particle[]
            {
                new Particle(1, new Vector(0,0,0)),
                new Particle(1, new Vector(0,1,0)),
                new Particle(1, new Vector(1,1,0)),
                new Particle(1, new Vector(1,0,0)),
            };

            Vector result = P_Array.CentreOfMass();
            Vector expected = new Vector(0.5, 0.5, 0);

            Assert.AreEqual(result, expected);

            List<Particle> P_List = new List<Particle>()
           {
                new Particle(position: new Vector(0,0,0), mass: 1),
                new Particle(position: new Vector(0,1,0), mass: 1),
                new Particle(position: new Vector(1,0,0), mass: 1),
                new Particle(position: new Vector(1,1,0), mass: 1),
           };

            Vector result2 = P_List.CentreOfMass();
            Vector expected2 = new Vector(0.5, 0.5, 0);

            Assert.AreEqual(result2, expected2);
        }

        [TestMethod]
        public void TestDistanceBetweenObjects()
        {
            Particle obj1 = new Particle(mass: 1)
            {
                Position = new Vector(-1, -1, -1)
            };
            Particle obj2 = new Particle(mass: 1)
            {
                Position = new Vector(2, 2, 2)
            };

            double result = obj1.DistanceTo(obj2);

            double expected = 5.196152422706632;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMove()
        {
            Vector startVel = new Vector(1, 1, 1);

            Particle test = new Particle(mass: 1)
            {
                Velocity = startVel
            };

            test.Move(5);

            Vector result = test.Position;
            Vector expected = new Vector(5, 5, 5);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMoveWithAcceleration()
        {
            Vector startVel = new Vector(1, 1, 1);
            Vector acceleration = new Vector(1, 0, 0);

            Particle test = new Particle(mass: 1)
            {
                Velocity = startVel,
                Acceleration = acceleration
            };

            test.Move(5);

            //s = ut + 1/2 at^2
            // = 1 * 5 + 0.5* 1 * 25
            // = 5 + 12.5
            // = 17.5
            Vector result = test.Position;
            Vector expected = new Vector(17.5, 5, 5);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObject3D_AddRotationalForce()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                //
                //  two masses about Z axis
                //
                //   5kg -------- | -------- 5kg

                new PointMass(new Vector(-5,0,0), 5),
                new PointMass(new Vector(5,0,0), 5),
            };

            Object3D obj = new Object3D(massPoints, new Vector(1, 1, 0));

            //moment of intertia = (0, 250, 250)

            //add rotational 2N force 5m from centre of mass
            //force in Z-direction, causing rotation anticlockwise about y (negative rotational direction)
            //Torque = f*d, so this is equivalent to 10Nm ===> obj.AddTorque(new Vector(5,0,0))
            obj.AddForce_OffCentre(new Vector(0, 0, 2), new Vector(5, 0, 0));

            Vector result = obj.RotationalAcceleration;

            Vector expected = new Vector(0, 10d / 250d, 0);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObject3D_AddTorque()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                //
                //  two masses about Z axis
                //
                //   5kg -------- | -------- 5kg

                new PointMass(new Vector(-5,0,0), 5),
                new PointMass(new Vector(5,0,0), 5),
            };

            Object3D obj = new Object3D(massPoints, new Vector(1, 1, 0));

            //moment of intertia = (0, 250, 250)

            //add torque on z axis

            obj.AddTorque(new Vector(0, 0, 10));

            Vector result = obj.RotationalAcceleration;

            Vector expected = new Vector(0, 0, 10d / 250d);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObject3D_CentreOfMass()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                new PointMass(new Vector(-1,-1,0), 1),
                new PointMass(new Vector(0,0,0), 1),
                new PointMass(new Vector(0,-1,0), 1),
                new PointMass(new Vector(-1,0,0), 1),
            };

            Object3D obj = new Object3D(massPoints);

            Vector result = obj.CentreOfGravity;
            Vector expected = new Vector(-0.5, -0.5, 0);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestObject3D_GetMsss()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                new PointMass(new Vector(-5,0,0), 5),
                new PointMass(new Vector(5,0,0), 5),
            };

            Object3D obj = new Object3D(massPoints);

            double mass = obj.Mass;

            Assert.AreEqual(10d, mass);
        }

        [TestMethod]
        public void TestObject3D_MomentOfInertia()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                //
                //  two masses on X axis. Will therefore have intertia about Y and Z axes.
                //
                //   5kg -------- | -------- 5kg

                new PointMass(new Vector(-5,0,0), 5),
                new PointMass(new Vector(5,0,0), 5),
            };

            Object3D obj = new Object3D(massPoints, new Vector(1, 1, 0));

            Vector result = obj.MomentOfInertia;
            Vector expected = new Vector(0, 250, 250);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObject3D_Momentum()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                //Total mass = 10kg
                new PointMass(new Vector(-5,0,0), 5),
                new PointMass(new Vector(5,0,0), 5),
            };

            Object3D obj = new Object3D(massPoints);

            obj.Velocity = new Vector(1, 0, 1);

            Vector result = obj.Momentum;
            Vector expected = new Vector(10, 0, 10);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObject3D_RotationalKineticEnergy()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                //
                //  two masses about Z axis
                //
                //   0.5kg -------- | -------- 0.5kg

                new PointMass(new Vector(-5,0,0), 5),
                new PointMass(new Vector(5,0,0), 5),
            };

            Object3D obj = new Object3D(massPoints, new Vector(1, 1, 0));

            //moment of intertia = (0, 0, 250)

            obj.Rotation = new Vector(0, 0, 10);

            Vector result = obj.KineticEnergy_Rotational;
            // = 0.5 I ω^2
            Vector expected = new Vector(0, 0, 0.5 * 250 * 10 * 10);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObject3D_WithNonZeroPosition_CentreOfMass()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                new PointMass(new Vector(1,1,0), 1),
                new PointMass(new Vector(0,0,0), 1),
                new PointMass(new Vector(0,1,0), 1),
                new PointMass(new Vector(1,0,0), 1),
            };
            //original centre of gravity at (0.5, 0.5, 0)

            //assign massPoints to object positioned at (1, 1, 0)
            Object3D obj = new Object3D(massPoints, new Vector(-1, -1, 0));

            Vector result = obj.CentreOfGravity;
            Vector expected = new Vector(-0.5, -0.5, 0);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObject3D_WithNonZeroPosition_CentreOfMass_SetPositionAfter()
        {
            List<PointMass> massPoints = new List<PointMass>()
            {
                new PointMass(new Vector(1,1,0), 1),
                new PointMass(new Vector(0,0,0), 1),
                new PointMass(new Vector(0,1,0), 1),
                new PointMass(new Vector(1,0,0), 1),
            };

            //original centre of gravity at (0.5, 0.5, 0)

            //assign massPoints to object positioned at (1, 1, 0)
            Object3D obj = new Object3D(massPoints, new Vector(1, 1, 0));

            //move object to (-1, -1, 0)
            obj.Position = new Vector(-1, -1, 0);

            Vector result = obj.CentreOfGravity;
            Vector expected = new Vector(-0.5, -0.5, 0);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestParticle_RotationalKineticEnergy()
        {
            Particle p = new Particle(10);
            p.Rotation = new Vector(10, 10, 10);

            //shoudl always be zero because it's a point particle.
            Vector result = p.KineticEnergy_Rotational;
            Vector expected = new Vector();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPhysicsObjectBase_Momentum()
        {
            Particle p = new Particle(5);

            p.Velocity = new Vector(1, 1, 1);

            Vector result = p.Momentum;
            Vector expected = new Vector(5, 5, 5);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPhysicsObjectToString()
        {
            Particle p = new Particle(mass: 12)
            {
                Acceleration = new Vector(1, 2, 3),
                Velocity = new Vector(0, 0, 4),
                Charge = -3,
            };

            string s = p.ToString();
        }

        [TestMethod]
        public void TestSimplePendulum()
        {
            SimplePendulum p = new SimplePendulum(1, 1, Math.PI / 10);
            p.LocalGravity = 9.8;

            double period = p.Period;
            double expected = 2.007;

            Assert.IsTrue(Helpers.WithinTolerance(period, expected));

            double frequency = p.Frequency;
            double expected2 = 0.4983;

            Assert.IsTrue(Helpers.WithinTolerance(frequency, expected2));
        }

        #endregion Methods
    }
}