using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string name, params string[] fieldsNames)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {name}");

        var type = Type.GetType(name);
        var allFields = type.GetFields(
            BindingFlags.Static | BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.NonPublic);

        Object instanceHackerClass = Activator.CreateInstance(type); 
        foreach (FieldInfo field in allFields)
        {
            if (fieldsNames.Contains(field.Name))
            {
                var fieldName = field.Name;
                var fieldValue = field.GetValue(instanceHackerClass);
                sb.AppendLine($"{fieldName} = {fieldValue}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}

