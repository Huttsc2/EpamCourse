using EpamCourse.Development_and_Build_Tools;
using EpamCourse.Basic_of_dotnet_Framework_and_CSharp;
using EpamCourse.OOP;
using EpamCourse.Collections.Builders;
using EpamCourse.Collections.XMLWriters;
using EpamCourse.Exceptions.CarModels;

namespace EpamCourse
{
    public class MainClass
    {

        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            try
            {
                Car? car = new CarBuilder()
                .SetCarModel(new CarModel("Mercedes-Benz", "A-Class"))
                .SetEngine(120, 2000, "Petrol", "SN12345")
                .SetChassis(4, "CH123", 1500)
                .SetTransmission("Automatic", 5, "ZF")
                .Build() as Car;
                vehicles.Add(car);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Bus? bus = new BusBuilder()
                .SetPassengerCapacity(40)
                .SetEngine(500, 2000, "Diesel", "SN1234")
                .SetChassis(6, "CH1234", 10000)
                .SetTransmission("Automatic", 8, "Allison")
                .Build() as Bus;
            vehicles.Add(bus);

            Scooter? scooter = new ScooterBuilder()
                .SetHasPedal(false)
                .SetEngine(15, 50, "Gasoline", "SN5678")
                .SetChassis(2, "CH5678", 150)
                .SetTransmission("Automatic", 0, "Generic")
                .Build() as Scooter;
            vehicles.Add(scooter);

            Truck? truck = new TruckBuilder()
                .SetCargoCapacity(10000)
                .SetEngine(400, 5000, "Diesel", "SN9876")
                .SetChassis(6, "CH9876", 20000)
                .SetTransmission("Manual", 6, "ZF")
                .Build() as Truck;
            vehicles.Add(truck);

            foreach (var vehicle in vehicles)
            {
                vehicle.PrintInfo();
                Console.WriteLine();
            }


            new VehiclesWriter().WriteVehiclesWithEngineVolumeOver1_5(vehicles);
            new VehiclesWriter().WriteVehiclesGroupedByTransmissionType(vehicles);
            new VehiclesWriter().WriteEngineTypeSerialNumberAndPowerForBusesAndTrucks(vehicles);

        }

        //main for Basic of .NET Framework and C#
        /*public static void Main()
        {
            Console.WriteLine("Enter the number to convert");
            string inputNumber = Console.ReadLine();
            Console.WriteLine("Enter numeral system in range 2 - 20");
            string numeralSystem = Console.ReadLine();
            try
            {
                string? convertedNumber =
                new ConverterToTargetNumeralSystem(int.Parse(inputNumber), int.Parse(numeralSystem)).GetConvertedNumber();
                Console.WriteLine(convertedNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/

        //main for Development and Build Tools task
        /*public static void Main()
        {
            string input = Console.ReadLine();
            int maxNumbers = new NonidenticalCharactersCouner(input).GetMaxNumber();
            Console.WriteLine(maxNumbers);
        }*/
    }
}
