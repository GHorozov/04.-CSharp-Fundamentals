using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ChampionsLeague
{
    class Score
    {
        public Score()
        {
            this.Wins = 0;
            this.Oponents = new List<string>();
        }

        public string TeamName { get; set; }
        public int Wins { get; set; }
        public List<string> Oponents { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- Wins: {this.Wins}");
            sb.AppendLine($"- Opponents: {string.Join(", ", this.Oponents.OrderBy(x =>x))}");

            return sb.ToString().Trim();
        }
    } 

    class ChampionsLeagueTask
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Score>();

            var input = Console.ReadLine();
            while (input != "stop")
            {
                var teams = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var team1 = teams[0].Trim();
                var team2 = teams[1].Trim();

                var teamsGoals = teams[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var team1Goals = int.Parse(teamsGoals[0]);
                var team2Goals = int.Parse(teamsGoals[1]);

                var teamsGoalsSecondMatch = teams[3].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var team2GoalsHome = int.Parse(teamsGoalsSecondMatch[0]);
                var team1GoalsAway = int.Parse(teamsGoalsSecondMatch[1]) ;

                var allTeam1Goals = team1Goals + team1GoalsAway;
                var allTeam2Goals = team2Goals + team2GoalsHome;

                

                if (allTeam1Goals > allTeam2Goals)
                {
                    AddTeamToDict(dict, team1, team2);
                    AddStatForTeam1(dict, team1, team2);
                }
                else if (allTeam1Goals < allTeam2Goals)
                {
                    AddTeamToDict(dict, team1, team2);
                    AddStatForTeam2(dict, team1, team2);
                }
                else
                {
                    AddTeamToDict(dict, team1, team2);

                    if(team2Goals < team1GoalsAway)
                    {
                        AddStatForTeam1(dict, team1, team2);
                    }
                    else
                    {
                        AddStatForTeam2(dict, team1, team2);
                    }
                   
                }

                input = Console.ReadLine();
            }


            foreach (var team in dict.OrderByDescending(w => w.Value.Wins).ThenBy(x => x.Key))
            {
                Console.WriteLine(team.Key);

                Console.WriteLine(team.Value.ToString());
            }
        }

        private static void AddStatForTeam2(Dictionary<string, Score> dict, string team1, string team2)
        {
            dict[team2].TeamName = team2;
            dict[team2].Wins++;
            dict[team2].Oponents.Add(team1);
            dict[team1].Oponents.Add(team2);
        }

        private static void AddStatForTeam1(Dictionary<string, Score> dict, string team1, string team2)
        {
            dict[team1].TeamName = team1;
            dict[team1].Wins++;
            dict[team1].Oponents.Add(team2);
            dict[team2].Oponents.Add(team1);
        }

        private static void AddTeamToDict(Dictionary<string, Score> dict, string team1, string team2)
        {
            if (!dict.ContainsKey(team1))
            {
                dict.Add(team1, new Score());
            }
            if (!dict.ContainsKey(team2))
            {
                dict.Add(team2, new Score());
            }
        }
    }
}
