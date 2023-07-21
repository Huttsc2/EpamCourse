namespace EpamCourse.Interfaces_and_Abstract_Classes.Objects
{
    public class Bird : FlyableObject
    {
        public Bird()
        {
            Speed = new Random().Next(0, 21) * 1000 / 3600.0; // Random speed between 0 and 20 km/h, converted to m/s
        }
    }
}
