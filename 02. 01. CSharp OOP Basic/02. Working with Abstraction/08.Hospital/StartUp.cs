namespace _08.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> doktors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                ProccessLine(doktors, departments, command);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                PrintResult(doktors, departments, command);
                command = Console.ReadLine();
            }
        }

        private static void PrintResult(Dictionary<string, List<string>> doktors, Dictionary<string, List<List<string>>> departments, string command)
        {
            var lineParams = command.Split();

            if (lineParams.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[lineParams[0]]
                    .Where(x => x.Count > 0)
                    .SelectMany(x => x)));
            }
            else if (lineParams.Length == 2 && int.TryParse(lineParams[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[lineParams[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doktors[lineParams[0] + lineParams[1]].OrderBy(x => x)));
            }
        }

        private static void ProccessLine(Dictionary<string, List<string>> doktors, Dictionary<string, List<List<string>>> departments, string command)
        {
            string[] lineParts = command.Split();
            var departament = lineParts[0];
            var doctorName = lineParts[1] + lineParts[2];
            var patient = lineParts[3];


            if (!doktors.ContainsKey(doctorName))
            {
                doktors[doctorName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }

            bool hasSpace = departments[departament].SelectMany(x => x).Count() < 60;
            if (hasSpace)
            {
                int room = 0;
                doktors[doctorName].Add(patient);
                for (int i = 0; i < departments[departament].Count; i++)
                {
                    if (departments[departament][i].Count < 3)
                    {
                        room = i;
                        break;
                    }
                }
                departments[departament][room].Add(patient);
            }
        }
    }
}
