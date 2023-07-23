namespace EpamCourse.Exceptions.CarModels
{
    public class Toyota : CarBrand
    {
        public Toyota()
        {
            Cars = new List<CarModel>
                {
                    new CarModel("Toyota", "Corolla"),
                    new CarModel("Toyota", "Camry"),
                    new CarModel("Toyota", "Rav4"),
                    new CarModel("Toyota", "Highlander"),
                    new CarModel("Toyota", "Yaris"),
                    new CarModel("Toyota", "Tacoma"),
                    new CarModel("Toyota", "Tundra"),
                    new CarModel("Toyota", "4Runner"),
                    new CarModel("Toyota", "Avalon"),
                    new CarModel("Toyota", "C-HR"),
                };
        }
    }
}
