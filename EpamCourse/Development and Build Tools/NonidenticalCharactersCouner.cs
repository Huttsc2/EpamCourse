namespace EpamCourse.Development_and_Build_Tools
{
    public class NonidenticalCharactersCouner
    {
        public string InputString { get; set; }
        public int MaxNumberOfNonidenticalCharacters { get; set; }
        public bool IsCorrectInput { get; set; }

        public NonidenticalCharactersCouner(string input)
        {
            InputString = input;
            CheckConditions();
            if (IsCorrectInput)
            {
                CountMaxNumberOfUniqueCharacters();
            }
            else
            {
                MaxNumberOfNonidenticalCharacters = 0;
            }
        }

        public void CheckConditions()
        {
            IsCorrectInput = !CheckNull() && !CheckEmpty();
        }

        public bool CheckNull()
        {
            return InputString == null;
        }

        public bool CheckEmpty()
        {
            return InputString.Length == 0;
        }



        public void CountMaxNumberOfUniqueCharacters()
        {
            MaxNumberOfNonidenticalCharacters = 1;
            int currentDistinctCount = 1;

            for (int i = 1; i < InputString.Length; i++)
            {
                if (InputString[i] != InputString[i - 1])
                {
                    currentDistinctCount++;
                    if (currentDistinctCount > MaxNumberOfNonidenticalCharacters)
                    {
                        MaxNumberOfNonidenticalCharacters = currentDistinctCount;
                    }
                }
                else
                {
                    currentDistinctCount = 1;
                }
            }
        }

        public int GetMaxNumber()
        {
            return MaxNumberOfNonidenticalCharacters;
        }

    }
}
