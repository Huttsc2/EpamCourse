using EpamCourse.Webdriver.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamCourse.Webdriver.Pages;
using EpamCourse.Webdriver.UserData;
using EpamCourse.Webdriver.SoftAssertions;
using EpamCourse.Helpers;
using EpamCourse.Webdriver.Letter;

namespace EpamCourseTests.Webdriver_Tests
{
    [TestClass]
    public class MailTests
    {
        [TestInitialize]
        public void Setup()
        {
            Browser _ = Browser.GetInstance();
        }

        [TestCleanup]
        public void CleanUp()
        {
            //Browser.GetInstance().Quit();
        }

        [TestMethod]
        public void Login()
        {
            WebPages webPages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            Users users = new TestDataReader().GetTestUsers();

            webPages.YandexMainPage.Open();
            webPages.YandexMainPage.LogInButton.Click();
            webPages.YandexPassportPage.UserNameArea.SendKey(users.YandexMailData.Login);
            webPages.YandexPassportPage.SubmitButton.Click();
            webPages.YandexPassportPage.PasswordArea.SendKey(users.YandexMailData.Password);
            webPages.YandexPassportPage.SubmitButton.Click();
            webPages.YandexMainPage.UserPicButton.Click();

            string actualLogin = webPages.YandexMainPage.UserName.GetText();
            string expectionLogin = users.YandexMailData.Login;
            softAssertions.Add("Login", expectionLogin, actualLogin);
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void IncorrectUsernameLogin()
        {
            WebPages webPages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            Users users = new TestDataReader().GetTestUsers();

            webPages.YandexMainPage.Open();
            webPages.YandexMainPage.LogInButton.Click();
            webPages.YandexPassportPage.UserNameArea.SendKey(users.YandexMailData.Login + 
                new RandomString().GetRandomString(8));
            webPages.YandexPassportPage.SubmitButton.Click();
            try
            {
                string actualResult = webPages.YandexPassportPage.AlertArea.GetText();
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
            WebPages webPages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            Users users = new TestDataReader().GetTestUsers();

            webPages.YandexMainPage.Open();
            webPages.YandexMainPage.LogInButton.Click();
            webPages.YandexPassportPage.UserNameArea.SendKey(users.YandexMailData.Login);
            webPages.YandexPassportPage.SubmitButton.Click();
            webPages.YandexPassportPage.PasswordArea.SendKey(new RandomString().GetRandomString(8));
            webPages.YandexPassportPage.SubmitButton.Click();
            try
            {
                string actualResult = webPages.YandexPassportPage.AlertArea.GetText();
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
            WebPages webPages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();

            webPages.YandexMainPage.Open();
            webPages.YandexMainPage.LogInButton.Click();
            webPages.YandexPassportPage.SubmitButton.Click();
            try
            {
                string actualResult = webPages.YandexPassportPage.AlertArea.GetText();
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
            WebPages webPages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            Users users = new TestDataReader().GetTestUsers();

            webPages.YandexMainPage.Open();
            webPages.YandexMainPage.LogInButton.Click();
            webPages.YandexPassportPage.UserNameArea.SendKey(users.YandexMailData.Login);
            webPages.YandexPassportPage.SubmitButton.Click();
            webPages.YandexPassportPage.SubmitButton.Click();
            try
            {
                string actualResult = webPages.YandexPassportPage.AlertArea.GetText();
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
            WebPages webPages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            Users users = new TestDataReader().GetTestUsers();
            string messageFromYandex = new RandomString().GetRandomString();
            string subjectFromYandex = new RandomString().GetRandomString();
            string messageFromGoogle = new RandomString().GetRandomString();
            Letter letterFromYandex = new LetterBuilder()
                .SetRecipient(users.GoogleMailData.Email)
                .SetMessage(messageFromYandex)
                .SetSubject(subjectFromYandex)
                .Build();

            webPages.YandexMainPage.Open();
            webPages.YandexMainPage.LogInButton.Click();
            webPages.YandexPassportPage.UserNameArea.SendKey(users.YandexMailData.Login);
            webPages.YandexPassportPage.SubmitButton.Click();
            webPages.YandexPassportPage.PasswordArea.SendKey(users.YandexMailData.Password);
            webPages.YandexPassportPage.SubmitButton.Click();
            webPages.YandexMainPage.UserPicButton.Click();
            webPages.YandexMainPage.OpenMailButton.Click();
            webPages.YandexMailPage.WriteLetterButton.Click();
            webPages.YandexMailPage.LetterRecipientArea.SendKey(letterFromYandex.Recipient);
            webPages.YandexMailPage.SubjectArea.SendKey(letterFromYandex.Subject);
            webPages.YandexMailPage.MessageArea.SendKey(letterFromYandex.Message);
            webPages.YandexMailPage.SendMessageButton.Click();
            Thread.Sleep(1000);
            webPages.GmailMainPage.Open();
            webPages.GmailMainPage.SignInButton.Click();
            webPages.GmailPassportPage.EmailOrPhoneArea.SendKey(users.GoogleMailData.Email);
            webPages.GmailPassportPage.NextButton.Click();
            webPages.GmailPassportPage.PasswordArea.SendKey(users.GoogleMailData.Password);
            webPages.GmailPassportPage.NextButton.Click();
            webPages.GmailMainPage.OpenMailButton.Click();
            try
            {
                webPages.GmailMailPage.UnreadLetterBySubject(letterFromYandex.Subject).Click();
                string actualSender = webPages.GmailMailPage.OpenedLetterSenderArea.GetText();
                string actualMessage = webPages.GmailMailPage.OpenedLetterMessageArea.GetText();
                string actualSubject = webPages.GmailMailPage.OpenedLetterSubjectArea.GetText();
                softAssertions.Add("Sender", users.YandexMailData.Name, actualSender);
                softAssertions.Add("Message", letterFromYandex.Message, actualMessage);
                softAssertions.Add("Subject", letterFromYandex.Subject, actualSubject);
                softAssertions.AssertAll();
                softAssertions.ClearAssertList();
            }
            catch (Exception)
            {
                webPages.GmailMailPage.LetterBySubject(letterFromYandex.Subject).Click();
                Assert.Fail("Email is not marked as unread");
            }
            catch
            {
                Assert.Fail("The letter did not arrive");
            }
            webPages.GmailMailPage.ReplyButton.Click();
            webPages.GmailMailPage.MessageArea.SendKey(messageFromGoogle);
            webPages.GmailMailPage.SendMessageButton.Click();
            webPages.YandexMailPage.Open();
            Browser.GetInstance().AlertAccept();
        }
    }
}
