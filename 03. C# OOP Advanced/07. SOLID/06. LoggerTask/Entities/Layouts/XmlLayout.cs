using _06.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.LoggerTask.Entities.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string timeString, string reportLevel, string message)
        {
            var sb = new StringBuilder();

            return sb.AppendLine($"<log>")
                .AppendLine($"  <date>{timeString}</date>")
                .AppendLine($"  <level>{reportLevel}</level>")
                .AppendLine($"  <message>{message}</message>")
                .Append($"</log>")
                .ToString();
        }
    }
}
