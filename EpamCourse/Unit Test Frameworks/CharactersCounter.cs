using EpamCourse.Development_and_Build_Tools;

namespace EpamCourse.Unit_Test_Frameworks
{
    public class CharactersCounter : NonidenticalCharactersCouner
    {
        public CharactersCounter(string input) : base(input)
        {
            InputString = input;
            CheckConditions();
            if (IsCorrectInput)
            {
                InputString = InputString.ToLower();
            }
        }

        public int GetMaxConsecutiveSameLettersCount()
        {
            if (IsCorrectInput)
            {
                int maxCount = 0;
                int currentCount = 0;
                char lastChar = '\0';

                foreach (char c in InputString)
                {
                    if (Char.IsLetter(c) && c == lastChar)
                    {
                        currentCount++;
                    }
                    else
                    {
                        if (Char.IsLetter(c))
                        {
                            currentCount = 1;
                        }
                        else
                        {
                            currentCount = 0;
                        }
                    }
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                    lastChar = c;
                }

                return maxCount;
            }
            else
            {
                return 0;
            }
        }

        public int GetMaxConsecutiveSameDigitsCount()
        {
            if (IsCorrectInput)
            {
                int maxCount = 0;
                int currentCount = 0;
                char lastChar = '\0';

                foreach (char c in InputString)
                {
                    if (Char.IsDigit(c) && c == lastChar)
                    {
                        currentCount++;
                    }
                    else
                    {
                        if (Char.IsDigit(c))
                        {
                            currentCount = 1;
                        }
                        else
                        {
                            currentCount = 0;
                        }
                    }
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                    lastChar = c;
                }

                return maxCount;
            }
            else 
            { 
                return 0; 
            }
        }
    }
}
