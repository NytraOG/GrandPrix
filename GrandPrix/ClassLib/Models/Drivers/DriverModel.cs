namespace ClassLib.Models.Drivers
{
    public class DriverModel : IDriverModel
    {
        public DriverModel(string name, CarModel car)
        {
            Name = name;
            Car  = car;
        }

        public string   Name                 { get; set; }
        public double   TotalTime            { get; set; }
        public CarModel Car                  { get; set; }
        public double   FuelConsumptionPerKm { get; set; }
        public double   Speed                { get; set; }

        public virtual double CalculateAndSetSpeed()
        {
            Speed = (Car.HorsePower + Car.Tire.Degradation) / Car.FuelAmount;
            return Speed;
        }
    }
}