namespace ClassLib.Models.Drivers
{
    public interface IDriverModel
    {
        CarModel Car { get; set; }
        double FuelConsumptionPerKm { get; set; }
        string Name { get; set; }
        double Speed { get; set; }
        double TotalTime { get; set; }

        void CalculateSpeed();
    }
}