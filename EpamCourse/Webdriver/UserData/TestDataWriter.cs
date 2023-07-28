using EpamCourse.Helpers;
using Newtonsoft.Json.Linq;

namespace EpamCourse.Webdriver.UserData
{
    public class TestDataWriter
    {
        public void WriteNewUsername(string name)
        {
            string path = PathFinder.GetRootDirectory() + "/Webdriver/UserData/MailDataTest.json";
            string json = File.ReadAllText(path);
            var jsonObject = JObject.Parse(json);
            jsonObject["yandexMailData"]["username"] = name;
            File.WriteAllText(path, jsonObject.ToString());
        }
    }
}
