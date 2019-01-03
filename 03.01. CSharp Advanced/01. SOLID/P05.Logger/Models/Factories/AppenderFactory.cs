namespace P05.Logger.Models.Factories
{
    using P05.Logger.Enums;
    using P05.Logger.Models.Appenders;
    using P05.Logger.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AppenderFactory
    {
        private const string DefaultFileName = "logfile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender GetAppender(string appenderType, string errorLevel, string layoutType)
        {
            ILayout currentLayout = this.layoutFactory.GetLayout(layoutType);
            ErrorLevel currentErrorLever;
            bool IsCanParse = Enum.TryParse<ErrorLevel>(errorLevel, out currentErrorLever);

            IAppender appender = null;
            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(currentLayout, currentErrorLever);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    appender = new FileAppender(currentLayout, currentErrorLever, logFile);
                    break;
                default:
                    throw new InvalidOperationException("Invalid appender!");
            }

            return appender;
        }
    }
}
