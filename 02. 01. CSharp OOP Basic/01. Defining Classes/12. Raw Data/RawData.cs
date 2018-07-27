using System;
using System.Collections.Generic;
using System.Linq;

class RawData
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var list = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            var lineArgs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var model = lineArgs[0];

            var engineSpeed = int.Parse(lineArgs[1]);
            var enginePower = int.Parse(lineArgs[2]);
            var engine = new Engine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(lineArgs[3]);
            var cargoType = lineArgs[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            var tire1Pressure = double.Parse(lineArgs[5]);
            var tire1Age = int.Parse(lineArgs[6]);
            var tire2Pressure = double.Parse(lineArgs[7]);
            var tire2Age = int.Parse(lineArgs[8]);
            var tire3Pressure = double.Parse(lineArgs[9]);
            var tire3Age = int.Parse(lineArgs[10]);
            var tire4Pressure = double.Parse(lineArgs[11]);
            var tire4Age = int.Parse(lineArgs[12]);
            var tires = new List<Tire>();
            tires.Add(new Tire(tire1Pressure, tire1Age));
            tires.Add(new Tire(tire2Pressure, tire2Age));
            tires.Add(new Tire(tire3Pressure, tire3Age));
            tires.Add(new Tire(tire4Pressure, tire4Age));

            list.Add(new Car(model, engine, cargo, tires));
        }

        var inputCargoType = Console.ReadLine();

        if (inputCargoType == "fragile")
        {
            var resultFragile = list.Where(x => x.cargo.cargoType == "fragile" && x.tires.Any(t => t.tirePressure < 1)).Select(x => x.model).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, resultFragile));
        }
        else
        {
            var resultFlamable = list.Where(x => x.cargo.cargoType == "flamable" && x.engine.enginePower > 250).Select(x => x.model).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, resultFlamable));
        }
    }
}
