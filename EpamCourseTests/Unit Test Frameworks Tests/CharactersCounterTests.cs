using EpamCourse.Development_and_Build_Tools;
using EpamCourse.Unit_Test_Frameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamCourseTests.Unit_Test_Frameworks_Tests
{
    [TestClass]
    public class CharactersCounterTests
    {
        [TestMethod]
        public void EmptyStringGetLetter()
        {
            string input = "";
            int exptctedResult = 0;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameLettersCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void NullStringGetLetter()
        {
            string input = null;
            int exptctedResult = 0;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameLettersCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void EmptyStringGetDigit()
        {
            string input = "";
            int exptctedResult = 0;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameDigitsCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void NullStringGetDigit()
        {
            string input = null;
            int exptctedResult = 0;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameDigitsCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void OneLetterGetDigit()
        {
            string input = "a";
            int exptctedResult = 0;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameDigitsCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void OneDigitGetLetter()
        {
            string input = "1";
            int exptctedResult = 0;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameLettersCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void OneDigitGetDigit()
        {
            string input = "5";
            int exptctedResult = 1;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameDigitsCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void OneLetterGetLetter()
        {
            string input = "A";
            int exptctedResult = 1;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameLettersCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void SameLetterInRow()
        {
            string input = "AaAaA";
            int exptctedResult = 5;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameLettersCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void SameDigitInRow()
        {
            string input = "22222";
            int exptctedResult = 5;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameDigitsCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void DifferentLetterInRow()
        {
            string input = "qwert";
            int exptctedResult = 1;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameLettersCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void DifferentDigitInRow()
        {
            string input = "45678";
            int exptctedResult = 1;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameDigitsCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void TwoSameLetterInSubstring()
        {
            string input = "qqwert";
            int exptctedResult = 2;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameLettersCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }

        [TestMethod]
        public void TwoSameDigitInSubstring()
        {
            string input = "456788";
            int exptctedResult = 2;
            int actualResult = new CharactersCounter(input).GetMaxConsecutiveSameDigitsCount();
            Assert.AreEqual(exptctedResult, actualResult);
        }
    }
}
