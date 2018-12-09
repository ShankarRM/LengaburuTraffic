using Ninject;
using System;
using System.Configuration;
using System.Reflection;

namespace LengaburuTraffic
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
                var configReader = kernel.Get<IConfigReader>();

                Console.WriteLine("Please enter weather condition \n Sunny \n Windy \n Rainy \n");
                string Weather = Console.ReadLine();

                int NosOrbits = configReader.GetValue<Int32>("NosOrbit");

                var travelDesk = new TravelDesk(configReader, Weather, NosOrbits);
                int[] AllowedSpeeds = new int[NosOrbits];
                for (int i = 0; i < NosOrbits; i++)
                {
                    AllowedSpeeds[i] = Convert.ToInt32(Console.ReadLine());
                }


                var vehicle = travelDesk.RequestForVehicleAndRoute(AllowedSpeeds);

                Console.WriteLine($"Vehicles {vehicle.Value.Name} on {vehicle.Key}");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
