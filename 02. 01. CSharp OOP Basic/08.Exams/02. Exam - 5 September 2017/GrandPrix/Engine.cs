using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower = new RaceTower();

    public void Run()
    {
        var numberOfLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());

        raceTower.SetTrackInfo(numberOfLaps, trackLength);

        for (int i = 0; i < numberOfLaps; i++)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var command = input[0];
            var args = input.Skip(1).ToList();

            switch (command)
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(args);
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
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
                    raceTower.DriverBoxes(args);
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(args);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}

