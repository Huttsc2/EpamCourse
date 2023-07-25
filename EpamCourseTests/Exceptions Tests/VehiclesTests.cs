using EpamCourse.Collections.Builders;
using EpamCourse.Exceptions.CarModels;
using EpamCourse.Exceptions.CustomExceptions;
using EpamCourse.Exceptions.TransportListChangers;
using EpamCourse.OOP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpamCourseTests.Exceptions_Tests
{
    [TestClass]
    public class VehiclesTests
    {
        [TestMethod]
        public void ValidCar()
        {
            try
            {
                Car? car = new CarBuilder()
                .SetCarModel(new CarModel("Mercedes-Benz", "A-Class"))
                .SetEngine(120, 2000, "Petrol", "SN12345")
                .SetChassis(4, "CH123", 1500)
                .SetTransmission("Automatic", 5, "ZF")
                .Build() as Car;
                Assert.IsNotNull(car);
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }

        [Ignore]
        [TestMethod]
        public void InvalidCarBrand()
        {
            try
            {
                Car? car = new CarBuilder()
                .SetCarModel(new CarModel("Mercedes-Benz1", "A-Class"))
                .SetEngine(120, 2000, "Petrol", "SN12345")
                .SetChassis(4, "CH123", 1500)
                .SetTransmission("Automatic", 5, "ZF")
                .Build() as Car;
                Assert.Fail("No exception thrown");
            }
            catch (InitializationException ex)
            {
                Assert.AreEqual("No such car brand", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }

        [Ignore]
        [TestMethod]
        public void InvalidCarModel()
        {
            try
            {
                Car? car = new CarBuilder()
                .SetCarModel(new CarModel("Mercedes-Benz", "F-Class"))
                .SetEngine(120, 2000, "Petrol", "SN12345")
                .SetChassis(4, "CH123", 1500)
                .SetTransmission("Automatic", 5, "ZF")
                .Build() as Car;
                Assert.Fail("No exception thrown");
            }
            catch (InitializationException ex)
            {
                Assert.AreEqual("No such car model", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }

        [TestMethod]
        public void AddValidCarModel()
        {
            CarModel carToAdd = new CarModel("BMW", "X7");
            BMW bmw = new BMW();
            try
            {
                bmw.AddNewCar(carToAdd);
                List<CarModel> cars = bmw.GetCarModels();
                Assert.IsTrue(cars.Any(c => c.Make == carToAdd.Make && c.Model == carToAdd.Model));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void AddInvalidCarBrand()
        {
            CarModel carToAdd = new CarModel("Toyota", "X7");
            BMW bmw = new BMW();
            try
            {
                bmw.AddNewCar(carToAdd);
                Assert.Fail("No exception thrown");
            }
            catch (AddException ex)
            {
                Assert.AreEqual("Invalid car brand", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }

        [TestMethod]
        public void AddInvalidCarModel()
        {
            CarModel carToAdd = new CarModel("BMW", "X1");
            BMW bmw = new BMW();
            try
            {
                bmw.AddNewCar(carToAdd);
                Assert.Fail("No exception thrown");
            }
            catch (AddException ex)
            {
                Assert.AreEqual("Model already exists", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }

        [TestMethod]
        public void GetCarByValidParameter()
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

            List<Vehicle> targetVehicle = new AutoSorter(vehicles).GetAutoByParameter("Transmission.Type", "Manual");
            Assert.IsTrue(targetVehicle.All(v => v.Transmission.Type == "Manual"));
        }

        [TestMethod]
        public void GetCarByInvalidParameter()
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

            try
            {
                List<Vehicle> targetVehicle = new AutoSorter(vehicles).GetAutoByParameter("InvalidParameter", "Manual");
                Assert.Fail();
            }
            catch (GetAutoByParameterException ex)
            {
                Assert.AreEqual("No such vehicles or invalid parameter", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }

        [TestMethod]
        public void DeleteAutoByValidID()
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

            VehicleListManager vehicleList = new VehicleListManager(vehicles);
            vehicleList.RemoveVehicleById(1);
            List<Vehicle> newVehiclesList = vehicleList.GetVehicleList();

            Assert.IsTrue(!newVehiclesList.Any(v => v.Id == 1));
        }

        [TestMethod]
        public void DeleteAutoByInvalidID()
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

            VehicleListManager vehicleList = new VehicleListManager(vehicles);
            try
            {
                vehicleList.RemoveVehicleById(5);
                Assert.Fail();
            }
            catch (RemoveAutoException ex)
            {
                Assert.AreEqual("No car with this id", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }

        [TestMethod]
        public void ReplaceAutoByValidID()
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


            Car? carToReplace = new Car();
            try
            {
                carToReplace = new CarBuilder()
                .SetCarModel(new CarModel("Mercedes-Benz", "A-Class"))
                .SetEngine(120, 2000, "Petrol", "SN12345")
                .SetChassis(4, "CH123", 1500)
                .SetTransmission("Automatic", 5, "ZF")
                .SetId(5)
                .Build() as Car;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            VehicleListManager vehicleList = new VehicleListManager(vehicles);
            vehicleList.ReplaceVehicleById(1, carToReplace);
            List<Vehicle> newVehiclesList = vehicleList.GetVehicleList();

            bool existsId5 = newVehiclesList.Any(v => v.Id == 5);
            bool notExistsId1 = !newVehiclesList.Any(v => v.Id == 1);

            Assert.IsTrue(existsId5 && notExistsId1);
        }

        [TestMethod]
        public void ReplaceAutoByInvalidID()
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

            Car? carToReplace = new Car();
            try
            {
                carToReplace = new CarBuilder()
                .SetCarModel(new CarModel("Mercedes-Benz", "A-Class"))
                .SetEngine(120, 2000, "Petrol", "SN12345")
                .SetChassis(4, "CH123", 1500)
                .SetTransmission("Automatic", 5, "ZF")
                .SetId(5)
                .Build() as Car;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            VehicleListManager vehicleList = new VehicleListManager(vehicles);
            try
            {
                vehicleList.ReplaceVehicleById(7, carToReplace);
                Assert.Fail();
            }
            catch (UpdateAutoException ex)
            {
                Assert.AreEqual("No car with this id", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception type thrown");
            }
        }
    }
}
