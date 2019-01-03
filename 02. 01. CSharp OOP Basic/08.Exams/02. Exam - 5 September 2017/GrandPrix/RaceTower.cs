using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private const string failReasonMessage = "Crashed";

    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;
    private Stack<Driver> failedDrivers;
    private int lapsNumber;
    private int trackLength;
    private int currentLap;
    private List<Driver> drivers;
    private Weather weather;

    public RaceTower()
    {
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.drivers = new List<Driver>();
        this.currentLap = 0;
        this.weather = Weather.Sunny;
        this.failedDrivers = new Stack<Driver>();
        IsRaceOver = false;
    }

    public bool IsRaceOver { get; private set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var newDriver = this.driverFactory.CreateDriver(commandArgs);
            this.drivers.Add(newDriver);
        }
        catch (Exception ex)
        {
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var command = commandArgs[0];
        var driverName = commandArgs[1];
        var driver = this.drivers.FirstOrDefault(x => x.Name == driverName);
        switch (command)
        {
            case "Refuel":
                var fuelAmount = double.Parse(commandArgs[2]);
                driver.AddFuel(fuelAmount);
                break;
            case "ChangeTyres":
                var newTyre = this.tyreFactory.CreateTyre(commandArgs.Skip(2).ToList());
                driver.ChangeTyre(newTyre);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var sb = new StringBuilder();

        var numberOfLaps = int.Parse(commandArgs[0]);
        if (numberOfLaps > (this.lapsNumber - this.currentLap))
        {
            sb.AppendLine($"There is no time! On lap {currentLap}.");
            return sb.ToString().TrimEnd();
        }

        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            for (int i = 0; i < this.drivers.Count; i++)
            {
                var driver = this.drivers[i];
                try
                {
                    driver.CompleteLap(this.trackLength);
                }
                catch (Exception ex)
                {
                    driver.Fail(ex.Message);
                    this.failedDrivers.Push(driver);
                    this.drivers.RemoveAt(i);
                    i--;
                }
            }

            this.currentLap++;

            //overtaking
            var orderedDrivers = this.drivers.OrderByDescending(x => x.TotalTime).ToList();
            for (int i = 0; i < orderedDrivers.Count - 1; i++)
            {
                var driverOne = orderedDrivers[i];
                var driverTwo = orderedDrivers[i + 1];

                var isOvertake = this.TryOvertake(driverOne, driverTwo);

                if (isOvertake)
                {
                    i++;
                    sb.AppendLine($"{driverOne.Name} has overtaken {driverTwo.Name} on lap {this.currentLap}.");
                }
                else
                {
                    if (driverOne.IsOutOfTheRace)
                    {
                        this.failedDrivers.Push(driverOne);
                        this.drivers.Remove(driverOne);
                    }
                }
            }
        }

        if(this.currentLap == this.lapsNumber)
        {
            this.IsRaceOver = true;
            var winner = this.drivers.OrderBy(x => x.TotalTime).First();
            
            sb.AppendLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
        }

        return sb.ToString().TrimEnd();
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Lap {this.currentLap}/{this.lapsNumber}");
        var count = 1;
        var leaderboardDrivers = this.drivers.OrderBy(x => x.TotalTime).Concat(this.failedDrivers);
        foreach (var driver in leaderboardDrivers)
        {
            sb.AppendLine($"{count} {driver.ToString()}");
            count++;
        }

        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var input = commandArgs[0];
        switch (input)
        {
            case "Sunny":
                this.weather = Weather.Sunny;
                break;
            case "Foggy":
                this.weather = Weather.Foggy;
                break;
            case "Rainy":
                this.weather = Weather.Rainy;
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    private bool TryOvertake(Driver driverOne, Driver driverTwo)
    {
        var timeDiff = driverOne.TotalTime - driverTwo.TotalTime;

        bool isAgressiveDriver = driverOne is AggressiveDriver &&
           driverOne.Car.Tyre is UltrasoftTyre;

        bool isEnduranceDriver = driverOne is EnduranceDriver &&
                 driverOne.Car.Tyre is HardTyre;

        bool isCrash = (this.weather == Weather.Foggy) || (this.weather == Weather.Rainy);

        if ((isAgressiveDriver || isEnduranceDriver) && timeDiff <= 3)
        {
            if (isCrash)
            {
                driverOne.Fail(failReasonMessage);

                return false;
            }

            driverOne.DecreaseTotalTimeBySeconds(3); 
            driverTwo.IncreaseTotalTimeBySeconds(3);

            return true;
        }
        else if (timeDiff <= 2)
        {
            driverOne.DecreaseTotalTimeBySeconds(2);
            driverTwo.IncreaseTotalTimeBySeconds(2);

            return true;
        }

        return false;
    }
}

