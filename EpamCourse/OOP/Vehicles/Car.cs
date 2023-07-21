
namespace EpamCourse.OOP
{
    public class Car : Vehicle
    {
        public string CarType { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Car type: {CarType}");
        }
    }
}
