﻿using System;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.Maths
{
    public interface IVector
    {
        #region Public Methods

        double Abs();

        Vector Cross(Vector v);

        double Dot(Vector v);

        Vector Normalised();

        void NormaliseSelf();

        #endregion Public Methods
    }

    public enum AngleType
    {
        Radians,
        Degrees
    }

    public class Vector : IVector
    {
        #region Public Properties

        public double X { get; set; } = 0d;

        public double Y { get; set; } = 0d;

        public double Z { get; set; } = 0d;

        #endregion Public Properties

        #region Public Constructors

        public Vector()
        {
        }

        //Constructors
        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #endregion Public Constructors

        #region Public Methods

        public static implicit operator Vector(double[] vals)
        {
            if (vals.Length == 2)
                return new Vector(vals[0], vals[1]);
            else if (vals.Length == 3)
                return new Vector(vals[0], vals[1], vals[2]);
            else
                throw new VectorException("Vector initialisation array must be of the form {x, y} or {x, y, z}");
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector operator -(Vector a)
        {
            return new Vector(-a.X, -a.Y, -a.Z);
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !MathsHelpers.WithinTolerance(a.X, b.X)
                || !MathsHelpers.WithinTolerance(a.Y, b.Y)
                || !MathsHelpers.WithinTolerance(a.Z, b.Z);
        }

        /// <summary>
        /// Returns cross product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, Vector b)
        {
            return a.Cross(b);
        }

        public static Vector operator *(Vector a, int b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator *(Vector a, float b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator *(int b, Vector a)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator *(double b, Vector a)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator *(float b, Vector a)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator *(Vector a, Mass m)
        {
            return a * m.Kilograms;
        }

        public static Vector operator *(Mass m, Vector a)
        {
            return a * m.Kilograms;
        }

        public static Vector operator /(Vector a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vector operator /(Vector a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vector operator /(Vector a, float b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vector operator /(Vector a, Mass m)
        {
            if (m == 0)
                throw new DivideByZeroException();

            return a / m.Kilograms;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        //Operators
        public static bool operator ==(Vector a, Vector b)
        {
            return MathsHelpers.WithinTolerance(a.X, b.X)
                && MathsHelpers.WithinTolerance(a.Y, b.Y)
                && MathsHelpers.WithinTolerance(a.Z, b.Z);
        }

        public double Abs()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public double AngleBetween(Vector v, AngleType angleType = AngleType.Radians)
        {
            double angleRads = Math.Acos(this.Dot(v) / (this.Abs() * v.Abs()));

            return angleType == AngleType.Radians
                ? angleRads
                : angleRads * 180d / Math.PI;
        }

        public Vector Cross(Vector v)
        {
            return new Vector(Y * v.Z - Z * v.Y, Z * v.X - X * v.Z, X * v.Y - Y * v.X);
        }

        public double Dot(Vector v)
        {
            return this.X * v.X + this.Y * v.Y + this.Z * v.Z;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Vector))
                return false;
            else
            {
                Vector v = (obj as Vector);

                return this == v;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public Vector Normalised()
        {
            return this / this.Abs();
        }

        public void NormaliseSelf()
        {
            double abs = this.Abs();
            X /= abs;
            Y /= abs;
            Z /= abs;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }

        public string ToString(int decimalPoints)
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X.DecimalPoints(decimalPoints), Y.DecimalPoints(decimalPoints), Z.DecimalPoints(decimalPoints));
        }

        #endregion Public Methods

        #region Public Classes

        [Serializable]
        public class VectorException : Exception
        {
            #region Public Constructors

            public VectorException()
            {
            }

            public VectorException(string message) : base(message)
            {
            }

            public VectorException(string message, Exception inner) : base(message, inner)
            {
            }

            #endregion Public Constructors

            #region Protected Constructors

            protected VectorException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

            #endregion Protected Constructors
        }

        #endregion Public Classes
    }
}