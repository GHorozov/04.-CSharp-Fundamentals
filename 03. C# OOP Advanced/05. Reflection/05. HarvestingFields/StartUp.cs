using _01HarestingFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        Type classType = typeof(HarvestingFields);
        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

        FieldInfo[] fieldByType = null;
        string input;
        while((input = Console.ReadLine()) != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    fieldByType = classFields.Where(f => f.IsPrivate).ToArray();
                    break;
                case "public":
                    fieldByType = classFields.Where(f => f.IsPublic).ToArray();
                    break;
                case "protected":
                    fieldByType = classFields.Where(f => f.IsFamily).ToArray();
                    break;
                case "all":
                    fieldByType = classFields;
                    break;
                default:
                    fieldByType = null;
                    break;
            }

            string[] result = fieldByType
                .Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}").ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
        }
    }
}
