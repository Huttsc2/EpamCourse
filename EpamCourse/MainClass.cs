using EpamCourse.Development_and_Build_Tools;
using EpamCourse.Basic_of_dotnet_Framework_and_CSharp;

namespace EpamCourse
{
    public class MainClass
    {

        public static void Main()
        {
            Console.WriteLine("Enter the number to convert");
            string inputNumber = Console.ReadLine();
            Console.WriteLine("Enter numeral system in range 2 - 20");
            string numeralSystem = Console.ReadLine();
            try
            {
                string? convertedNumber =
                new ConverterToTargetNumeralSystem(int.Parse(inputNumber), int.Parse(numeralSystem)).GetConvertedNumber();
                Console.WriteLine(convertedNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //main for Development and Build Tools task
        /*public static void Main()
        {
            string input = Console.ReadLine();
            int maxNumbers = new NonidenticalCharactersCouner(input).GetMaxNumber();
            Console.WriteLine(maxNumbers);
        }*/
    }
}
