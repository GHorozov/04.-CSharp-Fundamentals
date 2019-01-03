namespace _02.CryptoMaster
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var longestSequance = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumberIndex = i;

                for (int step = 1; step <= numbers.Length; step++)
                {
                    var currentNumber = numbers[i];
                    var nextNumberIndex = (i + step) % numbers.Length;
                    var nextNumber = numbers[nextNumberIndex];
                    var currentMax = 1;

                    while (currentNumber < nextNumber)
                    {
                        currentMax++;
                        currentNumberIndex = nextNumberIndex;
                        nextNumberIndex = (currentNumberIndex + step) % numbers.Length;
                        currentNumber = nextNumber;
                        nextNumber = numbers[nextNumberIndex];
                    }

                    if (currentMax > longestSequance)
                    {
                        longestSequance = currentMax;
                    }
                }
            }

            Console.WriteLine(longestSequance);
        }
    }
}
