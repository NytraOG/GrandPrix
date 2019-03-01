using ClassLib.Models.Tires.Interface;

namespace ClassLib.Models.Tires
{
    public class HardTire : TireModel
    {
        public HardTire(string name, double hardness, double grip) : base(name, hardness)
        {
            Name = "Hard";
            Degradation = 100;
            Grip = grip;
        }
        public double Grip { get; set; }
    }
}
