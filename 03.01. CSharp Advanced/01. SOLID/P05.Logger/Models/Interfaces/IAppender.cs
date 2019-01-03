namespace P05.Logger.Models.Interfaces
{
    using P05.Logger.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel ErrorLevel { get; }

        void Append(IError error);
    }
}
