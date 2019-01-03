using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        var type = Type.GetType(className);
        MethodInfo[] allMethods = type.GetMethods(
            BindingFlags.Static | BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.NonPublic);

        var sb = new StringBuilder();
        foreach (var method in allMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (var method in allMethods.Where(x => x.Name.StartsWith("set")))
        {
            var parameterType = method.GetParameters().First().ParameterType;
            sb.AppendLine($"{method.Name} will set field of {parameterType}");
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        var type = Type.GetType(className);
        MethodInfo[] allPrivateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");
        foreach (var method in allPrivateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var type = Type.GetType(className);

        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var method in privateMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }
        foreach (var method in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }

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

