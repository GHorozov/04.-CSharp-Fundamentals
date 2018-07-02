namespace _16._Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var arguments = Console.ReadLine().Split();
                var command = int.Parse(arguments[0]);

                switch (command)
                {
                    case 1:
                        stack.Push(sb.ToString());
                        var str = arguments[1];
                        sb.Append(str);
                        break;
                    case 2:
                        stack.Push(sb.ToString());
                        var count = int.Parse(arguments[1]);
                        sb.Remove(sb.Length - count, count);
                        break;
                    case 3:
                        var index = int.Parse(arguments[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;
                    case 4:
                        sb.Clear();
                        sb.Append(stack.Pop());
                        break;
                }
            }
        }
    }
}

