using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    public class PhysicsObjectBase
    {
       
        public double Mass { get; set; } = 0d;
        public Vector Position { get; set; } = new Vector();
        public Vector Velocity { get; set; } = new Vector();
        public Vector Acceleration { get; set; } = new Vector();
        public double Charge { get; set; } = 0d;
        public Vector Rotation { get; set; } = new Vector();
        public Vector RotationalAcceleration { get; set; } = new Vector();
        public Vector Momentum
        {
            get { return Velocity * Mass; }
        }
        public Vector KineticEnergy
        {
            get { return 0.5 * Mass * new Vector(Velocity.X * Velocity.X, Velocity.Y * Velocity.Y, Velocity.Z * Velocity.Z); }
        }
        public double TotalEnergy 
        {
            get
            {
                Vector e = KineticEnergy;
                return e.X + e.Y + e.Z;
            } 
        }

        /// <summary>
        /// Updates velocity via v = u + at
        /// </summary>
        /// <param name="acceleration"></param>
        /// <param name="timeDelta"></param>
        public void Accelerate(Vector acceleration, double timeDelta)
        {
            Velocity += acceleration * timeDelta;
        }

        /// <summary>
        /// Updates Position, uses s = ut + 1/2 at^2
        /// </summary>
        /// <param name="timeDelta"></param>
        public void Move(double timeDelta)
        {
            Position += (Velocity * timeDelta  + 0.5 * Acceleration * timeDelta * timeDelta);
        }

        /// <summary>
        /// Adds an extra force to the object. (Updates Acceleration property via F=ma ).
        /// </summary>
        public void AddForce_Translational(Vector force)
        {
            Acceleration += (force / Mass);
        }

        public override string ToString()
        {
            string[] properties = new string[]
            {
                string.Format("{0} ---------- {1} ( kg )",  "Mass", Mass),
                string.Format("{0} ---------- {1}",  "Positions", Position),
                string.Format("{0} ---------- {1} ( m/s )",  "Velocity", Velocity),
                string.Format("{0} ---------- {1} ( kg m/s )",  "Momentum", Momentum),
                string.Format("{0} ---------- {1} ( m/s^2 )",  "Acceleration", Acceleration),
                string.Format("{0} ---------- {1} ( As )",  "Charge", Charge),
                string.Format("{0} ---------- {1} ( J )",  "Kinetic Energy", KineticEnergy),
                string.Format("{0} ---------- {1} ( J )",  "Total Kinetic Energy", TotalEnergy),
            };

            return string.Join('\n',properties);
        }


    }
}
