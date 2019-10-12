using UniversityPhysics.Maths;

namespace UniversityPhysics.PhysicsObjects
{
    /// <summary>
    /// Use in a collection to create Object3D objects
    /// </summary>
    public class MassPoint
    {
        #region Public Fields

        public double Mass;

        /// <summary>
        /// Position in 3D space
        /// </summary>
        public Vector Position;

        #endregion Public Fields

        #region Public Constructors

        public MassPoint(Vector position, double mass)
        {
            Position = position;
            Mass = mass;
        }

        #endregion Public Constructors

        #region Public Methods

        public Particle ToPhysicsObject(MassPoint m)
        {
            return new Particle(m.Position, Mass);
        }

        #endregion Public Methods
    }
}