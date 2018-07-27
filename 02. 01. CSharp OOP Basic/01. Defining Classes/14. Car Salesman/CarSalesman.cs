using System;
using System.Collections.Generic;
using System.Linq;

class CarSalesman
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var enginesList = new List<Engine>();
        for (int i = 0; i < n; i++)
        {
            var lineParts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var model = lineParts[0];
            var power = int.Parse(lineParts[1]);

            if(lineParts.Length == 3)
            {
                var newEngine = new Engine(model, power);

                if (IsDigit(lineParts[2]))
                {
                    newEngine.displacement = lineParts[2];
                }
                else
                {
                    newEngine.efficiency = lineParts[2];
                }

                enginesList.Add(newEngine);
            }
            else if (lineParts.Length == 4)
            {
                var displacement = lineParts[2];
                var efficiency = lineParts[3];
                enginesList.Add(new Engine(model, power, displacement, efficiency));
            }
            else
            {
                enginesList.Add(new Engine(model, power));
            }
        }

        var m = int.Parse(Console.ReadLine());
        var carList = new List<Car>();
        for (int i = 0; i < m; i++)
        {
            var lineParts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var model = lineParts[0];
            var engine = enginesList.FirstOrDefault(x => x.model == lineParts[1]);

            var newCar = new Car(model, engine);
            if (lineParts.Length == 3)
            {
                if (IsDigit(lineParts[2]))
                {
                    newCar.weight = lineParts[2];   
                }
                else
                {
                    newCar.color = lineParts[2];
                }

                carList.Add(newCar);
            }
            else if(lineParts.Length == 4)
            {
                var weight = lineParts[2];
                var color = lineParts[3];
                carList.Add(new Car(model, engine, weight, color));
            }
            else
            {
                carList.Add(new Car(model, engine));
            }
            
        }

        Console.WriteLine(string.Join(Environment.NewLine, carList));
    }

    private static bool IsDigit(string str)
    {
        return int.TryParse(str, out int result);
    }
}

