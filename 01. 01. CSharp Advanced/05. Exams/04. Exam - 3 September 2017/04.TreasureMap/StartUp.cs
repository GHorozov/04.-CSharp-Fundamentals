namespace _04.TreasureMap
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var mainPattern = @"[!#][^!#]{12,}[!#]";
            var streetNamePattern = @"[^0-9A-Za-z]+(?<name>[A-Za-z]{4})[^0-9A-Za-z]+";
            var streetNumberAndPasswordPattern = @"[^0-9]((?<number>[0-9]{3})-(?<password>[0-9]{6}|[0-9]{4}))[^0-9]";

            for (int i = 0; i < n; i++)
            {
                var text = Console.ReadLine();
                var matchesMain = Regex.Matches(text, mainPattern);

                if(matchesMain.Count > 0)
                {
                    var listOfValidMatches = new List<int>();

                    for (int j = 0; j < matchesMain.Count; j++)
                    {
                        var nameMatches = Regex.Matches(matchesMain[j].ToString(), streetNamePattern);
                        var numberAndPasswordMatches = Regex.Matches(matchesMain[j].ToString(), streetNumberAndPasswordPattern);

                        if (nameMatches.Count > 0 && numberAndPasswordMatches.Count > 0)
                        {
                            listOfValidMatches.Add(j);
                        }
                    }

                    if(listOfValidMatches.Count > 0)
                    {
                        var currentMatch = matchesMain[listOfValidMatches[listOfValidMatches.Count / 2]].ToString();
                        var streetName = Regex.Matches(currentMatch, streetNamePattern)[0].Groups["name"].ToString();
                        var numberMatches = Regex.Matches(currentMatch, streetNumberAndPasswordPattern);
                        var streetNumber = numberMatches[numberMatches.Count - 1].Groups["number"].ToString();
                        var password = numberMatches[numberMatches.Count - 1].Groups["password"].ToString();

                        Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
                    }
                }
            }
        }
    }
}
