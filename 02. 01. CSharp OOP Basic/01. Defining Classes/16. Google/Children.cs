public class Children
{
    public string childrenName;
    public string childrenBirthday;

    public Children(string childrenName, string childrenBirthday)
    {
        this.childrenName = childrenName;
        this.childrenBirthday = childrenBirthday;
    }

    public override string ToString()
    {
        return $"{childrenName} {childrenBirthday}";
    }
}