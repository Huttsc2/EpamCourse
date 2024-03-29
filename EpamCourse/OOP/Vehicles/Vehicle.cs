﻿
using System.Xml.Serialization;

namespace EpamCourse.OOP
{

    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Scooter))]
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get; set; }
        public Engine? Engine { get; set; }
        public Chassis? Chassis { get; set; }
        public Transmission? Transmission { get; set; }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Cost {Cost}");
            Console.WriteLine($"Engine: {Engine.Power} HP, {Engine.Volume} cm3, {Engine.Type}, SN: {Engine.SerialNumber}");
            Console.WriteLine($"Chassis: {Chassis.WheelCount} wheels, {Chassis.Number}, max load: {Chassis.MaxLoad} kg");
            Console.WriteLine($"Transmission: {Transmission.Type}, {Transmission.GearCount} gears, made by {Transmission.Manufacturer}");
        }
    }
}
