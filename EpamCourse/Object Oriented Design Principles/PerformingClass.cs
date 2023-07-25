using EpamCourse.Collections.Builders;
using EpamCourse.Exceptions.CarModels;
using EpamCourse.Exceptions.CustomExceptions;
using EpamCourse.Object_Oriented_Design_Principles.Commands;
using EpamCourse.OOP;

namespace EpamCourse.Object_Oriented_Design_Principles
{
    public class PerformingClass
    {
        CarManager CarManager { get; set; }

        public PerformingClass()
        {
            CarManager = CarManager.GetInstante();
        }

        public void AddPredefinedCars()
        {
            Car? carBMWx5 = new CarBuilder()
                .SetCarModel(new CarModel("BMW", "X5"))
                .SetAmount(12)
                .SetCost(14000)
                .Build() as Car;

            Car? carMercedes = new CarBuilder()
                .SetCarModel(new CarModel("Mercedes-Benz", "A-Class"))
                .SetAmount(2)
                .SetCost(26000)
                .Build() as Car;

            Car? carToyota = new CarBuilder()
                .SetCarModel(new CarModel("Toyota", "Camry"))
                .SetAmount(6)
                .SetCost(9000)
                .Build() as Car;

            Car? carBMWx3 = new CarBuilder()
                .SetCarModel(new CarModel("BMW", "X3"))
                .SetAmount(10)
                .SetCost(12000)
                .Build() as Car;

            CarManager.AddCar(carBMWx3);
            CarManager.AddCar(carToyota);
            CarManager.AddCar(carBMWx5);
            CarManager.AddCar(carMercedes);
        }

        public void AddCarsFromConsoleInput()
        {
            while (true)
            {
                Console.WriteLine("Enter the car brand:");
                string brand = Console.ReadLine();

                Console.WriteLine("Enter the car model:");
                string model = Console.ReadLine();

                Console.WriteLine("Enter the number of cars:");
                if (!int.TryParse(Console.ReadLine(), out int amount))
                {
                    Console.WriteLine("Invalid input for amount, please try again.");
                    continue;
                }

                Console.WriteLine("Enter the cost of the car:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal cost))
                {
                    Console.WriteLine("Invalid input for cost, please try again.");
                    continue;
                }

                Car? car = new CarBuilder()
                    .SetCarModel(new CarModel(brand, model))
                    .SetAmount(amount)
                    .SetCost(cost)
                    .Build() as Car;

                if (car != null)
                {
                    CarManager.AddCar(car);
                    Console.WriteLine("The car has been added successfully.");

                    Console.WriteLine("Do you want to add another car? (yes/no)");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() != "yes") break;
                }
            }
        }

        public void ExecuteCommand()
        {
            CommandInvoker invoker = new CommandInvoker(CarManager);

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter a command:");
                    string command = Console.ReadLine();
                    string[] words = command.Split(' ');
                    if (words[0] == "average" && words[1] == "price" && words.Length > 2)
                    {
                        string argument = string.Join(" ", words.Skip(2));
                        invoker.ExecuteCommand("average price type", argument);
                    }
                    else
                    {
                        invoker.ExecuteCommand(command);
                    }
                }
                catch (ExitException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
}
