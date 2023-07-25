namespace EpamCourse.Object_Oriented_Design_Principles.Commands
{
    public class AveragePriceTypeCommand : ICommand
    {
        private string _type;
        private readonly CarManager _carManager;

        public AveragePriceTypeCommand(CarManager carManager)
        {
            _carManager = carManager;
        }

        public void SetArguments(string args)
        {
            _type = args;
        }

        public void Execute()
        {
            decimal averagePrice = _carManager.GetAverageCostOfCarsByBrand(_type);
            Console.WriteLine($"Average price for {_type} is {averagePrice}");
        }
    }
}
