using System;
using System.Collections.Generic;
using System.Linq;

namespace LengaburuTraffic
{
    public class VehicleProvider
    {
        public readonly IConfigReader _configReader;
        public VehicleProvider(IConfigReader configReader)
        {
            _configReader = configReader;
        }
        public List<Vehicle> GetAvailableVehiclesForWeather(string weather) {

            List<Vehicle> vehicles = new List<Vehicle>();
            List<string> availableVehicles = _configReader.GetValueCollection<string>(weather).Cast<string>().ToList();

            foreach (var name in availableVehicles)
            {
                string MAX_SPEED_KEY = $"{name.ToUpper()}_SPEED";
                string POTHOLE_SPEED_KEY = $"{name.ToUpper()}_SPEED_POTHOLE";

                double MaxSpeed = _configReader.GetValue<double>(MAX_SPEED_KEY);
                double PotHoleSpeed = _configReader.GetValue<double>(POTHOLE_SPEED_KEY);

                Vehicle vehicle = new Vehicle(name, MaxSpeed, PotHoleSpeed);
                

                vehicles.Add(vehicle);
            }
            return vehicles;
        }
    }
}
