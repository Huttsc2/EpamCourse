using EpamCourse.Webdriver.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamCourse.Webdriver.Pages;
using EpamCourse.Webdriver.UserData;
using EpamCourse.Webdriver.SoftAssertions;
using EpamCourse.Helpers;
using EpamCourse.Webdriver.Letter;
using EpamCourse.Webdriver.Steps;

namespace EpamCourseTests.Webdriver_Tests
{
    [TestClass]
    public class MailTests
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Browser _ = Browser.GetInstance();
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                Browser.GetInstance().TakeScreenshotOnFailure();
            }
            Browser.GetInstance().Quit();
        }

        [TestMethod]
        public void Login()
        {
            SoftAssertions softAssertions = new SoftAssertions();

            new MailSteps().LoginYandexMail(new TestDataReader().GetTestUsers().YandexMailData);
            new WebPages().YandexMainPage.UserPicButton.Click();

            string actualLogin = new WebPages().YandexMainPage.UserName.GetText();
            string expectionLogin = new TestDataReader().GetTestUsers().YandexMailData.Username;
            softAssertions.Add("Login", expectionLogin, actualLogin);
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void IncorrectUsernameLogin()
        {
            SoftAssertions softAssertions = new SoftAssertions();

            new WebPages().YandexMainPage.Open();
            new WebPages().YandexMainPage.LogInButton.Click();
            new WebPages().YandexPassportPage.UserNameArea.SendKey
                (
                new TestDataReader().GetTestUsers().YandexMailData.Login + 
                new RandomString().GetRandomString(8)
                );
            new WebPages().YandexPassportPage.SubmitButton.Click();
            try
            {
                string actualResult = new WebPages().YandexPassportPage.AlertArea.GetText();
                string expectedResult = "Такого аккаунта нет";
                softAssertions.Add("Alert", expectedResult, actualResult);
                softAssertions.AssertAll();
            }
            catch
            {
                Assert.Fail("No warning");
            }
        }

        [TestMethod]
        public void IncorrectPasswordLogin()
        {
            SoftAssertions softAssertions = new SoftAssertions();

            new WebPages().YandexMainPage.Open();
            new WebPages().YandexMainPage.LogInButton.Click();
            new WebPages().YandexPassportPage.UserNameArea.SendKey(new TestDataReader().GetTestUsers().YandexMailData.Login);
            new WebPages().YandexPassportPage.SubmitButton.Click();
            new WebPages().YandexPassportPage.PasswordArea.SendKey(new RandomString().GetRandomString(8));
            new WebPages().YandexPassportPage.SubmitButton.Click();
            try
            {
                string actualResult = new WebPages().YandexPassportPage.AlertArea.GetText();
                string expectedResult = "Неверный пароль";
                softAssertions.Add("Alert", expectedResult, actualResult);
                softAssertions.AssertAll();
            }
            catch
            {
                Assert.Fail("No warning");
            }
        }

        [TestMethod]
        public void EmptyUsernameLogin()
        {
            SoftAssertions softAssertions = new SoftAssertions();

            new WebPages().YandexMainPage.Open();
            new WebPages().YandexMainPage.LogInButton.Click();
            new WebPages().YandexPassportPage.SubmitButton.Click();
            try
            {
                string actualResult = new WebPages().YandexPassportPage.AlertArea.GetText();
                string expectedResult = "Логин не указан";
                softAssertions.Add("Alert", expectedResult, actualResult);
                softAssertions.AssertAll();
            }
            catch
            {
                Assert.Fail("No warning");
            }
        }

        [TestMethod]
        public void EmptyPasswordLogin()
        {
            SoftAssertions softAssertions = new SoftAssertions();

            new WebPages().YandexMainPage.Open();
            new WebPages().YandexMainPage.LogInButton.Click();
            new WebPages().YandexPassportPage.UserNameArea.SendKey(new TestDataReader().GetTestUsers().YandexMailData.Login);
            new WebPages().YandexPassportPage.SubmitButton.Click();
            new WebPages().YandexPassportPage.SubmitButton.Click();
            try
            {
                string actualResult = new WebPages().YandexPassportPage.AlertArea.GetText();
                string expectedResult = "Пароль не указан";
                softAssertions.Add("Alert", expectedResult, actualResult);
                softAssertions.AssertAll();
            }
            catch
            {
                Assert.Fail("No warning");
            }
        }

        [TestMethod]
        public void SendLetter()
        {
            SoftAssertions softAssertions = new SoftAssertions();
            LetterObject letterFromYandex = new LetterCreater
                (
                new TestDataReader().GetTestUsers().GoogleMailData.Email
                )
                .GetLetter();

            new MailSteps().LoginYandexMail(new TestDataReader().GetTestUsers().YandexMailData);
            new MailSteps().OpenYandexMailbox();
            new MailSteps().SendLetterFromYandx(letterFromYandex);
            Thread.Sleep(1000);//костыль, пока не разобрался как обработать всплывающий Alert
            new MailSteps().LoginGmail(new TestDataReader().GetTestUsers().GoogleMailData);
            new MailSteps().OpenGoogleMailbox();
            try
            {
                new WebPages().GmailMailPage.UnreadLetterBySubject(letterFromYandex.Subject).Click();
                string actualSender = new WebPages().GmailMailPage.OpenedLetterSenderArea.GetText();
                string actualMessage = new WebPages().GmailMailPage.OpenedLetterMessageArea.GetText();
                string actualSubject = new WebPages().GmailMailPage.OpenedLetterSubjectArea.GetText();
                softAssertions.Add("Sender", new TestDataReader().GetTestUsers().YandexMailData.Name, actualSender);
                softAssertions.Add("Message", letterFromYandex.Message, actualMessage);
                softAssertions.Add("Subject", letterFromYandex.Subject, actualSubject);
            }
            catch (Exception)
            {
                new WebPages().GmailMailPage.Open();
                new WebPages().GmailMailPage.LetterBySubject(letterFromYandex.Subject).Click();
                Assert.Fail("Email is not marked as unread");
            }
            catch
            {
                new WebPages().GmailMailPage.Open();
                Assert.Fail("The letter did not arrive");
            }
            softAssertions.AssertAll();
        }

        //считаю, что третий тест должен выглядеть так,
        //с новой процедурой отправки письма, ибо если
        //делать как написано в задании, то он
        //становится зависимым от предыдущего
        [TestMethod]
        public void ReadLetterAndChangeName()
        {
            SoftAssertions softAssertions = new SoftAssertions();
            LetterObject letterFromYandex = new LetterCreater
                (
                new TestDataReader().GetTestUsers().GoogleMailData.Email
                )
                .GetLetter();
            string messageFromGoogle = new RandomString().GetRandomString();

            new MailSteps().LoginYandexMail(new TestDataReader().GetTestUsers().YandexMailData);
            new MailSteps().OpenYandexMailbox();
            new MailSteps().SendLetterFromYandx(letterFromYandex);
            Thread.Sleep(1000);//костыль, пока не разобрался как обработать всплывающий Alert
            new MailSteps().LoginGmail(new TestDataReader().GetTestUsers().GoogleMailData);
            new MailSteps().OpenGoogleMailbox();
            new WebPages().GmailMailPage.LetterBySubject(letterFromYandex.Subject).Click();
            new WebPages().GmailMailPage.ReplyButton.Click();
            new WebPages().GmailMailPage.MessageArea.SendKey(messageFromGoogle);
            new WebPages().GmailMailPage.SendMessageButton.Click();
            Thread.Sleep(2000);//костыль, пока не разобрался как обработать всплывающий Alert
            new WebPages().YandexMailPage.Open();
            new WebPages().YandexMailPage.LetterBySubject(letterFromYandex.Subject).Click();
            new WebPages().YandexMailPage.LetterByMessageInReply(messageFromGoogle).Click();
            string newName = new WebPages().YandexMailPage.ReplyedLetterMessage(messageFromGoogle).GetText();
            new WebPages().YandexMailPage.UserPicButton.Click();
            new WebPages().YandexMailPage.UserPicButtonGoToSetting.Click();
            new WebPages().YandexPassportPage.ClearNameButton.Click();
            new WebPages().YandexPassportPage.NewNameArea.SendKey(newName);
            new WebPages().YandexPassportPage.SaveNewNameButton.Click();
            new TestDataWriter().WriteNewUsername(newName);
            new WebPages().YandexMailPage.UserPicButton.Click();
            new WebPages().YandexMailPage.AccountManagmentButton.Click();
            new WebPages().YandexIdPage.PersonalButton.Click();

            string actualUsername = new WebPages().YandexIdPage.UsernameArea.GetText();
            softAssertions.Add("Username", messageFromGoogle, actualUsername);
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void Username()
        {
            SoftAssertions softAssertions = new SoftAssertions();

            new MailSteps().LoginYandexMail(new TestDataReader().GetTestUsers().YandexMailData);
            new WebPages().YandexMainPage.UserPicButton.Click();
            new WebPages().YandexMainPage.AccountManagmentButton.Click();
            new WebPages().YandexIdPage.PersonalButton.Click();

            string actualUsername = new WebPages().YandexIdPage.UsernameArea.GetText();
            softAssertions.Add("Username", new TestDataReader().GetTestUsers().YandexMailData.Username, actualUsername);
            softAssertions.AssertAll();
        }

    }
}
