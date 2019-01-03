namespace _02.Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var lineParts = input.Split(new[] { " ", "->" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(lineParts[0] == "ban")
                {
                    var name = lineParts[1];

                    dict.Remove(name);
                    continue;
                }

                var username = lineParts[0];
                var tag = lineParts[1];
                var likes = int.Parse(lineParts[2]);

                if (!dict.ContainsKey(username))
                {
                    dict[username] = new Dictionary<string, int>();
                }
                if (!dict[username].ContainsKey(tag))
                {
                    dict[username][tag] = 0;
                }

                dict[username][tag] = likes;
            }


            var orderedDict = dict
                .OrderByDescending(x => x.Value.Sum(l => l.Value))
                .ThenBy(x => x.Value.Select(t => t.Key).Count())
                .ToArray();

            foreach (var user in orderedDict)
            {
                Console.WriteLine($"{user.Key}");
                foreach (var item in user.Value)
                {
                    Console.WriteLine($"- {item.Key}: {item.Value}");
                }
            }
        }
    }
}
