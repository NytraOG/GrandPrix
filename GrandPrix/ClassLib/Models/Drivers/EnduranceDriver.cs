namespace ClassLib.Models.Drivers
{
    public class EnduranceDriver : DriverModel
    {
        public EnduranceDriver(string name, CarModel car) : base(name, car)
        {
            FuelConsumptionPerKm = 1.5;
        }
    }
}