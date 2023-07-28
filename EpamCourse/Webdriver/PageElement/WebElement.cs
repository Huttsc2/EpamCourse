using EpamCourse.Webdriver.Driver;
using OpenQA.Selenium;

namespace EpamCourse.Webdriver.PageElement
{
    public class WebElement
    {
        private Browser Browser = Browser.GetInstance();
        private IWebElement? Element { get; set; }
        private string XPath { get; set; }
        private bool IsHidden { get; set; }
        private int TimeoutInSec = 60;
        private bool ReloadObject = true;

        public WebElement(bool isHidden, string xpath)
        {
            XPath = xpath;
            IsHidden = isHidden;
        }

        public void SetElement(IWebElement element)
        {
            Element = element;
            ReloadObject = false;
        }

        public void Click()
        {
            CheckCondition();
            CheckNull();
            Element.Click();
        }

        public void SendKey(string data)
        {
            CheckCondition();
            CheckNull();
            Element.SendKeys(data);
        }


        public string GetText()
        {
            CheckCondition();
            CheckNull();
            return Element.Text;
        }

        private void CheckCondition()
        {
            if (!ReloadObject)
            {
                return;
            }
            if (!IsHidden)
            {
                Element = Browser.FindClickableElement(XPath, TimeoutInSec);
            } 
            else if (IsHidden)
            {
                Element = Browser.FindHiddenElement(XPath, TimeoutInSec);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void CheckNull()
        {
            if (Element == null)
            {
                try
                {
                    throw new Exception($"Element with xpath = {XPath} is not found");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
