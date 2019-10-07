using System;

namespace UniversityPhysics.Maths
{
    public enum AngleType 
    {
        Radians,
        Degrees
    }

    
    public interface IVector 
    {
        double Abs();
        double Dot(Vector v);
        Vector Cross(Vector v);
        void NormaliseSelf();
        Vector Normalised();
    }

    public class Vector : IVector
    {
        //Properties

        public double X { get; set; } = 0d;
        public double Y { get; set; } = 0d;
        public double Z { get; set; } = 0d;

        //Constructors 

        public Vector() { }
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

        //Methods

        public double Dot(Vector v)
        {
            return this.X * v.X + this.Y * v.Y + this.Z * v.Z;
        }

        public Vector Cross(Vector v)
        {
            return new Vector(Y * v.Z - Z * v.Y, Z * v.X - X * v.Z, X * v.Y - Y * v.X);
        }

        public void NormaliseSelf()
        {
            double abs = this.Abs();
            X /= abs;
            Y /= abs;
            Z /= abs;

        }

        public Vector Normalised()
        {
            return this / this.Abs();
        }

        public double AngleBetween(Vector v, AngleType angleType = AngleType.Radians)
        {
            double angleRads = Math.Acos(this.Dot(v) / (this.Abs() * v.Abs()));

            return angleType == AngleType.Radians
                ? angleRads
                : angleRads * 180d / Math.PI;
        }

        public double Abs()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        //Operators

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
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

            return new Vector(a.X / b, a.Y / b,  a.Z / b);
        }
        public static Vector operator /(Vector a, float b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }
        public static bool operator ==(Vector a, Vector b)
        {
            return WithinTolerance(a.X, b.X) 
                && WithinTolerance(a.Y,b.Y) 
                && WithinTolerance(a.Z, b.Z);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !WithinTolerance(a.X, b.X)
                || !WithinTolerance(a.Y, b.Y)
                || !WithinTolerance(a.Z, b.Z);
        }
            
        //Overrides
        
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Vector))
                return false;
            else
            {
                Vector v = (obj as Vector);

                //return v == this && v.GetHashCode() == this.GetHashCode();
                return this == v;
            }
            
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }


        //Private

        /// <summary>
        /// For vector comparison. Necessary for avoiding floating point accurary errors
        /// </summary>
        private const double tolerance = 0.0000001;
        private static bool WithinTolerance(double a, double b)
        {
            return Math.Abs(a - b) <= tolerance;
        }
    }

    
}
