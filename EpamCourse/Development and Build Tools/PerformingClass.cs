namespace EpamCourse.Development_and_Build_Tools
{
    public class PerformingClass
    {
        public void GetMaxNumberOfNonidenticalCharacters()
        {
            string input = Console.ReadLine();
            int maxNumbers = new NonidenticalCharactersCouner(input).GetMaxNumber();
            Console.WriteLine(maxNumbers);
        }
    }
}
