using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePartyReservationFilterModule
{
    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var secondListNames = new List<string>();
            foreach (var name in names)
            {
                secondListNames.Add(name);
            }
            var input = Console.ReadLine();
            while (input != "Print")
            {
                string[] inputParts = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var firstCommand = inputParts[0];
                var secondCommand = inputParts[1];
                var variable = inputParts[2];

                Predicate<string> isStartsWith = s => s.StartsWith(variable);
                Predicate<string> isEndsWith = s => s.EndsWith(variable);
                Predicate<string> isLenght = s => s.Length == int.Parse(variable);
                Predicate<string> isContains = s => s.Contains(variable);

                if (firstCommand == "Add filter")
                {
                    if(secondCommand == "Starts with")
                    {
                        names.RemoveAll(isStartsWith);
                    }
                    else if(secondCommand == "Ends with")
                    {
                        names.RemoveAll(isEndsWith);
                    }
                    else if(secondCommand == "Lenght")
                    {
                        names.RemoveAll(isLenght);
                    }
                    else if(secondCommand == "Contains")
                    {
                        names.RemoveAll(isContains);
                    }
                }
                else if (firstCommand == "Remove filter")
                {
                    var listToAdd = new List<string>();
                    if (secondCommand == "Starts with")
                    {
                        listToAdd= secondListNames.FindAll(isStartsWith); //Find all names that starts with parameter.
                        names.AddRange(listToAdd);
                    }
                    else if (secondCommand == "Ends with")
                    {
                        listToAdd= secondListNames.FindAll(isEndsWith);
                        names.AddRange(listToAdd);
                    }
                    else if (secondCommand == "Lenght")
                    {
                        listToAdd= secondListNames.FindAll(isLenght);
                        foreach (var name in listToAdd)
                        {
                            var index = secondListNames.LastIndexOf(name); //Return index of exact place where name is in list.
                            names.Insert(index, name);
                        }
                    }
                    else if (secondCommand == "Contains")
                    {
                        listToAdd= secondListNames.FindAll(isContains);
                        foreach (var name in listToAdd)
                        {
                            var index = secondListNames.LastIndexOf(name);
                            names.Insert(index, name);
                        }
                    }
                }

                input = Console.ReadLine();
            }


            Console.WriteLine(string.Join(" ", names));
        }
    }
}
