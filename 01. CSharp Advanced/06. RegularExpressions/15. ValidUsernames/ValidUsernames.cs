using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            var usernames = Console.ReadLine().Split(new char[] { '/', '\\', ',', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var pattern = @"\b[A-Za-z]\w{2,24}\b";
            Regex regex = new Regex(pattern);

            var list = new List<string>();
            foreach (var name in usernames)
            {
                if (regex.IsMatch(name))
                {
                    list.Add(name.ToString());
                }
            }

            var maxSum = 0;
            var firstValid = string.Empty;
            var secondValid = string.Empty;
            for (int i = 0; i < list.Count-1; i++)
            {
                var currentSum = list[i].Length + list[i+1].Length;
                if(currentSum > maxSum)
                {
                    maxSum = currentSum;
                    firstValid = list[i].ToString();
                    secondValid = list[i + 1].ToString();
                }
            }

            Console.WriteLine(firstValid);
            Console.WriteLine(secondValid);
        }
    }
}
