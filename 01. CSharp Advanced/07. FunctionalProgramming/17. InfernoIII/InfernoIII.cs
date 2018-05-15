using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfernoIII
{
    class InfernoIII
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var input = Console.ReadLine();

            var exclusionFilters = new Queue<KeyValuePair<string, int>>();

            while (input != "Forge")
            {
                var inputParts = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var firstCommand = inputParts[0];
                var filter = inputParts[1];
                var parameter = int.Parse(inputParts[2]);

                if (firstCommand == "Exclude")
                {
                    exclusionFilters.Enqueue(new KeyValuePair<string, int>(filter, parameter));                
                }
                else if (firstCommand == "Reverse")
                {
                    if (exclusionFilters.Count > 0)
                    {
                        exclusionFilters.Dequeue();
                    }
                }

                input = Console.ReadLine();
            }

            ExecuteExclusions(numbers, exclusionFilters);

            Console.WriteLine(string.Join(" ",numbers));
        }


        public static void ExecuteExclusions(List<int> numbers, Queue<KeyValuePair<string, int>> exclusionFilters)
        {
            foreach (var filter in exclusionFilters.Reverse())
            {
                switch (filter.Key)
                {
                    case "Sum Left":
                        SumLeftMethod(numbers, filter.Value);
                        break;
                    case "Sum Right":
                        SumRightMethod(numbers, filter.Value);
                        break;
                    case "Sum Left Right":
                        SumLeftRightMethod(numbers, filter.Value);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SumLeftRightMethod(List<int> numbers,int parameter)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var leftGemPower = (i == 0) ? 0 : numbers[i - 1];
                var rightGemPower = (i == numbers.Count - 1) ? 0 : numbers[i + 1];

                if (leftGemPower + numbers[i] + rightGemPower == parameter)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void SumRightMethod(List<int> numbers, int parameter)
        {
            while (numbers.Count > 0 && numbers.Last() == parameter)
            {
                numbers.RemoveAt(numbers.Count - 1);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                var rightNum = (i == numbers.Count - 1) ? 0 : numbers[i + 1];

                if (numbers[i] + rightNum == parameter)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void SumLeftMethod(List<int> numbers, int parameter)
        {
            while (numbers.Count > 0 && numbers.First() == parameter)
            {
                numbers.RemoveAt(0);
            }

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                var leftNum = (i > 0) ? numbers[i - 1] : 0;

                if (numbers[i] + leftNum == parameter)
                {
                    numbers.RemoveAt(i);
                }
            }
        }
    }
}
