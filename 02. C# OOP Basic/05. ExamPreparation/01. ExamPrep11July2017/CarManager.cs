using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private List<int> racesClosed;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.racesClosed = new List<int>();
    }
    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        if (type == "Performance")
        {
            this.cars.Add(id, new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
        if (type == "Show")
        {
            this.cars.Add(id, new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
    }
    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int pricePool)
    {
        switch (type)
        {
            case "Casual":
                this.races.Add(id, new CasualRace(length, route, pricePool));
                break;

            case "Drag":
                this.races.Add(id, new DragRace(length, route, pricePool));
                break;

            case "Drift":
                this.races.Add(id, new DriftRace(length, route, pricePool));
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!this.garage.ParkedCars.Contains(carId))
        {
            if (!racesClosed.Contains(raceId))
            {
                this.races[raceId].Participants.Add(carId, cars[carId]);
            }
        }
    }

    public string Start(int raceId)
    {
        if(races[raceId].Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }
        var result = races[raceId].StartRace();
        racesClosed.Add(raceId);

        return result;
    }

    public void Park(int carId)
    {
        foreach (var race in races.Where(r => !racesClosed.Contains(r.Key)))
        {
            if (race.Value.Participants.ContainsKey(carId))
            {
                return;
            }
        }

        this.garage.ParkCar(carId);
    }

    public void Unpark(int id)
    {
        this.garage.UnparkCar(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var carId in this.garage.ParkedCars)
        {
            cars[carId].Tune(tuneIndex, addOn);
        }
    }
}

