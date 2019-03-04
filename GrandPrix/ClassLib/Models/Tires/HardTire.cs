using ClassLib.Models.Tires.Interface;

namespace ClassLib.Models.Tires
{
    public class HardTire : TireModel
    {
        public HardTire(double hardness) : base(hardness)
        {
            Name = "Hard";
            Degradation = 100;
        }
    }
}
