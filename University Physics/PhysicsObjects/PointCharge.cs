using UniversityPhysics.Electromagnetism;
using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    public class PointCharge : PhysicsObjectBase
    {
        #region Public Constructors

        public PointCharge(double charge)
        {
            Charge = charge;
        }

        public PointCharge(double charge, Vector position)
        {
            Charge = charge;
            Position = position;
        }

        #endregion Public Constructors

    }
}