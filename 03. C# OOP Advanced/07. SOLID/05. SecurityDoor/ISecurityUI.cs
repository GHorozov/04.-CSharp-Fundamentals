using _05.SecurityDoor;

namespace _05.Security_Door
{
    public interface ISecurityUI : IkeyCardUI, IPinCodeUI
    {
        string RequestKeyCard();
    }
}