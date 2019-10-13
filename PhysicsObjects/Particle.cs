using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    public class Particle : PhysicsObjectBase
    {
        #region Public Constructors

        public Particle(double mass) : base()
        {
            if (mass <= 0)
                throw new Exception("This object cannot be massless!");

            Mass = mass;
        }

        public Particle(double mass, Vector position) : base()
        {
            if (mass <= 0)
                throw new Exception("This object cannot be massless!");

            Position = position;
            Mass = mass;
        }

        #endregion Public Constructors
    }
}