namespace EpamCourse.Object_Oriented_Design_Principles.Commands
{
    public class CountAllCommand : ICommand
    {
        private CarManager _carManager;

        public CountAllCommand(CarManager carManager)
        {
            _carManager = carManager;
        }

        public void Execute()
        {
            int totalNumberOfCar = _carManager.GetTotalNumberOfCars();
            Console.WriteLine($"Total number of cars: {totalNumberOfCar}");
        }

        public void SetArguments(string args) { }
    }
}
