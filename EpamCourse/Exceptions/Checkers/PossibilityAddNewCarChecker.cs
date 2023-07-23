using EpamCourse.Exceptions.CarModels;
using EpamCourse.Exceptions.CustomExceptions;

namespace EpamCourse.Exceptions.Checkers
{
    public class PossibilityAddNewCarChecker
    {
        private CarModel CarToCheck { get; set; }
        private List<CarModel> CarList { get; set; }

        public PossibilityAddNewCarChecker(CarModel carToAdd, List<CarModel> carList)
        {
            CarToCheck = carToAdd;
            CarList = carList;
        }

        public void CheckValidCar()
        {
            if (CarToCheck.Make != CarList[0].Make)
            {
                throw new AddException("Invalid car brand");
            }
            if (CarList.Any(car => car.Model == CarToCheck.Model))
            {
                throw new AddException("Model already exists");
            }
        }
    }
}
