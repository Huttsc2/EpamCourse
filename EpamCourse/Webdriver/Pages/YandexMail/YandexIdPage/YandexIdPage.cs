using EpamCourse.Webdriver.PageElement;

namespace EpamCourse.Webdriver.Pages.YandexMail.YandexIdPage
{
    public class YandexIdPage : PageBase
    {
        public WebElement UserPicButton = new(isHidden: false, "//button[@class='UserID-Account']");
        public WebElement UsernameArea = new(isHidden: false, "//span[@class='Text Text_typography_primary UserId-FirstLine']");
    }
}
