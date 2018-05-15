using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{
    private CarManager manager;
    public Engine()
    {
        this.manager = new CarManager();
    }
    public void Run()
    {
        string commandInfo;
        while ((commandInfo = Console.ReadLine()) != "Cops Are Here")
        {
            var command = commandInfo.Split(' ');
            Execute(command);

        }
    }

    private void Execute(string[] command)
    {
        int id;
        string type;
        int raceId;

        switch (command[0])
        {
            case "register":
                id = int.Parse(command[1]);
                type = command[2];
                var brand = command[3];
                var model = command[4];
                var yearOfProduction = int.Parse(command[5]);
                var horsepower = int.Parse(command[6]);
                var acceleration = int.Parse(command[7]);
                var suspension = int.Parse(command[8]);
                var durability = int.Parse(command[9]);

                manager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;

            case "check":
                id = int.Parse(command[1]);
                Console.WriteLine(manager.Check(id));
                break;

            case "open":
                id = int.Parse(command[1]);
                type = command[2];
                var length = int.Parse(command[3]);
                var route = command[4];
                var pricePool = int.Parse(command[5]);

                manager.Open(id, type, length, route, pricePool);
                break;

            case "participate":
                var carId = int.Parse(command[1]);
                raceId = int.Parse(command[2]);

                manager.Participate(carId, raceId);
                break;

            case "start":
                raceId = int.Parse(command[1]);

                Console.WriteLine(manager.Start(raceId));
                break;

            case "park":
                carId = int.Parse(command[1]);

                manager.Park(carId);
                break;

            case "unpark":
                carId = int.Parse(command[1]);

                manager.Unpark(carId);
                break;

            case "tune":
                var tuneIndex = int.Parse(command[1]);
                var addOn = command[2];

                manager.Tune(tuneIndex, addOn);
                break;
        }
    }
}

