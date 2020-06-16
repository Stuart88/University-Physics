using System;
using UniversityPhysics.Enums;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics.Maths
{
    public static class MathsHelpers
    {
        #region Public Fields

        /// <summary>
        /// Percentage of allowed difference when accounting for floating point errors
        /// </summary>
        public const double Tolerance = 0.5;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// For finding the rotation rate (in rads per second) of a planetary body based on the length of its day
        /// </summary>
        /// <param name="radius">Radius of the planentary body in metres</param>
        /// <param name="dayLength">Length of day</param>
        /// <param name="timeMeasure">The measure in which dayLength is given. Defaults to Hours</param>
        /// <returns>Vector(0, 0, rotation in rad/s)</returns>
        public static Vector DayLengthToRotation(double radius, double dayLength, TimeMeasure timeMeasure = TimeMeasure.Hour)
        {
            //convert dayLength to seconds
            dayLength = DayLengthToSeconds(dayLength, timeMeasure);

            //circumference / dayLength
            double radialVelocity = (2 * Math.PI * radius) / dayLength;
            // m/s

            double radsPerSec = radialVelocity / radius;

            return new Vector(0, 0, radsPerSec);
        }

        public static double DecimalPoints(this double d, int points)
        {
            double scale = Math.Pow(10, points);
            d = d * scale;
            d = Math.Round(d);

            return d / scale;
        }

        public static Vector DecimalPoints(this Vector d, int points)
        {
            double scale = Math.Pow(10, points);

            d = d * scale;

            d.X = Math.Round(d.X);
            d.Y = Math.Round(d.Y);
            d.Z = Math.Round(d.Z);

            return d / scale;
        }

        /// <summary>
        /// Calculates the distance in metres between two physical objects
        /// </summary>
        /// <returns>Distance in metres</returns>
        public static double DistanceTo(this PhysicsObjectBase obj, PhysicsObjectBase obj2)
        {
            return (obj.Position - obj2.Position).Abs();
        }

        /// <summary>
        /// Calculates the distance between two vector positions
        /// </summary>
        /// <returns>Distance in metres</returns>
        public static double DistanceTo(this Vector v1, Vector v2)
        {
            return (v1 - v2).Abs();
        }

        public static double ToDegrees(double radians)
        {
            return radians * 180d / Math.PI;
        }

        public static double ToRadians(double degrees)
        {
            return Math.PI * degrees / 180d;
        }

        /// <summary>
        /// Compares two double values and returns true if they are within 0.5% of each other
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool WithinTolerance(double a, double b)
        {
            //basic check.
            if (a == b)
                return true;

            // Convert both into positive values.
            // This ensures the higher of the two values is always the denominator
            // in division below, to prevents a DivideByZero exception.

            a = Math.Abs(a);
            b = Math.Abs(b);

            double diff = Math.Abs(a - b);

            double highest = Math.Max(a, b);

            double percentOff = (diff / highest) * 100;

            return percentOff < Tolerance;
        }

        #endregion Public Methods

        #region Private Methods

        private static double DayLengthToSeconds(double dayLength, TimeMeasure timeMeasure)
        {
            switch (timeMeasure)
            {
                case TimeMeasure.Second: return dayLength;
                case TimeMeasure.Minute: return dayLength * UnitsAndConstants.Constants.Time.Minute_Seconds;
                case TimeMeasure.Hour: return dayLength * UnitsAndConstants.Constants.Time.Hour_Seconds;
                case TimeMeasure.Day: return dayLength * UnitsAndConstants.Constants.Time.Day_Seconds;
                case TimeMeasure.Week: return dayLength * UnitsAndConstants.Constants.Time.Week_Seconds;
                case TimeMeasure.Month: return dayLength * UnitsAndConstants.Constants.Time.Month_Seconds;
                case TimeMeasure.Year: return dayLength * UnitsAndConstants.Constants.Time.Year_Seconds;
                default: return dayLength * UnitsAndConstants.Constants.Time.Hour_Seconds;
            };
        }

        #endregion Private Methods
    }
}