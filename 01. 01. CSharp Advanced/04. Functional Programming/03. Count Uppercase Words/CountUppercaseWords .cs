namespace _03._Count_Uppercase_Words
{
    using System;
    using System.Linq;

    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> wordsFilter = (word) => char.IsUpper(word[0]);

            var text = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(wordsFilter)
                .ToArray();

            foreach (var word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}
