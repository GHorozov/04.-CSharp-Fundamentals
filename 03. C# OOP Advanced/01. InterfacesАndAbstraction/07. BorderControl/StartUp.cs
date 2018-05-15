using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var list = new List<ICitizen>();
        

        while (input != "End")
        {
            var lineParts = input.Trim().Split(' ').ToArray();

            if (lineParts.Length == 3)
            {
                var name = lineParts[0];
                var age = int.Parse(lineParts[1]);
                var id = lineParts[2];

                var citizen = new Citizen(name, age, id);
                list.Add(citizen);
            }
            else if (lineParts.Length == 2)
            {
                var model = lineParts[0];
                var id = lineParts[1];

                var robot = new Robot(model, id);
                list.Add(robot);
            }

            input = Console.ReadLine();
        }

        var checkNumber = Console.ReadLine();
       
        list
            .Where(x => x.Id.EndsWith(checkNumber))
            .ToList()
            .ForEach(x => Console.WriteLine(x.Id));
    }
}

