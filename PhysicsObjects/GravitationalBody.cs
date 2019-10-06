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

        
    }
}
