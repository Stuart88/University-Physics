using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityPhysics.Enums
{
    public enum TimeMeasure
    {
        Nanosecond,
        Millisecond,
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year
    }

    public enum LengthMeasure
    {
        Nanometre,
        Millimetre,
        Centimetre,
        Metre,
        Kilometre
    }

    public enum Axis_Cartesian
    {
        X,
        Y,
        Z
    }

    public enum TemperatureType
    {
        Kelvin,
        Celsius,
        Fahrenheit
    }

    public enum EnergyMeasure
    {
        Joule,
        eV,
        MeV,
        kWh
    }
}
