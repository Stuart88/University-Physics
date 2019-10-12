using System;
using UniversityPhysics.Enums;
using UniversityPhysics.Maths;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.PhysicsObjects
{
    public abstract class PhysicsObjectBase
    {

        #region Internal Fields

        internal Vector _momentOfInertia = new Vector();
        internal double _object3DMass = 0d;

        #endregion Internal Fields

        #region Public Properties

        public Vector Acceleration { get; set; } = new Vector();

        public double Charge { get; set; } = 0d;

        public Vector KineticEnergy_Rotational
        {
            get { return 0.5 * new Vector(_momentOfInertia.X * Math.Pow(Rotation.X, 2), _momentOfInertia.Y * Math.Pow(Rotation.Y, 2), _momentOfInertia.Z * Math.Pow(Rotation.Z, 2)); }
        }

        public Vector KineticEnergy_Translational
        {
            get { return 0.5 * Mass * new Vector(Velocity.X * Velocity.X, Velocity.Y * Velocity.Y, Velocity.Z * Velocity.Z); }
        }

        /// <summary>
        /// Mass of the object. For Object 3D type, set mass via MassPoints setter.
        /// </summary>
        public double Mass { get; set; } = 0d;

        public Vector MomentOfInertia { get { return _momentOfInertia; } }

        public Vector Momentum
        {
            get
            {
                return this is Object3D
                    ? Velocity * _object3DMass
                    : Velocity * Mass;
            }
        }

        public Vector Position { get; set; } = new Vector();

        public Vector Rotation { get; set; } = new Vector();

        public Vector RotationalAcceleration { get; set; } = new Vector();

        public double TotalEnergy
        {
            get
            {
                return KineticEnergy_Translational.Abs() + KineticEnergy_Rotational.Abs();
            }
        }

        public Vector Velocity { get; set; } = new Vector();

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Updates velocity via v = u + at
        /// </summary>
        /// <param name="acceleration"></param>
        /// <param name="timeDelta"></param>
        public void Accelerate(Vector acceleration, double timeDelta)
        {
            Velocity += acceleration * timeDelta;
        }

        /// <summary>
        /// Adds an extra force to the object. (Updates Acceleration property via F=ma ).
        /// </summary>
        public void AddForce_Translational(Vector force)
        {
            Acceleration += (force / Mass);
        }

        /// <summary>
        /// Updates Position, uses s = ut + 1/2 at^2
        /// </summary>
        /// <param name="timeDelta"></param>
        public void Move(double timeDelta)
        {
            Position += (Velocity * timeDelta + 0.5 * Acceleration * timeDelta * timeDelta);
        }

        /// <summary>
        /// Gives the time to complete one full rotation about the given axis
        /// </summary>
        /// <param name="timeMeasure">Desired time measure for returned value</param>
        /// <returns>Rotation period in the desired time format</returns>
        public double RotationPeriod(Axis_Cartesian axis, TimeMeasure timeMeasure = TimeMeasure.Second)
        {
            switch (axis)
            {
                case Axis_Cartesian.X:
                    if (Rotation.X == 0)
                        throw new Exception("There is no rotation on this axis!");
                    return RotationToPeriod(Rotation.X, timeMeasure);

                case Axis_Cartesian.Y:
                    if (Rotation.Y == 0)
                        throw new Exception("There is no rotation on this axis!");
                    return RotationToPeriod(Rotation.Y, timeMeasure);

                case Axis_Cartesian.Z:
                    if (Rotation.Z == 0)
                        throw new Exception("There is no rotation on this axis!");
                    return RotationToPeriod(Rotation.Z, timeMeasure);

                default:
                    if (Rotation.Z == 0)
                        throw new Exception("Object is not rotating!");
                    return RotationToPeriod(Rotation.Z, timeMeasure);
            }
        }

        //Private Methods

        public override string ToString()
        {
            string[] properties = new string[]
            {
                string.Format("{0} ---------- {1} ( kg )",  "Mass", Mass),
                string.Format("{0} ---------- {1}",  "Position", Position),
                string.Format("{0} ---------- {1} ( m/s )",  "Velocity", Velocity),
                string.Format("{0} ---------- {1} ( kg m/s )",  "Momentum", Momentum),
                string.Format("{0} ---------- {1} ( m/s^2 )",  "Acceleration", Acceleration),
                string.Format("{0} ---------- {1} ( As )",  "Charge", Charge),
                string.Format("{0} ---------- {1} ( J )",  "Kinetic Energy", KineticEnergy_Translational),
                string.Format("{0} ---------- {1} ( J )",  "Total Kinetic Energy", TotalEnergy),
            };

            return string.Join('\n', properties);
        }

        #endregion Public Methods

        #region Private Methods

        private double RotationToPeriod(double rotation, TimeMeasure timeMeasure)
        {
            // T = 2Pi / rotation

            double periodInSeconds = 2 * Math.PI / rotation;

            return timeMeasure switch
            {
                TimeMeasure.Second => periodInSeconds,
                TimeMeasure.Hour => periodInSeconds / Constants.Time.Hour_Seconds,
                TimeMeasure.Minute => periodInSeconds / Constants.Time.Minute_Seconds,
                TimeMeasure.Day => periodInSeconds / Constants.Time.Day_Seconds,
                TimeMeasure.Week => periodInSeconds / Constants.Time.Week_Seconds,
                TimeMeasure.Month => periodInSeconds / Constants.Time.Month_Seconds,
                TimeMeasure.Year => periodInSeconds / Constants.Time.Year_Seconds,
                _ => periodInSeconds
            };
        }

        #endregion Private Methods

    }
}