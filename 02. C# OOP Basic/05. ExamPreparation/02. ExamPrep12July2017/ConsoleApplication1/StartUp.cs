using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        var nations = new NationsBuilder();

        var input = Console.ReadLine();
        while ( input != "Quit")
        {
            var lineParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = lineParts[0];

            switch (command)
            {
                case "Bender":
                    nations.AssignBender(lineParts);
                    break;

                case "Monument":
                    nations.AssignMonument(lineParts);
                    break;

                case "Status":
                    var nation = lineParts[1];
                    Console.WriteLine(nations.GetStatus(nation));
                    break;

                case "War":
                    var nationType = lineParts[1];
                    nations.IssueWar(nationType);
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(nations.GetWarsRecord());
    }
}

