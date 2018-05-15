using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var commands = Console.ReadLine();

            var list = input;
            while (commands != "end")
            {
                switch (commands)
                {
                    case "add":
                        Func<int, int> add = n => n + 1;
                        list = Operations(list, add);
                        break;
                    case "multiply":
                        Func<int, int> multiply = n => n * 2;
                        list = Operations(list, multiply);
                        break;
                    case "subtract":
                        Func<int, int> subtract = n => n - 1;
                        list = Operations(list, subtract);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", list));                    
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine();
            }
      
        }

        private static List<int> Operations(List<int> list, Func<int, int> func)
        {
            var resultList = new List<int>();
            foreach (var member in list)
            {
                var resultFunc = func(member);
                resultList.Add(resultFunc);
            }

            return resultList;
        }
    }
}
