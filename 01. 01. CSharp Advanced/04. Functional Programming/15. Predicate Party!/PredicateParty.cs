namespace _15._Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateParty
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var commands = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                
                people = UpdatePeople(commands, people);
            }

            PrintResult(people);
        }

        private static void PrintResult(List<string> people)
        {
            if (people.Any())
            {
                Action<List<string>> printer = x => Console.Write(string.Join(", ", x));
                printer(people);
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> UpdatePeople(List<string> commands, List<string> people)
        {
            var command = commands[0];
            var criteria = commands[1];
            var stringPartOrLenght = commands[2];

            Predicate<string> startsWithFilter = x => x.StartsWith(stringPartOrLenght);
            Predicate<string> endsWithFilter = x => x.EndsWith(stringPartOrLenght);
            Predicate<string> lenghtFilter = x => x.Length == int.Parse(stringPartOrLenght);

            
            if (command == "Double")
            {
                var currentList = new List<string>();

                if (criteria == "StartsWith")
                {
                    currentList = people.FindAll(startsWithFilter);
                    people.AddRange(currentList);
                    return people;
                }
                else if(criteria == "EndsWith")
                {
                    currentList = people.FindAll(endsWithFilter);
                    people.AddRange(currentList);
                    return people;
                }
                else if(criteria == "Length")
                {
                    currentList = people.FindAll(lenghtFilter);
                    people.AddRange(currentList);
                    return people.OrderBy(x => x).ToList();
                }
            }
            else if(command == "Remove")
            {
                if (criteria == "StartsWith")
                {
                    people.RemoveAll(startsWithFilter);
                    return people;
                }
                else if (criteria == "EndsWith")
                {
                    people.RemoveAll(endsWithFilter);
                    return people;
                }
                else if (criteria == "Length")
                {
                    people.RemoveAll(lenghtFilter);
                    return people;
                }
            }

            return null; 
        }
    }
}
