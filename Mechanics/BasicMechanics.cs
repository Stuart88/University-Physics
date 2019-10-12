using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics.Mechanics
{
    public static class BasicMechanics
    {
        #region Public Methods

        /// <summary>
        /// Finds the centre of mass of an array of Physics objects
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static Vector CentreOfMass(this PhysicsObjectBase[] objects)
        {
            double totalMass = objects.Sum(x => x.Mass);

            if (totalMass <= 0)
                throw new NegativeMassException("Objects must have real mass!");

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
        public static Vector CentreOfMass<T>(this List<T> p) where T : PhysicsObjectBase
        {
            double totalMass = p.Sum(x => x.Mass);

            if (totalMass <= 0)
                throw new NegativeMassException("Objects must have real mass!");

            double centreOfMassX = p.Sum(o => o.Mass * o.Position.X) / totalMass;
            double centreOfMassY = p.Sum(o => o.Mass * o.Position.Y) / totalMass;
            double centreOfMassZ = p.Sum(o => o.Mass * o.Position.Z) / totalMass;

            return new Vector(centreOfMassX, centreOfMassY, centreOfMassZ);
        }

        #endregion Public Methods

        #region Public Classes

        [Serializable]
        public class NegativeMassException : Exception
        {
            #region Public Constructors

            public NegativeMassException()
            {
            }

            public NegativeMassException(string message) : base(message)
            {
            }

            public NegativeMassException(string message, Exception inner) : base(message, inner)
            {
            }

            #endregion Public Constructors

            #region Protected Constructors

            protected NegativeMassException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

            #endregion Protected Constructors
        }

        #endregion Public Classes
    }
}