 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var type = typeof(HarvestingFields);
            FieldInfo[] allFields = type.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                var command = input;
                
                switch (command)
                {
                    case "private":
                        foreach (var field in allFields.Where(x => x.IsPrivate))
                        {
                            sb.AppendLine($"private {field.FieldType.Name} {field.Name}");
                        }
                        break;
                    case "protected":
                        foreach (var field in allFields.Where(x => x.IsFamily))
                        {
                            sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                        break;
                    case "public":
                        foreach (var field in allFields.Where(x => x.IsPublic))
                        {
                            sb.AppendLine($"public {field.FieldType.Name} {field.Name}");
                        }
                        break;
                    case "all":
                        foreach (var field in allFields)
                        {
                            if (field.IsPrivate)
                            {
                                sb.AppendLine($"private {field.FieldType.Name} {field.Name}");
                            }
                            else if (field.IsFamily)
                            {
                                sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
                            }
                            else if (field.IsPublic)
                            {
                                sb.AppendLine($"public {field.FieldType.Name} {field.Name}");
                            }
                        }
                        break;
                    default:
                        throw new InvalidOperationException("Invalid input!Try again.");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
