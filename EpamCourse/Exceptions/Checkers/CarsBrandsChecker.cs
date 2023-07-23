using EpamCourse.Exceptions.CarModels;
using EpamCourse.Exceptions.CustomExceptions;

namespace EpamCourse.Exceptions.Checkers
{
    public class CarsBrandsChecker
    {
        private CarModel CarModel { get; set; }

        public CarsBrandsChecker(CarModel carModel)
        {
            CarModel = carModel;
        }

        public void CheckValidCarBrand()
        {
            if (CarModel.Make != "BMW" &&
                CarModel.Make != "Toyota" &&
                CarModel.Make != "Mercedes-Benz")
            {
                throw new InitializationException("No such car brand");
            }
        }
    }
}
