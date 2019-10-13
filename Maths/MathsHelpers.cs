using System;
using UniversityPhysics.Enums;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics.Maths
{
    public static class MathsHelpers
    {
        #region Private Fields

        /// <summary>
        /// For value comparison. Necessary for avoiding floating point accurary errors
        /// </summary>
        private const double tolerance = 0.0000001;

        #endregion Private Fields

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
            dayLength = timeMeasure switch
            {
                TimeMeasure.Second => dayLength,
                TimeMeasure.Minute => dayLength * UnitsAndConstants.Constants.Time.Minute_Seconds,
                TimeMeasure.Hour => dayLength * UnitsAndConstants.Constants.Time.Hour_Seconds,
                TimeMeasure.Day => dayLength * UnitsAndConstants.Constants.Time.Day_Seconds,
                TimeMeasure.Week => dayLength * UnitsAndConstants.Constants.Time.Week_Seconds,
                TimeMeasure.Month => dayLength * UnitsAndConstants.Constants.Time.Month_Seconds,
                TimeMeasure.Year => dayLength * UnitsAndConstants.Constants.Time.Year_Seconds,
                _ => dayLength * UnitsAndConstants.Constants.Time.Hour_Seconds,
            };

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

        public static bool WithinTolerance(double a, double b)
        {
            return Math.Abs(a - b) <= tolerance;
        }

        #endregion Public Methods
    }
}