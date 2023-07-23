using EpamCourse.OOP;

namespace EpamCourse.Exceptions.TransportDatabase
{
    public class TransportDatabaseChanger
    {
        private List<Vehicle> Vehicles { get; set; }

        public TransportDatabaseChanger(List<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        public List<Vehicle> GetAutoByParameter(string parameter, string value)
        {
            List<Vehicle> autoByParameter = new List<Vehicle>();
            return autoByParameter;
        }
    }
}
