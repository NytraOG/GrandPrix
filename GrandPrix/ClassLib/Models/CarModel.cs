using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Models.Tires;
using ClassLib.Models.Tires.Interface;

namespace ClassLib.Models
{
    public class CarModel
    {
        public CarModel()
        {
            FuelAmount = 160;
        }

        public int HorsePower { get; set; }
        public double FuelAmount { get; set; }
        public ITireModel Tire { get; set; }

        public void RefuelCar(double fuelAmount)
        {
            if (FuelAmount + fuelAmount > 160)
                FuelAmount = 160;
            else
                FuelAmount += fuelAmount;
        }

        public void ConsumeFuel(double consumedFuel)
        {
            FuelAmount -= consumedFuel;
        }
    }
}
