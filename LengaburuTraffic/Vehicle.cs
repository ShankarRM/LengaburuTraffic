using System;

namespace LengaburuTraffic
{
    public class Vehicle
    {

        private readonly string _name;
        private readonly double _maxSpeed;
        private readonly double _potHoleSpeed;
        public const int MINUTES = 60;

        public Vehicle(string Name, double MaxSpeed, double PotHoleSpeed)
        {
            _name = Name;
            _maxSpeed = MaxSpeed;
            _potHoleSpeed = PotHoleSpeed;

        }
        
        public string Name { get { return _name; } }

        public double MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }

        public double PotHoleSpeed
        {
            get
            {
                return _potHoleSpeed;
            }
        }

        public float TravelTime{ get; private set; }
        
        public float CalculateTravelTime(Route route)
        {
            double SpeedLimit = route.GetSpeedLimitForVehicle(this);

            float NormalTime = (float)(route.Distance / SpeedLimit);

            float TimeForPotHoles = TravelTimeForPotHoles(route);

            var TotalTimeForTravel = (NormalTime + TimeForPotHoles) * MINUTES;


            int hours = (int)(TotalTimeForTravel / MINUTES);
            int mins = (int)(TotalTimeForTravel % MINUTES);

            Console.WriteLine($"{this.Name}-{TotalTimeForTravel}-{hours}:{mins}");
            this.TravelTime = TotalTimeForTravel;
            return TotalTimeForTravel;
        }
        public float TravelTimeForPotHoles(Route route)
        {
            return (float)(route.PotHoles * this.PotHoleSpeed) / MINUTES;
        }
                
    }
    
    
}
