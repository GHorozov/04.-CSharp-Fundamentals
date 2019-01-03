namespace P05.Logger.Models.Interfaces
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}