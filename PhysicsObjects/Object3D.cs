using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Maths;
using UniversityPhysics.Mechanics;

namespace UniversityPhysics.PhysicsObjects
{
    public class Object3D : PhysicsObjectBase
    {
        public Object3D(List<PhysicsObjectBase> massPoints)
        {
            MassPoints = massPoints;
            CentreOfGravity = massPoints.CentreOfMass();
            MomentOfInertia = SetMomentOfInertia(massPoints);
        }
        public List<PhysicsObjectBase> MassPoints { get; set; }
        public Vector CentreOfGravity { get; }
        public Vector MomentOfInertia { get; }



        private Vector SetMomentOfInertia(List<PhysicsObjectBase> massPoints) 
        {
            double momentX = 0;
            double momentY = 0;
            double momentZ = 0;
            foreach (PhysicsObjectBase m in massPoints)
            {
                momentX += m.Mass * Math.Pow(Math.Abs(this.Position.X - m.Position.X), 2);
                momentY += m.Mass * Math.Pow(Math.Abs(this.Position.Y - m.Position.Y), 2);
                momentZ += m.Mass * Math.Pow(Math.Abs(this.Position.Y - m.Position.Z), 2);
            }

            return new Vector(momentX, momentY, momentZ);
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
