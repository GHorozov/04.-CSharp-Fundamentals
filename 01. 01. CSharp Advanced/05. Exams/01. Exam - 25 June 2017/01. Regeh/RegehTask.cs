namespace _01._Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class RegehTask
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"[[^]]*[A-Za-z]+<(\d+)REGEH(\d+)>[A-Za-z]+]");

            var numbers = new List<int>();
            foreach (Match match in regex.Matches(input))
            {
                var firstNumber = int.Parse(match.Groups[1].Value);
                var secondNumber = int.Parse(match.Groups[2].Value);
                numbers.Add(firstNumber);
                numbers.Add(secondNumber);
            }

            var result = new StringBuilder();
            for (int i = 0; i < numbers.Count; i++)
            {
                var currentIndex = numbers.Take(i+1).Sum();
                if(currentIndex >= input.Length)
                {
                    currentIndex = currentIndex % input.Length+1;
                }
                result.Append(input[currentIndex]);
            }
            
            Console.WriteLine(result);
        }
    }
}
