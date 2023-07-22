using EpamCourse.OOP;

namespace EpamCourse.Collections.Builders
{
    public class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            _vehicle = new Car();
        }

        public override VehicleBuilder SetEngine(int power, int volume, string type, string serialNumber)
        {
            _vehicle.Engine = new Engine { Power = power, Volume = volume, Type = type, SerialNumber = serialNumber };
            return this;
        }

        public override VehicleBuilder SetChassis(int wheelCount, string number, int maxLoad)
        {
            _vehicle.Chassis = new Chassis { WheelCount = wheelCount, Number = number, MaxLoad = maxLoad };
            return this;
        }

        public override VehicleBuilder SetTransmission(string type, int gearCount, string manufacturer)
        {
            _vehicle.Transmission = new Transmission { Type = type, GearCount = gearCount, Manufacturer = manufacturer };
            return this;
        }

        public CarBuilder SetCarType(string carType)
        {
            ((Car)_vehicle).CarType = carType;
            return this;
        }
    }
}
