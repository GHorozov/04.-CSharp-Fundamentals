using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.LoggerTask.Entities
{
    public class LogFile
    {
        private const string DefaultFileName = "log.txt";
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size { get; private set; }

        public void Write(string formatMsg)
        {
            this.sb.AppendLine(formatMsg);

            File.AppendAllText(DefaultFileName, formatMsg + Environment.NewLine); //Write to file log.txt current message

            this.Size = this.GetLettersSum(formatMsg); //Take current size of current message.
        }

        private int GetLettersSum(string formatMsg)
        {
            return formatMsg.Where(c => char.IsLetter(c)).Sum(s => s);
        }
    }
}
