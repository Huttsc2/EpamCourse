using EpamCourse.Webdriver.PageElement;

namespace EpamCourse.Webdriver.Pages.GMail.GmailPassportPage.GmailMailPage
{
    public class GmailMailPage : PageBase
    {
        public WebElement WriteLetterButton = new(isHidden: false, "//div[@class='T-I T-I-KE L3']");
        public WebElement LetterRecipientArea = new(isHidden: false, "//input[@role='combobox']");
        public WebElement SubjectArea = new(isHidden: false, "//input[@name='subjectbox']");
        public WebElement MessageArea = new(isHidden: false, "//div[@aria-label='Message Body']");
        public WebElement SendMessageButton = new(isHidden: false, "//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']");
        public WebElement UserPicButton = new(isHidden: false, "//img[@class='gb_n gbii']");
        public WebElement ExitButton = new(isHidden: false, "//div[@class='T6SHIc']");
        public WebElement OpenedLetterSenderArea = new(isHidden: false, "//span[@class='gD']");
        public WebElement OpenedLetterSubjectArea = new(isHidden: false, "//h2[@class='hP']");
        public WebElement OpenedLetterMessageArea = new(isHidden: false, "//div[@class='ii gt' and not(@style)]");
        public WebElement ReplyButton = new(isHidden: false, "//span[@class='ams bkH']");
        public WebElement LetterBySubject(string subject)
        {
            return new WebElement(isHidden: false, $"//span[@class='bog']/span[text()='{subject}']");
        }
        public WebElement UnreadLetterBySubject(string subject)
        {
            return new WebElement(isHidden: false, $"//tr[@class='zA zE' and contains(., '{subject}')]");
        }
    }
}
