using System.Text.RegularExpressions;

namespace EpamCourse.Helpers
{
    public class PathFinder
    {
        public static string GetRootDirectory()
        {
            string dir = Directory.GetCurrentDirectory();
            Regex reg = new(".{0,}EpamCourse");
            return reg.Match(dir).Captures.First().Value;
        }

        public static string GetTestDirectory()
        {
            string dir = Directory.GetCurrentDirectory();
            Regex reg = new(".{0,}EpamCourseTests");
            return reg.Match(dir).Captures.First().Value;
        }
    }
}
