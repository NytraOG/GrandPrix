using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.@enum;
using ClassLib.Models;
using ClassLib.Models.Drivers;
using ClassLib.Models.Tires;

namespace ClassLib.Controllers
{
    public class RaceTower
    {
        private int lapsNumber;
        private int trackLength;
        private Weather weather;
        private List<IDriverModel> listofDrivers;

        public RaceTower()
        {
            weather = Weather.Sunny;
            listofDrivers = new List<IDriverModel>();
        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.lapsNumber     = lapsNumber;
            this.trackLength    = trackLength;
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            var driverType      = commandArgs[0].ToLower();
            var driverName      = commandArgs[1].ToLower();
            var horsePower      = Convert.ToInt32(commandArgs[2]);
            var fuelAmount      = Convert.ToDouble(commandArgs[3]);
            var tireType        = commandArgs[4].ToLower();
            var tireHardness    = Convert.ToDouble(commandArgs[5]);
            var tireGrip        = Convert.ToDouble(commandArgs[6]);     //TODO: IndexOutOfRange fixen für hard tires
            
            switch (driverType)
            {
                case Konstanten.DriverTypeAggressive when tireType == Konstanten.TireTypeHard:
                    listofDrivers.Add(new AggressiveDriver(driverName, new CarModel(new HardTire(tireHardness), horsePower, fuelAmount)));
                    break;
                case Konstanten.DriverTypeAggressive when tireType == Konstanten.TireTypeUltrasoft:
                    listofDrivers.Add(new AggressiveDriver(driverName, new CarModel(new UltrasoftTire(tireHardness, tireGrip), horsePower, fuelAmount)));
                    break;
                case Konstanten.DriverTypeEndurance when tireType == Konstanten.TireTypeHard:
                    listofDrivers.Add(new EnduranceDriver(driverName, new CarModel(new HardTire(tireHardness), horsePower, fuelAmount)));
                    break;
                case Konstanten.DriverTypeEndurance when tireType == Konstanten.TireTypeUltrasoft:
                    listofDrivers.Add(new EnduranceDriver(driverName, new CarModel(new UltrasoftTire(tireHardness, tireGrip), horsePower, fuelAmount)));
                    break;
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            var boxType         = commandArgs[0];
            var driverName      = commandArgs[1];

            var boxingDriver    = listofDrivers.FirstOrDefault(x => x.Name == driverName);

            if (boxingDriver != null)
            {
                boxingDriver.TotalTime += 20;

                switch (boxType)
                {
                    case Konstanten.BoxTypeRefuel:
                        {
                            var fuelAmount      = Convert.ToDouble(commandArgs[2]);

                            boxingDriver.Car.RefuelCar(fuelAmount);
                            break;
                        }
                    case Konstanten.BoxTypeChangeTires:
                        {
                            var tireType        = commandArgs[2];
                            var tireHardness    = Convert.ToDouble(commandArgs[3]);

                            if (tireType == Konstanten.TireTypeHard)
                            {
                                boxingDriver.Car.Tire.ChangeTire(tireHardness, 0);
                            }
                            else if (tireType == Konstanten.TireTypeUltrasoft)
                            {
                                var tireGrip    = Convert.ToDouble(commandArgs[4]);

                                boxingDriver.Car.Tire.ChangeTire(tireHardness, tireGrip);
                            }

                            break;
                        }
                }
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            var numberOfLapsToComplete = Convert.ToInt32(commandArgs[0]);

            if(numberOfLapsToComplete > lapsNumber)
                throw new Exception($"Impossible to drive this many Laps. There are {lapsNumber} Laps left.");

            for (int i = 1; i <= numberOfLapsToComplete; i++)
            {
                foreach (var driver in listofDrivers)
                {
                    driver.TotalTime += 60 / (trackLength / driver.CalculateAndSetSpeed());
                    driver.Car.ConsumeFuel(trackLength * driver.FuelConsumptionPerKm);
                    driver.Car.Tire.DegradeTire();
                }

                //TODO: overtaking
            }

            lapsNumber -= numberOfLapsToComplete;

            return "";
        }

        public string GetLeaderboard()
        {
            int driverPosition          = 1;
            string leaderBoard          = string.Empty;
            var orderedListOfDrivers    = listofDrivers.OrderBy(totalTime => totalTime);

            foreach (var driver in orderedListOfDrivers)
            {
                leaderBoard += $"{driverPosition}.\t{driver}\t{driver.TotalTime}\n";

                driverPosition++;
            }

            return leaderBoard;
        }

        public void Changeweather(List<string> commandArgs)
        {
            var weatherInput = commandArgs[0].ToLower();

            switch (weatherInput)
            {
                case "sunny":
                    weather = Weather.Sunny;
                    break;
                case "rainy":
                    weather = Weather.Rainy;
                    break;
                case "foggy":
                    weather = Weather.Foggy;
                    break;
            }
        }

        public List<IDriverModel> GetDriverInfo()
        {
            return listofDrivers;
        }
    }
}
