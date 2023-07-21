
namespace EpamCourse.OOP
{
    public class Bus : Vehicle
    {
        public int PassengerCapacity { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Passenger Capacity: {PassengerCapacity}");
        }
    }
}
