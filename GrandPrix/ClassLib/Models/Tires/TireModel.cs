﻿using System;
using ClassLib.Models.Tires.Interface;

namespace ClassLib.Models.Tires
{
    public class TireModel : ITireModel
    {
        public TireModel(double hardness)
        {
            Degradation = 100;
            Hardness    = hardness;
        }

        public string Name { get; set; }
        public double Hardness { get; set; }
        public double Degradation { get; set; }

        public virtual void DegradeTire()
        {
            Degradation -= Hardness;

            if (Degradation <= 0)
                throw new Exception("Tire blew up, too bad! :C");
        }

        public virtual void ChangeTire(double hardness, double grip) { }
    }
}
