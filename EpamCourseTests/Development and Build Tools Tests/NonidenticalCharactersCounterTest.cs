using EpamCourse.Development_and_Build_Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpamCourseTests.Development_and_Build_Tools_Tests;

[TestClass]
public class NonidenticalCharactersCounterTest
{
    [TestMethod]
    public void UniqueCharacters()
    {
        string input = "qwer";
        int exptctedResult = 4;
        int actualResult = new NonidenticalCharactersCouner(input).GetMaxNumber();
        Assert.AreEqual(exptctedResult, actualResult);
    }

    [TestMethod]
    public void MostNonidenticalCharactersInFirstPart()
    {
        string input = "asdqqwe";
        int exptctedResult = 4;
        int actualResult = new NonidenticalCharactersCouner(input).GetMaxNumber();
        Assert.AreEqual(exptctedResult, actualResult);
    }

    [TestMethod]
    public void EmptyString()
    {
        string input = "";
        int exptctedResult = 0;
        int actualResult = new NonidenticalCharactersCouner(input).GetMaxNumber();
        Assert.AreEqual(exptctedResult, actualResult);
    }

    [TestMethod]
    public void NullString()
    {
        string input = null;
        int exptctedResult = 0;
        int actualResult = new NonidenticalCharactersCouner(input).GetMaxNumber();
        Assert.AreEqual(exptctedResult, actualResult);
    }

    [TestMethod]
    public void OneCharacter()
    {
        string input = "1";
        int exptctedResult = 1;
        int actualResult = new NonidenticalCharactersCouner(input).GetMaxNumber();
        Assert.AreEqual(exptctedResult, actualResult);
    }

    [TestMethod]
    public void SameCharacters()
    {
        string input = "1111";
        int exptctedResult = 1;
        int actualResult = new NonidenticalCharactersCouner(input).GetMaxNumber();
        Assert.AreEqual(exptctedResult, actualResult);
    }

    [TestMethod]
    public void RepeatingCharacters()
    {
        string input = "12121212";
        int exptctedResult = 8;
        int actualResult = new NonidenticalCharactersCouner(input).GetMaxNumber();
        Assert.AreEqual(exptctedResult, actualResult);
    }

    [TestMethod]
    public void MostNonidenticalCharactersInLastPart()
    {
        string input = "1233123456";
        int exptctedResult = 7;
        int actualResult = new NonidenticalCharactersCouner(input).GetMaxNumber();
        Assert.AreEqual(exptctedResult, actualResult);
    }
}