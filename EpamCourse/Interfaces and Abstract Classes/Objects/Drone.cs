namespace EpamCourse.Interfaces_and_Abstract_Classes.Objects
{
    public class Drone : FlyableObject
    {
        public Drone()
        {
            Speed = 50 * 1000 / 3600.0; // Assume constant speed of 50 km/h, converted to m/s
        }

        public override double GetFlyTime(Coordinate newLocation)
        {
            double distance = Math.Sqrt(
                Math.Pow(newLocation.X - CurrentPosition.X, 2) + 
                Math.Pow(newLocation.Y - CurrentPosition.Y, 2) + 
                Math.Pow(newLocation.Z - CurrentPosition.Z, 2)
                );

            if (distance > 1000 * 1000) // Maximum flight distance of a drone is 1000 km
            {
                throw new Exception("The flight distance is too long for a drone.");
            }

            double time = distance / Speed;
            int breaks = (int)(time / (10 * 60)); // Drone takes a 1-minute break every 10 minutes

            return time + breaks * 60; // Add break time to the total flight time
        }
    }
}
