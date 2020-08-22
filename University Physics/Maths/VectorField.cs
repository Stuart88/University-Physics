using System;

namespace UniversityPhysics.Maths
{
    public abstract class VectorField
    {
        #region Public Properties

        public Func<Vector, Vector> Result { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public VectorField()
        {
            Result = v => new Vector();
        }

        public VectorField(Func<Vector, Vector> v)
        {
            //Func<Vector, Vector>  takes vector and returns vector
            //e.g. for velocity field, takes Position and returns a Velocity for that position
            Result = v;
        }

        #endregion Public Constructors
    }
}