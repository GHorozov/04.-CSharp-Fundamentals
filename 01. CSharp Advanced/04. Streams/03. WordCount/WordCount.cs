using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            using (StreamReader readerWords= new StreamReader("../../words.txt"))
            {
                using (StreamReader readerText = new StreamReader("../../text.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("result.txt"))
                    {
                        var inputWords = readerWords.ReadToEnd().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var splitText = readerText.ReadToEnd().ToLower().Split(new char[] { ' ', '-', '.', ',', '?', '!','\r','\n' }, StringSplitOptions.RemoveEmptyEntries);

                        var result = new Dictionary<string, int>();
                        for (int i = 0; i < inputWords.Length; i++)
                        {
                            var currentWord = inputWords[i];
                            var count = 0;
                            for (int j = 0; j < splitText.Length; j++)
                            {
                                if(currentWord == splitText[j])
                                {
                                    count++;
                                }
                            }

                            result[currentWord] = count;
                        }

                        var orderedResult = result.OrderByDescending(x => x.Value).Select(x => $"{x.Key} - {x.Value}").ToArray();

                        foreach (var entry in orderedResult)
                        {
                            writer.WriteLine(entry);
                        }
                    }
                }
            }
        }
    }
}
