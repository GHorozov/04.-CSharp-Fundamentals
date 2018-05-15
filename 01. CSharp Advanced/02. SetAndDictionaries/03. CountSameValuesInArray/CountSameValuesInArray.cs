using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            var numbers = new SortedDictionary<double, int>();
            var input = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var num = input[i];
                //Check for difrence languages format(, and .).
                double keyNumber;
                if (num.Contains(","))
                {
                    keyNumber = double.Parse(num.Replace(",", "."));
                }
                else
                {
                    keyNumber = double.Parse(num);
                }

               
                if (!numbers.ContainsKey(keyNumber))
                {
                    numbers[keyNumber] = 0;
                }

                numbers[keyNumber] += 1;
            }

            foreach (var number in numbers)
            {
                // Reformat back to original input.
                if (number.Key.ToString().Contains("."))
                {
                    var resultKey = number.Key.ToString().Replace(".", ",");
                    Console.WriteLine($"{resultKey} - {number.Value} times");
                }
                else
                {
                    Console.WriteLine($"{number.Key} - {number.Value} times");
                }
               
            }
        }
    }
}
