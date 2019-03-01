using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Models.Drivers
{
    public class AggressiveDriver : DriverModel
    {
        public AggressiveDriver(string name, CarModel car) : base(name, car)
        {
            FuelConsumptionPerKm = 2.7;
        }

        public override void CalculateSpeed()
        {
            Speed = (Car.HorsePower + Car.Tire.Degradation) / Car.FuelAmount * 1.3;
        }
    }
}
