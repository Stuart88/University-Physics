using System;
using UniversityPhysics.Enums;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.Astrophysics
{
    public class GravitationalBody : PhysicsObjectBase
    {
        #region Public Constructors

        public GravitationalBody(double radius, double mass)
        {
            Radius = radius;
            Mass = mass;
        }

        #endregion Public Constructors

        #region Public Properties

        public double EscapeVelocity => Math.Sqrt(2 * Constants.Common.G * Mass / Radius);
        public double GravityAtSurface => Constants.Common.G * Mass / (Radius * Radius);
        public double Radius { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Calculates the gravitational force that exists between this body and another gravitational body.
        /// </summary>
        /// <returns>Force (Vector) directed toward this body, i.e. if the other body has higher gravitational strength,
        /// the force will be negative (directed away from this body)</returns>
        public Vector GravitationalForceOn(GravitationalBody b)
        {
            double distance = Math.Abs(Position.Abs() - b.Position.Abs());

            if (distance < Radius || distance < b.Radius)
                throw new Exception("Bodies must not be connected!");

            Vector direction = b.Position - Position;

            double r_squared = direction.Abs() * direction.Abs();

            var x = direction.Abs() * direction.Abs();

            return direction.Normalised() * Constants.Common.G * Mass * b.Mass / r_squared;
        }

        /// <summary>
        /// Finds the time to complete a full orbit about a gravitational body
        /// </summary>
        /// <param name="orbitRadius">Distance from centre of gravitational body</param>
        /// <param name="timeMeasure">Desired time measure for returned value</param>
        /// <returns>Orbit period time</returns>
        public double OrbitPeriodAtDistance(double orbitRadius, TimeMeasure timeMeasure = TimeMeasure.Second)
        {
            double periodInSeconds = Math.Sqrt(Math.Pow(orbitRadius, 3) * (4 * Math.Pow(Math.PI, 2)) / (Constants.Common.G * Mass));

            return timeMeasure switch
            {
                TimeMeasure.Second => periodInSeconds,
                TimeMeasure.Hour => periodInSeconds / Constants.Time.Hour_Seconds,
                TimeMeasure.Minute => periodInSeconds / Constants.Time.Minute_Seconds,
                TimeMeasure.Day => periodInSeconds / Constants.Time.Day_Seconds,
                TimeMeasure.Week => periodInSeconds / Constants.Time.Week_Seconds,
                TimeMeasure.Month => periodInSeconds / Constants.Time.Month_Seconds,
                TimeMeasure.Year => periodInSeconds / Constants.Time.Year_Seconds,
                _ => periodInSeconds / Constants.Time.Day_Seconds, //60 * 24
            };
        }

        #endregion Public Methods
    }
}