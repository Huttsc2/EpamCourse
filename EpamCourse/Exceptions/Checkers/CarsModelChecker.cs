using EpamCourse.Exceptions.CarModels;
using EpamCourse.Exceptions.CustomExceptions;

namespace EpamCourse.Exceptions.Checkers
{
    public class CarsModelChecker
    {
        private CarModel CarModel { get; set; }
        private List<CarModel> CarModels { get; set; }

        public CarsModelChecker(CarModel carModel)
        {
            CarModel = carModel;
        }

        public void CheckValidCarModel()
        {
            SetCarModels();
            if (!CarModels.Any(car => car.Model == CarModel.Model))
            {
                throw new InitializationException("No such car model");
            }
        }

        private void SetCarModels()
        {
            if (CarModel.Make == "BMW")
            {
                CarModels = new BMW().GetCarModels();
            }
            else if (CarModel.Make == "Toyota")
            {
                CarModels = new Toyota().GetCarModels();
            }
            else if (CarModel.Make == "Mercedes-Benz")
            {
                CarModels = new Mercedes().GetCarModels();
            }
        }
    }
}
