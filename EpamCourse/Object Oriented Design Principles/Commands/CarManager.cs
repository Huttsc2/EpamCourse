using EpamCourse.OOP;

namespace EpamCourse.Object_Oriented_Design_Principles.Commands
{
    public class CarManager
    {
        private static CarManager? _instance;
        private List<Car> _cars;

        private CarManager()
        {
            _cars = new List<Car>();
        }

        public static CarManager GetInstante()
        {
            if (_instance == null)
            {
                _instance = new CarManager();
            }
            return _instance;
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public void CleanList()
        {
            _cars.Clear();
        }

        public int GetNumberOfCarBrands()
        {
            HashSet<string> uniaueBrands = new HashSet<string>();
            foreach (Car car in _cars)
            {
                uniaueBrands.Add(car.CarModel.Make);
            }
            int numbersOfCarBrands = uniaueBrands.Count;
            return numbersOfCarBrands;
        }

        public int GetTotalNumberOfCars()
        {
            int numbersOfCars = 0;
            foreach (Car car in _cars)
            {
                numbersOfCars += car.Amount;
            }
            return numbersOfCars;
        }

        public decimal GetAverageCostOfCar()
        {
            decimal priceForAllCars = 0;
            foreach (Car car in _cars)
            {
                priceForAllCars += car.Cost;
            }
            decimal averageCostOfCar = priceForAllCars / _cars.Count;
            return averageCostOfCar;
        }

        public decimal GetAverageCostOfCarsByBrand(string brand)
        {
            decimal priceForAllCarsByBrand = 0;
            List<Car> carsByBrand = _cars.Where(c => c.CarModel.Make == brand).ToList();
            foreach (Car car in carsByBrand)
            {
                priceForAllCarsByBrand += car.Cost;
            }
            if (carsByBrand.Count == 0)
            {
                return 0;
            }
            decimal averageCostOfCarByBrand = priceForAllCarsByBrand / carsByBrand.Count;
            return averageCostOfCarByBrand;
        }
    }
}
