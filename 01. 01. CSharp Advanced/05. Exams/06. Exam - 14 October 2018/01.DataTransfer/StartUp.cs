namespace _01.DataTransfer
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var totalData = 0;
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var pattern = @"^s:(?<sender>[^;]+);r:(?<receiver>[^:]+);m--""(?<message>[A-Za-z\s]+)""$";
                var match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    var sender = match.Groups["sender"].Value;
                    var receiver = match.Groups["receiver"].Value;
                    var message = match.Groups["message"].Value;

                    var senderMatch = Regex.Matches(sender, @"[A-Za-z\s]+");
                    var senderName = string.Empty;
                    foreach (Match item in senderMatch)
                    {
                        senderName += item.Value;
                    }
                    var receiverMatch = Regex.Matches(receiver, @"[A-Za-z\s]+");
                    var receiverName = string.Empty;
                    foreach (Match item in receiverMatch)
                    {
                        receiverName += item.Value;
                    }

                    totalData += GetSum(sender);
                    totalData += GetSum(receiver);

                    sb.AppendLine($@"{senderName} says ""{message}"" to {receiverName}");
                }
            }

            sb.AppendLine($"Total data transferred: {totalData}MB");

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static int GetSum(string input)
        {
            var sum = 0;

            var matches = Regex.Matches(input, @"\d");
            foreach (Match item in matches)
            {
                sum += int.Parse(item.Value);
            }

            return sum;
        }
    }
}
