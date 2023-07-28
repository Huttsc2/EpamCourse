using EpamCourse.Webdriver.PageElement;

namespace EpamCourse.Webdriver.Pages.YandexMail.YandexPassportPage
{
    public class YandexPassportPage : PageBase
    {
        public WebElement UserNameArea = new(isHidden: false, "//input[@name='login']");
        public WebElement PasswordArea = new(isHidden: false, "//input[@type='password']");
        public WebElement SubmitButton = new(isHidden: false, "//button[@type='submit']");
        public WebElement CurrentAccountButton = new(isHidden: false, "//a[contains(@class, 'CurrentAccount')]");
        public WebElement AddAccountButton = new(isHidden: false, "//span[@class='AddAccountButton-icon']");
        public WebElement AlertArea = new(isHidden: false, "//div[@aria-live='polite']");
        public WebElement ClearNameButton = new(isHidden: false, "//span[contains(@class,'Clear Textinput-')]");
        public WebElement NewNameArea = new(isHidden: false, "//input[@type='text']");
        public WebElement SaveNewNameButton = new(isHidden: false, "//button[@type='submit']");
    }
}
