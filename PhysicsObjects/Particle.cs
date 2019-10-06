using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    public class Particle: PhysicsObjectBase
    {
        public Particle(double mass)
        {
            if (mass == 0)
                throw new Exception("Cannot be massless!");
            Mass = mass;
        }
        public Particle(Vector position, double mass): base ()
        {
            if (mass == 0)
                throw new Exception("Cannot be massless!");

            Position = position;
            Mass = mass;
        }

        
    }

    
}
