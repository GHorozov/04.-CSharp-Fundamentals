namespace _10.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();
            string commandInput;
            while ((commandInput = Console.ReadLine()) != "END")
            {
                var lineParts = commandInput.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = lineParts[0];
                var teamName = lineParts[1];
                switch (command)
                {
                    case "Team":
                        try
                        {
                            teams.Add(new Team(teamName));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Add":
                        if (!teams.Any(x => x.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            var name = lineParts[2];
                            var endurande = double.Parse(lineParts[3]);
                            var sprint = double.Parse(lineParts[4]);
                            var drobble = double.Parse(lineParts[5]);
                            var passing = double.Parse(lineParts[6]);
                            var shooting = double.Parse(lineParts[7]);

                            var currentTeamToAdd = teams.FirstOrDefault(x => x.Name == teamName);
                            try
                            {
                                currentTeamToAdd.AddPlayer(new Player(name, endurande, sprint, drobble, passing, shooting));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                        break;
                    case "Remove":
                        var playerName = lineParts[2];
                        var currentTeamToRemove = teams.FirstOrDefault(x => x.Name == teamName);
                        try
                        {
                            currentTeamToRemove.RemovePlayer(playerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "Rating":
                        if (!teams.Any(x => x.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            var currentTeamReating = teams.FirstOrDefault(x => x.Name == teamName);
                            Console.WriteLine($"{teamName} - {currentTeamReating.Rating}");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
