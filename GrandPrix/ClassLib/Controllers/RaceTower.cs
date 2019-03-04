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
        private Weather weather = Weather.Sunny;
        List<IDriverModel> listofDrivers = new List<IDriverModel>();

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            //TODO: addlogic
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            //TODO: ultrasoft implementation(grip), driver type, horsePower, fuel

            var driverType = commandArgs[0];
            var driverName = commandArgs[1];
            var horsePower = commandArgs[2];
            var fuelAmount = commandArgs[3];
            var tireType = commandArgs[4];
            var tireHardness = Convert.ToDouble(commandArgs[5]);
            var tireGrip = Convert.ToDouble(commandArgs[6]);

            if (driverType == Konstantensammlung.driverTypeAggressive && tireType == Konstantensammlung.tireTypeHard)
            {
                listofDrivers.Add(
                    new AggressiveDriver(
                        driverName,
                        new CarModel(
                            new HardTire(
                                tireHardness,
                                tireGrip))));
            }

            listofDrivers.Add(
                new DriverModel(
                    driverName,
                    new CarModel(
                        new TireModel(
                            tireName,
                            tireHardness))));
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            //TODO: addlogic
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
