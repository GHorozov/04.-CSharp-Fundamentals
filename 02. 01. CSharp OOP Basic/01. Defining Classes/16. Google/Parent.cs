public class Parent
{
    public string parentName;
    public string parentBirthday;

    public Parent(string parentName, string parentBirthday)
    {
        this.parentName = parentName;
        this.parentBirthday = parentBirthday;
    }

    public override string ToString()
    {
        return $"{parentName} {parentBirthday}";
    }
}