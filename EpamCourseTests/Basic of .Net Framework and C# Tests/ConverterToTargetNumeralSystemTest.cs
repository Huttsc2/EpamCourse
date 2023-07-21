using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamCourse.Basic_of_dotnet_Framework_and_CSharp;

namespace EpamCourseTests.Basic_of_dotnet_Framework_and_CSharp_Tests
{
    [TestClass]
    public class ConverterToTargetNumeralSystemTest
    {
        [TestMethod]
        public void LowerLimitNumeralSystem()
        {
            int originalNumber = 17;
            int numeralSystem = 2;
            string expectedResult = "10001";
            string? actualResult = 
                new ConverterToTargetNumeralSystem(originalNumber, numeralSystem).GetConvertedNumber();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MiddleCaseNumeralSystem()
        {
            int originalNumber = 26;
            int numeralSystem = 11;
            string expectedResult = "24";
            string? actualResult = 
                new ConverterToTargetNumeralSystem(originalNumber, numeralSystem).GetConvertedNumber();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void UpperLimitNumeralSystem()
        {
            int originalNumber = 267;
            int numeralSystem = 20;
            string expectedResult = "D7";
            string? actualResult = 
                new ConverterToTargetNumeralSystem(originalNumber, numeralSystem).GetConvertedNumber();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void NegativeNumber()
        {
            int originalNumber = -264;
            int numeralSystem = 18;
            string expectedResult = "-EC";
            string? actualResult = new ConverterToTargetNumeralSystem(originalNumber, numeralSystem).GetConvertedNumber();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ZeroInput()
        {
            int originalNumber = 0;
            int numeralSystem = 5;
            string expectedResult = "0";
            string? actualResult = 
                new ConverterToTargetNumeralSystem(originalNumber, numeralSystem).GetConvertedNumber();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void BelowLowerLimit()
        {
            int originalNumber = 21;
            int numeralSystem = 1;
            try
            {
                string? convertedNumner = 
                    new ConverterToTargetNumeralSystem(originalNumber, numeralSystem).GetConvertedNumber();
                Assert.Fail("No exception thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Incorrect input data", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }

        [TestMethod]
        public void AboveUpperLimit()
        {
            int originalNumber = 274;
            int numeralSystem = 21;
            try
            {
                string? convertedNumner = 
                    new ConverterToTargetNumeralSystem(originalNumber, numeralSystem).GetConvertedNumber();
                Assert.Fail("No exception thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Incorrect input data", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }
    }
}
