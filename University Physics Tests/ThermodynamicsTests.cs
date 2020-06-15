using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics_Tests
{
    [TestClass]
    public class ThermoDynamicsTests
    {
        #region Public Methods

        [TestMethod]
        public void TestTemperature_Casting()
        {
            Temperature A = 45d;

            Assert.AreEqual(A.Kelvin, 45);
        }

        [TestMethod]
        public void TestTemperatureConversions()
        {
            double k = 0d;
            double c = 0d;
            double f = 0d;

            // First temp, Celsius
            Temperature temp = new Temperature(100, UniversityPhysics.Enums.TemperatureType.Celsius);

            k = temp.Kelvin;
            Assert.IsTrue(Helpers.WithinTolerance(k, 373.15));
            f = temp.Fahrenheit;
            Assert.IsTrue(Helpers.WithinTolerance(f, 212));
            c = temp.Celsius;
            Assert.IsTrue(Helpers.WithinTolerance(c, 100));

            //Assign new temp, Fahrenheit

            temp.SetTemperature(-109, UniversityPhysics.Enums.TemperatureType.Fahrenheit);

            k = temp.Kelvin;
            Assert.IsTrue(Helpers.WithinTolerance(k, 195));
            f = temp.Fahrenheit;
            Assert.IsTrue(Helpers.WithinTolerance(f, -109));
            c = temp.Celsius;
            Assert.IsTrue(Helpers.WithinTolerance(c, -78));

            //Assign new temp, Kelvin

            temp.SetTemperature(90, UniversityPhysics.Enums.TemperatureType.Kelvin);

            k = temp.Kelvin;
            Assert.IsTrue(Helpers.WithinTolerance(k, 90));
            f = temp.Fahrenheit;
            Assert.IsTrue(Helpers.WithinTolerance(f, -298));
            c = temp.Celsius;
            Assert.IsTrue(Helpers.WithinTolerance(c, -183));
        }

        [TestMethod]
        public void TestTemperatureOperators()
        {
            Temperature A = new Temperature(100, UniversityPhysics.Enums.TemperatureType.Kelvin);
            Temperature B = new Temperature(50, UniversityPhysics.Enums.TemperatureType.Kelvin);
            double x = 2;

            Temperature result = A + B;
            Temperature expected = new Temperature(150, UniversityPhysics.Enums.TemperatureType.Kelvin);

            Assert.AreEqual(expected, result);

            result = A - B;
            expected = new Temperature(50, UniversityPhysics.Enums.TemperatureType.Kelvin);

            Assert.AreEqual(expected, result);

            result = A * x;
            expected = new Temperature(200, UniversityPhysics.Enums.TemperatureType.Kelvin);

            Assert.AreEqual(expected, result);

            result = x * A;
            expected = new Temperature(200, UniversityPhysics.Enums.TemperatureType.Kelvin);

            Assert.AreEqual(expected, result);

            result = A / x;
            expected = new Temperature(50, UniversityPhysics.Enums.TemperatureType.Kelvin);

            Assert.AreEqual(expected, result);

            bool equalityCheck = A == B;
            Assert.IsFalse(equalityCheck);

            bool inequalityCheck = A != B;
            Assert.IsTrue(inequalityCheck);
        }

        [TestMethod]
        public void TestTempTooLowException()
        {
            Temperature A = new Temperature(100, UniversityPhysics.Enums.TemperatureType.Celsius);

            void SetTemp()
            {
                A.SetTemperature(-500, UniversityPhysics.Enums.TemperatureType.Celsius);
            }
            Assert.ThrowsException<Temperature.TemperatureException>(SetTemp);
        }

        #endregion Public Methods
    }
}