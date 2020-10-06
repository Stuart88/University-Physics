using System;
using UniversityPhysics.Electromagnetism;
using UniversityPhysics.Enums;
using UniversityPhysics.FluidDynamics;
using UniversityPhysics.Maths;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.PhysicsObjects
{
    public abstract class PhysicsObjectBase
    {
        #region Internal Fields

        internal Vector _momentOfInertia = new Vector();
        internal double _object3DMass = 0d;
        internal ElectricField ElectricField = new ElectricField();
        internal VelocityField VelocityField = new VelocityField();

        #endregion Internal Fields

        #region Public Properties

        public Vector Acceleration { get; set; } = new Vector();

        /// <summary>
        /// Angular velocity in radians per second
        /// </summary>
        public Vector AngularVelocity { get; set; } = new Vector();

        public double Charge { get; set; } = 0d;

        public Vector KineticEnergy_Rotational
        {
            get { return 0.5 * new Vector(_momentOfInertia.X * Math.Pow(AngularVelocity.X, 2), _momentOfInertia.Y * Math.Pow(AngularVelocity.Y, 2), _momentOfInertia.Z * Math.Pow(AngularVelocity.Z, 2)); }
        }

        public Vector KineticEnergy_Translational
        {
            get { return 0.5 * Mass * new Vector(Velocity.X * Velocity.X, Velocity.Y * Velocity.Y, Velocity.Z * Velocity.Z); }
        }

        public double LifeTime { get; set; } = 0d;

        /// <summary>
        /// Mass of the object. For Object 3D type, set mass via MassPoints setter.
        /// </summary>
        public Mass Mass { get; set; } = 0d;

        public Vector MomentOfInertia { get { return _momentOfInertia; } }

        public Vector Momentum
        {
            get
            {
                return this is Object3D
                    ? Velocity * ((Object3D) this).Mass
                    : Velocity * Mass;
            }
        }

        public Vector Position { get; set; } = new Vector();

        /// <summary>
        /// Amount of rotation in radians from default/start position
        /// </summary>
        public Vector Rotation { get; set; } = new Vector();

        public Vector RotationalAcceleration { get; set; } = new Vector();
        public double TimeElapsed { get; set; } = 0d;

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

        public void AccelerateRotational(Vector acceleration, double timeDelta)
        {
            this.AngularVelocity += acceleration * timeDelta;
        }

        /// <summary>
        /// Adds an extra force to the object. (Updates Acceleration property via F=ma ).
        /// </summary>
        public void AddForce_Translational(Vector force)
        {
            Acceleration += (force / Mass);
        }

        public void ClearForce_Translational()
        {
            Acceleration = new Vector();
        }

        public void ClearForce_Rotational()
        {
            RotationalAcceleration = new Vector();
        }

        public void ApplyElectricField(ElectricField f)
        {
            //AddForce_Translational(f.Result(Position) * Charge);
            ElectricField = f;
        }

        public void ApplyVelocityField(VelocityField f)
        {
            VelocityField = f;
        }

        public void ClearElectricField()
        {
            ElectricField = new ElectricField();
        }

        public void ClearVelocityField()
        {
            VelocityField = new VelocityField();
        }

        /// <summary>
        /// Updates Position, uses s = ut + 1/2 at^2. Any active velocity field will also be effected here.
        /// </summary>
        /// <param name="timeDelta"></param>
        public void Move(double timeDelta)
        {
            //Move based on current info
            Position += ((Velocity + VelocityField.Result(Position)) * timeDelta + 0.5 * Acceleration * timeDelta * timeDelta);
            Rotation += AngularVelocity * timeDelta;

            //Then set velocity to what it should be after acceleration has been applied (if any)
            Accelerate(Acceleration, timeDelta);
            AccelerateRotational(RotationalAcceleration, timeDelta);
        }

        public Vector RotationAsDegreesPerSecond()
        {
            return this.Rotation * 180f / Math.PI;
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
                    //if (Rotation.X == 0)
                    //    throw new Exception("There is no rotation on this axis!");
                    return RotationToPeriod(AngularVelocity.X, timeMeasure);

                case Axis_Cartesian.Y:
                    //if (Rotation.Y == 0)
                    //    throw new Exception("There is no rotation on this axis!");
                    return RotationToPeriod(AngularVelocity.Y, timeMeasure);

                case Axis_Cartesian.Z:
                    //if (Rotation.Z == 0)
                    //    throw new Exception("There is no rotation on this axis!");
                    return RotationToPeriod(AngularVelocity.Z, timeMeasure);

                default:
                    //if (Rotation.Z == 0)
                    //    throw new Exception("Object is not rotating!");
                    return RotationToPeriod(AngularVelocity.Z, timeMeasure);
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

            return string.Join("\n", properties);
        }

        #endregion Public Methods

        #region Private Methods

        private double RotationToPeriod(double rotation, TimeMeasure timeMeasure)
        {
            // T = 2Pi / rotation

            double periodInSeconds = 2 * Math.PI / rotation;

            switch (timeMeasure)
            {
                case TimeMeasure.Second: return periodInSeconds;
                case TimeMeasure.Hour: return periodInSeconds / Constants.Time.Hour_Seconds;
                case TimeMeasure.Minute: return periodInSeconds / Constants.Time.Minute_Seconds;
                case TimeMeasure.Day: return periodInSeconds / Constants.Time.Day_Seconds;
                case TimeMeasure.Week: return periodInSeconds / Constants.Time.Week_Seconds;
                case TimeMeasure.Month: return periodInSeconds / Constants.Time.Month_Seconds;
                case TimeMeasure.Year: return periodInSeconds / Constants.Time.Year_Seconds;
                default: return periodInSeconds;
            };
        }

        #endregion Private Methods
    }
}