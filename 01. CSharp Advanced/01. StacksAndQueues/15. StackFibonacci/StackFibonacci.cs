using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var fibStack = new Stack<long>();
            var resultStack = new Stack<long>();

            var a = 0L;
            var b = 1L;
            var c = 0L;
            fibStack.Push(a);
            fibStack.Push(b);
            resultStack.Push(a);
            resultStack.Push(b);
            for (int i = 2; i <= n; i++)
            {
                c = a+b;
                resultStack.Push(c);        
                a = resultStack.Peek();
                b = fibStack.Peek();
                fibStack.Push(c);
            }

            Console.WriteLine(resultStack.Pop());
        }
    }
}
