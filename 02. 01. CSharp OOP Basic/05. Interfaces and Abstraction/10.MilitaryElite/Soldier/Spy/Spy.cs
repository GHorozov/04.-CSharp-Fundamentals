using System.Text;

public class Spy : Soldier,ISpy
{
    public Spy(int id,string firstName, string lastName, int codeNumber)
        :base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Code Number: {CodeNumber}");

        return sb.ToString().TrimEnd();
    }
}

