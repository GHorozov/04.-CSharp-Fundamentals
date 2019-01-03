using _06.CodeTracker;
using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        MethodInfo[] allMethods = type.GetMethods(
            BindingFlags.Static | BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in allMethods)
        {
            if(method.CustomAttributes.Any(x => x.AttributeType == typeof(SoftUniAttribute)))
            {
                var allAttributes = method.GetCustomAttributes(false); 
                foreach (SoftUniAttribute attribute in allAttributes)
                {
                    Console.WriteLine($"{method.Name} is writen by {attribute.Name}");
                }
            }
        }
    }
}

