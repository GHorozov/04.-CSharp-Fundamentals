using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            var visitCard = new Dictionary<string, string>();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var name = Console.ReadLine();
                if (name == "stop") break;
                var email = Console.ReadLine();

                if (email.EndsWith("us") || email.EndsWith("uk")) continue;

                if (!visitCard.ContainsKey(name))
                {
                    visitCard.Add(name, string.Empty);
                }

                visitCard[name] = email;
            }

            foreach (var entry in visitCard)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
