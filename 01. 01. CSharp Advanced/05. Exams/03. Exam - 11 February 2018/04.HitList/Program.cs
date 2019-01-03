namespace _04.HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Person
    {
        public string name;
        public Dictionary<string, string> personalInfo;

        public Person(string name)
        {
            this.name = name;
            this.personalInfo = new Dictionary<string, string>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var targetInfoIndex = int.Parse(Console.ReadLine());
            var listOfPeople = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "end transmissions")
            {
                var lineArgs = command.Split("=");
                var name = lineArgs[0];
                var infoArgs = lineArgs[1].Split(";");

                var person = listOfPeople.FirstOrDefault(x => x.name == name);
                if (person == null)
                {
                    var newPerson = new Person(name);

                    foreach (var info in infoArgs)
                    {
                        var details = info.Split(":");
                        var detailName = details[0];
                        var detailAttr = details[1];
                        newPerson.personalInfo.Add(detailName, detailAttr);
                    }

                    listOfPeople.Add(newPerson);
                }
                else
                {
                    foreach (var info in infoArgs)
                    {
                        var details = info.Split(":");
                        var detailName = details[0];
                        var detailAttr = details[1];

                        if (person.personalInfo.ContainsKey(detailName))
                        {
                            person.personalInfo[detailName] = detailAttr;
                        }
                        else
                        {
                            person.personalInfo.Add(detailName, detailAttr);
                        }
                    }
                }
            }

            var inputCommand = Console.ReadLine().Split(" ");
            var targetName = inputCommand[1];

            var target = listOfPeople.Single(x => x.name == targetName);
            var keysLength = target.personalInfo.Keys.Sum(x => x.Length);
            var valuesLength = target.personalInfo.Values.Sum(x => x.Length);
            var infoIndex = keysLength + valuesLength;

            Console.WriteLine($"Info on {target.name}:");
            foreach (var item in target.personalInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{item.Key}: {item.Value}");
            }
            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                var infoNeeded = targetInfoIndex - infoIndex;
                Console.WriteLine($"Need {infoNeeded} more info.");
            }
        }
    }
}
