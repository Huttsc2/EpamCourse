using EpamCourse.OOP;
using System.Xml.Serialization;
using EpamCourse.Helpers;
using EpamCourse.OOP.SpareParts;

namespace EpamCourse.Collections.XMLWriters
{
    public class VehiclesWriter
    {
        private protected string TargetDirectory = PathFinder.GetRootDirectory() + "\\Collections\\XMLData\\";

        public void WriteVehiclesWithEngineVolumeOver1_5(List<Vehicle> vehicles)
        {
            List<Vehicle> filteredVehicles = vehicles.Where(v => v.Engine.Volume > 1500).ToList();
            XmlSerializer xs = new XmlSerializer(typeof(List<Vehicle>));
            using (TextWriter tw = new StreamWriter(TargetDirectory + "VehiclesWithEngineVolumeOver1_5.xml"))
            {
                xs.Serialize(tw, filteredVehicles);
            }
        }

        public void WriteEngineTypeSerialNumberAndPowerForBusesAndTrucks(List<Vehicle> vehicles)
        {
            List<EngineInfo> busAndTruckEngineInfo = vehicles
                .Where(v => v is Bus || v is Truck)
                .Select(v => new EngineInfo
                {
                    EngineType = v.Engine.Type,
                    SerialNumber = v.Engine.SerialNumber,
                    Power = v.Engine.Power
                })
                .ToList();
            XmlSerializer xs = new XmlSerializer(typeof(List<EngineInfo>));
            using (TextWriter tw = new StreamWriter(TargetDirectory + "EngineInfoForBusesAndTrucks.xml"))
            {
                xs.Serialize(tw, busAndTruckEngineInfo);
            }
        }

        public void WriteVehiclesGroupedByTransmissionType(List<Vehicle> vehicles)
        {
            IEnumerable<IGrouping<string, Vehicle>> groupedVehicles = vehicles.GroupBy(v => v.Transmission.Type);
            XmlSerializer xs = new XmlSerializer(typeof(List<Vehicle>));
            foreach (var group in groupedVehicles)
            {
                using (TextWriter tw = new StreamWriter(TargetDirectory + $"VehiclesWith{group.Key}Transmission.xml"))
                {
                    xs.Serialize(tw, group.ToList());
                }
            }
        }
    }
}
