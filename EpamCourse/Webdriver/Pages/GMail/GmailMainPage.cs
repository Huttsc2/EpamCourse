using EpamCourse.Webdriver.PageElement;

namespace EpamCourse.Webdriver.Pages.GMail
{
    public class GmailMainPage : PageBase
    {
        public WebElement SignInButton = new(isHidden: false, "//span[@class='gb_Od']");
        public WebElement OpenMailButton = new(isHidden: false, "//a[@aria-label='Gmail (opens a new tab)']");
        public WebElement UserPicButton = new(isHidden: false, "//img[@class='gb_n gbii']");
        public WebElement LogOutButton = new(isHidden: true, "//a[@class='V5tzAf jFfZdd']");
        public WebElement UsernameArea = new(isHidden: true, "//div[@class='Wdz6e']");

    }
}
