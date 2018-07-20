namespace _04._Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Hospital
    {
        static void Main(string[] args)
        {
            var departmentPatients = new Dictionary<string, List<string>>();
            var doctorPatients = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                var lineParts = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var department = lineParts[0];
                var doctor = lineParts[1] + " " + lineParts[2];
                var patient = lineParts[3];

                if (!departmentPatients.ContainsKey(department))
                {
                    departmentPatients.Add(department, new List<string>());
                }

                if(departmentPatients[department].Count > 60)
                {
                    continue;
                }

                departmentPatients[department].Add(patient);

                if (!doctorPatients.ContainsKey(doctor))
                {
                    doctorPatients.Add(doctor, new List<string>());
                }

                doctorPatients[doctor].Add(patient);
            }


            string secondInput;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                var command = secondInput
                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                //Print department patients
                if (command.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departmentPatients[command[0]]));
                }
                else if (command.Length == 2)
                {
                    int number = 0;
                    if (int.TryParse(command[1], out number))
                    {
                        //print department patients in room number

                        var result = departmentPatients[command[0]].Take(number * 3).Skip((number - 1) * 3).ToArray();
                        Console.WriteLine(string.Join(Environment.NewLine, result.OrderBy(x => x)));
                    }
                    else
                    {
                        //print doctor patients
                        Console.WriteLine(string.Join(Environment.NewLine, doctorPatients[command[0] + " " + command[1]].OrderBy(x => x)));
                    }
                }

            }
        }
    }
}
