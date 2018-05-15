using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(input, (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0) //Check x and y.If x is even and y is odd return -1;First even than odd
                {
                    return -1; //move even on left.
                }
                if (x % 2 != 0 && y % 2 == 0) // First odd than even.
                {
                    return 1; //move odd on right.
                }
                if(x > y)
                {
                    return 1; // move x on right.
                }
                if(x < y)
                {
                    return -1; //x stay where it is.
                }
                return 0; //Zero means that there is not way to error.
            });

            ////II-way
            //Array.Sort(input, (x, y) =>
            //{
            //    int a = (x % 2).CompareTo(y % 2);//first sort
            //    if (a == 0)
            //    {
            //        return x.CompareTo(y); //second sort
            //    }

            //    return a;
            //});

                Console.WriteLine(string.Join(" ", input));
        }
    }
}
