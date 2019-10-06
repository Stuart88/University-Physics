using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics.Astrophysics
{
    public static class BasicAstrophysics
    {
        /// <summary>
        /// Calculates the gravitational force that exists between this body and another gravitational body.
        /// Force is directed toward this body, i.e. if the other body has higher gravitational strength, 
        /// the force will be negative (directed away from this body)
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector GravitationalForceOn(this GravitationalBody _this, GravitationalBody b)
        {
            double distance = Math.Abs(_this.Position.Abs() - b.Position.Abs());

            if (distance < _this.Radius || distance < b.Radius)
                throw new Exception("Bodies must not be connected!");

            Vector direction = b.Position - _this.Position;

            double r_squared = direction.Abs() * direction.Abs();

            var x = direction.Abs() * direction.Abs();

            return direction.Normalised() * UnitsAndConstants.Constants.G * _this.Mass * b.Mass / r_squared;
        }

    }
}
