namespace P05.Logger.Models.Appenders
{
    using P05.Logger.Enums;
    using P05.Logger.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.logFile = logFile;
            this.AppendedMessages = 0;
        }

        public ILayout Layout { get; }
        public ErrorLevel ErrorLevel { get; }
        public int AppendedMessages { get; private set; }

        public void Append(IError error)
        {
            this.AppendedMessages++;
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
        }

        public override string ToString()
        {
            var appenderType = this.GetType().Name;
            var layoutType = this.Layout.GetType().Name;
            var errorLevel = this.ErrorLevel.ToString();
            var countAppendedMessages = this.AppendedMessages;
            var fileSize = this.logFile.Size;

            return $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {errorLevel}, Messages appended: {countAppendedMessages}, File size: {fileSize}";
        }
    }
}
