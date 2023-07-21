
namespace EpamCourse.OOP
{
    public class Scooter : Vehicle
    {
        public bool HasPedals { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Has Pedals: {HasPedals}");
        }
    }
}
