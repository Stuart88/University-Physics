using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    public class Particle: PhysicsObjectBase
    {
        public Particle() { }
        public Particle(Vector position, double mass)
        {
            Position = position;
            Mass = mass;
        }

        
    }

    
}
