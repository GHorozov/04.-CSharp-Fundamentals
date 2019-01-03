namespace _03.CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();

            while (true)
            {
                var encryptedLine = Console.ReadLine();
                if (encryptedLine == "Over!") break;
                var number = int.Parse(Console.ReadLine());
               
                var pattern = @"^(?<code>[0-9]+)(?<message>[A-Za-z]+)(?<rest>[^A-Za-z]*?)$";
                var regex = Regex.Match(encryptedLine, pattern);
                var message = regex.Groups["message"].Value;

                if (regex.Success && message.Length == number)
                {
                    var code = regex.Groups["code"].Value;
                    var rest = regex.Groups["rest"].Value;

                    sb.Append($"{message} == ");
                    for (int i = 0; i < code.Length; i++)
                    {
                        var currentDigit = int.Parse(code[i].ToString());
                        if (currentDigit < message.Length)
                        {
                            sb.Append(message[currentDigit]);
                        }
                        else
                        {
                            sb.Append(" ");
                            
                        }
                    }

                    var rightDigits = TakeDigits(rest);

                    foreach (var num in rightDigits)
                    {
                        if (num < message.Length)
                        {
                            sb.Append(message[num]);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    sb.AppendLine();
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static List<int> TakeDigits(string rest)
        {
            var list = new List<int>();
            foreach (var item in rest)
            {
                var num = 0;
                if(int.TryParse(item.ToString(), out num))
                {
                    list.Add(num);
                }
            }

            return list;
        }
    }
}
