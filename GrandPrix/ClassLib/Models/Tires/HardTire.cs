using ClassLib.Models.Tires.Interface;

namespace ClassLib.Models.Tires
{
    public class HardTire : TireModel
    {
        public HardTire(double hardness) : base(hardness)
        {
            Type        = "hard";
            Degradation = 100;
        }

        public override void ChangeTire(double hardness, double grip)
        {
            Degradation = 100;
            Hardness    = hardness;
        }
    }
}
