using EpamCourse.Exceptions.CustomExceptions;
using EpamCourse.OOP;

namespace EpamCourse.Exceptions.TransportListChangers
{
    public class VehicleListManager
    {
        private List<Vehicle> Vehicles { get; set; }

        public VehicleListManager(List<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        public void RemoveVehicleById(int id)
        {
            Vehicle? vehicleToRemove = Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicleToRemove != null)
            {
                Vehicles.Remove(vehicleToRemove);
            }
            else
            {
                throw new RemoveAutoException("No car with this id");
            }
        }

        public void ReplaceVehicleById(int id, Vehicle newVehicle)
        {
            int index = Vehicles.FindIndex(v => v.Id == id);

            if (index != -1)
            {
                Vehicles[index] = newVehicle;
            }
            else
            {
                throw new UpdateAutoException("No car with this id");
            }
        }

        public List<Vehicle> GetVehicleList()
        {
            return Vehicles;
        }
    }
}
