namespace _13.LinkedListTraversal
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                if(command[0] == "Add")
                {
                    var number = int.Parse(command[1]);
                    linkedList.Add(number);
                }
                else if(command[0] == "Remove")
                {
                    var number = int.Parse(command[1]);
                    linkedList.Remove(number);
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}
