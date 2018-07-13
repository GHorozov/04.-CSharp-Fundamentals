namespace _12._PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateForNames
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> filter = (x) => x.Length <= n;
            var result = FilterNames(names, n, filter);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static List<string> FilterNames(List<string> names, int n, Predicate<string> filter)
        {
            var list = new List<string>();
            foreach (var name in names)
            {
                if(filter(name) )
                {
                    list.Add(name);
                }
            }

            return list;
        }
    }
}
