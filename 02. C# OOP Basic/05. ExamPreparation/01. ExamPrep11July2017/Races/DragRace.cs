using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DragRace : Race
{
    public DragRace(int length, string route, int pricePool) : base(length, route, pricePool)
    {
    }

    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];

        return (car.HorsePower / car.Acceleration);
    }
}

