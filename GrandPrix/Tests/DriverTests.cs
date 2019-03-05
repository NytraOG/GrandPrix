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
        private List<string> aggressiveDriverSoftTires;
        private List<string> fastDegradationEnduranceDriverSoftTires;
        private List<string> tooMuchFuelDriverSoftTires;

        [TestInitialize]
        public void Init()
        {
            raceTower = new RaceTower();
            raceTower.SetTrackInfo(10, 20);

            aggressiveDriverSoftTires               = new List<string> { "Aggressive", "Bob", "500", "160", "Ultrasoft", "5", "5" };
            fastDegradationEnduranceDriverSoftTires = new List<string> { "Endurance", "Bob", "500", "160", "Ultrasoft", "10", "10" };
            tooMuchFuelDriverSoftTires              = new List<string> { "Endurance", "Bob", "500", "5000", "Ultrasoft", "5", "5" };
        }

        [TestMethod]
        public void Should_Create_Driver_With_Correct_Properties_Soft_Tires()
        {
            // Arrange & Act 
            raceTower.RegisterDriver(aggressiveDriverSoftTires);

            // Assert
            Assert.AreEqual(aggressiveDriverSoftTires[1].ToLower(), raceTower.GetDriverInfo()[0].Name);
            Assert.AreEqual(aggressiveDriverSoftTires[4].ToLower(), raceTower.GetDriverInfo()[0].Car.Tire.Type);
            Assert.AreEqual(Convert.ToDouble(aggressiveDriverSoftTires[5]), raceTower.GetDriverInfo()[0].Car.Tire.Hardness);
        }

        [TestMethod]
        public void Should_Throw_Exception_On_Degraded_Tire()
        {
            // Arrange
            raceTower.RegisterDriver(fastDegradationEnduranceDriverSoftTires);
            var lapInput = new List<string> { "7" };

            // Act & Assert
            Assert.ThrowsException<DataException>(() => raceTower.CompleteLaps(lapInput));
        }

        [TestMethod]
        public void Should_Not_Allow_Creating_Car_With_Fuel_Over_160()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<Exception>(() => raceTower.RegisterDriver(tooMuchFuelDriverSoftTires));
        }

        [TestMethod]
        [DataRow("changetires", "bob", "ultrasoft", "1", "1")]
        [DataRow("changetires", "bob", "hard", "1", "1")]
        public void Should_Restore_Tire_Degradation_After_Boxing(string boxType, string driverName, string tireType, string hardness, string grip)
        {
            // Arrange
            raceTower.RegisterDriver(aggressiveDriverSoftTires);
            raceTower.CompleteLaps(new List<string> {"2"});
            var expectedDegradation = 100;

            // Act
            raceTower.DriverBoxes(new List<string> {boxType, driverName, tireType, hardness, grip});

            // Assert
            Assert.AreEqual(expectedDegradation, raceTower.GetDriverInfo()[0].Car.Tire.Degradation);
        }

        [TestMethod]
        public void Should_Throw_Exception_If_Too_many_Laps_Must_Be_Completed()
        {
            // Assert & Arrange & Act
            Assert.ThrowsException<Exception>(() => raceTower.CompleteLaps(new List<string> {"50"}));
        }

        [TestMethod]
        [DataRow("refuel", "bob", "50")]
        public void Should_Refuel_Car_Properly_After_Boxing(string boxType, string driverName, string fuelAmount)
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
