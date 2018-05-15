using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            var resourses = new Dictionary<string, int>();
            var junk = new Dictionary<string, int>();

            resourses["shards"] = 0;
            resourses["fragments"] = 0;
            resourses["motes"] = 0;

            while (true)
            {
                var input = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
               
                for (int i = 1; i <= input.Length; i++)
                {

                    if (i % 2 != 0)
                    {
                        if (input[i] == "shards" || input[i] == "fragments" || input[i] == "motes")
                        {
                           
                            resourses[input[i]] += int.Parse(input[i - 1]);
                        }
                        else
                        {
                            if (!junk.ContainsKey(input[i]))
                            {
                                junk.Add(input[i], 0);
                            }

                            junk[input[i]] += int.Parse(input[i - 1]);
                        }
                    }

                    //When one of resourses reach more than 250 I have to break and print the result. 

                    if (resourses["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");

                        resourses["shards"] -= 250;

                        Print(resourses, junk);

                        return;
                    }
                    else if (resourses["fragments"] >= 250)
                    {

                        Console.WriteLine("Valanyr obtained!");

                        resourses["fragments"] -= 250;

                        Print(resourses, junk);

                        return;

                    }
                    else if (resourses["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");

                        resourses["motes"] -= 250;

                        Print(resourses, junk);

                        return;
                    }
                }
            }

            
        }

        private static void Print(Dictionary<string, int> resourses, Dictionary<string, int> junk)
        {
            foreach (var pair in resourses.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            foreach (var pair in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
