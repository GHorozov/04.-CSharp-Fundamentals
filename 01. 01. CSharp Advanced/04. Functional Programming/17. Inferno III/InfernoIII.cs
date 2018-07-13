namespace _17._Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class InfernoIII
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var excludeFilters = new Queue<List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Forge")
            {
                var commandArgs = input
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commandArgs[0] == "Exclude")
                {
                    excludeFilters.Enqueue(commandArgs);
                }
                else
                {
                    if (excludeFilters.Count > 0)
                    {
                        excludeFilters.Dequeue();
                    }
                }
            }

            var queue = new Queue<int>();
            foreach (var filterToExclude in excludeFilters)
            {
                numbers = UpdateNumbers(filterToExclude, numbers, queue);
            }
            

            var result = GetFinalResult(numbers, queue);
            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> GetFinalResult(List<int> numbers, Queue<int> Queue)
        {
            return numbers.Where(x => !Queue.Contains(x)).ToList();
        }

        private static List<int> UpdateNumbers(List<string> commandArgs, List<int> numbers, Queue<int> Queue)
        {
            var filter = commandArgs[1];
            var filterParam = int.Parse(commandArgs[2]);

            if (filter == "Sum Left")
            {
                ExcludeSumLeft(numbers, filterParam, Queue);
            }
            else if (filter == "Sum Right")
            {
                ExcludeSumRight(numbers, filterParam, Queue);
            }
            else if (filter == "Sum Left Right")
            {
                ExcludeSumLeftRight(numbers, filterParam, Queue);
            }

            return numbers;
        }

        private static void ExcludeSumRight(List<int> numbers, int filterParam, Queue<int> Queue)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var rightSide = (i == numbers.Count - 1) ? 0 : numbers[i + 1];
                var currentSum = numbers[i] + rightSide;
                if (currentSum == filterParam)
                {
                    Queue.Enqueue(numbers[i]);
                }
            }
        }

        private static void ExcludeSumLeftRight(List<int> numbers, int filterParam, Queue<int> Queue)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var leftSide = (i == 0) ? 0 : numbers[i - 1];
                var rightSide = (i == numbers.Count - 1) ? 0 : numbers[i + 1];
                var currentSum = leftSide + numbers[i] + rightSide;
                if (currentSum == filterParam)
                {
                    Queue.Enqueue(numbers[i]);
                }
            }
        }

        private static void ExcludeSumLeft(List<int> numbers, int filterParam, Queue<int> Queue)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var leftSide = (i == 0) ? 0 : numbers[i - 1];
                var currentSum = leftSide + numbers[i];
                if (currentSum == filterParam)
                {
                    Queue.Enqueue(numbers[i]);
                }
            }
        }
    }
}
