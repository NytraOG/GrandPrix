using System;
using System.Collections.Generic;
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
        private List<string> mockList;

         [TestInitialize]
        public void Init()
        {
            raceTower = new RaceTower();
            mockList = new List<string> { "Bob", "awesomeTire-1000", "10" };
        }

        [TestMethod]
        public void Should_Create_Driver_With_Correct_Properties()
        {
            // Arrange & Act 
            raceTower.RegisterDriver(mockList);

            // Assert
            Assert.AreEqual(mockList[0], raceTower.GetDriverInfo()[0].Name);
            Assert.AreEqual(mockList[1], raceTower.GetDriverInfo()[0].Car.Tire.Name);
            Assert.AreEqual(Convert.ToDouble(mockList[2]), raceTower.GetDriverInfo()[0].Car.Tire.Hardness);
        }
    }
}
