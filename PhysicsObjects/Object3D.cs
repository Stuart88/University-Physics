using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityPhysics.Maths;
using UniversityPhysics.Mechanics;

namespace UniversityPhysics.PhysicsObjects
{
    public class Object3D : PhysicsObjectBase
    {
        //Constructors

        /// <summary>
        /// Object3D constructor
        /// </summary>
        /// <param name="massPoints">List of points defining areas of mass on the object</param>
        public Object3D(List<MassPoint> massPoints)
        {
            MassPoints = massPoints;
            _object3DMass = massPoints.Sum(m => m.Mass);
            Mass = _object3DMass;
            Position = new Vector();
            _centreOfGravity = SetCentreOfMass();
            _momentOfInertia = SetMomentOfInertia(massPoints, Position);
        }

        /// <summary>
        /// Object3D constructor
        /// </summary>
        /// <param name="massPoints">List of points defining areas of mass on the object</param>
        /// <param name="position">Position of object, aligned to object's centre of mass</param>
        public Object3D(List<MassPoint> massPoints, Vector position)
        {
            MassPoints = massPoints;
            _object3DMass = massPoints.Sum(m => m.Mass);
            Mass = _object3DMass;
            Position = position;
            _centreOfGravity = SetCentreOfMass();
            _momentOfInertia = SetMomentOfInertia(massPoints, position);
        }

        // Fields

        private Vector _centreOfGravity = new Vector();
        private Vector _position = new Vector();

        // Properties

        public List<MassPoint> MassPoints { get; set; }
        public Vector CentreOfGravity { get { return _centreOfGravity; } }
        new public Vector Position
        {
            get { return _position; }
            set {
                Vector diff = new Vector();
                foreach (MassPoint m in MassPoints)
                {
                    //find difference between old and new position
                    diff = value - _position;

                    //move m by same difference, so it stays aligned.
                    m.Position = m.Position + diff;
                }

                //assign new position 
                _position = value;
                //and update _centreOfGravity field.
                _centreOfGravity = SetCentreOfMass();
            }
        }
        new public double Mass { get; }
        

        //Public Methods

        /// <summary>
        /// Adds constant external force to the object at some distance away from the centre of mass. This will result in a torque being applied.
        /// </summary>
        /// <param name="force">Force in Newtowns</param>
        /// <param name="applicationPoint">Radial position from centre of mass</param>
        public void AddForce_OffCentre(Vector force, Vector applicationPoint)
        {

            // hmmm
            double torqueX = Math.Sign(force.Y) * force.Z;
            double torqueY = Math.Sign(force.Z) * force.X;
            double torqueZ = Math.Sign(force.X) * force.Y;


            AddTorque(new Vector(torqueX, torqueY, torqueZ));
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

        // Private Methods

        private Vector SetMomentOfInertia(List<MassPoint> massPoints, Vector position)
        {
            double momentX = 0;
            double momentY = 0;
            double momentZ = 0;
            foreach (MassPoint m in massPoints)
            {
                momentX += m.Mass * Math.Pow(position.Y - m.Position.Y, 2);
                momentY += m.Mass * Math.Pow(position.Z - m.Position.Z, 2);
                momentZ += m.Mass * Math.Pow(position.X - m.Position.X, 2);
            }

            return new Vector(momentX, momentY, momentZ);
        }
        private Vector SetCentreOfMass()
        {
            List<Particle> massPoints = MassPoints.Select(m => m.ToPhysicsObject(m)).ToList();

            return BasicMechanics.CentreOfMass(massPoints);
        }

        

    }
}
