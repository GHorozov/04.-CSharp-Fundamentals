namespace _01._Odd_Lines
{
    using System;
    using System.IO;

    class OddLines
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("text.txt"))
            {
                var lineNumber = 0;

                while (true)
                {
                    var line = streamReader.ReadLine();
                    if (line == null) break;
                    if(lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;
                }
            }
        }
    }
}
