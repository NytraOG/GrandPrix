using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Models
{
    public class CarModel
    {
        public int HorsePower { get; set; }
        public double FuelAmount { get; set; }
        public TireModel Tire { get; set; }
    }
}
