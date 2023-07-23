namespace EpamCourse.Exceptions.CarModels
{
    public class Mercedes : CarBrand
    {
        public Mercedes()
        {
            Cars = new List<CarModel>
                {
                    new CarModel("Mercedes-Benz", "A-Class"),
                    new CarModel("Mercedes-Benz", "B-Class"),
                    new CarModel("Mercedes-Benz", "C-Class"),
                    new CarModel("Mercedes-Benz", "E-Class"),
                    new CarModel("Mercedes-Benz", "S-Class"),
                    new CarModel("Mercedes-Benz", "GLA"),
                    new CarModel("Mercedes-Benz", "GLC"),
                    new CarModel("Mercedes-Benz", "GLE"),
                    new CarModel("Mercedes-Benz", "GLS"),
                    new CarModel("Mercedes-Benz", "G-Class"),
                };
        }
    }
}
