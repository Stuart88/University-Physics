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

        public double Magnitude { get;}

        public double Phase { get;}


        public double RealPart { get; set; }

        public double ImaginaryPart { get; set; }



        // Complex Number Methods

        private static ComplexNumber Foil (ComplexNumber num1, ComplexNumber num2)
        {
            
            var realterm = num1.RealPart * num2.RealPart;
            var crossterm1 = num1.RealPart * num2.ImaginaryPart;
            var crossterm2 = num1.ImaginaryPart * num2.RealPart;
            var imagterm = num1.ImaginaryPart * num2.ImaginaryPart;
            return new ComplexNumber(realterm - imagterm, crossterm1 + crossterm2);
        }


        //Addition Operator Override
        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            var RealSum = num1.RealPart + num2.RealPart;
            var ImagSum = num1.ImaginaryPart + num2.ImaginaryPart;
            return new ComplexNumber(RealSum, ImagSum);
        }

        public static ComplexNumber operator +(double num1, ComplexNumber num2)
        {
            var RealSum = num1 + num2.RealPart;
            var ImagSum = num2.ImaginaryPart;
            return new ComplexNumber(RealSum, ImagSum);
        }

        public static ComplexNumber operator +(ComplexNumber num1, double num2)
        {
            var RealSum = num1.RealPart + num2;
            var ImagSum = num1.ImaginaryPart;
            return new ComplexNumber(RealSum, ImagSum);
        }

        //Subtraction Operator Overrride
        public static ComplexNumber operator - (ComplexNumber num1, ComplexNumber num2)
        {
            var RealSum = num1.RealPart - num2.RealPart;
            var ImagSum = num1.ImaginaryPart - num2.ImaginaryPart;
            return new ComplexNumber(RealSum, ImagSum);
        }

        //Multiplication Operator Override
        public static ComplexNumber operator * (ComplexNumber num1, ComplexNumber num2)
        {
            var product = new ComplexNumber();
            product = ComplexNumber.Foil(num1,num2);
            return product;
            
        }

        //Division Operator Override
        public static ComplexNumber operator / (ComplexNumber cnum1, ComplexNumber cnum2)
        {

            double divMagnitude = cnum1.Magnitude / cnum2.Magnitude;
            double divAngle = (cnum1.Phase - cnum2.Phase);
            double divrealPart = divMagnitude * Math.Cos(divAngle);
            double divimagPart = divMagnitude * Math.Sin(divAngle);

            return new ComplexNumber(divrealPart, divimagPart);
        }

        public ComplexNumber Conjugate()
        {
            ImaginaryPart = -1.0*ImaginaryPart;

            return this;
        }

        public override string ToString()
        {
            return $"{RealPart}" + Sign() + $"{Math.Abs(ImaginaryPart)}i";
        }

        private string Sign()
        {
            if (ImaginaryPart < 0)
            {
                return "-";
            }
            else
            {
                return "+";
            }
        }

        






    }
}
