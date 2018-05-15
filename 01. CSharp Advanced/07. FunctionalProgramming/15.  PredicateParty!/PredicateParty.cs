using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            var input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] inputParts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = inputParts[0];
                string startsEndsOrLength = inputParts[1];
                string strOrLength = inputParts[2];

                Predicate<string> predicateStarts = s => s.StartsWith(strOrLength);
                Predicate<string> predicateEnds = s => s.EndsWith(strOrLength);
                Predicate<string> predicateLength = s => s.Length == int.Parse(strOrLength);

                if (command.Equals("Remove"))
                {
                    switch (startsEndsOrLength)
                    {
                        case "StartsWith":
                            names.RemoveAll(predicateStarts);
                            break;

                        case "EndsWith":
                            names.RemoveAll(predicateEnds);
                            break;

                        case "Length":
                            names.RemoveAll(predicateLength);
                            break;
                    }
                }
                else if (command.Equals("Double"))
                {
                    List<string> toBeAdded = new List<string>();

                    switch (startsEndsOrLength)
                    {
                        case "StartsWith":
                            toBeAdded = names.FindAll(predicateStarts);
                            names.AddRange(toBeAdded);
                            break;

                        case "EndsWith":
                            toBeAdded = names.FindAll(predicateEnds);
                            names.AddRange(toBeAdded);
                            break;

                        case "Length":

                            toBeAdded = names.FindAll(predicateLength);

                            foreach (string person in toBeAdded)
                            {
                                int index = names.LastIndexOf(person);
                                names.Insert(index, person);
                            }
                            break;
                    }
                }

                input = Console.ReadLine();
            }


            if (names.Any())
            {
                Console.Write(string.Join(", ", names));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
