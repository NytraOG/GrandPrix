using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
