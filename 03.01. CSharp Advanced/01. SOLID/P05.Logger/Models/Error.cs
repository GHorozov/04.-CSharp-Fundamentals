namespace P05.Logger.Models
{
    using P05.Logger.Enums;
    using P05.Logger.Models.Interfaces;
    using System;

    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel error, string message)
        {
            this.DateTime = dateTime;
            this.ErrorLevel = error;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel ErrorLevel { get; }
    }
}
