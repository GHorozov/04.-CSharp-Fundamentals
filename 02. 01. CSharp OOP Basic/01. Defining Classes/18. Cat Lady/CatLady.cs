using System;
using System.Collections.Generic;
using System.Linq;

class CatLady
{
    static void Main(string[] args)
    {
        var cats = new List<Cat>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var lineParts = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var species = lineParts[0];
            var name = lineParts[1];
            
            if(species == "Siamese")
            {
                cats.Add(new Siamese(species, name, long.Parse(lineParts[2])));
            }
            else if(species == "Cymric")
            {
                cats.Add(new Cymric(species, name, double.Parse(lineParts[2])));
            }
            else if (species == "StreetExtraordinaire")
            {
                cats.Add(new StreetExtraordinaire(species, name, double.Parse(lineParts[2])));
            }
        }

        var theName = Console.ReadLine();
        Console.WriteLine(cats.FirstOrDefault(x => x.Name == theName));
    }
}

