using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Models
{
    public class DriverModel
    {
        public string Name { get; set; }
        public double TotalTime { get; set; }
        public CarModel Car { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double Speed { get; set; }

    }
}
