using UniversityPhysics.Maths;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.PhysicsObjects
{
    /// <summary>
    /// Use in a collection to create Object3D objects
    /// </summary>
    public class PointMass
    {
        #region Public Fields

        public Mass Mass;

        /// <summary>
        /// Position in 3D space
        /// </summary>
        public Vector Position;

        #endregion Public Fields

        #region Public Constructors

        public PointMass(Vector position, Mass mass)
        {
            Position = position;
            Mass = mass;
        }

        #endregion Public Constructors

        #region Public Methods

        public Particle ToPhysicsObject(PointMass m)
        {
            return new Particle(Mass, m.Position);
        }

        #endregion Public Methods
    }
}