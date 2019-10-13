using System;
using System.Collections.Generic;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.Electromagnetism
{
    public static class BasicElectromagnetism
    {
        #region Public Methods

        /// <summary>
        /// Finds the electric field at a position relating to a charged physical object.
        /// </summary>
        /// <param name="p">Physics Object</param>
        /// <param name="position">Spacial position for measurement</param>
        /// <returns></returns>
        public static Vector ElectricFieldAtPoint(this PhysicsObjectBase p, Vector position)
        {
            /// F =  k * (p q / r^2) r_hat
            ///
            ///r_hat <==== unit vector in direction pq

            return (Constants.Common.K_Coulomb * p.Charge / Math.Pow(p.Position.DistanceTo(position), 2)) * (position - p.Position).Normalised();
        }

        public static Vector ElectricForce(this List<PointCharge> charges, PhysicsObjectBase q)
        {
            Vector force = new Vector();

            foreach (PhysicsObjectBase p in charges)
            {
                force += p.ElectricForceOn(q);
            }

            return force;
        }

        public static Vector ElectricForceOn(this PhysicsObjectBase p, PhysicsObjectBase q)
        {
            return (p.ElectricFieldAtPoint(q.Position) * q.Charge);
        }

        #endregion Public Methods
    }
}