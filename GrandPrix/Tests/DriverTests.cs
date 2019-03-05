using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Controllers;
using ClassLib.Models;
using ClassLib.Models.Drivers;
using ClassLib.Models.Tires;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DriverTests
    {
        private RaceTower raceTower;
        private List<string> inputAggressiveDriverSoftTires;
        private List<string> inputEnduranceDriverSoftTires;
        private List<string> inputTooMuchFuelDriverSoftTires;

        [TestInitialize]
        public void Init()
        {
            raceTower = new RaceTower();
            raceTower.SetTrackInfo(10, 20);
            inputAggressiveDriverSoftTires = new List<string> { "Aggressive", "Bob", "500", "160", "Ultrasoft", "5", "5" };
            inputEnduranceDriverSoftTires = new List<string> { "Endurance", "Bob", "500", "160", "Ultrasoft", "10", "10" };
            inputTooMuchFuelDriverSoftTires = new List<string> { "Endurance", "Bob", "500", "5000", "Ultrasoft", "5", "5" };
        }

        [TestMethod]
        public void Should_Create_Driver_With_Correct_Properties_Soft_Tires()
        {
            // Arrange & Act 
            raceTower.RegisterDriver(inputAggressiveDriverSoftTires);

            // Assert
            Assert.AreEqual(inputAggressiveDriverSoftTires[1].ToLower(), raceTower.GetDriverInfo()[0].Name);
            Assert.AreEqual(inputAggressiveDriverSoftTires[4].ToLower(), raceTower.GetDriverInfo()[0].Car.Tire.Type);
            Assert.AreEqual(Convert.ToDouble(inputAggressiveDriverSoftTires[5]), raceTower.GetDriverInfo()[0].Car.Tire.Hardness);
        }

        [TestMethod]
        public void Should_Throw_Exception_On_Degraded_Tire()
        {
            // Arrange
            raceTower.RegisterDriver(inputEnduranceDriverSoftTires);
            var lapInput = new List<string> { "7" };

            // Act & Assert
            Assert.ThrowsException<DataException>(() => raceTower.CompleteLaps(lapInput));
        }

        [TestMethod]
        public void Should_Not_Allow_Creating_Car_With_Fuel_Over_160()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<Exception>(() => raceTower.RegisterDriver(inputTooMuchFuelDriverSoftTires));
        }
    }
}
