using EpamCourse.Helpers;

namespace EpamCourse.Webdriver.UserData
{
    public class PathToScreenshots
    {
        public string GetPathToScreenshots()
        {
            return PathFinder.GetTestDirectory() + "/Webdriver Tests/Screenshots/";
        }
    }
}
