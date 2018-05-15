using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseURLs
{
    class ParseURLs
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine();
            var urlParts = url.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if(urlParts.Length != 2 || urlParts[1].IndexOf('/') == -1) //if there are two ://  OR there is not /
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var protocol = urlParts[0];
                var indexResource = urlParts[1].IndexOf("/");
                var server = urlParts[1].Substring(0, indexResource);
                var resouses = urlParts[1].Substring(indexResource+1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resouses}");
            }
        }
    }
}
