using EpamCourse.Helpers;
using EpamCourse.Webdriver.Driver;
using Newtonsoft.Json;

namespace EpamCourse.Webdriver.UserData
{
    public class WebDriverReader
    {
        public BrowserType GetBrowserType()
        {
            string path = PathFinder.GetRootDirectory();
            using StreamReader r = new(path + "/Webdriver/Driver/Browser.json");
            string json = r.ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
            string browserTypeStr = data.BrowserType;
            return Enum.Parse<BrowserType>(browserTypeStr);
        }
    }
}
