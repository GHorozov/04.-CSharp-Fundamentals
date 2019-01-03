using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private const double ConstBoxTime = 20;

    private List<Driver> drivers;
    private Stack<Driver> outOfRaceDrivers;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;
    private int totalLapsNumber;
    private int trackLength;
    private int currentLap;
    private string weather;

    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.outOfRaceDrivers = new Stack<Driver>();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.currentLap = 0;
        this.weather = "Sunny";
        this.IsRaceOver = false;
    }

    public bool IsRaceOver { get; set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driver = this.driverFactory.CreateDriver(commandArgs);
            this.drivers.Add(driver);
        }
        catch (Exception)
        {
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];
        var driver = this.drivers.FirstOrDefault(x => x.Name == driverName);

        driver.IncreaseTotalTime(ConstBoxTime);

        if (reasonToBox == "ChangeTyres")
        {
            var tyre = this.tyreFactory.CreateTyre(commandArgs.Skip(2).ToList());
            driver.Car.ChangeTyre(tyre);
        }
        else if (reasonToBox == "Refuel")
        {
            var fuelAmount = double.Parse(commandArgs[2]);
            driver.Car.Refuel(fuelAmount);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > (this.totalLapsNumber - this.currentLap))
        {
            throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
        }

        var sb = new StringBuilder();
        for (int i = 0; i < numberOfLaps; i++)
        {
            this.currentLap++;

            foreach (var driver in this.drivers)
            {
                var currentDriverTime = 60 / (this.trackLength / driver.Speed);
                driver.IncreaseTotalTime(currentDriverTime);
            }

            foreach (var driver in this.drivers)
            {
                try
                {
                    var usedFuel = this.trackLength * driver.FuelConsumptionPerKm;
                    driver.Car.ReduceFuelAmount(usedFuel);
                }
                catch (ArgumentException e)
                {
                    driver.GetDriverOutOfRace();
                    driver.SetReasonToFail(e.Message);
                    this.outOfRaceDrivers.Push(driver);
                }

                try
                {
                    driver.Car.Tyre.CurrentLapDropDagradation();
                }
                catch (ArgumentException ex)
                {
                    driver.GetDriverOutOfRace();
                    driver.SetReasonToFail(ex.Message);
                    this.outOfRaceDrivers.Push(driver);
                }
            }

            var orederDrivers = this.drivers
                .Where(x => x.IsOutOfRace == false)
                .OrderByDescending(x => x.TotalTime)
                .ToList();

            for (int j = 0; j < orederDrivers.Count-1; j++)
            {
                var dOne = orederDrivers[j];
                var dTwo = orederDrivers[j + 1];

                var timeDiff = dOne.TotalTime - dTwo.TotalTime;

                var isAggressiveDriver = dOne.GetType().Name == "AggressiveDriver"
                    && dOne.Car.Tyre.Name == "Ultrasoft";

                var isEnduranceDriver = dOne.GetType().Name == "EnduranceDriver"
                    && dOne.Car.Tyre.Name == "Hard";

                var isWeatherBad = this.weather == "Foggy" || this.weather == "Rainy";

                if ((isAggressiveDriver || isEnduranceDriver) && timeDiff <= 3)
                {
                    if (isWeatherBad)
                    {
                        this.outOfRaceDrivers.Push(dOne);
                        dOne.GetDriverOutOfRace();
                        dOne.SetReasonToFail("Crashed");
                    }
                    else
                    {
                        dOne.DecreaseTotalTime(3);
                        dTwo.IncreaseTotalTime(3);

                        sb.AppendLine($"{dOne.Name} has overtaken {dTwo.Name} on lap {this.currentLap}.");
                    }
                }
                else if(timeDiff <= 2)
                {
                    dOne.DecreaseTotalTime(2);
                    dTwo.IncreaseTotalTime(2);

                    sb.AppendLine($"{dOne.Name} has overtaken {dTwo.Name} on lap {this.currentLap}.");
                }
            }

            this.drivers = this.drivers.Where(x => x.IsOutOfRace == false).ToList();
        }

        if (this.currentLap == this.totalLapsNumber)
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

        sb.AppendLine($"Lap {this.currentLap}/{this.totalLapsNumber}");

        var position = 1;
        var allDrivers = this.drivers.OrderBy(x => x.TotalTime).Concat(this.outOfRaceDrivers);
        foreach (var driver in allDrivers)
        {
            sb.AppendLine($"{position++} {driver.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var currentWether = commandArgs[0];
        this.weather = currentWether;
    }
}

