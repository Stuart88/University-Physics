using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Enums;

namespace UniversityPhysics.Thermodynamics
{
    public class Temperature
    {
        //Constructors

        public Temperature(double temp, TemperatureType type)
        {
            SetTemperature(temp, type);
        }

        //Properties

        public double Kelvin { get; private set; }
        public double Celsius { get; private set; }
        public double Fahrenheit { get; private set; }

        //Public Methods

        public void SetTemperature(double temp, TemperatureType type)
        {
            switch (type)
            {
                case TemperatureType.Kelvin:
                    Kelvin = temp;
                    Celsius = KelvinToCelsius(temp);
                    Fahrenheit = KelvinToFahrenheit(temp);
                    break;
                case TemperatureType.Celsius:
                    Kelvin = CelsiusToKelvin(temp);
                    Celsius = temp;
                    Fahrenheit = CelsiusToFahrenheit(temp);
                    break;
                case TemperatureType.Fahrenheit:
                    Kelvin = FahrenheitToKelvin(temp);
                    Celsius = FahrenheitToCelsius(temp);
                    Fahrenheit = temp;
                    break;
            }
        }

        //Private Methods

        private double CelsiusToKelvin(double tempC)
        {
            return tempC + 273.15;
        }
        private double CelsiusToFahrenheit(double tempC)
        {
            return (9d / 5 * tempC) + 32;
        }
        private double FahrenheitToCelsius(double tempF)
        {
            return (5d / 9) * (tempF - 32);
        }
        private double FahrenheitToKelvin(double tempF)
        {
            return CelsiusToKelvin(FahrenheitToCelsius(tempF));
        }
        private double KelvinToCelsius(double tempK)
        {
            return tempK - 273.15;
        }
        private double KelvinToFahrenheit(double tempK)
        {
            return CelsiusToFahrenheit(KelvinToCelsius(tempK));
        }
    }
}
