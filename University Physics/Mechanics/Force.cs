using UniversityPhysics.Maths;

namespace UniversityPhysics.Mechanics
{
    public class Force
    {
        #region Public Properties

        public Vector Value { get; set; }

        public Vector Direction { get; set; }

        #endregion Public Properties

        #region Public Methods

        public double Magnitude()
        {
            return this.Value.Abs();
        }

        #endregion Public Methods
    }
}