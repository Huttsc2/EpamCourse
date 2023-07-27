using EpamCourse.Webdriver.Pages.YandexMail;
using EpamCourse.Webdriver.Pages.YandexMail.YandexPassportPage;
using EpamCourse.Webdriver.Pages.YandexMail.YandexPassportPage.YandexMailPage;
using EpamCourse.Webdriver.Pages.GMail;
using EpamCourse.Webdriver.Pages.GMail.GmailPassportPage;
using EpamCourse.Webdriver.Pages.GMail.GmailPassportPage.GmailMailPage;

namespace EpamCourse.Webdriver.Pages;

public class WebPages
{
    public YandexMainPage YandexMainPage
    {
        get
        {
            YandexMainPage yandexMainPage = new();
            yandexMainPage.SetUrl("https://360.yandex.ru/");
            return yandexMainPage;
        }
    }

    public YandexPassportPage YandexPassportPage
    {
        get
        {
            YandexPassportPage yandexPassportPage = new();
            yandexPassportPage.SetUrl("https://passport.yandex.ru/");
            return yandexPassportPage;
        }
    }

    public YandexMailPage YandexMailPage
    {
        get
        {
            YandexMailPage yandexMailPage = new();
            yandexMailPage.SetUrl("https://mail.yandex.ru/");
            return yandexMailPage;
        }
    }

    public GmailMainPage GmailMainPage
    {
        get
        {
            GmailMainPage gmailMainPage = new();
            gmailMainPage.SetUrl("https://www.google.com/");
            return gmailMainPage;
        }
    }

    public GmailPassportPage GmailPassportPage
    {
        get
        {
            GmailPassportPage gmailPassportPage = new();
            gmailPassportPage.SetUrl("https://accounts.google.com/");
            return gmailPassportPage;
        }
    }

    public GmailMailPage GmailMailPage
    {
        get
        {
            GmailMailPage gmailMailPage = new();
            gmailMailPage.SetUrl("https://mail.google.com/mail");
            return gmailMailPage;
        }
    }
}
