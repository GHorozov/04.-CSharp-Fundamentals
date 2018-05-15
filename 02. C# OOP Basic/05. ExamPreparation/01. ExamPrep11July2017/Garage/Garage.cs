using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Garage
{
    public List<int> ParkedCars { get; set; }

    public Garage()
    {
        this.ParkedCars = new List<int>();
    }


    public void ParkCar(int id)
    {
        this.ParkedCars.Add(id);
    }

    public void UnparkCar(int carId)
    {

        this.ParkedCars.Remove(carId);

    }
}

