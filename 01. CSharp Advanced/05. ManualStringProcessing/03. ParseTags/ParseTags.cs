using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTags
{
    class ParseTags
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var patternOpen = "<upcase>";
            var patternClose = "</upcase>";
            var indexOfStart = text.IndexOf(patternOpen);
            
            while(indexOfStart != -1)
            {
                var indexOfLast = text.IndexOf("</upcase>");
                if(indexOfLast == -1)
                {
                    break;
                }

                var toBeReplaced = text.Substring(indexOfStart, (indexOfLast + patternClose.Length) - indexOfStart);
                var replaced = toBeReplaced.Replace(patternOpen, string.Empty).Replace(patternClose, string.Empty).ToUpper();
                text = text.Replace(toBeReplaced, replaced);

                indexOfStart = text.IndexOf(patternOpen);
            }

            Console.WriteLine(text);
        }
    }
}
