using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var sumHapinesPoints = 0;
        foreach (var item in input)
        {
            var foodFactory = new FoodFactory(item);
            sumHapinesPoints += foodFactory.GetFoodPoints(item);
        }

        var moodFactory = new MoodFactory(sumHapinesPoints);

        Console.WriteLine(sumHapinesPoints);
        moodFactory.GetMood(sumHapinesPoints);     
    }
}

