namespace _05.VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var factory = new VehicleFactory();
            var listOfVehicles = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var currentVehicle = factory.GetVehicle();
                    listOfVehicles.Add(currentVehicle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var numberOfCommands = int.Parse(Console.ReadLine());

            while (numberOfCommands > 0)
            {
                var lineParts = Console.ReadLine().Split();
                var command = lineParts[0];
                var vehicleType = lineParts[1];
                var currentVehicle = listOfVehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);

                switch (command)
                {
                    case "Drive":
                        var distance = double.Parse(lineParts[2]);
                        if(currentVehicle != null)
                        {
                            try
                            {
                                Console.WriteLine(currentVehicle.Drive(distance));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "Refuel":
                        var fuel = double.Parse(lineParts[2]);
                        if (currentVehicle != null)
                        {
                            try
                            {
                                currentVehicle.Refuel(fuel);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "DriveEmpty":
                        distance = double.Parse(lineParts[2]);
                        if (currentVehicle != null)
                        {
                            try
                            {
                                Console.WriteLine(currentVehicle.DriveWithoutAirCondition(distance));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    
                    default:
                        break;
                }

                numberOfCommands--;
            }

            foreach (var vehicle in listOfVehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
