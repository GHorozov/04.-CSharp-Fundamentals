namespace _08.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthday> citizensAndPets = new List<IBirthday>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var lineParts = input.Split();

                if (lineParts[0] == "Citizen")
                {
                    var citizen = new Citizen(lineParts[1], int.Parse(lineParts[2]), lineParts[3], lineParts[4]);
                    citizensAndPets.Add(citizen);
                }
                else if(lineParts[0] == "Pet")
                {
                    var pet = new Pet(lineParts[1], lineParts[2]);
                    citizensAndPets.Add(pet);
                }
            }

            var searchYear = Console.ReadLine();
            citizensAndPets
                .Where(x => x.Birthday.EndsWith(searchYear))
                .ToList()
                .ForEach(x => Console.WriteLine(x.Birthday));
        }
    }
}
