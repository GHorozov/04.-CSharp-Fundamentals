using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hospital
{
    class Room
    {
        public Room(string patient)
        {
            this.Parients = new List<string>();
            this.Parients.Add(patient);
        }
        public List<string> Parients { get; set; }
    }

    class HospitalTask
    {
        static void Main(string[] args)
        {
            var depPatients = new Dictionary<string, List<string>>();
            var docPatients = new Dictionary<string, List<string>>();
            var depRooms = new Dictionary<string, List<string>>();

            var input = Console.ReadLine();
            while (input != "Output")
            {
                var line = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var department = line[0];
                var doctor = line[1] + " " + line[2];
                var patient = line[3];

                if (!depPatients.ContainsKey(department))
                {
                    depPatients[department] = new List<string>();
                }
                depPatients[department].Add(patient);

                if (!docPatients.ContainsKey(doctor))
                {
                    docPatients[doctor] = new List<string>();
                }
                docPatients[doctor].Add(patient);

                if (!depRooms.ContainsKey(department))
                {
                    depRooms[department] = new List<string>();
                }
                if (depRooms[department].Count < 20)
                {
                    depRooms[department].Add(patient);
                }

                input = Console.ReadLine();
            }


            var inputCommand = Console.ReadLine();
            while (inputCommand != "End")
            {
                var lookFor = inputCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var room = 0;
                if (lookFor.Length == 1) //department
                {
                    foreach (var dep in depPatients)
                    {
                        if (dep.Key == lookFor[0])
                        {
                            foreach (var patient in dep.Value)
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
                else if (lookFor.Length == 2 && int.TryParse(lookFor[1], out room)) //department room
                {
                    var departmentName = lookFor[0];
                    var roomNumber = int.Parse(lookFor[1]);

                    foreach (var dep in depRooms)
                    {
                        if (dep.Key == departmentName)
                        {
                            //var takeRoomPatients = dep.Value
                            //        .GetRange(((roomNumber - 1) * 3), 3)
                            //        .OrderBy(x => x)
                            //        .ToList();

                            var firstList = dep.Value;
                            var result = new List<string>();

                            for (int i = roomNumber * 3 - 1; i >= roomNumber * 3 - 3; i--)
                            {
                                if (firstList[i] != null)
                                {
                                    result.Add(firstList[i]);
                                }
                            }

                            foreach (var patient in result.OrderBy(x => x))
                            {
                                if (patient != string.Empty)
                                {
                                    Console.WriteLine(patient);
                                }
                            }
                        }
                    }
                }
                else //doctor
                {
                    foreach (var doc in docPatients)
                    {
                        if (doc.Key == (lookFor[0] + " " + lookFor[1]))
                        {
                            foreach (var patient in doc.Value.OrderBy(x => x))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }

                inputCommand = Console.ReadLine();
            }

        }
    }
}
