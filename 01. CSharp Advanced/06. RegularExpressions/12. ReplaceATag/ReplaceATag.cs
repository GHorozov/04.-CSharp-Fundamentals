using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceATag
{
    class ReplaceATag
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = @"<a.*?href.*?=(.*?)>(.*?)<\/a>";
   
            while (text != "end")
            {      
                var result = Regex.Replace(text, pattern, "[URL href=$1]$2[/URL]"); //Replace if pattern match with string("[URL href=$1]$2[/URL]") 
                Console.WriteLine(result); 
                         
                text = Console.ReadLine();
            } 
        }
    }
}
