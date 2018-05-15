using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class LogsAggregator
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var userLog = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var lineParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var ip = lineParts[0];
                var user = lineParts[1];
                var duration = int.Parse(lineParts[2]);

                if (!userLog.ContainsKey(user))
                {
                    userLog[user] = new SortedDictionary<string, int>();
                }
                if (!userLog[user].ContainsKey(ip))
                {
                    userLog[user].Add(ip, 0);
                }

                userLog[user][ip] += duration;
            }

            foreach (var user in userLog)
            {
                var userName = user.Key;
                var userDuration = user.Value.Values.Sum();
                var userIps = user.Value.Keys.ToList();

                Console.WriteLine($"{userName}: {userDuration} [{string.Join(", ", userIps)}]");      
            }
        }
    }
}
