namespace _16._The_Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            var finalList = new List<string>();
            finalList = people.Select(x => (x.Clone()).ToString()).ToList();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                var filters = input
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                finalList = UpdatePeople(filters, people, finalList);
            }

            Console.WriteLine(string.Join(" ", finalList));

        }

        private static List<string> UpdatePeople(List<string> filters, List<string> people, List<string> finalList)
        {
            var filter = filters[0];
            var filterType = filters[1];
            var stringPart = filters[2];

            Predicate<string> startsWithFilter = (x) => x.StartsWith(stringPart);
            Predicate<string> endsWithFilter = (x) => x.EndsWith(stringPart);
            Predicate<string> lenghtFilter = (x) => x.Length == int.Parse(stringPart);
            Predicate<string> containsFilter = (x) => x.Contains(stringPart);

            if(filter == "Add filter")
            {
                switch (filterType)
                {
                    case "Starts with":
                        finalList.RemoveAll(startsWithFilter);
                        break;
                    case "Ends with":
                        finalList.RemoveAll(endsWithFilter);
                        break;
                    case "Length":
                        finalList.RemoveAll(lenghtFilter);
                        break;
                    case "Contains":
                        finalList.RemoveAll(containsFilter);
                        break;
                    default:
                        break;
                }
            }
            else if(filter == "Remove filter")
            {
                var temp = new List<string>();
                switch (filterType)
                {
                    case "Starts with":
                        temp = people.FindAll(startsWithFilter).OrderBy(x => x).ToList();
                        finalList.AddRange(temp);
                        break;
                    case "Ends with":
                        temp = people.Where(x => endsWithFilter(x)).OrderBy(x => x).ToList();
                        finalList.AddRange(temp);
                        break;
                    case "Length":
                        temp = people.Where(x => lenghtFilter(x)).OrderBy(x => x).ToList();
                        finalList.AddRange(temp);
                        finalList.OrderBy(x => x).ToList();
                        break;
                    case "Contains":
                        temp = people.Where(x => containsFilter(x)).OrderBy(x => x).ToList();
                        finalList.AddRange(temp);
                        finalList.OrderBy(x => x).ToList();
                        break;
                    default:
                        break;
                }
            }

            return finalList;
        }
    }
}
