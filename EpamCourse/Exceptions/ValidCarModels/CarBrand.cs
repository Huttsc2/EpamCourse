using EpamCourse.Exceptions.Checkers;

namespace EpamCourse.Exceptions.CarModels
{
    public abstract class CarBrand
    {
        protected List<CarModel> Cars { get; set; }

        public CarBrand()
        {
            Cars = new List<CarModel>();
        }

        public List<CarModel> GetCarModels()
        {
            return Cars;
        }

        public void AddNewCar(CarModel carModel)
        {
            new PossibilityAddNewCarChecker(carModel, Cars).CheckValidCar();
            Cars.Add(carModel);
        }
    }
}
