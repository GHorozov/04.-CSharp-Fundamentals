using _06.Logger.Interfaces;
using System;
using _06.LoggerTask.Enums;
using System.Text;

namespace _06.Logger.Entities.Apenders
{
    public class ConsoleAppender : IAppender
    {

        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string timeString,string reportLevel, string message)
        {
            string formattedMsg = this.Layout.FormatMessage(timeString, reportLevel, message);
            Console.WriteLine(formattedMsg);
        }

       
    }
}
