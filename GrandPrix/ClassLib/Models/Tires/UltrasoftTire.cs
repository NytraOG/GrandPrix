﻿using System;

namespace ClassLib.Models.Tires
{
    public class UltrasoftTire : TireModel
    {
        public UltrasoftTire(string name, double hardness, double grip) : base(name, hardness)
        {
            Name = "Ultrasoft";
            Degradation = 100;
            Grip = grip;
        }

        public double Grip { get; set; }

        public override void DegradeTire()
        {
            Degradation -= (Grip + Hardness);

            if(Degradation <= 30)
                throw new Exception("Tire blew up, too bad! :C");
        }
    }
}