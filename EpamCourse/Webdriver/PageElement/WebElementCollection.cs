using EpamCourse.Webdriver.Driver;
using OpenQA.Selenium;

namespace EpamCourse.Webdriver.PageElement
{
    public class WebElementCollection
    {
        private readonly Browser Browser = Browser.GetInstance();
        private List<IWebElement>? Elements { get; set; }
        private string XPath { get; set; }

        private bool IsHidden { get; set; }

        public WebElementCollection(bool isHidden, string xpath)
        {
            XPath = xpath;
            IsHidden = isHidden;
        }
        public List<WebElement> ConvertToListCollection()
        {
            Elements = Browser.FindVivsibleElements(XPath, 60);
            List<WebElement> newCollectioon = new();
            foreach (IWebElement element in Elements)
            {
                WebElement newElement = new(IsHidden, XPath);
                newElement.SetElement(element);
                newCollectioon.Add(newElement);
            }
            return newCollectioon;
        }
    }
}
