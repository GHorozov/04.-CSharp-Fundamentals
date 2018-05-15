using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            using(StreamReader reader= new StreamReader("../../text.txt"))
            {
                var lineNumber = 0;
                var line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 == 1)
                    {
                        Console.WriteLine($"Line {lineNumber}: {line}");
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
