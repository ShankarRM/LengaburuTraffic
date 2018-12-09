using System;
using System.Collections.Generic;


namespace LengaburuTraffic
{
    public static class RouteCalculator
    {
        public static Vehicle GetfastestVehicleForRoute(List<Vehicle> availableVehicles, Route route)
        {
            Vehicle fastestvehicle = null;
            double? prevVehicleTravelTime = null;
            foreach (var vehicle in availableVehicles)
            {
                float TravelTime = vehicle.CalculateTravelTime(route);

                if (prevVehicleTravelTime == null || prevVehicleTravelTime > TravelTime)
                {
                    fastestvehicle = vehicle;
                    prevVehicleTravelTime = TravelTime;
                }

            }

            return fastestvehicle;
        }
    }
}
