namespace _03.TicketTrouble
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var location = Console.ReadLine();
            var text = Console.ReadLine();

            string pattern = @"((?<opener>\[)|{)(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)" + location +
                @"(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)(?<seat>[A-Z][0-9]{1,2})(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener)\]|})";
            var allMatches = Regex.Matches(text, pattern);

            var seats = allMatches.Select(x => x.Groups["seat"].Value).ToArray();

            if(seats.Length > 2)
            {
                seats = seats.GroupBy(s => s.Substring(1))
                    .Where(g => g.Count() > 1)
                    .Select(g => g.ToArray())
                    .First();
            }
            
            Console.WriteLine($"You are traveling to {location} on seats {seats[0]} and {seats[1]}.");
        }
    }
}
