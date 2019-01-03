namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var type = typeof(BlackBoxInteger);
            var box = (BlackBoxInteger)Activator.CreateInstance(type, true);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var lineArgs = input.Split("_");
                var command = lineArgs[0];
                var number = int.Parse(lineArgs[1]);

                switch (command)
                {
                    case "Add":
                        methods.FirstOrDefault(x => x.Name == "Add").Invoke(box, new object[] { number });
                        break;
                    case "Subtract":
                        methods.FirstOrDefault(x => x.Name == "Subtract").Invoke(box, new object[] { number });
                        break;
                    case "Divide":
                        methods.FirstOrDefault(x => x.Name == "Divide").Invoke(box, new object[] { number });
                        break;
                    case "Multiply":
                        methods.FirstOrDefault(x => x.Name == "Multiply").Invoke(box, new object[] { number });
                        break;
                    case "RightShift":
                        methods.FirstOrDefault(x => x.Name == "RightShift").Invoke(box, new object[] { number });
                        break;
                    case "LeftShift":
                        methods.FirstOrDefault(x => x.Name == "LeftShift").Invoke(box, new object[] { number });

                        break;
                }

                var currentResult = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(x => x.Name == "innerValue").GetValue(box);
                    
                sb.AppendLine(currentResult.ToString());
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
