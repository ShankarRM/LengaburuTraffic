using System;
using System.Collections.Generic;
using System.Linq;

namespace LengaburuTraffic
{
    public class TravelDesk
    {
        private readonly IConfigReader _configReader;
        private readonly string _weather;
        private readonly int _nosOfOrbits;

        public TravelDesk(IConfigReader configReader,string weather, int nosOfOrbits)
        {
            _configReader = configReader;
            _weather = weather;
            _nosOfOrbits = nosOfOrbits;
        }

        private Route InitializeRoutes(string routeName, int AllowedSpeed, string POT_HOLES_OFFSET_WEATHER_KEY)
        {
            return new Route(routeName,
                                AllowedSpeed,
                                _configReader.GetValue<Int32>($"{routeName}_POTHOLES"),
                                _configReader.GetValue<Int32>($"{routeName}_DISTANCE"),
                                _configReader.GetValue<double>(POT_HOLES_OFFSET_WEATHER_KEY)
                                );
        }

        public KeyValuePair<string, Vehicle> RequestForVehicleAndRoute(int[] AllowedSpeeds)
        {
            string POT_HOLES_OFFSET_WEATHER_KEY = $"WEATHER_{_weather.ToUpper()}_POTHOLES";
            Dictionary<string, Vehicle> fastestVehicle = new Dictionary<string, Vehicle>();

            for (int i = 0; i < AllowedSpeeds.Length; i++)
            {

                var vehicleProvider = new VehicleProvider(_configReader);

                List<Vehicle> vehicles = vehicleProvider.GetAvailableVehiclesForWeather(_weather);

                
                

                string routeName = $"Orbit{i + 1}";

                Console.WriteLine($"Input:{routeName} traffic speed is");

                Route route = InitializeRoutes(routeName, AllowedSpeeds[i], POT_HOLES_OFFSET_WEATHER_KEY);
                
                var vehicle =route.GetfastestVehicleForRoute(vehicles);

                fastestVehicle.Add(routeName, vehicle);
            }

            return fastestVehicle.OrderBy(p=>p.Value.TravelTime).FirstOrDefault();
        }
    }
}
