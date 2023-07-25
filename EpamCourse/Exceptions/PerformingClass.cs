using EpamCourse.Collections.Builders;
using EpamCourse.Collections.XMLWriters;
using EpamCourse.Exceptions.CarModels;
using EpamCourse.OOP;

namespace EpamCourse.Exceptions
{
    public class PerformingClass
    {
        public void WriteDataToXML()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            try
            {
                Car? car = new CarBuilder()
                .SetCarModel(new CarModel("Mercedes-Benz", "A-Class"))
                .SetEngine(120, 2000, "Petrol", "SN12345")
                .SetChassis(4, "CH123", 1500)
                .SetTransmission("Automatic", 5, "ZF")
                .SetId(1)
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
                .SetId(2)
                .Build() as Bus;
            vehicles.Add(bus);

            Scooter? scooter = new ScooterBuilder()
                .SetHasPedal(false)
                .SetEngine(15, 50, "Gasoline", "SN5678")
                .SetChassis(2, "CH5678", 150)
                .SetTransmission("Automatic", 0, "Generic")
                .SetId(3)
                .Build() as Scooter;
            vehicles.Add(scooter);

            Truck? truck = new TruckBuilder()
                .SetCargoCapacity(10000)
                .SetEngine(400, 5000, "Diesel", "SN9876")
                .SetChassis(6, "CH9876", 20000)
                .SetTransmission("Manual", 6, "ZF")
                .SetId(4)
                .Build() as Truck;
            vehicles.Add(truck);


            new VehiclesWriter().WriteVehiclesWithEngineVolumeOver1_5(vehicles);
            new VehiclesWriter().WriteVehiclesGroupedByTransmissionType(vehicles);
            new VehiclesWriter().WriteEngineTypeSerialNumberAndPowerForBusesAndTrucks(vehicles);
        }
    }
}
