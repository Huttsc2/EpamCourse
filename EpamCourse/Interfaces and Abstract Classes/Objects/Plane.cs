namespace EpamCourse.Interfaces_and_Abstract_Classes.Objects
{
    public class Plane : FlyableObject
    {
        public Plane()
        {
            Speed = 200 * 1000 / 3600.0; // Initial speed is 200 km/h, converted to m/s
        }

        public override double GetFlyTime(Coordinate newLocation)
        {
            double distance = Math.Sqrt(
                Math.Pow(newLocation.X - CurrentPosition.X, 2) + 
                Math.Pow(newLocation.Y - CurrentPosition.Y, 2) + 
                Math.Pow(newLocation.Z - CurrentPosition.Z, 2)
                );
            double time = 0;
            double remainingDistance = distance;

            while (remainingDistance > 0)
            {
                double flyDistance = Math.Min(remainingDistance, Speed * 10 * 60); // Fly for 10 minutes at the current speed
                remainingDistance -= flyDistance;
                time += flyDistance / Speed;

                Speed += 10 * 1000 / 3600.0; // Increase speed by 10 km/h
            }

            return time;
        }
    }
}
