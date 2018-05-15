using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MelrahShake
{
    class MelrahShake
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                if (pattern.Length == 0)
                {
                    break;
                }

                var findLeft = text.IndexOf(pattern);
                var findRight = text.LastIndexOf(pattern);

                if (findLeft == -1 || findRight == -1)
                {
                    break;
                }

                if(findLeft == findRight)
                {
                    break;
                }

                text = text.Remove(findLeft, pattern.Length);
                text = text.Remove(findRight- pattern.Length, pattern.Length);
                Console.WriteLine("Shaked it.");

                var charToRemove = pattern.Length / 2;
                pattern = pattern.Remove(charToRemove, 1);
            }

            Console.WriteLine("No shake.");
            Console.WriteLine($"{text}");
        }
    }
}
