namespace _04.Vehicles
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split();
            var carFuelQuantity = double.Parse(carInput[1]);
            var carFuelConsumption = double.Parse(carInput[2]);
            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);

            var truckInput = Console.ReadLine().Split();
            var truckFuelQuantity = double.Parse(truckInput[1]);
            var truckFuelConsumption = double.Parse(truckInput[2]);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            List<IVehicle> list = new List<IVehicle>();
            list.Add(car);
            list.Add(truck);

            var NumberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < NumberOfCommands; i++)
            {
                var lineArgs = Console.ReadLine().Split();
                var command = lineArgs[0];
                var vihicleType = lineArgs[1];
                switch (command)
                {
                    case "Drive":
                        var distance = double.Parse(lineArgs[2]);
                        if(vihicleType == "Car")
                        {
                            Console.WriteLine(car.DriveCar(distance));
                        }
                        else
                        {
                            Console.WriteLine(truck.DriveCar(distance));
                        }

                        break;
                    case "Refuel":
                        var fuel = double.Parse(lineArgs[2]);
                        if (vihicleType == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else
                        {
                            truck.Refuel(fuel);
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (var vihicle in list)
            {
                Console.WriteLine(vihicle);
            }
        }
    }
}
