using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityPhysics.Mechanics
{
    public class SimplePendulum
    {
        /// <summary>
        /// Simple Pendulum constructor
        /// </summary>
        /// <param name="stringLength">Length of pendulum string</param>
        /// <param name="mass">Mass of pendulum bob in kg</param>
        /// <param name="swingAngleRadians">Swing angle in radians. Should be less than pi/6 (for small angle approximationvalidity)</param>
        public SimplePendulum(double stringLength, double mass, double swingAngleRadians)
        {
            if (swingAngleRadians > Math.PI / 6)
                throw new Exception("Swing angle too large!");

            StringLength = stringLength;
            Mass = mass;
            SwingAngle = swingAngleRadians;
        }
        public double StringLength { get; set; }
        
        public double Mass { get; set; }

        /// <summary>
        /// Angle in radians
        /// </summary>
        public double SwingAngle { get; }
        public double LocalGravity { get; set; } = UnitsAndConstants.Constants.Common.StandardGravity;

        /// <summary>
        /// T = 1/f = 2 pi * sqrt(L/g)
        /// </summary>
        public double Period => 2 * Math.PI * Math.Sqrt(StringLength / LocalGravity);
        /// <summary>
        /// f = 1/T = sqrt(g/L) / (2 pi)
        /// </summary>
        public double Frequency => 1d / Period;
        /// <summary>
        /// ω = sqrt(g/L)
        /// </summary>
        public double AngularFrequency => Math.Sqrt(LocalGravity / StringLength);
    }
}
