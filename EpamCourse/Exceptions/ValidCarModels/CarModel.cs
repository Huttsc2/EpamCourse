namespace EpamCourse.Exceptions.CarModels
{
    public class CarModel
    {
        public string Make { get; set; }
        public string Model { get; set; }

        private CarModel() { }

        public CarModel(string make, string model)
        {
            Make = make;
            Model = model;
        }
    }
}
