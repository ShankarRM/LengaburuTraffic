using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LengaburuTraffic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lengaburu.Test
{
    [TestClass]
    public class Vehicles_Test
    {
        Dictionary<string, string> configuration = new Dictionary<string, string>();
        [TestInitialize]
        public void Init() {
            
            configuration.Add("Sunny", "Bike;Car;TukTuk");
        }
        [TestMethod]
        public void GetBike_TravelTimeFor_Orbit1_InSunny()
        {
            //Act Action Assert
            
            var collection = configuration["Sunny"].Split(';');
            var configReader = new Mock<IConfigReader>();
            ArrayList list = new ArrayList();
            list.AddRange(collection);
            configReader.Setup(cr => cr.GetValueCollection<string>("Sunny")).Returns(list);

            Vehicle vehicle = new Vehicle("Bike", 10, 2);
            Route route = new Route("Orbit1",12,20,18,-10);
            
            double time = (int)vehicle.CalculateTravelTime(route);
            Assert.AreEqual(time,144);

        }
        [TestMethod]
        public void Get_Bike_Speed_Expected_10 (){
            
            var configReader = new Mock<IConfigReader>();
            
            
            
            configReader.Setup(cr => cr.GetValue<int>("BIKE_SPEED")).Returns(10);
            
            Vehicle vehicle = new Vehicle("Bike",10,2);
            
            Assert.AreEqual(10, vehicle.MaxSpeed);
        }
        
    }
}
