using System;
using System.Collections.Generic;
using System.Linq;

class SpeedRacing
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var list = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var model = input[0];
            var fuelAmount = decimal.Parse(input[1]);
            var fuelExpence = decimal.Parse(input[2]);

            list.Add(new Car(model, fuelAmount, fuelExpence));
        }

        string commands;
        while ((commands = Console.ReadLine()) != "End")
        {
            var commandArds = commands.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var carModel = commandArds[1];
            var distanceToTravel = decimal.Parse(commandArds[2]);

            list.FirstOrDefault(x => x.model == carModel).Drive(distanceToTravel);
        }

        Console.WriteLine(string.Join(Environment.NewLine, list));
    }
}

