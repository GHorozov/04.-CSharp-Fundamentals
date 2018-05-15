using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var guestsList = new SortedSet<string>();

            while (input != "PARTY")
            {
                guestsList.Add(input);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                guestsList.Remove(input);

                input = Console.ReadLine();
            }

            Console.WriteLine($"{guestsList.Count}");
            Console.WriteLine(string.Join("\n", guestsList));

        }
    }
}
