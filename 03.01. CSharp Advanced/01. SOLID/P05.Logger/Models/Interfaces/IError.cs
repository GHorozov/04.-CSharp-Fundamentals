namespace P05.Logger.Models.Interfaces
{
    using P05.Logger.Enums;
    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel ErrorLevel { get; }
    }
}
