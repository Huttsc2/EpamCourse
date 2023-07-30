using EpamCourse.Webdriver.PageElement;

namespace EpamCourse.Webdriver.Pages.YandexMail
{
    public class YandexMainPage : PageBase
    {
        public WebElement LogInButton = new(isHidden: false, "//a[@class='Button2 Button2_type_link Button2_view_default Button2_size_m']");
        public WebElement UserPicButton = new(isHidden: false, "//div[contains(@class,'_ user-account')]/img[contains(@src, 'middle')]");
        public WebElement OpenMailButton = new(isHidden: false, "//span[@class='legouser__menu-counter']");
        public WebElement UserName = new(isHidden: false, "//div[@class='user-account user-account_has-subname_yes legouser__account i-bem']");
        public WebElement UserPicGoToSettingButton = new(isHidden: false, "//div[@class='user-pic__camera']");
        public WebElement UsernameArea = new(isHidden: false, "//div[contains(@class,'subname')]/span[contains(@class, 'user')]");
        public WebElement AccountManagmentButton = new(isHidden: false, "//a[@class='menu__item menu__item_type_link legouser__menu-item legouser__menu-item_action_passport']");
    }
}
