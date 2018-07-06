namespace _03._Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class WordCount
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReaderText = new StreamReader("text.txt"))
            {
                using (StreamReader streamReaderWords = new StreamReader("words.txt"))
                {
                    using (StreamWriter streamWriter = new StreamWriter("result.txt"))
                    {
                        var wordsToSearch = streamReaderWords
                            .ReadToEnd()
                            .Split(new[] {'\n',' ', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                        var wordsFromText = streamReaderText
                            .ReadToEnd()
                            .Split(new[] { ' ', '-', '.', ',', '?', '!', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray(); ;
                        


                        var wordsAndCount = new Dictionary<string, int>();
                        foreach (var wordWords in wordsToSearch)
                        {
                            var count = 0;

                            foreach (var wordText in wordsFromText)
                            {
                                if(string.Equals(wordWords, wordText, StringComparison.OrdinalIgnoreCase))
                                {
                                    count++;
                                }
                            }

                            wordsAndCount[wordWords] = count; 
                        }


                        var result = wordsAndCount
                            .OrderByDescending(x => x.Value)
                            .ToArray();

                        foreach (var word in result)
                        {
                            streamWriter.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}
