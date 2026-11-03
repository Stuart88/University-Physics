using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class VectorTests
    {
        #region Private Fields

        private Vector A = new Vector(1, 1, 0);
        private Vector B = new Vector(0, 2, 2);

        #endregion Private Fields

        #region Public Methods

        [TestMethod]
        public void TestAngleBetween()
        {
            double RoundToSignificantDigits(double d, int digits)
            {
                if (d == 0)
                    return 0;

                double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
                return scale * Math.Round(d / scale, digits);
            }
            double resultRads = A.AngleBetween(B);
            double expectedRads = Math.PI / 3d;
            Assert.AreEqual(RoundToSignificantDigits(resultRads, 10), RoundToSignificantDigits(expectedRads, 10));

            double resultDeg = A.AngleBetween(B, AngleType.Degrees);
            double expectedDeg = 60;
            Assert.AreEqual(RoundToSignificantDigits(resultDeg, 10), RoundToSignificantDigits(expectedDeg, 10));
        }

        [TestMethod]
        public void TestCrossProduct()
        {
            Vector result = A.Cross(B);
            Vector expected = new Vector(2, -2, 2);
            Assert.AreEqual(expected, result);

            result = (A * B).Cross(A * B);
            expected = new Vector();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDotProduct()
        {
            double result = A.Dot(B);
            double expected = 2d;
            Assert.AreEqual(expected, result);

            result = B.Dot(A * B);
            expected = 0d;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestEqualsOperator()
        {
            bool result = A == new Vector(1, 1);
            bool expected = true;
            Assert.AreEqual(expected, result);

            result = A == B;
            expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestNormalise()
        {
            Vector result = A.Normalised();
            Vector expected = new Vector(1d / Math.Sqrt(2), 1d / Math.Sqrt(2));
            Assert.AreEqual(expected, result);
            Assert.AreEqual(result, A / Math.Sqrt(2));

            result = B.Normalised();
            expected = new Vector(0, 2d / Math.Sqrt(8), 2d / Math.Sqrt(8));
            Assert.AreEqual(expected, result);
            Assert.AreEqual(result, B / Math.Sqrt(8));
        }

        [TestMethod]
        public void TestNormaliseSelf()
        {
            A.NormaliseSelf();
            Vector expected = new Vector(1d / Math.Sqrt(2), 1d / Math.Sqrt(2));
            Assert.AreEqual(expected, A);

            B.NormaliseSelf();
            expected = new Vector(0, 2d / Math.Sqrt(8), 2d / Math.Sqrt(8));
            Assert.AreEqual(expected, B);
        }

        [TestMethod]
        public void TestNotEqualsOperator()
        {
            bool result = A != new Vector(1, 1);
            bool expected = false;
            Assert.AreEqual(expected, result);

            result = A != B;
            expected = true;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestOperators()
        {
            Vector result = A + B;
            Vector expected = new Vector(1, 3, 2);
            Assert.AreEqual(expected, result);

            result = B + A;
            expected = new Vector(1, 3, 2);
            Assert.AreEqual(expected, result);

            result = A - B;
            expected = new Vector(1, -1, -2);
            Assert.AreEqual(expected, result);

            result = B - A;
            expected = new Vector(-1, 1, 2);
            Assert.AreEqual(expected, result);

            result = A * B;
            expected = new Vector(2, -2, 2);
            Assert.AreEqual(expected, result);

            result = B * A;
            expected = new Vector(-2, 2, -2);
            Assert.AreEqual(expected, result);

            result = 2 * A;
            expected = new Vector(2, 2, 0);
            Assert.AreEqual(expected, result);

            result = 5f * A;
            expected = new Vector(5, 5, 0);
            Assert.AreEqual(expected, result);

            result = 0.00001 * A;
            expected = new Vector(0.00001, 0.00001, 0);
            Assert.AreEqual(expected, result);

            result = A * 2;
            expected = new Vector(2, 2, 0);
            Assert.AreEqual(expected, result);

            result = A * 5f;
            expected = new Vector(5, 5, 0);
            Assert.AreEqual(expected, result);

            result = A * 0.00001;
            expected = new Vector(0.00001, 0.00001, 0);
            Assert.AreEqual(expected, result);

            result = A / 2;
            expected = new Vector(0.5, 0.5, 0);
            Assert.AreEqual(expected, result);

            result = A / 5f;
            expected = new Vector(0.2, 0.2, 0);
            Assert.AreEqual(expected, result);

            result = A / 0.00001;
            expected = new Vector(100000, 100000, 0);
            Assert.IsTrue(Helpers.WithinTolerance(expected, result)); // uses tolerance check here because A/0.00001 has floating point error.

            void dividebyzero()
            {
                _ = A / 0;
            }
            Assert.ThrowsExactly<DivideByZeroException>(dividebyzero);
        }

        [TestMethod]
        public void TestToString()
        {
            string result = A.ToString();
            string expected = "X: 1, Y: 1, Z: 0";

            Assert.AreEqual(expected, result);
        }

        #endregion Public Methods
    }
}