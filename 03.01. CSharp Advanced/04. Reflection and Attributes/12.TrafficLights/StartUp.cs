namespace _12.TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            var list = new List<Light>();
            foreach (var item in input)
            {
                list.Add(new Light(item));
            }

            for (int i = 0; i < n; i++)
            {
                list.ForEach(x => x.Change());

                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}
