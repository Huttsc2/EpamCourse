namespace EpamCourse.Interfaces_and_Abstract_Classes
{
    public interface IFlyable
    {
        void FlyTo(Coordinate newLocation);
        double GetFlyTime(Coordinate newLocation);
    }
}
