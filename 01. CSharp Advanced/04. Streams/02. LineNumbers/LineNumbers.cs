using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("Result.txt"))
                {
                    var lineNumber = 0;
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        lineNumber++;
                        writer.WriteLine($"Line {lineNumber}: {line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
