using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    /// <summary>
    /// Use in a collection to create Object3D objects
    /// </summary>
    public class PointMass
    {
        #region Public Fields

        public double Mass;

        /// <summary>
        /// Position in 3D space
        /// </summary>
        public Vector Position;

        #endregion Public Fields

        #region Public Constructors

        public PointMass(Vector position, double mass)
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