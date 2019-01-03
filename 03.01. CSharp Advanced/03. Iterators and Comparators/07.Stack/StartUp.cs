namespace _07.StackTask
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = null;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var lineParts = input.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = lineParts[0];

                switch (command)
                {
                    case "Push":
                        var elements = lineParts.Skip(1).ToArray();
                        if (stack == null)
                        {
                           stack = new Stack<string>(elements);
                        }
                        else
                        {
                            stack.Push(elements);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
