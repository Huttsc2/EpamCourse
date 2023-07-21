
namespace EpamCourse.OOP
{
    public abstract class Vehicle
    {
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Engine: {Engine.Power} HP, {Engine.Volume} cm3, {Engine.Type}, SN: {Engine.SerialNumber}");
            Console.WriteLine($"Chassis: {Chassis.WheelCount} wheels, {Chassis.Number}, max load: {Chassis.MaxLoad} kg");
            Console.WriteLine($"Transmission: {Transmission.Type}, {Transmission.GearCount} gears, made by {Transmission.Manufacturer}");
        }
    }
}
