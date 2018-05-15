using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.JediMeditation
{
    class JediMeditationTask
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var masters = new List<string>();
            var knights = new List<string>();
            var parawans = new List<string>();
            var isThereYoda = false;
            var listTashkoSlav = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < list.Length; j++)
                {
                    var currentElement = list[j];

                    if (currentElement.StartsWith("y"))
                    {
                        isThereYoda = true;
                        continue;
                    }

                    if (currentElement.StartsWith("t"))
                    {
                        listTashkoSlav.Add(currentElement);
                    }
                    else if (currentElement.StartsWith("s"))
                    {
                        listTashkoSlav.Add(currentElement);
                    }
                    else if (currentElement.StartsWith("m"))
                    {
                        masters.Add(currentElement);
                    }
                    else if (currentElement.StartsWith("k"))
                    {
                        knights.Add(currentElement);
                    }
                    else if (currentElement.StartsWith("p"))
                    {
                        parawans.Add(currentElement);
                    }
                }
            }

            if (isThereYoda)
            {
                Console.WriteLine(string.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", listTashkoSlav) + " " +
                    string.Join(" ", parawans));
            }
            else
            {
                Console.WriteLine(string.Join(" ", listTashkoSlav) + " " + string.Join(" ", masters) + " " + string.Join(" ", knights) +
                " " + string.Join(" ", parawans));
            }
        }
    }
}
