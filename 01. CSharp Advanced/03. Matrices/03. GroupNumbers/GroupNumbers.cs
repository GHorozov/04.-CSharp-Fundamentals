using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupNumbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var zero = input.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            var one = input.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            var two = input.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));


            //II- longer way

            //var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //var sizes = new int[3];

            //foreach (var number in numbers)
            //{
            //    int reminder = Math.Abs(number % 3);
            //    sizes[reminder]++;
            //}

            //int[][] matrix = new int[3][]
            //{
            //    new int[sizes[0]],
            //    new int[sizes[1]],
            //    new int[sizes[2]],
            //};

            //var offset = new int[3];
            //foreach (var number in numbers)
            //{
            //    int reminder = Math.Abs(number % 3);
            //    int index = offset[reminder];
            //    offset[reminder]++;
            //    matrix[reminder][index] = number;
            //}


            //foreach (var row in matrix)
            //{
            //    Console.WriteLine(string.Join(" ", row));
            //}
        }
    }
}
