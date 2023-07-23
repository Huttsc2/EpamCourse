namespace EpamCourse.Exceptions.CarModels
{
    public class BMW : CarBrand
    {
        public BMW()
        {
            Cars = new List<CarModel>
                {
                    new CarModel("BMW", "1 Series"),
                    new CarModel("BMW", "2 Series"),
                    new CarModel("BMW", "3 Series"),
                    new CarModel("BMW", "4 Series"),
                    new CarModel("BMW", "5 Series"),
                    new CarModel("BMW", "6 Series"),
                    new CarModel("BMW", "7 Series"),
                    new CarModel("BMW", "X1"),
                    new CarModel("BMW", "X3"),
                    new CarModel("BMW", "X5"),
                };
        }
    }
}
