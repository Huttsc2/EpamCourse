using EpamCourse.Collections.Builders;
using EpamCourse.Exceptions.CarModels;
using EpamCourse.Exceptions.CustomExceptions;
using EpamCourse.Exceptions.TransportDatabase;
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Unexpected exception type thrown");
            }
        }
    }
}
