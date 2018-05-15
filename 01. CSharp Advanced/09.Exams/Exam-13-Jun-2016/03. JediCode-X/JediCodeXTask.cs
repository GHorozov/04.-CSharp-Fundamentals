using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.JediCode_X
{
    class JediCodeXTask
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string text ="";
            for (int i = 0; i < n; i++)
            {
                text += Console.ReadLine() + Environment.NewLine;
            }

            //var firstPattern = Console.ReadLine();
            //var secondPattern = Console.ReadLine();

            //var firstMatches = Regex.Matches(text, Regex.Escape(firstPattern) + $@"([A-Za-z]{firstPattern.Length})");
            //var secondMatches = Regex.Matches(text, Regex.Escape(secondPattern) + $@"([A-Za-z0-9]{secondPattern.Length})");


            string nPat = Console.ReadLine();
            string mPat = Console.ReadLine();

            string patternName = Regex.Escape(nPat) + @"([a-zA-Z]{" + nPat.Length + @"})(?![a-zA-Z])";
            string patternMsg = Regex.Escape(mPat) + @"([a-zA-Z0-9]{" + mPat.Length + @"})(?![a-zA-Z0-9])";

            Regex nRgx = new Regex(patternName);
            Regex mRgx = new Regex(patternMsg);

            var names = nRgx.Matches(text);
            var messagesRaw = mRgx.Matches(text);

            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var list = new List<string>();

            var group1 = 1;
            for(int i = 0; i < names.Count;i++)
            {
                var currentName = names[i].Value;
                var name = currentName.Substring(nPat.Length);
                var message = "";
                for (int j = 0; j < indexes.Length; j++)
                {
                    var index = indexes[i];
                    try
                    {
                        var messageArs = messagesRaw[j].Value;
                        message = messageArs.Substring(mPat.Length); 
                    }
                    catch
                    {

                    }

                    if(message != string.Empty)
                    {
                        list.Add(message);
                    }
                    
                }

                Console.WriteLine($"{name} - {list[i]}");
            }
        }
    }
}
