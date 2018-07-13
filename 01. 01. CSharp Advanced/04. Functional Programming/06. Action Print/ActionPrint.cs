namespace _06._Action_Print
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ActionPrint
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = x => Console.WriteLine(x);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
