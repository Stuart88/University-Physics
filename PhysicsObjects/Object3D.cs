using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Maths;
using UniversityPhysics.Mechanics;

namespace UniversityPhysics.PhysicsObjects
{
    public class Object3D : PhysicsObjectBase
    {
        //Constructors

        #region Fields

        private Vector _position = new Vector();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Object3D constructor
        /// </summary>
        /// <param name="massPoints">List of points defining areas of mass on the object</param>
        public Object3D(List<PointMass> massPoints)
        {
            MassPoints = massPoints;
            _object3DMass = massPoints.Sum(m => m.Mass);
            Mass = _object3DMass;
            Position = new Vector();
            CentreOfGravity = SetCentreOfMass();
            SetMomentOfInertia(massPoints, Position);
        }

        /// <summary>
        /// Object3D constructor
        /// </summary>
        /// <param name="massPoints">List of points defining areas of mass on the object</param>
        /// <param name="position">Position of object, aligned to object's centre of mass</param>
        public Object3D(List<PointMass> massPoints, Vector position)
        {
            MassPoints = massPoints;
            _object3DMass = massPoints.Sum(m => m.Mass);
            Mass = _object3DMass;
            Position = position;
            CentreOfGravity = SetCentreOfMass();
            SetMomentOfInertia(massPoints, position);
        }

        #endregion Constructors

        // Fields
        // Properties

        #region Properties

        public Vector CentreOfGravity { get; private set; } = new Vector();
        new public double Mass { get; }
        public List<PointMass> MassPoints { get; set; }

        new public Vector Position
        {
            get { return _position; }
            set
            {
                Vector diff = new Vector();
                foreach (PointMass m in MassPoints)
                {
                    //find difference between old and new position
                    diff = value - _position;

                    //move m by same difference, so it stays aligned.
                    m.Position = m.Position + diff;
                }

                //assign new position
                _position = value;
                //and update _centreOfGravity field.
                CentreOfGravity = SetCentreOfMass();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// <para>
        /// Adds constant external force to the object at some distance away from the centre of mass. This will result in a torque being applied.
        /// </para>
        /// <para>
        /// </para>
        /// </summary>
        /// <param name="force">Force in Newtowns</param>
        /// <param name="applicationPoint">Radial position from centre of mass</param>
        public void AddForce_OffCentre(Vector force, Vector applicationPoint)
        {
            //resultant torque is simply the cross product of force with position vector
            //(it correctly adds the torque for each component about the relative axes,
            //in the correct direction about each axis (negative or positive))

            AddTorque(force.Cross(applicationPoint));
        }

        /// <summary>
        /// Adds a constant torque to the object using τ = Iα (torque = moment of intertia * angular acceleration)
        /// </summary>
        /// <param name="torque">Torque (vector) in Newton metres, applied about X, Y and Z axes</param>
        public void AddTorque(Vector torque)
        {
            double aX = torque.X != 0 ? torque.X / MomentOfInertia.X : 0;
            double aY = torque.Y != 0 ? torque.Y / MomentOfInertia.Y : 0;
            double aZ = torque.Z != 0 ? torque.Z / MomentOfInertia.Z : 0;

            RotationalAcceleration += new Vector(aX, aY, aZ);
        }

        private Vector SetCentreOfMass()
        {
            List<Particle> massPoints = MassPoints.Select(m => m.ToPhysicsObject(m)).ToList();

            return BasicMechanics.CentreOfMass(massPoints);
        }

        private void SetMomentOfInertia(List<PointMass> massPoints, Vector position)
        {
            double momentX = 0;
            double momentY = 0;
            double momentZ = 0;
            foreach (PointMass m in massPoints)
            {
                momentX += (m.Mass * (Math.Pow(position.Y - m.Position.Y, 2) + Math.Pow(position.Z - m.Position.Z, 2)));
                momentY += (m.Mass * (Math.Pow(position.Z - m.Position.Z, 2) + Math.Pow(position.X - m.Position.X, 2)));
                momentZ += (m.Mass * (Math.Pow(position.X - m.Position.X, 2) + Math.Pow(position.Y - m.Position.Y, 2)));
            }

            _momentOfInertia = new Vector(momentX, momentY, momentZ);
        }

        #endregion Methods
    }
}