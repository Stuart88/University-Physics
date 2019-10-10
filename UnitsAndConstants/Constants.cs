using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityPhysics.UnitsAndConstants
{
    public static class Constants
    {
        public static class Common
        {
            public const double StandardGravity = 9.81;

            /// <summary>
            /// Planck Constant
            /// </summary>
            public const double h = 6.626E-34;
            /// <summary>
            /// Planck Constant in MeV/c^2
            /// </summary>
            public const double h_eV = 4.136E-15;
            /// <summary>
            /// hBar
            /// </summary>
            public const double hBar = 1.055E-34;
            /// <summary>
            /// hBar in MeV/c^2
            /// </summary>
            public const double hBar_eV = 6.582E-16;
            /// <summary>
            /// Speed of light in a vacuum
            /// </summary>
            public const double C = 2.997E8;
            /// <summary>
            /// Gravitational Constant
            /// </summary>
            public const double G = 6.673E-11;
            /// <summary>
            /// Boltzmann Constant
            /// </summary>
            public const double k = 1.381E-11;
            /// <summary>
            /// Boltzmann Constant in MeV/c^2
            /// </summary>
            public const double k_eV = 8.617E-5;
            /// <summary>
            /// Molar Gas Constant
            /// </summary>
            public const double R = 8.314;
            /// <summary>
            /// Avogadro's Number
            /// </summary>
            public const double NA = 6.022E23;
            /// <summary>
            /// Electron Charge
            /// </summary>
            public const double e = 1.602E-19;
            /// <summary>
            /// Permeability of Vacuum
            /// </summary>
            public const double mu0 = Math.PI * 4E-7;
            /// <summary>
            /// Permitivity of vacuum
            /// </summary>
            public const double epsilon0 = 8.854E-12;
            /// <summary>
            /// Coulomb Constant
            /// </summary>
            public const double K = 8.988E9;
            /// <summary>
            /// Faraday Constant
            /// </summary>
            public const double F = 94685.309;
            /// <summary>
            /// Electron Mass
            /// </summary>
            public const double M_e = 9.109E-31;
            /// <summary>
            /// Electron Mass in MeV/c^2
            /// </summary>
            public const double M_e_eV = 0.51099906;
            /// <summary>
            /// Proton Mass
            /// </summary>
            public const double m_p = 1.672E-27;
            /// <summary>
            /// Proton Mass in MeV/c^2
            /// </summary>
            public const double m_p_eV = 938.27231;
            /// <summary>
            /// Neutron Mass
            /// </summary>
            public const double m_n = 1.675E-27;
            /// <summary>
            /// Neutron Mass in MeV/c^2
            /// </summary>
            public const double m_n_eV = 939.56563;
            /// <summary>
            /// Atomic Mass Unit
            /// </summary>
            public const double u = 1.661E-27;
            /// <summary>
            /// Atomic Mass Unit in MeV/c^2
            /// </summary>
            public const double u_eV = 931.49432;
            /// <summary>
            /// Stefan-Boltzmann Constant
            /// </summary>
            public const double sigma = 5.671E-8;
            /// <summary>
            /// Bohr Magneton
            /// </summary>
            public const double mu_b = 9.274E-24;
            /// <summary>
            /// Bohr Magneton in MeV/c^2
            /// </summary>
            public const double mu_b_eV = 5.788E-5;
            /// <summary>
            /// Bohr Radius
            /// </summary>
            public const double a0 = 0.529E-10;
            /// <summary>
            /// Standard Atmosphere
            /// </summary>
            public const double atm = 101325;
            /// <summary>
            /// Wien Displacement Constant
            /// </summary>
            public const double b = 2.898E-3;
        }

        //Solar System
        public static class AstrophysicalConstants
        {
            /// <summary>
            /// Astronomical Unit
            /// </summary>
            public const double AU = 149.6E9;
            public const double Sun_Mass = 1.989E30;
            public const double Sun_Radius = 6.957E8;
            public const double Earth_Mass = 5.9723E24;
            public const double Earth_Radius = 6.371E6;
        }
       
        public static class Time
        {
            public const double Year_Seconds = 31536000;
            public const double Month_Seconds = 2628000;
            public const double Week_Seconds = 604800;
            public const double Day_Seconds = 86400;
            public const double Hour_Seconds = 3600;
            public const double Minute_Seconds = 60;
        }

        
    }
}
