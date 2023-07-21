namespace EpamCourse.Interfaces_and_Abstract_Classes.Objects
{
    public abstract class FlyableObject : IFlyable
    {
        protected double Speed { get; set; }
        public Coordinate CurrentPosition { get; set; }

        public virtual void FlyTo(Coordinate newLocation)
        {
            CurrentPosition = newLocation;
        }

        public virtual double GetFlyTime(Coordinate newLocation)
        {
            double distance = Math.Sqrt(
                Math.Pow(newLocation.X - CurrentPosition.X, 2) + 
                Math.Pow(newLocation.Y - CurrentPosition.Y, 2) + 
                Math.Pow(newLocation.Z - CurrentPosition.Z, 2)
                );
            return distance / Speed;
        }
    }
}
