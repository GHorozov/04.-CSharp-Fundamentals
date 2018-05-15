using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] fields)
    {
        var getClass = Type.GetType(investigatedClass);
        var classFields = getClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                             BindingFlags.NonPublic);

        var sb = new StringBuilder();
        var classIstance = Activator.CreateInstance(getClass, new object[] { });

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var fied in classFields.Where(f => fields.Contains(f.Name)))
        {
            sb.AppendLine($"{fied.Name} = {fied.GetValue(classIstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        foreach (FieldInfo f in classFields)
        {
            sb.AppendLine($"{f.Name} must be private!");
        }

        foreach (MethodInfo m in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{m.Name} have to be public!");
        }

        foreach (MethodInfo m in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{m.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}

