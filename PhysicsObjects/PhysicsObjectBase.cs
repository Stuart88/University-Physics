using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    public class PhysicsObjectBase
    {
       
        public double Mass { get; set; } = 0d;
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public Vector Acceleration { get; set; }
        public double Charge { get; set; } = 0d;
        public Vector Rotation { get; set; }
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

    }
}
