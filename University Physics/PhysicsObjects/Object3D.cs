using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Maths;
using UniversityPhysics.Mechanics;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.PhysicsObjects
{
    public class Object3D : PhysicsObjectBase
    {
        //Constructors

        #region Private Fields

        private Vector _position = new Vector();

        #endregion Private Fields

        #region Public Properties

        public Vector CentreOfGravity { get; private set; } = new Vector();

        public new Mass Mass
        {
            get { return MassPoints.Sum(p => p.Mass); }
        }

        public List<PointMass> MassPoints { get; set; }

        public new Vector Position
        {
            get => _position;
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

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Object3D constructor
        /// </summary>
        /// <param name="massPoints">List of points defining areas of mass on the object</param>
        public Object3D(List<PointMass> massPoints)
        {
            MassPoints = massPoints;
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
            Position = position;
            CentreOfGravity = SetCentreOfMass();
            SetMomentOfInertia(massPoints, position);
        }

        #endregion Public Constructors

        #region Public Methods

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
        /// <para>
        /// Add applies force for the given timeDelta, results in an application of.
        /// </para>
        /// <para>
        /// </para>
        /// </summary>
        /// <param name="force">Force in Newtowns</param>
        /// <param name="applicationPoint">Radial position from centre of mass</param>
        public void AddForceDelta_OffCentre(Vector force, Vector applicationPoint, float timeDelta)
        {
            AddTorqueDelta(force.Cross(applicationPoint), timeDelta);
        }

        /// <summary>
        /// Updates angulra velocity based on energy being added
        /// </summary>
        /// <param name="joules"></param>
        public void AddRotationalKineticEnergy(Vector joules)
        {
            //KE = 1/2 I w^2

            //change in angular vel = sqrt(2 KE / I)

            double dx = this.MomentOfInertia.X > 0 ? Math.Sign(joules.Z) * Math.Sqrt(2 * Math.Abs(joules.X) / MomentOfInertia.X) : 0;
            double dy = this.MomentOfInertia.Y > 0 ? Math.Sign(joules.Y) * Math.Sqrt(2 * Math.Abs(joules.Y) / MomentOfInertia.Y) : 0;
            double dz = this.MomentOfInertia.Z > 0 ? Math.Sign(joules.Z) * Math.Sqrt(2 * Math.Abs(joules.Z) / MomentOfInertia.Z) : 0;

            //if energy removed will put it into negative energy... just set angular velocity to 0.

            if (this.KineticEnergy_Rotational.X + joules.X <= 0)
                this.AngularVelocity.X = 0;
            else
                this.AngularVelocity.X += dx;

            if (this.KineticEnergy_Rotational.Y + joules.Y <= 0)
                this.AngularVelocity.Y = 0;
            else
                this.AngularVelocity.Y += dy;

            if (this.KineticEnergy_Rotational.Z + joules.Z <= 0)
                this.AngularVelocity.Z = 0;
            else
                this.AngularVelocity.Z += dz;
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

        /// <summary>
        /// Adds a torque to the object using τ = Iα (torque = moment of intertia * angular acceleration) for the given time delta
        /// </summary>
        /// <param name="torque">Torque (vector) in Newton metres, applied about X, Y and Z axes</param>
        public void AddTorqueDelta(Vector torque, float timeDelta)
        {
            double aX = torque.X != 0 ? torque.X / MomentOfInertia.X : 0;
            double aY = torque.Y != 0 ? torque.Y / MomentOfInertia.Y : 0;
            double aZ = torque.Z != 0 ? torque.Z / MomentOfInertia.Z : 0;

            AccelerateRotational(new Vector(aX, aY, aZ), timeDelta);
        }

        public void SetRotationalKineticEnergy(Vector joules)
        {
            if (joules.X < 0 || joules.Y < 0 || joules.Z < 0)
                throw new Exception("Cannot assign negative kinetic energy!");

            double newX = Math.Sqrt(2 * joules.X / MomentOfInertia.X);
            double newY = Math.Sqrt(2 * joules.Y / MomentOfInertia.Y);
            double newZ = Math.Sqrt(2 * joules.Z / MomentOfInertia.Z);

            this.AngularVelocity = new Vector(newX > 0 ? newX : 0, newY > 0 ? newY : 0, newZ > 0 ? newZ : 0);
        }

        public void UpdateMomentOfInertia()
        {
            SetMomentOfInertia(this.MassPoints, this.Position);
        }

        #endregion Public Methods

        #region Private Methods

        private Vector SetCentreOfMass()
        {
            List<Particle> massPoints = MassPoints.Select(m => m.ToPhysicsObject(m)).ToList();

            return massPoints.CentreOfMass();
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

        #endregion Private Methods
    }
}