using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var log = new SortedDictionary<string, Dictionary<string, List<string>>>();

            while(input != "end")
            {
                var lineParts = input.Split(new string[] {"IP=", "message=", "user="}, StringSplitOptions.RemoveEmptyEntries);
                var ip = lineParts[0].Trim(' ');
                var message = lineParts[1].Trim(' ', '\'');
                var user = lineParts[2].Trim(' ');

                if (!log.ContainsKey(user))
                {
                    log[user] = new Dictionary<string, List<string>>();
                }
                if (!log[user].ContainsKey(ip))
                {
                    log[user][ip] = new List<string>();
                }

                log[user][ip].Add(message);

                input = Console.ReadLine();
            }

            foreach (var entry in log)
            {
                Console.WriteLine($"{entry.Key}:");

                var stringBuilder = new StringBuilder();
                foreach (var pair in entry.Value)
                {
                    stringBuilder.Append($"{pair.Key} => {pair.Value.Count}").Append(", ");
                }

                var result = stringBuilder.ToString();
                if (result.EndsWith(", "))
                {
                    result = result.TrimEnd(',', ' ');
                }

                Console.WriteLine($"{result}.");
            }
        }
    }
}
