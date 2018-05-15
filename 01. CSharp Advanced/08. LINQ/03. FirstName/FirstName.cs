using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstName
{
    class FirstName
    {
        static void Main(string[] args)
        {
            var sequance = Console.ReadLine().Split(' ');
            var letters = Console.ReadLine()
                .Split(' ')
                .OrderBy(x => x);

            foreach (var letter in letters)
            {
                var result = sequance.Where(x => x.ToLower().StartsWith(letter.ToLower())).FirstOrDefault();
                
                if(result != null)
                {
                    Console.WriteLine(result);
                    return;
                }
            }

            Console.WriteLine("No match");
        }
    }
}
