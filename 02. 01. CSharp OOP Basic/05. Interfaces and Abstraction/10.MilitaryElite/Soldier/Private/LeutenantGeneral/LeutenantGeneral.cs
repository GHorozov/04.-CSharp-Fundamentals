using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LeutenantGeneral: Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary, List<Private> privates)
        :base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public List<Private> Privates { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");
        foreach (var man in Privates)
        {
            sb.AppendLine($"  {man.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}

