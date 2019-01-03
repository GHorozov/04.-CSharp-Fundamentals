namespace _02.Task
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "Report")
            {
                var pattern = @",[A-Za-z]+\d|_[A-Za-z]+\d";
                var matches = Regex.Matches(input, pattern);

                var result = string.Empty;
                foreach (var word in matches)
                {
                    var currentWord = word.ToString().Substring(0, word.ToString().Length-1);
                    var digit = int.Parse(word.ToString().Substring(word.ToString().Length - 1));
                    //add
                    if (word.ToString().StartsWith(",")) 
                    {
                        var resultWord = string.Empty;
                        for (int i = 0; i < currentWord.Length; i++)
                        {
                            if(i == 0)
                            {
                                continue;
                            }
                            resultWord += (char)((int)currentWord[i] + digit);
                        }

                        result += resultWord + " ";
                    }
                    else if (word.ToString().StartsWith("_")) //substract
                    {
                        var resultWord = string.Empty;
                        for (int i = 0; i < currentWord.Length; i++)
                        {
                            if (i == 0)
                            {
                                continue;
                            }
                            resultWord += (char)((int)currentWord[i] - digit);
                        }
                        
                        result += resultWord + " ";
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}
