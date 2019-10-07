using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Maths;
using System.Linq;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics.Mechanics
{
    public static class BasicMechanics
    {
        

        /// <summary>
        /// Finds the centre of mass of an array of Physics objects
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static Vector CentreOfMass(this PhysicsObjectBase[] objects)
        {
            double totalMass = objects.Sum(x => x.Mass);

            if (totalMass <= 0)
                throw new Exception("Objects must have real mass!");

            double centreOfMassX = objects.Sum(o => o.Mass * o.Position.X) / totalMass;
            double centreOfMassY = objects.Sum(o => o.Mass * o.Position.Y) / totalMass;
            double centreOfMassZ = objects.Sum(o => o.Mass * o.Position.Z) / totalMass;

            return new Vector(centreOfMassX, centreOfMassY, centreOfMassZ);
        }

        /// <summary>
        /// Finds the centre of mass of a List of Physics objects
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Vector CentreOfMass<T>(this List<T> p) where T :  PhysicsObjectBase
        {
            double totalMass = p.Sum(x => x.Mass);

            if (totalMass <= 0)
                throw new Exception("Objects must have real mass!");

            double centreOfMassX = p.Sum(o => o.Mass * o.Position.X) / totalMass;
            double centreOfMassY = p.Sum(o => o.Mass * o.Position.Y) / totalMass;
            double centreOfMassZ = p.Sum(o => o.Mass * o.Position.Z) / totalMass;

            return new Vector(centreOfMassX, centreOfMassY, centreOfMassZ);
        }

        
    }
}
