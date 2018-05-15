using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stat = new Dictionary<string, Dictionary<string, List<string>>();
            
            

            var count = 0;
            while (input != "Output")
            {
                var line = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var department = line[0];
                var doctor = line[1] + " " + line[2];
                var patient = line[3];


                if (!stat.ContainsKey(department))
                {
                    stat[department] = new Dictionary<string, List<string>>();
                }
                if (!stat[department].ContainsKey(doctor))
                {
                    stat[department][doctor] = new List<string>();
                }

                stat[department][doctor].Add(patient);
               
                input = Console.ReadLine();
            }

            var command = Console.ReadLine();



            if (stat.ContainsKey(command))
            {
                foreach (var department in stat.Take(3))
                {
                    Console.WriteLine($"{string.Join("\n", department.Value)}");
                }
            }
            else if (stat.ContainsKey(command))
            {
                foreach (var doctor in stat.OrderBy(x => x.Value))
                {
                    Console.WriteLine($"{string.Join("\n", doctor.Value)}");
                }
            }
            else if (stat.ContainsKey(command))
            {
                // var pac = int.Parse(command[1]);

                //foreach (var item in departmentPacients.Take(3*pac))
                //{
                //    Console.WriteLine($"{item.Value}");
                //}
            }

        }
    }
}
