namespace ClassLib.Models.Tires.Interface
{
    public interface ITireModel
    {
        double Degradation { get; set; }
        double Hardness { get; set; }
        string Type { get; set; }

        void DegradeTire();
        void ChangeTire(double hardness, double grip);
    }
}