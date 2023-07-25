using EpamCourse.Basic_of_dotnet_Framework_and_CSharp;

namespace EpamCourse.Basic_of_.NET_Framework_and_C_
{
    public class PerformingClass
    {
        public void ConvertNumber()
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
    }
}
