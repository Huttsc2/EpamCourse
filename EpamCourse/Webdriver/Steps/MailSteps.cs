using EpamCourse.Webdriver.Pages;
using EpamCourse.Webdriver.UserData;
using EpamCourse.Webdriver.Letter;

namespace EpamCourse.Webdriver.Steps
{
    public class MailSteps
    {
        public void LoginYandexMail(User user)
        {
            new WebPages().YandexMainPage.Open();
            new WebPages().YandexMainPage.LogInButton.Click();
            new WebPages().YandexPassportPage.UserNameArea.SendKey(user.Login);
            new WebPages().YandexPassportPage.SubmitButton.Click();
            new WebPages().YandexPassportPage.PasswordArea.SendKey(user.Password);
            new WebPages().YandexPassportPage.SubmitButton.Click();
        }

        public void OpenYandexMailbox()
        {
            new WebPages().YandexMainPage.UserPicButton.Click();
            new WebPages().YandexMainPage.OpenMailButton.Click();
        }

        public void SendLetterFromYandx(LetterObject letter)
        {
            new WebPages().YandexMailPage.WriteLetterButton.Click();
            new WebPages().YandexMailPage.LetterRecipientArea.SendKey(letter.Recipient);
            new WebPages().YandexMailPage.SubjectArea.SendKey(letter.Subject);
            new WebPages().YandexMailPage.MessageArea.SendKey(letter.Message);
            new WebPages().YandexMailPage.SendMessageButton.Click();
        }

        public void LoginGmail(User user)
        {
            new WebPages().GmailMainPage.Open();
            new WebPages().GmailMainPage.SignInButton.Click();
            new WebPages().GmailPassportPage.EmailOrPhoneArea.SendKey(user.Email);
            new WebPages().GmailPassportPage.NextButton.Click();
            new WebPages().GmailPassportPage.PasswordArea.SendKey(user.Password);
            new WebPages().GmailPassportPage.NextButton.Click();
        }

        public void OpenGoogleMailbox()
        {
            new WebPages().GmailMainPage.OpenMailButton.Click();
        }

        public void ChangeYandexUsername(string username)
        {

        }

        public void GoToSettingPageFromMailPageYandex()
        {

        }
    }
}
