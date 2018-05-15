using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var listCitizens = new List<ICreature>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');

            if (input.Length == 4)
            {
                listCitizens.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
            }
            else if (input.Length == 3)
            {
                listCitizens.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
            }
        }

        string name;
        while ((name = Console.ReadLine()) != "End")
        {
            foreach (var item in listCitizens)
            {
                if (item.Name == name)
                {
                    item.BuyFood();
                }
            }
        }

        Console.WriteLine(listCitizens.Sum(x => x.Food));
    }
}

