using EpamCourse.Helpers;
using Newtonsoft.Json;

namespace EpamCourse.Webdriver.UserData
{
    public class TestDataReader
    {
        public Users GetTestUsers()
        {
            string path = PathFinder.GetRootDirectory();
            using StreamReader r = new(path + "/Webdriver/UserData/MailDataTest.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<Users>(json);
        }
    }
}
