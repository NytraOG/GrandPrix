using ClassLib.Models.Tires;
using ClassLib.Models.Tires.Interface;

namespace ClassLib.Models.Drivers
{
    public class DriverModel : IDriverModel
    {
        public string Name { get; set; }
        public double TotalTime { get; set; }
        public CarModel Car { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double Speed { get; set; }

        public virtual void CalculateSpeed()
        {
            Speed = (Car.HorsePower + Car.Tire.Degradation) / Car.FuelAmount;
        }
    }
}
