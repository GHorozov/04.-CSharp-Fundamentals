namespace _09.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> citizensAndRebels = new List<IBuyer>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var name = line[0];
                var age = int.Parse(line[1]);

                if(line.Length == 4)
                {
                    var id = line[2];
                    var birthdate = line[3];
                    var citizen = new Citizen(name, age, id, birthdate);
                    citizensAndRebels.Add(citizen);
                }
                else if(line.Length == 3)
                {
                    var group = line[2];
                    var rebel = new Rebel(name, age, group);
                    citizensAndRebels.Add(rebel);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var person = citizensAndRebels.FirstOrDefault(x => x.Name == input);
                if(person != null)
                {
                    person.BuyFood();
                }
            }

            Console.WriteLine(citizensAndRebels.Select(x => x.Food).Sum());
        }
    }
}
