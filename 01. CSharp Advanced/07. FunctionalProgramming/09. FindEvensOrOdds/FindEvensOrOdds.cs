using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
         {  //I-way
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var start = input[0];
            var end = input[1];
            var command = Console.ReadLine();

            var numbers = Enumerable.Range(start, end - start + 1).ToList();
            Predicate<int> isEven = n => n % 2 == 0;
            PrintNumbers(numbers, command, isEven);   



            //II-way
            //var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //var start = input[0];
            //var end = input[1];
            //var command = Console.ReadLine();

            //var numbers = new List<int>();
            //for (int i = start; i <= end; i++)
            //{
            //    numbers.Add(i);
            //}

            //var numberType = 0;
            //if (command == "odd")
            //{
            //    numberType = 1;
            //}

            //var finalResult = ReturnResultList(numbers, n => n % 2 == numberType || n % 2 == -1);

            //Console.WriteLine(string.Join(" ", finalResult));


            //III-way
            //// obtain list size
            //List<int> listSize =
            //    Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            //string option = Console.ReadLine();

            //long min = listSize.Min();
            //long max = listSize.Max();

            //List<long> list = new List<long>();

            //// list populate
            //for (long i = min; i <= max; i++)
            //{
            //    list.Add(i);
            //}

            //// declare predictate
            //Predicate<long> even = x => { return x % 2 == 0; };
            //Predicate<long> odd = x => { return x % 2 != 0; };

            ////output processing
            //List<long> result = new List<long>();
            //if (option == "odd")
            //{
            //    result = list.FindAll(odd);
            //}
            //else
            //{
            //    result = list.FindAll(even);
            //}

            //// result print
            //Console.WriteLine(string.Join(" ", result));
        }

        //For I-way.
        private static void PrintNumbers(List<int> numbers, string command, Predicate<int> isEven)
        {
            var result = new List<int>();
            foreach (var number in numbers)
            {            
                if(isEven(number) && command == "even")
                {
                    result.Add(number);
                }
                else if(!isEven(number) && command == "odd")
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        //For II-way.
        //private static List<int> ReturnResultList(List<int> numbers, Predicate<int> numberType)
        //{
        //    var listToReturn = new List<int>();
        //    for (int i = 0; i < numbers.Count; i++)
        //    {
        //        if (numberType(numbers[i]))
        //        {
        //            listToReturn.Add(numbers[i]);
        //        }
        //    }

        //    return listToReturn;
        //}
    }
}
