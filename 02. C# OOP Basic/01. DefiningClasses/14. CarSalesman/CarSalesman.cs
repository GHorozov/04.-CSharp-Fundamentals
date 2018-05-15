using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CarSalesman
{
    static void Main(string[] args)
    {
        var carsList = new List<Car>();
        var enginesList = new List<Engine>();

        AddEngines(enginesList);
        AddCars(carsList, enginesList);

        //Print
        foreach (var car in carsList)
        {
            Console.WriteLine(car.ToString());
        }
    }

    private static void AddCars(List<Car> carsList, List<Engine> enginesList)
    {
        var carsNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < carsNumber; i++)
        {
            var currentCar = Console.ReadLine().Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries);
            var model = currentCar[0];
            var engine = currentCar[1];

            //Take engine
            var extractEngine = enginesList.Where(e => e.Model == engine).FirstOrDefault();

            var newCar = new Car(model, extractEngine);

            if (currentCar.Length > 2)
            {
                var number = 0;
                if (int.TryParse(currentCar[2], out number))
                {
                    var weight = currentCar[2];
                    newCar.Weight = weight;
                }
                else
                {
                    var color = currentCar[2];
                    newCar.Color = color;
                }

                if (currentCar.Length > 3)
                {
                    var color = currentCar[3];
                    newCar.Color = color;
                }
            }
           
            carsList.Add(newCar);
        }
    }

    private static void AddEngines(List<Engine> enginesList)
    {
        var enginesNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < enginesNumber; i++)
        {

            var currentEngine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = currentEngine[0];
            var power = int.Parse(currentEngine[1]);
            

            var newEngine = new Engine(model, power);

            if (currentEngine.Length > 2)
            {
                var number = 0;
                if (int.TryParse(currentEngine[2], out number))
                {
                    var displacement = currentEngine[2];
                    newEngine.Displacement = displacement;
                }
                else
                {
                    var efficiency = currentEngine[2];
                    newEngine.Efficiency = efficiency;
                }

                if (currentEngine.Length > 3)
                {
                    var efficiency = currentEngine[3];
                    newEngine.Efficiency = efficiency;
                }
            }
            enginesList.Add(newEngine);
        }
    }
}

