using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RawData
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var carInfo = Console.ReadLine().Split(' ');
            var model = carInfo[0];
            var engineSpeed = int.Parse(carInfo[1]);
            var enginePower = int.Parse(carInfo[2]);
            var cargoWeight = int.Parse(carInfo[3]);
            var cargoType = carInfo[4];
            var tire1Pressure = double.Parse(carInfo[5]);
            var tire1Age = int.Parse(carInfo[6]);
            var tire2Pressure = double.Parse(carInfo[7]);
            var tire2Age = int.Parse(carInfo[8]);
            var tire3Pressure = double.Parse(carInfo[9]);
            var tire3Age = int.Parse(carInfo[10]);
            var tire4Pressure = double.Parse(carInfo[11]);
            var tire4Age = int.Parse(carInfo[12]);

            //Use classes
            var newEngine = new Engine(engineSpeed, enginePower);
            var newCargo = new Cargo(cargoWeight, cargoType);
            var newTires = new Tire[]
            {
                new Tire(tire1Pressure, tire1Age),
                new Tire(tire2Pressure, tire2Age),
                new Tire(tire3Pressure, tire3Age),
                new Tire(tire4Pressure, tire4Age),
            };
            var newCar = new Car(model, newEngine, newCargo, newTires);

            cars.Add(newCar);
        }

        var command = Console.ReadLine();

        if (command == "fragile")
        {
            var result = cars.Where(c => c.Cargo.CargoType == command
                &&
                c.Tires.Where(t => t.TirePressure < 1).FirstOrDefault() != null).Select(c => c.Model);

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
        else if (command == "flamable")
        {
            var result = cars.Where(c => c.Cargo.CargoType == command
            &&
            c.Engine.EnginePower > 250).Select(c => c.Model);

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

    }
}

