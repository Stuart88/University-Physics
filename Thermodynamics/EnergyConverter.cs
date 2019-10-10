using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Enums;

namespace UniversityPhysics.Thermodynamics
{
    public class EnergyConverter
    {  
        //Constructors

        /// <summary>
        /// Stores a given energy value in the desired format, for conversion into various alternative representations.
        /// </summary>
        /// <param name="value">Energy value</param>
        /// <param name="measure">Energy type</param>
        public EnergyConverter(double energy, EnergyMeasure type)
        {
            SetEnergy(energy, type);
        }

        //Properties

        public double Joules { get; private set; }
        public double ElectronVolts { get; private set; }
        public double MegaElectronVolts { get; private set; }
        public double KilowattHours { get; private set; }

        //Public Methods

        public void SetEnergy(double value, EnergyMeasure measure)
        {
            switch (measure)
            {
                case EnergyMeasure.Joule:
                    Joules = value;
                    ElectronVolts = JoulesTo_eV(value);
                    MegaElectronVolts = JoulesTo_MeV(value);
                    KilowattHours = JoulesTo_kWh(value);
                    break;
                case EnergyMeasure.eV:
                    Joules = EV_to_Joules(value);
                    ElectronVolts = value;
                    MegaElectronVolts = EV_to_MeV(value);
                    KilowattHours = JoulesTo_MeV(EV_to_Joules(value));
                    break;
                case EnergyMeasure.MeV:
                    Joules = MeV_to_Joules(value);
                    ElectronVolts = MeV_to_eV(value);
                    MegaElectronVolts = value;
                    KilowattHours = MeV_to_kwH(value);
                    break;
                case EnergyMeasure.kWh:
                    KilowattHours = value;
                    ElectronVolts = JoulesTo_eV(KwH_to_Joules(value));
                    MegaElectronVolts = JoulesTo_MeV(value);
                    KilowattHours = JoulesTo_kWh(value);
                    break;
            }
        }


        //Private Methods

        private double JoulesTo_eV(double e)
        {
            return e * 6.241509E18;
        }
        private double JoulesTo_kWh(double e)
        {
            return e * 2.7778E-7;
        }
        private double JoulesTo_MeV(double e)
        {
            return e * 6.241509E12;
        }
        private double EV_to_Joules(double e)
        {
            return e * 1.6022E-19;
        }
        private double EV_to_MeV(double e)
        {
            return e * 10E-6;
        }
        private double MeV_to_Joules(double e)
        {
            return e * 1.6022E-13;
        }
        private double MeV_to_kwH(double e)
        {
            return e * 4.4505E-20;
        }
        private double MeV_to_eV(double e)
        {
            return e * 10E6;
        }
        private double KwH_to_Joules(double e)
        {
            return e * 3600000;
        }


    }
}
