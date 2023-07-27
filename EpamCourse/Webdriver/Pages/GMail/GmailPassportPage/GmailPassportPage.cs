using EpamCourse.Webdriver.PageElement;

namespace EpamCourse.Webdriver.Pages.GMail.GmailPassportPage
{
    public class GmailPassportPage : PageBase
    {
        public WebElement EmailOrPhoneArea = new(isHidden: false, "//input[@type='email']");
        public WebElement PasswordArea = new(isHidden: false, "//input[@type='password']");
        public WebElement NextButton = new(isHidden: false, "//button[contains(@class, 'qIypjc TrZEUc')]");
    }
}
