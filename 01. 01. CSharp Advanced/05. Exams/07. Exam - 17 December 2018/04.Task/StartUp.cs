namespace _04.Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var knives = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var forks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            var maxSet = 0;
            var sets = new Queue<int>();
            while (true)
            {
                if(knives.Count == 0 || forks.Count == 0)
                {
                    break;
                }

                var knive = knives.Peek();
                var fork = forks.Peek();

                if(knive > fork)
                {
                    var set = forks.Dequeue() + knives.Pop();
                    sets.Enqueue(set);
                    if(set > maxSet)
                    {
                        maxSet = set;
                    }
                }
                else if(knive < fork)
                {
                    knives.Pop();

                }
                else if(knive == fork)
                {
                    forks.Dequeue();
                    var incresedKnive = knives.Pop() + 1;
                    knives.Push(incresedKnive);
                }
            }

            Console.WriteLine($"The biggest set is: {maxSet}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
