using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics.FluidDynamics
{
    public static class CommonVelocityFields
    {
        #region Public Fields

        public static VelocityField FlowPast_Sphere = new VelocityField(SphereFlow_Func);
        public static VelocityField RankineVortex = new VelocityField(RankineVortex_Func);
        public static VelocityField RotatingCylinder = new VelocityField(RotatingCylinder_Func);
        public static VelocityField ShearFlow = new VelocityField(ShearFlow_Func);
        public static VelocityField StagnationPoint = new VelocityField(StagnationPointFlow_Func);
        public static VelocityField UniformStream = new VelocityField(UniformFlow_Func);
        public static VelocityField Vortex = new VelocityField(Vortex_Func);

        #endregion Public Fields

        #region Public Properties

        /// <summary>
        /// For preset velocity fields with a central object, e.g. flow around a sphere.
        /// </summary>
        public static double CentralObjectRadius { get; set; } = 0d;

        /// <summary>
        /// For central area of rankine vortex
        /// </summary>
        public static double CentralObjectRotation { get; set; } = 0d;

        /// <summary>
        /// Dimensions of velocity field container (often set to user screen size)
        /// </summary>
        public static Vector FieldDimensions { get; set; } = new Vector();

        /// <summary>
        /// Flow strength U for velocity field
        /// </summary>
        public static double FlowStrength { get; set; } = 0d;

        #endregion Public Properties

        #region Private Methods

        private static Vector RankineVortex_Func(Vector pos)
        {
            double xPos = pos.X - FieldDimensions.X / 2;
            double yPos = pos.Y - FieldDimensions.Y / 2;

            if (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2)) <= CentralObjectRadius)
            {
                return new Vector((-FlowStrength * (xPos)) / (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2))) - (CentralObjectRotation * (yPos)) / 2, ((CentralObjectRotation * (xPos)) / 2) - (FlowStrength * (yPos)) / (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2))));
            }
            else
            {
                return new Vector((-Math.Pow(CentralObjectRadius, 2) * CentralObjectRotation * (yPos)) / (2 * (Math.Pow(xPos, 2) + Math.Pow(yPos, 2))) - (FlowStrength * (xPos)) / (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2))), (Math.Pow(CentralObjectRadius, 2) * CentralObjectRotation * (xPos)) / (2 * (Math.Pow(xPos, 2) + Math.Pow(yPos, 2))) - (FlowStrength * (yPos)) / (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2))));
            }
        }

        private static Vector RotatingCylinder_Func(Vector pos)
        {
            double xPos = pos.X - FieldDimensions.X / 2;
            double yPos = pos.Y - FieldDimensions.Y / 2;
            double xysquare = Math.Pow(xPos, 2) + Math.Pow(yPos, 2);

            return new Vector((2 * 3.14 * Math.Pow(CentralObjectRadius, 2) * FlowStrength * (yPos * yPos - xPos * xPos) + xysquare * (2 * 3.14 * FlowStrength * xysquare - CentralObjectRotation * yPos)) / (2 * 3.14 * Math.Pow(xysquare, 2)), (xPos * (CentralObjectRotation * xysquare - 4 * 3.14 * Math.Pow(CentralObjectRadius, 2) * FlowStrength * yPos)) / (2 * 3.14 * Math.Pow(xysquare, 2)));
        }

        private static Vector ShearFlow_Func(Vector pos)
        {
            return new Vector(-FlowStrength * (pos.Y - FieldDimensions.Y), 0);
        }

        private static Vector SphereFlow_Func(Vector pos)
        {
            double xPos = pos.X - FieldDimensions.X / 2;
            double yPos = pos.Y - FieldDimensions.Y / 2;
            return new Vector(0.5 * FlowStrength * (((Math.Pow(CentralObjectRadius, 3)) / (Math.Pow((Math.Pow(xPos, 2) + Math.Pow(yPos, 2)), 1.5))) + 2) - (3 * Math.Pow(CentralObjectRadius, 3) * FlowStrength * Math.Pow(xPos, 2)) / (2 * Math.Pow((Math.Pow(xPos, 2) + Math.Pow(yPos, 2)), 2.5)), -(3 * Math.Pow(CentralObjectRadius, 3) * FlowStrength * (xPos) * (yPos)) / (2 * Math.Pow((Math.Pow(xPos, 2) + Math.Pow(yPos, 2)), 2.5)));
        }

        private static Vector StagnationPointFlow_Func(Vector pos)
        {
            double xPos = pos.X - FieldDimensions.X / 2;
            double yPos = pos.Y - FieldDimensions.Y / 2;
            return new Vector(FlowStrength * (xPos), -FlowStrength * (yPos));
        }

        private static Vector UniformFlow_Func(Vector pos)
        {
            return new Vector(FlowStrength, 0);
        }

        private static Vector Vortex_Func(Vector pos)
        {
            double xPos = pos.X - FieldDimensions.X / 2;
            double yPos = pos.Y - FieldDimensions.Y / 2;
            double angle = Math.Atan2(xPos, yPos);
            return new Vector((-FlowStrength * (xPos)) / (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2))) - (FlowStrength * (yPos)) / (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2))), (FlowStrength * (xPos)) / (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2))) - (FlowStrength * (yPos)) / (Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2))));
        }

        #endregion Private Methods
    }

    public class VelocityField : VectorField
    {
        #region Public Constructors

        public VelocityField()
        {
        }

        public VelocityField(Func<Vector, Vector> v) : base(v)
        {
        }

        #endregion Public Constructors
    }
}