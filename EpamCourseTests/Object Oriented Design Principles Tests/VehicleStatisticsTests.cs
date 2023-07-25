using EpamCourse.Collections.Builders;
using EpamCourse.Exceptions.CarModels;
using EpamCourse.OOP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamCourse.Object_Oriented_Design_Principles.Commands;

namespace EpamCourseTests.Object_Oriented_Design_Principles_Tests
{
    [TestClass]
    public class VehicleStatisticsTests
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            CarManager _ = CarManager.GetInstante();

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

            _.AddCar(carBMWx3);
            _.AddCar(carToyota);
            _.AddCar(carBMWx5);
            _.AddCar(carMercedes);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            CarManager.GetInstante().CleanList();
        }


        [TestMethod]
        public void GetAmountOfCarBrands()
        {
            CarManager _ = CarManager.GetInstante();

            int numberOfCarBrands = _.GetNumberOfCarBrands();

            Assert.AreEqual(3, numberOfCarBrands);
        }

        [TestMethod]
        public void GetTotalNumberOfCars()
        {
            CarManager _ = CarManager.GetInstante();

            int totalNumberOfCars = _.GetTotalNumberOfCars();

            Assert.AreEqual(30, totalNumberOfCars);
        }

        [TestMethod]
        public void GetAverageCostOfCar()
        {
            CarManager _ = CarManager.GetInstante();

            decimal avarageCostOfCar = _.GetAverageCostOfCar();

            Assert.AreEqual(15250, avarageCostOfCar);
        }

        [TestMethod]
        public void GetAverageCostOfCarByBrand()
        {
            CarManager _ = CarManager.GetInstante();

            decimal avarageCostOfCarByBrand = _.GetAverageCostOfCarsByBrand("BMW");

            Assert.AreEqual(13000, avarageCostOfCarByBrand);
        }
    }
}
