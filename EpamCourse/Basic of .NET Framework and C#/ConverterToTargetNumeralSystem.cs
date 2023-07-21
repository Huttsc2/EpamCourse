namespace EpamCourse.Basic_of_dotnet_Framework_and_CSharp
{
    public class ConverterToTargetNumeralSystem
    {
        private int OriginalNumber { get; set; }
        private int NumeralSystem { get; set; }
        private string? ConvertedNumber { get; set; }
        private bool IsCorrectInput { get; set; }
        private bool IsNegativeNumber { get; set; }
        private bool IsZero { get; set; }

        public ConverterToTargetNumeralSystem(int originalNumber, int numeralSystem)
        {
            OriginalNumber = originalNumber;
            NumeralSystem = numeralSystem;
            CheckConditions();
            if (IsCorrectInput)
            {
                ConvertNumber();
            } 
            else
            {
                throw new ArgumentException("Incorrect input data");
            }
        }

        private void CheckConditions()
        {
            IsCorrectInput = CheckNumeralSystemRange();
            IsNegativeNumber = CheckNegativeNumber();
            IsZero = CheckZero();
        }

        private bool CheckNumeralSystemRange()
        {
            return NumeralSystem >= 2 && NumeralSystem <= 20;
        }

        private bool CheckNegativeNumber()
        {
            return OriginalNumber < 0;
        }

        private bool CheckZero()
        {
            return OriginalNumber == 0;
        }

        private void ConvertNumber()
        {
            if (IsZero)
            {
                ConvertedNumber = "0";
                return;
            }

            const string digits = "0123456789ABCDEFGHIJ";
            string result = string.Empty;
            int numberToConvert = OriginalNumber;

            if (IsNegativeNumber)
            {
                numberToConvert *= -1;
            }

            while (numberToConvert > 0)
            {
                int remainder = numberToConvert % NumeralSystem;
                result = digits[remainder] + result;
                numberToConvert /= NumeralSystem;
            }

            if (IsNegativeNumber)
            {
                ConvertedNumber = "-" + result;
            }
            else
            {
                ConvertedNumber = result;
            }
        }

        public string? GetConvertedNumber()
        {
            return ConvertedNumber;
        }
    }
}
