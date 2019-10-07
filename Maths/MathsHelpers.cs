using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.Enums;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics.Maths
{
    public static class MathsHelpers
    {
        /// <summary>
        /// Calculates the distance between two physical objects
        /// </summary>
        /// <returns></returns>
        public static double DistanceBetween(this PhysicsObjectBase obj, PhysicsObjectBase obj2)
        {
            return (obj.Position - obj2.Position).Abs();
        }

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

        
        
    }
}
