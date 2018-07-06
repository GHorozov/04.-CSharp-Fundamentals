namespace _02._Line_Numbers
{
    using System;
    using System.IO;

    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamReader  streamReader = new StreamReader("text.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("result.txt"))
                {
                    var lineNumber = 1;
                    string currentLine;
                    while ((currentLine = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"Line {lineNumber++}:{currentLine}");
                    }
                }
            }
        }
    }
}
