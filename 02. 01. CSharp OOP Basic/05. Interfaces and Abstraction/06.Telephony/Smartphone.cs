public class Smartphone : ICallable, IBrowseble
{
    public string Call(string number)
    {
        return $"Calling... {number}";
    }

    public string Browse(string address)
    {
        return $"Browsing: {address}!";
    }
}

