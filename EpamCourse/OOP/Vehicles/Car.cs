
using EpamCourse.Exceptions.CarModels;

namespace EpamCourse.OOP
{
    public class Car : Vehicle
    {
        public CarModel CarModel { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Car make: {CarModel.Make}\nCar model: {CarModel.Model}");
        }
    }
}
