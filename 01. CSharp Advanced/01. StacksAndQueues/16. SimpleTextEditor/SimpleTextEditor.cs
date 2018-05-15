using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            var text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var command = int.Parse(input[0]);

                if(command == 1)
                {
                    stack.Push(text);
                    var textToAdd = input[1];
                    text += textToAdd;
                }
                else if (command == 2)
                {
                    stack.Push(text);
                    var count = int.Parse(input[1]);
                    text = text.Substring(0, text.Length - count);
                }
                else if (command == 3)
                {
                    var index = int.Parse(input[1]);
                    Console.WriteLine(text[index-1]);
                }
                else if (command == 4)
                {
                    text = stack.Pop();
                }
            }
        }
    }
}
