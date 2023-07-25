namespace EpamCourse.Object_Oriented_Design_Principles.Commands
{
    public class CountTypesCommand : ICommand
    {
        private CarManager _carManager;

        public CountTypesCommand(CarManager carManager)
        {
            _carManager = carManager;
        }

        public void Execute()
        {
            int numberOfCarBrands = _carManager.GetNumberOfCarBrands();
            Console.WriteLine($"Number of car types: {numberOfCarBrands}");
        }

        public void SetArguments(string args) { }
    }
}
