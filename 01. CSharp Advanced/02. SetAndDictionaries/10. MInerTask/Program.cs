using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MInerTask
{
    class Program
    {
        static void Main(string[] args)
        {        
            var total = new Dictionary<string, int>();

            for (int i = 0; i < int.MaxValue; i += 2)
            {
                var resourse = Console.ReadLine();
                if (resourse == "stop") break;
                var quantity = int.Parse(Console.ReadLine());

                if (!total.ContainsKey(resourse))
                {
                    total.Add(resourse, 0);
                }

                total[resourse] += quantity;
            }

            foreach (var pair in total)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }

        }
    }
}
