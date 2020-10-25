using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics.Electromagnetism
{

    public class MagneticField : VectorField
    {
        #region Public Constructors

        public MagneticField()
        {
        }

        public MagneticField(Func<Vector, Vector> v) : base(v)
        {
        }

        #endregion Public Constructors
    }
}