namespace P05.Logger.Models
{
    using System;
    using P05.Logger.Models.Interfaces;
    using System.Collections.Generic;

    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if(appender.ErrorLevel <= error.ErrorLevel)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
