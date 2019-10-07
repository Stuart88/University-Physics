using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Maths;
using UniversityPhysics.Mechanics;

namespace UniversityPhysics.PhysicsObjects
{
    /// <summary>
    /// Use in a collection to create Object3D objects
    /// </summary>
    public class MassPoint
    {
        public MassPoint(Vector position, double mass)
        {
            Position = position;
            Mass = mass;
        }
        /// <summary>
        /// Position in 3D space
        /// </summary>
        public Vector Position;
        public double Mass;
        
        public Particle ToPhysicsObject(MassPoint m)
        {
            return new Particle(m.Position, Mass);
        }


    }
}
