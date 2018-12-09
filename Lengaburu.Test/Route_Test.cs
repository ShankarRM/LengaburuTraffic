
using LengaburuTraffic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lengaburu.Test
{
    [TestClass]
    public class Route_Test
    {
        [TestMethod]
        public void Test_Route_Orbtit1_PotHoles_SunnyWeather_Expected_18() {
            var route = new Mock<Route>("Orbit1",12,20,18,10).Object;
            
            Assert.AreEqual(route.PotHoles,18,10);
            
        }
        [TestMethod]
        public void Test_Route_Orbtit1_PotHoles_RainyWeather_Expected_24()
        {
            var route = new Mock<Route>("Orbit1", 12, 20, 18,20).Object;
            
            Assert.AreEqual(route.PotHoles, 24);

        }
    }
}
