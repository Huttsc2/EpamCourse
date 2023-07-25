namespace EpamCourse.Object_Oriented_Design_Principles.Commands
{
    public class AveragePriceCommand : ICommand
    {
        private CarManager _carManager;

        public AveragePriceCommand(CarManager carManager)
        {
            _carManager = carManager;
        }

        public void Execute()
        {
            decimal avarageCostOfCar = _carManager.GetAverageCostOfCar();
            Console.WriteLine($"Average cost of cars: {avarageCostOfCar}");
        }

        public void SetArguments(string args) { }
    }
}
