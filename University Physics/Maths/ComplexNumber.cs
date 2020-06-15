using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace UniversityPhysics.Maths
{
    public class ComplexNumber
    {
        //ComplexNumber  Constructors
        public ComplexNumber()
        {
        }


        public ComplexNumber(double realPart, double imagPart)
        {
            RealPart = realPart;
            ImaginaryPart = imagPart;
            Magnitude = Math.Sqrt(Math.Pow(realPart, 2) + Math.Pow(imagPart, 2));
            Phase = Math.Atan2(imagPart, realPart);
        }

        //ComplexNumber Properties

        public double Magnitude { get; }

        /// <summary>
        /// Phase in radians
        /// </summary>
        public double Phase { get; }

        public double RealPart { get; set; }

        public double ImaginaryPart { get; set; }


        // Complex Number Methods

        /// <summary>
        /// Multiplies two complex numbers via the 'First, Inside, Outside, Last' method
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        private static ComplexNumber Multiply(ComplexNumber num1, ComplexNumber num2)
        {
            double first = num1.RealPart * num2.RealPart;
            double outside = num1.RealPart * num2.ImaginaryPart;
            double inside = num1.ImaginaryPart * num2.RealPart;
            double last = num1.ImaginaryPart * num2.ImaginaryPart;
            return new ComplexNumber(first - last, outside + inside);
        }

        /// <summary>
        /// Returns the conjugate of this complex number
        /// </summary>
        /// <returns></returns>
        public ComplexNumber GetConjugate()
        {
            return new ComplexNumber(this.RealPart, -1.0 * this.ImaginaryPart);
        }

        /// <summary>
        /// Conjugates the current complex number
        /// </summary>
        public void Conjugate()
        {
            this.ImaginaryPart *= -1.0;
        }

        //Addition Operator Override
        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            double realSum = num1.RealPart + num2.RealPart;
            double imagSum = num1.ImaginaryPart + num2.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator +(double num1, ComplexNumber num2)
        {
            double realSum = num1 + num2.RealPart;
            double imagSum = num2.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator +(ComplexNumber num1, double num2)
        {
            double realSum = num1.RealPart + num2;
            double imagSum = num1.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        //Subtraction Operator Overrride
        public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2)
        {
            double realSum = num1.RealPart - num2.RealPart;
            double imagSum = num1.ImaginaryPart - num2.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator -(double num1, ComplexNumber num2)
        {
            double realSum = num1 - num2.RealPart;
            double imagSum = num2.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator -(ComplexNumber num1, double num2)
        {
            double realSum = num1.RealPart - num2;
            double imagSum = num1.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        //Multiplication Operator Override
        public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2)
        {
            ComplexNumber product =  Multiply(num1, num2);
            return product;
        }

        //Division Operator Override
        public static ComplexNumber operator /(ComplexNumber cnum1, ComplexNumber cnum2)
        {
            double divMagnitude = cnum1.Magnitude / cnum2.Magnitude;
            double divAngle = cnum1.Phase - cnum2.Phase;
            double divrealPart = divMagnitude * Math.Cos(divAngle);
            double divimagPart = divMagnitude * Math.Sin(divAngle);

            return new ComplexNumber(divrealPart, divimagPart);
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return MathsHelpers.WithinTolerance(a.RealPart, b.RealPart)
                   && MathsHelpers.WithinTolerance(a.ImaginaryPart, b.ImaginaryPart);
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !MathsHelpers.WithinTolerance(a.RealPart, b.RealPart)
                   || !MathsHelpers.WithinTolerance(a.ImaginaryPart, b.ImaginaryPart);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ComplexNumber))
                return false;
            else
            {
                ComplexNumber v = (obj as ComplexNumber);

                return this == v;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        

        public override string ToString()
        {
            return $"{RealPart}{Sign()}{Math.Abs(ImaginaryPart)}i";
        }

        private string Sign()
        {
            if (ImaginaryPart < 0)
                return "-";
            else
                return "+";
        }
    }
}