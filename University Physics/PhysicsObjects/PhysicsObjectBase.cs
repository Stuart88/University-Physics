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
        internal MagneticField MagneticField = new MagneticField();
        internal VelocityField VelocityField = new VelocityField();
        private Vector _acceleration = new Vector();
        private Vector _rotationalAcceleration = new Vector();
        private Vector _force = new Vector();
        private Vector _torque = new Vector();


        #endregion Internal Fields

        #region Public Properties

        /// <summary>
        /// Note: You cannot directly set acceleration because it is altered by multiple possible external factors.
        /// Instead, set the External Force property, as this will result in acceleration on the object. Note that this object's acceleration will also be affected by
        /// any electric or magnetic fields it is placed in, if it has charge.
        /// </summary>
        public Vector Acceleration
        {
            get => _acceleration;
        }

        public Vector Force
        {
            get => _force;
            internal set
            {
                _force = value;
                _acceleration = _force / this.Mass;
            }
        }

        /// <summary>
        /// Any extra translational force applied
        /// </summary>
        public Vector ExternalForce { get; set; } = new Vector();

        /// <summary>
        /// Note: You cannot directly set acceleration because it is altered by multiple possible external factors.
        /// Instead, set the ExternalTorque property (τ = Iα)
        /// </summary>
        public Vector RotationalAcceleration
        {
            get => _rotationalAcceleration;
        }

        public Vector ExternalTorque { get; set; } = new Vector();

        public Vector Torque
        {
            get => _torque;
            internal set
            {
                _torque = value;
                double aX = MomentOfInertia.X != 0 ? _torque.X / MomentOfInertia.X : 0;
                double aY = MomentOfInertia.Y != 0 ? _torque.Y / MomentOfInertia.Y : 0;
                double aZ = MomentOfInertia.Z != 0 ? _torque.Z / MomentOfInertia.Z : 0;

                _rotationalAcceleration = new Vector(aX, aY,aZ);
            }
        }

        /// <summary>
        /// Angular velocity in radians per second
        /// </summary>
        public Vector AngularVelocity { get; set; } = new Vector();

        public double Charge { get; set; } = 0d;

        public Vector KineticEnergy_Rotational => 0.5 * new Vector(_momentOfInertia.X * Math.Pow(this.AngularVelocity.X, 2), _momentOfInertia.Y * Math.Pow(this.AngularVelocity.Y, 2), _momentOfInertia.Z * Math.Pow(this.AngularVelocity.Z, 2));

        public Vector KineticEnergy_Translational => 0.5 * this.Mass * new Vector(this.Velocity.X * this.Velocity.X, this.Velocity.Y * this.Velocity.Y, this.Velocity.Z * this.Velocity.Z);

        public double LifeTime { get; set; } = 0d;

        private Mass _mass = 0d;
        /// <summary>
        /// Mass of the object. For Object 3D type, set mass via MassPoints setter.
        /// </summary>
        public Mass Mass
        {
            get =>
                this is Object3D
                    ? ((Object3D)this).Mass
                    : this._mass;

            set => this._mass = value;
        }

        public Vector MomentOfInertia => _momentOfInertia;

        public Vector Momentum =>
            this is Object3D
                ? this.Velocity * ((Object3D) this).Mass
                : this.Velocity * this.Mass;    

        public Vector Position { get; set; } = new Vector();

        /// <summary>
        /// Amount of rotation in radians from default/start position
        /// </summary>
        public Vector Rotation { get; set; } = new Vector();
        public double TimeElapsed { get; set; } = 0d;

        public double TotalEnergy => this.KineticEnergy_Translational.Abs() + this.KineticEnergy_Rotational.Abs();

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
            this.Velocity += acceleration * timeDelta;
        }

        public void AccelerateRotational(Vector acceleration, double timeDelta)
        {
            this.AngularVelocity += acceleration * timeDelta;
        }

        public void ApplyElectricField(ElectricField f)
        {
            ElectricField = f;
        }

        public void ApplyMagneticField(MagneticField b)
        {
            MagneticField = b;
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

        public void ClearMagneticField()
        {
            MagneticField = new MagneticField();
        }

        /// <summary>
        /// Updates Position, uses s = ut + 1/2 at^2. Any active velocity field will also be effected here.
        /// </summary>
        /// <param name="timeDelta"></param>
        public void Move(double timeDelta)
        {
            var eForce = ElectricField.Result(this.Position);
            var bForce = MagneticField.Result(this.Position);
            this.Force = eForce + bForce + this.ExternalForce;
            this.Torque = this.ExternalTorque;// + any other types of possible torque?

            if (Math.Abs(this.Velocity.Y) > 0)
            {

            }

            //Move based on current info
            this.Position += ((this.Velocity + VelocityField.Result(this.Position)) * timeDelta + 0.5 * this.Acceleration * timeDelta * timeDelta);
            this.Rotation += this.AngularVelocity * timeDelta;

            //Then set velocity to what it should be after acceleration has been applied (if any)
            Accelerate(this.Acceleration, timeDelta);
            AccelerateRotational(this.RotationalAcceleration, timeDelta);

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
                    return RotationToPeriod(this.AngularVelocity.X, timeMeasure);

                case Axis_Cartesian.Y:
                    //if (Rotation.Y == 0)
                    //    throw new Exception("There is no rotation on this axis!");
                    return RotationToPeriod(this.AngularVelocity.Y, timeMeasure);

                case Axis_Cartesian.Z:
                    //if (Rotation.Z == 0)
                    //    throw new Exception("There is no rotation on this axis!");
                    return RotationToPeriod(this.AngularVelocity.Z, timeMeasure);

                default:
                    //if (Rotation.Z == 0)
                    //    throw new Exception("Object is not rotating!");
                    return RotationToPeriod(this.AngularVelocity.Z, timeMeasure);
            }
        }

        //Private Methods

        public override string ToString()
        {
            string[] properties = new string[]
            {
                string.Format("{0} ---------- {1} ( kg )",  "Mass", this.Mass),
                string.Format("{0} ---------- {1}",  "Position", this.Position),
                string.Format("{0} ---------- {1} ( m/s )",  "Velocity", this.Velocity),
                string.Format("{0} ---------- {1} ( kg m/s )",  "Momentum", this.Momentum),
                string.Format("{0} ---------- {1} ( m/s^2 )",  "Acceleration", this.Acceleration),
                string.Format("{0} ---------- {1} ( As )",  "Charge", this.Charge),
                string.Format("{0} ---------- {1} ( J )",  "Kinetic Energy", this.KineticEnergy_Translational),
                string.Format("{0} ---------- {1} ( J )",  "Total Kinetic Energy", this.TotalEnergy),
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