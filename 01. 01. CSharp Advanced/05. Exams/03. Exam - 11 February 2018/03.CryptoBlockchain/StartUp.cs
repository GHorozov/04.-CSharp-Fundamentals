namespace _03.CryptoBlockchain
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numbersOfRows = int.Parse(Console.ReadLine());
            var text = string.Empty;
            for (int i = 0; i < numbersOfRows; i++)
            {
                text += Console.ReadLine();
            }

            var patern = @"\{(?:[^\d\{\}\[\]]*)(?<numbers>[\d]{3,})(?:[^\{\}\[\]]*)}|\[(?:[^\d\[\]\{\}]*)(?<numbers>[\d]{3,})(?:[^\[\]\{\}]*)\]";
            var matches = Regex.Matches(text, patern);
            var sb = new StringBuilder();
            foreach(Match match in matches)
            {
                var currentBlock = match.Value;
                var numbersLength = match.Groups["numbers"].Value.Length;
                var numbers = match.Groups["numbers"].Value;

                if(currentBlock.Length == 0 || numbersLength % 3 != 0)
                {
                    continue;
                }

                for (int i = 0; i < numbersLength; i+=3)
                {
                    var threeNumbers = int.Parse(numbers.Substring(i, 3));
                    var letter = (char)(threeNumbers - currentBlock.Length);
                    sb.Append(letter);
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
