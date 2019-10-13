using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics.FluidDynamics
{
    public class VelocityField : VectorField
    {
        #region Public Constructors

        public VelocityField()
        {
        }

        public VelocityField(Func<Vector, Vector> v) : base(v)
        {
        }

        #endregion Public Constructors
    }
}