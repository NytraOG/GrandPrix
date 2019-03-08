using System.Data;

namespace ClassLib.Models.Tires
{
    public class UltrasoftTire : TireModel
    {
        public UltrasoftTire(double hardness, double grip) : base(hardness)
        {
            Type        = "ultrasoft";
            Degradation = 100;
            Grip        = grip;
        }

        public double Grip { get; set; }

        public override void DegradeTire()
        {
            Degradation -= Grip + Hardness;

            if (Degradation <= 30)
                throw new DataException("Tire blew up, too bad! :C");
        }

        public override void ChangeTire(double hardness, double grip)
        {
            Degradation = 100;
            Hardness    = hardness;
            Grip        = grip;
        }
    }
}