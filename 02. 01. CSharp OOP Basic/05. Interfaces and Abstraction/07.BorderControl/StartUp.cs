namespace _07.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentity> citizensAndRobots = new List<IIdentity>();  

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var lineParts = input.Split();

                if (lineParts.Length == 3)
                {
                    var citizen = new Citizen(lineParts[0], int.Parse(lineParts[1]), lineParts[2]);
                    citizensAndRobots.Add(citizen);
                }
                else
                {
                    var robot = new Robot(lineParts[0], lineParts[1]);
                    citizensAndRobots.Add(robot);
                }
            }

            var searchPart = Console.ReadLine();
            citizensAndRobots
                .Where(x => x.Id.EndsWith(searchPart))
                .ToList()
                .ForEach(x => Console.WriteLine(x.Id));
        }
    }
}
