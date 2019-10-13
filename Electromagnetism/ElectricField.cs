using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics.Electromagnetism
{
    public static class CommonElectricFields
    {
        #region Public Fields

        public static ElectricField RingOfCharge = new ElectricField(RingOfCharge_Func);

        #endregion Public Fields

        #region Private Properties

        /// <summary>
        /// For preset electric fields with a central object, e.g. flow around a sphere.
        /// </summary>
        private static double ChargeTotal { get; set; } = 0d;

        /// <summary>
        /// Dimensions of electric field container (often set to user screen size)
        /// </summary>
        private static Vector FieldDimensions { get; set; } = new Vector();

        #endregion Private Properties

        #region Private Methods

        private static Vector RingOfCharge_Func(Vector pos)
        {
            return new Vector(UnitsAndConstants.Constants.Common.K_Coulomb, 0, 0) * ChargeTotal;
        }

        #endregion Private Methods
    }

    public class ElectricField : VectorField
    {
        #region Public Constructors

        public ElectricField()
        {
        }

        public ElectricField(Func<Vector, Vector> v) : base(v)
        {
        }

        #endregion Public Constructors
    }
}