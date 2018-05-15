using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS
{
    class NMS
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();
            while (input != "---NMS SEND---")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            var delimer = Console.ReadLine();

            var result = new StringBuilder();
            result.Append(sb[0]);
            for (int i = 1; i < sb.Length; i++)
            {
                if(char.ToLower(sb[i]) >= char.ToLower(sb[i - 1]))
                {
                    result.Append(sb[i]);
                }
                else
                {
                    result.Append(delimer);
                    result.Append(sb[i]);
                }
            }

            Console.WriteLine(result);
        }
    }
}
