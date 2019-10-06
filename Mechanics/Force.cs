using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Maths;

namespace UniversityPhysics.Mechanics
{
    public class Force: Vector
    {
 
        public Vector Direction { get; set; }

        public double Magnitude()
        {
            return this.Abs();
        }
       
    }
}
