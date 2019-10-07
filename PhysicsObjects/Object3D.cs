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
        public Object3D(List<MassPoint> massPoints)
        {
            MassPoints = massPoints;
            CentreOfGravity = GetCentreOfMass();
            MomentOfInertia = SetMomentOfInertia(massPoints, new Vector());
        }
        public Object3D(List<MassPoint> massPoints, Vector position)
        {
            MassPoints = massPoints;
            Position = position;
            CentreOfGravity = GetCentreOfMass();
            MomentOfInertia = SetMomentOfInertia(massPoints, position);
        }
        public List<MassPoint> MassPoints { get; set; }
        public Vector CentreOfGravity { get; }
        public Vector MomentOfInertia { get; }
        new public Vector Position
        {
            get { return Position; }
            set
            {
                //move all mass points.
                Vector diff = Position - value;
                foreach(MassPoint m in MassPoints)
                {
                    m.Position += diff;
                }
                Position = value;
            }
        }

        private Vector SetMomentOfInertia(List<MassPoint> massPoints, Vector position) 
        {
            double momentX = 0;
            double momentY = 0;
            double momentZ = 0;
            foreach (MassPoint m in massPoints)
            {
                momentX += m.Mass * Math.Pow(Math.Abs(position.X - m.Position.X), 2);
                momentY += m.Mass * Math.Pow(Math.Abs(position.Y - m.Position.Y), 2);
                momentZ += m.Mass * Math.Pow(Math.Abs(position.Y - m.Position.Z), 2);
            }

            return new Vector(momentX, momentY, momentZ);
        }

        private Vector GetCentreOfMass()
        {
            List<Particle> massPoints = MassPoints.Select(m => m.ToPhysicsObject(m)).ToList();

            return BasicMechanics.CentreOfMass(massPoints);
        }

        /// <summary>
        /// Adds constant external force to the object at some distance away from the centre of mass. This will result in a torque being applied.
        /// </summary>
        /// <param name="force">Force in Newtowns</param>
        /// <param name="applicationPoint">Radial position from centre of mass</param>
        public void AddForce_OffCentre(Vector force, Vector applicationPoint)
        {
            AddTorque(new Vector(force.X * applicationPoint.X, force.Y * applicationPoint.Y, force.Z * applicationPoint.Z));
        }
        /// <summary>
        /// Adds a constant torque to the object using τ = Iα (torque = moment of intertia * angular acceleration)
        /// </summary>
        /// <param name="torque">Torque (vector) in Newton metres, applied about X, Y and Z axes</param>
        public void AddTorque(Vector torque)
        {
            RotationalAcceleration += new Vector(torque.X / MomentOfInertia.X, torque.Y / MomentOfInertia.Y, torque.Z / MomentOfInertia.Z);
        }

    }
}
