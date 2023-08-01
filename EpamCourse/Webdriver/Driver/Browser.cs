using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.WaitHelpers;
using EpamCourse.Webdriver.UserData;
using EpamCourse.Helpers;

namespace EpamCourse.Webdriver.Driver
{
    public class Browser
    {
        private readonly IWebDriver? Driver;
        private static Browser? Instance;

        private Browser()
        {
            BrowserType browserType = new WebDriverReader().GetBrowserType();

            switch (browserType)
            {
                case BrowserType.Chrome:
                    Driver = StartChromeDriver();
                    break;
                case BrowserType.Firefox:
                    Driver = StartFirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser type: {browserType}");
            }
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 60);
            Driver.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(0, 0, 60);
        }

        private ChromeDriver StartChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-browsing-history");
            options.AddArgument("--incognito");
            return new ChromeDriver(options);
        }

        private FirefoxDriver StartFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--disable-browsing-history");
            options.AddArgument("--incognito");
            return new FirefoxDriver(options);
        }

        public static Browser GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Browser();
            }
            return Instance;
        }

        public void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement? FindClickableElement(string xpath, int timeoutInSecond)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSecond))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element;
            try
            {
                element = fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            }
            catch (Exception)
            {
                return null;
            }
            return element;
        }

        public List<IWebElement> FindClickableElements(string xpath, int timeoutInSecond)
        {

            List<IWebElement>? visibleElements = FindVivsibleElements(xpath, timeoutInSecond);
            List<IWebElement> clickableElements = new();
            foreach (IWebElement element in visibleElements)
            {
                if (ExpectedConditions.ElementToBeClickable(element) != null)
                {
                    clickableElements.Add(element);
                }
            }
            return clickableElements;
        }

        public IWebElement? FindVisibleElement(string xpath, int timeoutInSecond)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSecond))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element;
            try
            {
                element = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            }
            catch (Exception)
            {
                return null;
            }
            return element;
        }

        public List<IWebElement>? FindVivsibleElements(string xpath, int timeoutInSecond)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSecond))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            List<IWebElement> elements;
            try
            {
                elements = fluentWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath))).ToList();
            }
            catch (Exception)
            {
                return null;
            }
            return elements;
        }

        public void AlertAccept()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }

        public IWebElement? FindHiddenElement(string xpath, int timeoutInSecond)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSecond))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element;
            try
            {
                element = fluentWait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
            }
            catch (Exception)
            {
                return null;
            }
            return element;
        }

        public List<IWebElement>? FindHiddenElements(string xpath, int timeoutInSecond)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSecond))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            List<IWebElement> elements;
            try
            {
                elements = fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath))).ToList();
            }
            catch (Exception)
            {
                return null;
            }
            return elements;
        }

        public void TakeScreenshotOnFailure()
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            string path = new PathToScreenshots().GetPathToScreenshots();
            try
            {
                ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile($"{path}/screenshot-{timestamp}.png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to take screenshot: {e.Message}");
            }
        }

        public void Refresh()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().Refresh();
        }

        public void Quit()
        {
            Instance = null;
            Driver.Quit();
        }

    }
}
