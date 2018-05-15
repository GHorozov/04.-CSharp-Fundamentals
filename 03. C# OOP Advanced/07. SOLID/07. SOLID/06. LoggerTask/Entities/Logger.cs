using _06.Logger.Interfaces;
using _06.LoggerTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Logger.Entities
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        private void Log(string timeString, string reportLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                ReportLevel currentReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);

                if(appender.ReportLevel <= currentReportLevel) //If currentReportLevel is smaller or equal than appenderReportLevel print else dont
                {
                    appender.Append(timeString, reportLevel, message);
                }            
            }
        }

        public void Error(string timeString, string message)
        {
            this.Log(timeString, "Error", message);
        }

        public void Info(string timeString, string message)
        {
            this.Log(timeString, "Info", message);
        }

        public void Fatal(string timeString, string message)
        {
            this.Log(timeString, "Fatal", message);
        }

        public void Critical(string timeString, string message)
        {
            this.Log(timeString, "Critical", message);
        }

        public void Warn(string timeString, string message)
        {
            this.Log(timeString, "Warning", message);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (IAppender appender in appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString();
        }

    }

}
