namespace ClassLib.Models.Tires.Interface
{
    public interface ITireModel
    {
        double Degradation { get; set; }
        double Hardness { get; set; }
        string Name { get; set; }

        void DegradeTire();
        void ChangeTire(double hardness, double grip);
    }
}