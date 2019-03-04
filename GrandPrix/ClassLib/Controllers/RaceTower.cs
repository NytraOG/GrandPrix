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
        List<IDriverModel> listofDrivers = new List<IDriverModel>();

        public RaceTower()
        {
            weather = Weather.Sunny;
        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.lapsNumber = lapsNumber;
            this.trackLength = trackLength;
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            var driverType = commandArgs[0];
            var driverName = commandArgs[1];
            var horsePower = Convert.ToInt32(commandArgs[2]);
            var fuelAmount = Convert.ToDouble(commandArgs[3]);
            var tireType = commandArgs[4];
            var tireHardness = Convert.ToDouble(commandArgs[5]);
            var tireGrip = Convert.ToDouble(commandArgs[6]);

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
            //TODO: addlogic

            var boxType = commandArgs[0];
            var driverName = commandArgs[1];

            if (boxType == Konstanten.BoxTypeRefuel)
            {
                var fuelAmount = Convert.ToDouble(commandArgs[2]);

                listofDrivers.FirstOrDefault(x => x.Name == driverName)?.Car.RefuelCar(fuelAmount);
            }
            else if (boxType == Konstanten.BoxTypeChangeTires)
            {
                var tireType = commandArgs[2];
                var tireHardness = Convert.ToDouble(commandArgs[3]);

                if (tireType == Konstanten.TireTypeHard)
                {
                    listofDrivers.FirstOrDefault(x => x.Name == driverName)?.Car.Tire.ChangeTire(tireHardness, 0);
                }
                else if (tireType == Konstanten.TireTypeUltrasoft)
                {
                    var tireGrip = Convert.ToDouble(commandArgs[4]);

                    listofDrivers.FirstOrDefault(x => x.Name == driverName)?.Car.Tire.ChangeTire(tireHardness, tireGrip);
                }
            }

        }

        public string CompleteLaps(List<string> commandArgs)
        {
            //TODO: addlogic
            return "";
        }

        public string GetLeaderboard()
        {
            //TODO: addlogic
            return "";
        }

        public void Changeweather(List<string> commandArgs)
        {
            //TODO: addlogic

        }

        public List<IDriverModel> GetDriverInfo()
        {
            return listofDrivers;
        }
    }
}
