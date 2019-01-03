namespace P05.Logger.Models.Appenders
{
    using P05.Logger.Enums;
    using P05.Logger.Models.Interfaces;
    using System;

    public class ConsoleAppender :IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.AppendedMessages = 0;
        }

        public ILayout Layout { get; }
        public ErrorLevel ErrorLevel { get; }
        public int AppendedMessages { get; private set; }

        public void Append(IError error)
        {
            this.AppendedMessages++;
            var formatedError = this.Layout.FormatError(error);
            Console.WriteLine(formatedError);
        }

        public override string ToString()
        {
            var appenderType = this.GetType().Name;
            var layoutType = this.Layout.GetType().Name;
            var errorLevel = this.ErrorLevel.ToString();
            var countAppendedMessages = this.AppendedMessages;

            return $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {errorLevel}, Messages appended: {countAppendedMessages}";
        }
    }
}
