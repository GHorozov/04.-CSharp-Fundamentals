namespace _4._Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    var closestOpeningBraketIndex = stack.Pop();
                    var expresionLenght = i - closestOpeningBraketIndex + 1;
                    Console.WriteLine(input.Substring(closestOpeningBraketIndex, expresionLenght));
                }
            }
        }
    }
}
