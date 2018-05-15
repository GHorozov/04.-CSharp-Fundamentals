using _06.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06.LoggerTask.Enums;

namespace _06.LoggerTask.Entities.Apenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public LogFile File { get;  }

        public int Count { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string timeString, string reportLevel, string message)
        {
            this.Count++;
            string formatMsg = this.Layout.FormatMessage(timeString, reportLevel, message);

            this.File.Write(formatMsg);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            return sb.AppendLine($"Appender type: {this.GetType().Name}, ")
                .AppendLine($"Layout type: {this.GetType().Name}, ")
                .AppendLine($"Report level: {this.ReportLevel}, ")
                .AppendLine($"Message appended: {this.Count}, ")
                .AppendLine($"File size: {this.File.Size}")
                .ToString();
        }
    }
}
