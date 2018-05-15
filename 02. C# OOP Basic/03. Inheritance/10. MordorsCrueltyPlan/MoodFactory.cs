using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MoodFactory
{
    private int points;
    public MoodFactory(int points)
    {
        this.points = points;
    }
    public void GetMood(int sumHappines)
    {
        if (sumHappines < -5)
        {
            Console.WriteLine("Angry");
        }
        else if (sumHappines >= -5 && sumHappines <= 0)
        {
            Console.WriteLine("Sad");
        }
        else if (sumHappines >= 1 && sumHappines <= 15)
        {
            Console.WriteLine("Happy");
        }
        else if (sumHappines > 15)
        {
            Console.WriteLine("JavaScript");
        }
    }
}

