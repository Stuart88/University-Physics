using System;

/*
 * Original work by https://github.com/BeyondBelief96
 * See: https://github.com/Stuart88/University-Physics/commit/d9ea9ad0b692210c0590b3690de0491c967fdce3
 * (Commit tracking history seems to have been lost after a very large reshuffle, sorry!)
 */

namespace UniversityPhysics.Maths
{
    public class ComplexNumber
    {
        #region Private Fields

        private double _imaginaryPart = 0d;

        private double _realPart = 0d;

        #endregion Private Fields

        #region Public Properties

        public double ImaginaryPart
        {
            get => _imaginaryPart;
            set
            {
                _imaginaryPart = value;
                SetMagnitude();
                SetPhase();
            }
        }

        public double Magnitude { get; private set; }

        //ComplexNumber Properties
        /// <summary>
        /// Phase in radians
        /// </summary>
        public double Phase { get; private set; }

        public double RealPart
        {
            get => _realPart;
            set
            {
                _realPart = value;
                SetMagnitude();
                SetPhase();
            }
        }

        #endregion Public Properties

        #region Public Constructors

        public ComplexNumber()
        {
        }

        public ComplexNumber(double realPart, double imagPart)
        {
            _realPart = realPart;
            _imaginaryPart = imagPart;

            SetMagnitude();
            SetPhase();
        }

        #endregion Public Constructors

        #region Public Methods

        //Subtraction Operator Overrride
        public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2)
        {
            double realSum = num1.RealPart - num2.RealPart;
            double imagSum = num1.ImaginaryPart - num2.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator -(double n, ComplexNumber c)
        {
            double realSum = n - c.RealPart;
            double imagSum = c.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator -(ComplexNumber c, double n)
        {
            double realSum = c.RealPart - n;
            double imagSum = c.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator -(int n, ComplexNumber c)
        {
            double realSum = n - c.RealPart;
            double imagSum = c.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator -(ComplexNumber c, int n)
        {
            double realSum = c.RealPart - n;
            double imagSum = c.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !MathsHelpers.WithinTolerance(a.RealPart, b.RealPart)
                   || !MathsHelpers.WithinTolerance(a.ImaginaryPart, b.ImaginaryPart);
        }

        //Multiplication Operator Override
        public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2)
        {
            ComplexNumber product = Multiply(num1, num2);
            return product;
        }

        public static ComplexNumber operator *(ComplexNumber c, int n)
        {
            return new ComplexNumber(c.RealPart * n, c.ImaginaryPart * n);
        }

        public static ComplexNumber operator *(int n, ComplexNumber c)
        {
            return new ComplexNumber(c.RealPart * n, c.ImaginaryPart * n);
        }

        public static ComplexNumber operator *(ComplexNumber c, double n)
        {
            return new ComplexNumber(c.RealPart * n, c.ImaginaryPart * n);
        }

        public static ComplexNumber operator *(double n, ComplexNumber c)
        {
            return new ComplexNumber(c.RealPart * n, c.ImaginaryPart * n);
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

        public static ComplexNumber operator /(ComplexNumber c, int n)
        {
            return new ComplexNumber(c.RealPart / n, c.ImaginaryPart / n);
        }

        public static ComplexNumber operator /(int n, ComplexNumber c)
        {
            return new ComplexNumber(n, 0) / c;
        }

        public static ComplexNumber operator /(ComplexNumber c, double n)
        {
            return new ComplexNumber(c.RealPart / n, c.ImaginaryPart / n);
        }

        public static ComplexNumber operator /(double n, ComplexNumber c)
        {
            return new ComplexNumber(n, 0) / c;
        }

        //Addition Operator Override
        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            double realSum = num1.RealPart + num2.RealPart;
            double imagSum = num1.ImaginaryPart + num2.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator +(double n, ComplexNumber c)
        {
            double realSum = n + c.RealPart;
            double imagSum = c.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator +(ComplexNumber c, double n)
        {
            double realSum = c.RealPart + n;
            double imagSum = c.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator +(int n, ComplexNumber c)
        {
            double realSum = n + c.RealPart;
            double imagSum = c.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static ComplexNumber operator +(ComplexNumber c, int n)
        {
            double realSum = c.RealPart + n;
            double imagSum = c.ImaginaryPart;
            return new ComplexNumber(realSum, imagSum);
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return MathsHelpers.WithinTolerance(a.RealPart, b.RealPart)
                   && MathsHelpers.WithinTolerance(a.ImaginaryPart, b.ImaginaryPart);
        }

        /// <summary>
        /// Conjugates the current complex number
        /// </summary>
        public void Conjugate()
        {
            ImaginaryPart *= -1.0;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ComplexNumber))
            {
                return false;
            }
            else
            {
                ComplexNumber v = obj as ComplexNumber;

                return this == v;
            }
        }

        /// <summary>
        /// Returns the conjugate of this complex number
        /// </summary>
        /// <returns></returns>
        public ComplexNumber GetConjugate()
        {
            return new ComplexNumber(RealPart, -1.0 * ImaginaryPart);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"{RealPart}{Sign()}{Math.Abs(ImaginaryPart)}i";
        }

        #endregion Public Methods

        #region Private Methods

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

        private void SetMagnitude()
        {
            Magnitude = Math.Sqrt(Math.Pow(RealPart, 2) + Math.Pow(ImaginaryPart, 2));
        }

        private void SetPhase()
        {
            Phase = Math.Atan2(ImaginaryPart, RealPart);
        }

        private string Sign()
        {
            if (ImaginaryPart < 0)
                return "-";
            else
                return "+";
        }

        #endregion Private Methods
    }
}