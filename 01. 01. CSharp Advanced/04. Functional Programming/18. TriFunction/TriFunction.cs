namespace _18._TriFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TriFunction
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            //First way
            Func<string, int, bool> isItPass = (name, number) => name.ToCharArray().Select(x => (int)(x)).Sum() >= number;

            Func<string[], int, Func<string, int, bool>, string> firstValidName =
                (list, number, func) => list.FirstOrDefault(name => func(name, number));

            Console.WriteLine(firstValidName(names, n, isItPass));

            //------------------------------------------------------------------------------------------------------
            
            //Second way
            //var resultList = new List<string>();
            //foreach (var name in names)
            //{
            //    var currentSum = 0;
            //    foreach (var ch in name)
            //    {
            //        currentSum += (int)(ch);
            //    }
            //    if(currentSum >= n)
            //    {
            //        resultList.Add(name);
            //    }
            //}
            
            //Console.WriteLine(string.Join(" ", resultList.FirstOrDefault()));
        }
    }
}
