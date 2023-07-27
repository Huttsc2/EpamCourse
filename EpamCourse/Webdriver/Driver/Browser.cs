using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace EpamCourse.Webdriver.Driver
{
    public class Browser
    {
        private readonly IWebDriver? Driver;
        private static Browser? Instance;

        private Browser()
        {
            Driver = StartChromDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 60);
            Driver.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(0, 0, 60);
        }

        private ChromeDriver StartChromDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-browsing-history");
            options.AddArgument("--incognito");
            return new ChromeDriver(options);
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

        public List<IWebElement> FindClickableElements(string xpath)
        {

            List<IWebElement>? visibleElements = FindVivsibleElements(xpath);
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

        public IWebElement? FindVisibleElement(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
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

        public List<IWebElement>? FindVivsibleElements(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
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

        public IWebElement? FindHiddenElement(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
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

        public List<IWebElement>? FindHiddenElements(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
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
