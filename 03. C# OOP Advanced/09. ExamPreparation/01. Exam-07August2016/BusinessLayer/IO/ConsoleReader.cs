namespace _01.Exam_07August2016.BusinessLayer.IO
{
    using System;
    using _01.Exam_07August2016.BusinessLayer.Constracts.IO;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
