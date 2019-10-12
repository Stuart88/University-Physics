using UniversityPhysics.Maths;

namespace UniversityPhysics.Mechanics
{
    public class Force : Vector
    {
        #region Public Properties

        public Vector Direction { get; set; }

        #endregion Public Properties

        #region Public Methods

        public double Magnitude()
        {
            return this.Abs();
        }

        #endregion Public Methods
    }
}