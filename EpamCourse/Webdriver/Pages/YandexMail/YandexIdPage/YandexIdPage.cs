using EpamCourse.Webdriver.PageElement;

namespace EpamCourse.Webdriver.Pages.YandexMail.YandexIdPage
{
    public class YandexIdPage : PageBase
    {
        public WebElement UserPicButton = new(isHidden: false, "//button[@class='UserID-Account']");
        public WebElement PersonalButton = new(isHidden: false, "//div[@class='PageTemplate_sidebar__jWClF']//a[@data-testid='personal-link']");
        public WebElement UsernameArea = new(isHidden: false, "//span[@data-testid='user-info-display-name']");
    }
}
