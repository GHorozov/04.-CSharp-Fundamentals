using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        var list = new List<ICreature>();

        var input = Console.ReadLine();
        while (input != "End")
        {
            var line = input.Split(' ');

            if (line[0] == "Citizen")
            {
                list.Add(new Citizen(line[1], int.Parse(line[2]), line[3], line[4]));
            }
            else if (line[0] == "Pet")
            {
                list.Add(new Pet(line[1], line[2]));
            }
            
            input = Console.ReadLine();
        }

        var year = Console.ReadLine();

        list
            .Where(x => x.Birthdate.EndsWith(year))
            .ToList()
            .ForEach(x => Console.WriteLine(x.Birthdate));

    }
}

