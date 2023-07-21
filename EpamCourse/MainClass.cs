using EpamCourse.Development_and_Build_Tools;

namespace EpamCourse
{
    public class MainClass
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int maxNumbers = new NonidenticalCharactersCouner(input).GetMaxNumber();
            Console.WriteLine(maxNumbers);
        }
    }
}
