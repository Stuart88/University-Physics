﻿using System;
using UniversityPhysics.Enums;
using UniversityPhysics.Maths;

namespace UniversityPhysics.UnitsAndConstants
{
    public class Temperature
    {
        #region Public Constructors

        public Temperature(double temp, TemperatureType type)
        {
            SetTemperature(temp, type);
        }

        #endregion Public Constructors

        #region Public Properties

        public double Celsius { get; private set; }
        public double Fahrenheit { get; private set; }
        public double Kelvin { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Implicitly set temperature in Kelvin
        /// </summary>
        /// <param name="temp">Temperature in Kelvin</param>
        public static implicit operator Temperature(double temp)
        {
            return new Temperature(temp, TemperatureType.Kelvin);
        }

        public static Temperature operator -(Temperature A, Temperature B)
        {
            return new Temperature(A.Kelvin - B.Kelvin, TemperatureType.Kelvin);
        }

        public static bool operator !=(Temperature A, Temperature B)
        {
            return !MathsHelpers.WithinTolerance(A.Kelvin, B.Kelvin);
        }

        public static Temperature operator *(Temperature A, int x)
        {
            return new Temperature(A.Kelvin * x, TemperatureType.Kelvin);
        }

        public static Temperature operator *(Temperature A, double x)
        {
            return new Temperature(A.Kelvin * x, TemperatureType.Kelvin);
        }

        public static Temperature operator *(Temperature A, float x)
        {
            return new Temperature(A.Kelvin * x, TemperatureType.Kelvin);
        }

        public static Temperature operator *(int x, Temperature A)
        {
            return new Temperature(A.Kelvin * x, TemperatureType.Kelvin);
        }

        public static Temperature operator *(double x, Temperature A)
        {
            return new Temperature(A.Kelvin * x, TemperatureType.Kelvin);
        }

        public static Temperature operator *(float x, Temperature A)
        {
            return new Temperature(A.Kelvin * x, TemperatureType.Kelvin);
        }

        public static Temperature operator /(Temperature A, int x)
        {
            return new Temperature(A.Kelvin / x, TemperatureType.Kelvin);
        }

        public static Temperature operator /(Temperature A, double x)
        {
            return new Temperature(A.Kelvin / x, TemperatureType.Kelvin);
        }

        public static Temperature operator /(Temperature A, float x)
        {
            return new Temperature(A.Kelvin / x, TemperatureType.Kelvin);
        }

        public static Temperature operator +(Temperature A, Temperature B)
        {
            return new Temperature(A.Kelvin + B.Kelvin, TemperatureType.Kelvin);
        }

        public static bool operator ==(Temperature A, Temperature B)
        {
            return MathsHelpers.WithinTolerance(A.Kelvin, B.Kelvin);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Temperature))
                return false;
            else
            {
                Temperature t = (obj as Temperature);

                return this == t;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public void SetTemperature(double temp, TemperatureType type)
        {
            switch (type)
            {
                case TemperatureType.Kelvin:
                    if (Kelvin < 0)
                    {
                        throw new TemperatureException("A temperature this low is not physically possible");
                    }
                    else
                    {
                        Kelvin = temp;
                        Celsius = KelvinToCelsius(temp);
                        Fahrenheit = KelvinToFahrenheit(temp);
                    }
                    break;

                case TemperatureType.Celsius:
                    if (CelsiusToKelvin(temp) < 0)
                    {
                        throw new TemperatureException("A temperature this low is not physically possible");
                    }
                    else
                    {
                        Kelvin = CelsiusToKelvin(temp);
                        Celsius = temp;
                        Fahrenheit = CelsiusToFahrenheit(temp);
                    }
                    break;

                case TemperatureType.Fahrenheit:
                    if (Kelvin < 0)
                    {
                        throw new TemperatureException("A temperature this low is not physically possible");
                    }
                    else
                    {
                        Kelvin = FahrenheitToKelvin(temp);
                        Celsius = FahrenheitToCelsius(temp);
                        Fahrenheit = temp;
                    }

                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}K, {1}C, {2}F", Kelvin, Celsius, Fahrenheit);
        }

        #endregion Public Methods

        #region Private Methods

        private double CelsiusToFahrenheit(double tempC)
        {
            return (9d / 5 * tempC) + 32;
        }

        private double CelsiusToKelvin(double tempC)
        {
            return tempC + 273.15;
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

        #endregion Private Methods

        #region Public Classes

        [Serializable]
        public class TemperatureException : Exception
        {
            #region Public Constructors

            public TemperatureException()
            {
            }

            public TemperatureException(string message) : base(message)
            {
            }

            public TemperatureException(string message, Exception inner) : base(message, inner)
            {
            }

            #endregion Public Constructors

            #region Protected Constructors

            protected TemperatureException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

            #endregion Protected Constructors
        }

        #endregion Public Classes
    }
}