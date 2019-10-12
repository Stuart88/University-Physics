using System;

namespace UniversityPhysics.Thermodynamics
{
    public static class BasicThermodynamics
    {
        #region Public Classes

        /// <summary>
        /// Find basic substance properties using pV=nRT nR = Nk ... n = N k/R
        /// </summary>
        public static class SubstanceEquations
        {
            #region Private Fields

            private static readonly double k = UnitsAndConstants.Constants.Common.k;

            private static readonly double NA = UnitsAndConstants.Constants.Common.NA;

            //Private
            private static readonly double R = UnitsAndConstants.Constants.Common.R;

            #endregion Private Fields

            #region Public Methods

            public static double EnergyPerMolecule(Temperature T) => 1.5 * k * T.Kelvin;

            public static double m_Total(double nMoles, double molarMass) => nMoles * molarMass;

            /// <summary>
            /// Finds the mean free path per particle for a set of N molecules in a given volume.
            /// </summary>
            /// <param name="N">Total number of molecules</param>
            /// <param name="r">Molecular radius of molecule</param>
            /// <param name="V">Available volume</param>
            /// <returns>Mean Free Path (metres)</returns>
            public static double MeanFreePath(double N, double r, double V) => V / (4d * Math.PI * Math.Sqrt(2) * Math.Pow(r, 2) * N);

            /// <summary>
            /// Finds molar mass of a substance
            /// </summary>
            /// <param name="m">Mass of an individual molecule</param>
            public static double MolarMass(double m) => m * NA;

            public static double n_Moles(double p, double V, Temperature T) => (p * V) / (R * T.Kelvin);

            //Public
            /// <summary>
            /// Converts a numerical count of particles into their molar equivalent value
            /// </summary>
            /// <param name="N">Total number of particles</param>
            /// <returns>Number of Moles</returns>
            public static double N_to_nMoles(double N) => N * k / R;

            public static double Pressure(double V, double nMoles, Temperature T) => (nMoles * R * T.Kelvin) / V;

            /// <summary>
            /// Finds the root-mean-square speed of molecules at given temperature
            /// </summary>
            /// <param name="m">Mass of indivudal molecule</param>
            /// <param name="T">Temperature</param>
            /// <returns></returns>
            public static double RMS_Speed(double m, Temperature T) => Math.Sqrt((3 * k * T.Kelvin) / m);

            public static Temperature Temperature(double p, double V, double nMoles) => (p * V) / (nMoles * R);

            /// <summary>
            /// Total translational kinetic energy of an ideal gas
            /// </summary>
            /// <param name="n_Moles">Number of moles</param>
            /// <param name="T">Temperature in Kelvin</param>
            public static double TotalTranslationalEnergy(double n_Moles, Temperature T) => 1.5 * n_Moles * R * T.Kelvin;

            public static double Volume(double p, double nMoles, Temperature T) => (nMoles * R * T.Kelvin) / p;

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}