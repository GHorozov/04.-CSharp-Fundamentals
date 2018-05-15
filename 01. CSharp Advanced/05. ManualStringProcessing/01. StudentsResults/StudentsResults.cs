using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResults
{
    class StudentsResults
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name" , "CAdv", "COOP", "AdvOOP", "Average"));
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] { '-', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var name = line[0];
                var cAdv = double.Parse(line[1]);
                var coop = double.Parse(line[2]);
                var advOOP = double.Parse(line[3]);

                var averageResult = line.Skip(1).Select(double.Parse).Average();

                Console.WriteLine(string.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", name, cAdv, coop, advOOP, averageResult));
            }
        }
    }
}
