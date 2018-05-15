using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ProSpeedRacinggram
{
    static void Main(string[] args)
    {
        var numberOfCars = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            var line = Console.ReadLine().Split(' ');
            var model = line[0];
            var fuelAmount = double.Parse(line[1]);
            var fuelConsumption = double.Parse(line[2]);

            var currentCar = new Car(model, fuelAmount, fuelConsumption);

            if (!cars.Select(c => c.Model).Any(x => x == model))
            {
                cars.Add(currentCar);
            }
        }

        var input = Console.ReadLine();
        while (input != "End")
        {
            var line = input.Split(' ');
            var command = line[0];
            var carModel = line[1];
            var amountKm = double.Parse(line[2]);

            var currCar = cars.Where(c => c.Model == carModel).FirstOrDefault();

            if(currCar != null)
            {
                currCar.Drive(carModel, amountKm);
            }

            input = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.Amount:f2} {car.Distance}");
        }
    }
}

