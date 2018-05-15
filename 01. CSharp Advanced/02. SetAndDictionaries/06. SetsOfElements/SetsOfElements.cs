using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            var setsNumber = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = setsNumber[0];
            var m = setsNumber[1];
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < n + m; i++)
            {
                var currentNum = int.Parse(Console.ReadLine());
                if (i <= n-1)
                {
                    firstSet.Add(currentNum);
                }
                else
                {
                    secondSet.Add(currentNum);
                }
            }

            var maxSet = firstSet.Count > secondSet.Count ? firstSet : secondSet;
            var queue = new Queue<int>();
            foreach (var number in maxSet)
            {
                if (firstSet.Contains(number) && secondSet.Contains(number))
                {
                    queue.Enqueue(number);
                }
            }

            if (queue.Any())
            {
                Console.WriteLine(String.Join(", ", queue.Dequeue()));
            }
        }
    }
}