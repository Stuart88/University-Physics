using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityPhysics.PhysicsObjects
{
    public class Pivot : PhysicsObjectBase
    {
       
        public List<Particle> Masses { get; set; }
        public double Mass2 { get; set; }

        /// <summary>
        /// Mass1 distance from central pivot
        /// </summary>
        public double Distance1 { get; set; }
        /// <summary>
        /// Mass2 distance from central pivot
        /// </summary>
        public double Distance2 { get; set; }

        
    }
}
