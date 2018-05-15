using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    private const double IncreaseFuelForACCar = 0.9;
    private const double IncreaseFuelForACTruck = 1.6;
    public static void Main(string[] args)
    {
       

        var inputCarInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var inputTruckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Vehicles car = new Car(double.Parse(inputCarInfo[1]), double.Parse(inputCarInfo[2]), IncreaseFuelForACCar);
        Vehicles truck = new Truck(double.Parse(inputTruckInfo[1]), double.Parse(inputTruckInfo[2]), IncreaseFuelForACTruck);

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var commandInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = commandInfo[0];
            var typeVehicle = commandInfo[1];
            var distanceOrLiters = double.Parse(commandInfo[2]);

            try
            {
                if(typeVehicle == "Car")
                {
                    if(command == "Drive")
                    {
                        Console.WriteLine(car.Drive(distanceOrLiters));
                    }
                    else
                    {
                        car.Refuel(distanceOrLiters);
                    }
                }
                else
                {
                    if(command == "Drive")
                    {
                        Console.WriteLine(truck.Drive(distanceOrLiters));
                    }
                    else
                    {
                        truck.Refuel(distanceOrLiters);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(car.ToString());
        Console.WriteLine(truck.ToString());
    }
}

