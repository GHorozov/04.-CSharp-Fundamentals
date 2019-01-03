namespace _10.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            var privatesList = new List<Private>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                ParseInput(soldiers, privatesList, input);
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }

        private static void ParseInput(List<ISoldier> soldiers, List<Private> privatesList, string input)
        {
            var lineArgs = input.Split();
            var rank = lineArgs[0];
            var id = int.Parse(lineArgs[1]);
            var firstName = lineArgs[2];
            var lastName = lineArgs[3];
            switch (rank)
            {
                case "Private":
                    var salary = double.Parse(lineArgs[4]);
                    var soldierPrivate = new Private(id, firstName, lastName, salary);
                    soldiers.Add(soldierPrivate);
                    privatesList.Add(soldierPrivate);
                    break;
                case "LeutenantGeneral":
                    var generalSalary = double.Parse(lineArgs[4]);
                    var inputPrivatesListIds = lineArgs.Skip(5).Select(int.Parse).ToArray();
                    var allPrivatesList = new List<Private>();
                    foreach (var privateId in inputPrivatesListIds)
                    {
                        var currentPrivate = privatesList.FirstOrDefault(x => x.Id == privateId);

                        if (currentPrivate != null)
                        {
                            allPrivatesList.Add(currentPrivate);
                        }
                    }
                    var soldierLeitenantGeneral = new LeutenantGeneral(id, firstName, lastName, generalSalary, allPrivatesList);
                    soldiers.Add(soldierLeitenantGeneral);
                    break;
                case "Engineer":
                    var engineerSalary = double.Parse(lineArgs[4]);
                    var engineerCorps = lineArgs[5];
                    var repairsList = lineArgs.Skip(6).ToArray();
                    var listAllRepairs = new List<Repair>();
                    for (int i = 0; i < repairsList.Length; i++)
                    {
                        var partName = repairsList[i];
                        i++;
                        var hoursWorked = int.Parse(repairsList[i]);
                        try
                        {
                            listAllRepairs.Add(new Repair(partName, hoursWorked));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    var soldierEngineer = new Engineer(id, firstName, lastName, engineerSalary, engineerCorps, listAllRepairs);
                    soldiers.Add(soldierEngineer);
                    break;
                case "Commando":
                    var commandoSalary = double.Parse(lineArgs[4]);
                    var commandoCorps = lineArgs[5];
                    var missionsList = lineArgs.Skip(6).ToArray();
                    var listAllMissions = new List<Mission>();
                    for (int i = 0; i < missionsList.Length; i++)
                    {
                        var missionCodeName = missionsList[i];
                        i++;
                        var missionState = missionsList[i];
                        try
                        {
                            listAllMissions.Add(new Mission(missionCodeName, missionState));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    var soldierCommando = new Commando(id, firstName, lastName, commandoSalary, commandoCorps, listAllMissions);
                    soldiers.Add(soldierCommando);
                    break;
                case "Spy":
                    var codeNumber = int.Parse(lineArgs[4]);
                    var soldierSpy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(soldierSpy);
                    break;
                default:
                    break;
            }
        }
    }
}
