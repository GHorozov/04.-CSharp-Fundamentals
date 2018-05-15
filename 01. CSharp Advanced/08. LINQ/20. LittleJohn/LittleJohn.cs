using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LittleJohn
{
    public class Arrow
    {
        public string Type { get; set; }
        public int Amount { get; set; }
    }
    class LittleJohn
    {
        static void Main(string[] args)
        {
            var arrows = new Arrow[]
            {
                new Arrow { Type = ">----->", Amount=0 },
                new Arrow { Type = ">>----->", Amount=0 },
                new Arrow { Type = ">>>----->>", Amount=0 },

            };

            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();
                var matches = Regex.Matches(input, $"(>----->)|(>>----->)|(>>>----->>)");

                foreach (Match match in matches)
                {
                    arrows.Where(arr => arr.Type == match.Value).First().Amount++; //add arrow count to each arrow Amount
                }
            }

            var sumArrows = int.Parse(string.Join(string.Empty, arrows.Select(a => a.Amount)));
            var binary = Convert.ToString(sumArrows, 2); //Convert arrow sum to binary number

            var concatNumer= binary;
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                concatNumer = string.Concat(concatNumer, binary[i]); //concat binary with reversed binary number
            }

            var result = Convert.ToInt32(concatNumer, 2);

            Console.WriteLine(result);

        }
    }
}
