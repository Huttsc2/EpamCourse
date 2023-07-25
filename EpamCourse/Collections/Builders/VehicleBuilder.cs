using EpamCourse.OOP;

namespace EpamCourse.Collections.Builders
{
    public abstract class VehicleBuilder
    {
        protected Vehicle? _vehicle;

        public virtual VehicleBuilder SetId(int id)
        {
            _vehicle.Id = id;
            return this;
        }

        public virtual VehicleBuilder SetAmount(int amount)
        {
            _vehicle.Amount = amount;
            return this;
        }

        public virtual VehicleBuilder SetCost(decimal cost)
        {
            _vehicle.Cost = cost;
            return this;
        }

        public abstract VehicleBuilder SetEngine(int power, int volume, string type, string serialNumber);

        public abstract VehicleBuilder SetChassis(int wheelCount, string number, int maxLoad);

        public abstract VehicleBuilder SetTransmission(string type, int gearCount, string manufacturer);

        public virtual Vehicle Build()
        {
            return _vehicle;
        }
    }
}
