
namespace EpamCourse.OOP
{
    public class Truck : Vehicle
    {
        public int CargoCapacity { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Cargo Capacity: {CargoCapacity} kg");
        }
    }
}
