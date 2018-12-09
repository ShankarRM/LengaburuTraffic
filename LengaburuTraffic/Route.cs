using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengaburuTraffic
{
    public class Route
    {
        private readonly string _name;
        private readonly int _maxAllowedSpeed;
        private readonly double _potHoles;
        private readonly int _distance;
        private readonly double _potHoleOffset;
        public string Name { get { return this._name; } }
        public Route()
        {

        }

        public Route(string Name,int MaxAllowedSpeed,double PotHoles,int Distance,double PotHoleOffset)
        {
            _name = Name;
            _maxAllowedSpeed = MaxAllowedSpeed;
            _potHoles = PotHoles;
            _distance = Distance;
            _potHoleOffset = PotHoleOffset;
        }

        public double PotHoles
        {
            get
            {
                return _potHoles+((_potHoleOffset/100)*_potHoles);
            }
        }
        
        public int Distance
        {
            get
            {
                return _distance;
            }
        }

        public double MaxAllowedSpeed { get { return _maxAllowedSpeed; } }

        public double GetSpeedLimitForVehicle(Vehicle vehicle) {
            return this.MaxAllowedSpeed < vehicle.MaxSpeed ? this.MaxAllowedSpeed : vehicle.MaxSpeed;
            
        }

        public Vehicle GetfastestVehicleForRoute(List<Vehicle> availableVehicles)
        {
            Vehicle fastestvehicle = null;
            double? prevVehicleTravelTime = null;
            foreach (var vehicle in availableVehicles)
            {
                float TravelTime = vehicle.CalculateTravelTime(this);

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
