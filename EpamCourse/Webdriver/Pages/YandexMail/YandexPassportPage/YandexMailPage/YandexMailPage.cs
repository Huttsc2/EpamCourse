using EpamCourse.Webdriver.PageElement;

namespace EpamCourse.Webdriver.Pages.YandexMail.YandexPassportPage.YandexMailPage
{
    public class YandexMailPage : PageBase
    {
        public WebElement WriteLetterButton = new(isHidden: false, "//a[@href='#compose']");
        public WebElement LetterRecipientArea = new(isHidden: false, "//div[@id='compose-field-1']");
        public WebElement SubjectArea = new(isHidden: false, "//input[@name='subject']");
        public WebElement MessageArea = new(isHidden: false, "//div[@role='textbox']");
        public WebElement SendMessageButton = new(isHidden: false, "//button[@aria-disabled='false']");
        public WebElement UserPicButton = new(isHidden: false, "//div[contains(@class,'_ user-account')]/img[contains(@src, 'middle')]");
        public WebElement UserPicButtonGoToSetting = new(isHidden: false, "//div[@class='user-pic__camera']");
        public WebElement ExitButton = new(isHidden: false, "//a[contains(@class, 'action_exit')]");
        public WebElementCollection LettersByRecipient = new(isHidden: false, "//span[@title='test1.levin@yandex.ru']");
        public WebElement OpenedLetterSubjectArea = new(isHidden: false, "//div[@class='Title_content_Q-Xik']");
        public WebElement OpenedLetterMessageArea = new(isHidden: false, "//div[@class='MessageBody_body_pmf3j react-message-wrapper__body']");
        public WebElement AccountManagmentButton = new(isHidden: false, "//a[contains(@class,'passport')]");
        public WebElement ReplyedLetterMessage(string message)
        {
            return new WebElement(isHidden: false, $"//div[@dir='ltr' and contains(text(),'{message}')]");
        }
        public WebElement LetterByMessageInReply(string message)
        {
            return new WebElement(isHidden: false, $"//div[@count='1']//span[@title='{message}']");
        }
        public WebElement LetterBySubject(string subject)
        {
            return new WebElement(isHidden: false, $"//span[@title='{subject}']");
        }
    }
}
