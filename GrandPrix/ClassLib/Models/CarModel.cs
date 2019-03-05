using System;
using System.CodeDom;
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
        private double fuelAmount;

        public CarModel(ITireModel tire, int horsePower, double fuelAmount)
        {
            FuelAmount  = fuelAmount;
            Tire        = tire;   
            HorsePower  = horsePower;
            FuelAmount  = fuelAmount;
        }

        public int HorsePower { get; set; }

        public double FuelAmount
        {
            get => fuelAmount;
            set
            {
                if (value > 160)
                {
                    throw new Exception("Maximum fuel capacity is 160!");
                }

                fuelAmount = value;
            }
        }

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
            if (FuelAmount - consumedFuel < 0)
            {
                FuelAmount = 0;
                throw new Exception("Fuel empty!");
            }

            FuelAmount -= consumedFuel;
        }
    }
}
