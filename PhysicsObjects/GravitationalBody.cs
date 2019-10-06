using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    public class GravitationalBody : PhysicsObjectBase
    {
        public GravitationalBody(double radius, double mass, Vector position)
        {
            Radius = radius;
            Mass = mass;
            Position = position;
        }
        public double Radius { get; set; }
        public double GravityAtSurface => UnitsAndConstants.Constants.G * Mass / (Radius * Radius);

        /// <summary>
        /// Calculates the gravitational force that exists between this body and another gravitational body.
        /// Force is directed toward this body, i.e. if the other body has higher gravitational strength, 
        /// the force will be negative (directed away from this body)
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public Vector GravitationalForceOn(GravitationalBody b)
        {
            double distance = Math.Abs(this.Position.Abs() - b.Position.Abs());

            if (distance < this.Radius || distance < b.Radius)
                throw new Exception("Bodies must not be connected!");

            Vector direction = b.Position - this.Position;

            double r_squared = direction.Abs() * direction.Abs();

            var x = direction.Abs() * direction.Abs();

            return direction.Normalised() * UnitsAndConstants.Constants.G * this.Mass * b.Mass / r_squared;
        }
    }
}
