using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniversityPhysics.Maths;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class ComplexNumberTests
    {
        #region Private Fields

        private ComplexNumber A = new ComplexNumber(3,5);
        private ComplexNumber B = new ComplexNumber(1,2);

        #endregion Private Fields

        #region Public Methods

        [TestMethod]
        public void TestMagnitude()
        {
            double result = A.Magnitude;
            double expected = Math.Sqrt(34);

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        [TestMethod]
        public void TestPhase()
        {
            double result = A.Phase;
            double expected = Math.Atan2(5, 3);

            Assert.IsTrue(Helpers.WithinTolerance(result, expected));
        }

        [TestMethod]
        public void TestAddition()
        {
            ComplexNumber result = A + B;
            ComplexNumber expected = new ComplexNumber(4, 7);

            Assert.AreEqual(result, expected);

            ComplexNumber result2 = A + 4;
            ComplexNumber expected2 = new ComplexNumber(7, 5);

            Assert.AreEqual(result2, expected2);

            ComplexNumber result3 = 4 + A;
            ComplexNumber expected3 = new ComplexNumber(7, 5);

            Assert.AreEqual(result2, expected2);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            ComplexNumber result = A - B;
            ComplexNumber expected = new ComplexNumber(2, 3);

            Assert.AreEqual(result, expected);

            ComplexNumber result2 = A - 4;
            ComplexNumber expected2 = new ComplexNumber(-1, 5);

            Assert.AreEqual(result2, expected2);

            ComplexNumber result3 = 4 - A;
            ComplexNumber expected3 = new ComplexNumber(1, 5);

            Assert.AreEqual(result3, expected3);
        }

        [TestMethod]
        public void TestMultiplicaton()
        {
            ComplexNumber result = A * B;
            ComplexNumber expected = new ComplexNumber(-7, 11);

            Assert.AreEqual(result, expected);

            ComplexNumber testVal = new ComplexNumber(3, -5);
            ComplexNumber result2 = B * testVal;
            ComplexNumber expected2 = new ComplexNumber(13, 1);

            Assert.AreEqual(result2, expected2);

            ComplexNumber result3 = testVal * B;
            ComplexNumber expected3 = new ComplexNumber(13, 1);

            Assert.AreEqual(result3, expected3);

            ComplexNumber result4 = 3 * A * 4;
            ComplexNumber expected4 = new ComplexNumber(36, 60);

            Assert.AreEqual(result4, expected4);
        }

        [TestMethod]
        public void TestDivide()
        {
            ComplexNumber result = A / B;
            ComplexNumber expected = new ComplexNumber(2.6, -0.2);

            Assert.AreEqual(result, expected);

            ComplexNumber result2 = B / A;
            ComplexNumber expected2 = new ComplexNumber(13d/34, 1d/34);

            Assert.AreEqual(result2, expected2);

            ComplexNumber result3 = 1 / A / 2;
            ComplexNumber expected3 = new ComplexNumber(3d/68, -5d/68);
            Assert.AreEqual(result3, expected3);
        }

        [TestMethod]
        public void TestEqualityCompare()
        {
            bool result = A == B;
            Assert.IsFalse(result);

            bool result2 = A != B;
            Assert.IsTrue(result2);

            ComplexNumber C = new ComplexNumber(3, 5);

            bool result3 = A == C;
            Assert.IsTrue(result3);

        }

        [TestMethod]
        public void TestConjugation()
        {
            ComplexNumber result = A.Conjugate;
            ComplexNumber expected = new ComplexNumber(3, -5);

            Assert.AreEqual(result, expected);

            A.ConjugateSelf();

            Assert.AreEqual(A, expected);
        }

        [TestMethod]
        public void TestToString()
        {
            string result = A.ToString();
            string expected = "3+5i";

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestToPower()
        {
            ComplexNumber test = new ComplexNumber(3, 3);
            ComplexNumber result = test.ToPower(5);
            ComplexNumber expected = new ComplexNumber(-972, 972);
            Assert.AreEqual(result, expected);

            ComplexNumber result2 = test.ToPower(0);
            ComplexNumber expected2 = new ComplexNumber(1, 0);
            Assert.AreEqual(result2, expected2);

            ComplexNumber result3 = test.ToPower(-5);
            ComplexNumber expected3 = new ComplexNumber(-1d/1944, 1d/1944);
            Assert.IsTrue(result3 == expected3);
        }

        #endregion Public Methods
    }
}