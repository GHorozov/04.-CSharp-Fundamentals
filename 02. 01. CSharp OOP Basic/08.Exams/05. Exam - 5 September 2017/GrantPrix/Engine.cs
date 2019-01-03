using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        var numberOfLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());
        raceTower.SetTrackInfo(numberOfLaps, trackLength);

        while (true)
        {
            var args = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = args[0];
            args = args.Skip(1).ToList();

            try
            {
                switch (command)
                {
                    case "RegisterDriver":
                        this.raceTower.RegisterDriver(args);
                        break;
                    case "Leaderboard":
                        Console.WriteLine(this.raceTower.GetLeaderboard());
                        break;
                    case "CompleteLaps":
                        string result = raceTower.CompleteLaps(args);
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            Console.WriteLine(result);
                        }
                        if (raceTower.IsRaceOver)
                        {
                            Environment.Exit(0);
                        }
                        break;
                    case "Box":
                        this.raceTower.DriverBoxes(args);
                        break;
                    case "ChangeWeather":
                        this.raceTower.ChangeWeather(args);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

