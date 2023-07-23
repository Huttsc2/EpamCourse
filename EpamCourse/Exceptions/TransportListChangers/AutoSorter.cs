using EpamCourse.Exceptions.CustomExceptions;
using EpamCourse.OOP;

namespace EpamCourse.Exceptions.TransportListChangers
{
    public class AutoSorter
    {
        private List<Vehicle> Vehicles { get; set; }

        public AutoSorter(List<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        public List<Vehicle> GetAutoByParameter(string parameter ,string value)
        {
            List<Vehicle> autoByParameter = new List<Vehicle>();

            switch (parameter)
            {
                case "Engine.Power":
                    autoByParameter = Vehicles.Where(v => v.Engine.Power == int.Parse(value)).ToList();
                    break;
                case "Engine.Volume":
                    autoByParameter = Vehicles.Where(v => v.Engine.Volume == int.Parse(value)).ToList();
                    break;
                case "Engine.Type":
                    autoByParameter = Vehicles.Where(v => v.Engine.Type == value).ToList();
                    break;
                case "Engine.SerialNumber":
                    autoByParameter = Vehicles.Where(v => v.Engine.SerialNumber == value).ToList();
                    break;
                case "Chassis.WheelCount":
                    autoByParameter = Vehicles.Where(v => v.Chassis.WheelCount == int.Parse(value)).ToList();
                    break;
                case "Chassis.Number":
                    autoByParameter = Vehicles.Where(v => v.Chassis.Number == value).ToList();
                    break;
                case "Chassis.MaxLoad":
                    autoByParameter = Vehicles.Where(v => v.Chassis.MaxLoad == int.Parse(value)).ToList();
                    break;
                case "Transmission.Type":
                    autoByParameter = Vehicles.Where(v => v.Transmission.Type == value).ToList();
                    break;
                case "Transmission.GearCount":
                    autoByParameter = Vehicles.Where(v => v.Transmission.GearCount == int.Parse(value)).ToList();
                    break;
                case "Transmission.Manufacturer":
                    autoByParameter = Vehicles.Where(v => v.Transmission.Manufacturer == value).ToList();
                    break;
                case "PassengerCapacity":
                    autoByParameter = Vehicles
                        .Where(v => v is Bus bus && bus.PassengerCapacity == int.Parse(value)).ToList();
                    break;
                case "CarModel.Model":
                    autoByParameter = Vehicles
                        .Where(v => v is Car car && car.CarModel.Model== value).ToList();
                    break;
                case "CarModel.Make":
                    autoByParameter = Vehicles
                        .Where(v => v is Car car && car.CarModel.Make == value).ToList();
                    break;
                case "HasPedals":
                    autoByParameter = Vehicles
                        .Where(v => v is Scooter scooter && scooter.HasPedals == bool.Parse(value)).ToList();
                    break;
                case "CargoCapacity":
                    autoByParameter = Vehicles
                        .Where(v => v is Truck truck && truck.CargoCapacity == int.Parse(value)).ToList();
                    break;
                default:
                    throw new GetAutoByParameterException("No such vehicles or invalid parameter");
            }

            return autoByParameter;
        }
    }
}
