using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CryptoMaster
{
    class CryptoMasterTask
    {
        static void Main(string[] args)
        {
            var sequance = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var longestSeqauance = int.MinValue;

            for (int i = 0; i < sequance.Length; i++)//all numbers
            {
                var currentNumberIndex = i;

                for (int j = 1; j <= sequance.Length; j++)//steps
                {
                    var step = j;
                    var currentNumber = sequance[i];
                    var indexOfNextNumber = (i + step) % sequance.Length;
                    var nextNumber = sequance[indexOfNextNumber];
                    var currentMaximum = 1;

                    while (currentNumber < nextNumber)
                    {
                        currentMaximum++;
                        currentNumberIndex = indexOfNextNumber;
                        indexOfNextNumber = (currentNumberIndex + step) % sequance.Length;
                        currentNumber = nextNumber;
                        nextNumber = sequance[indexOfNextNumber];
                    }


                    if (currentMaximum > longestSeqauance)
                    {
                        longestSeqauance = currentMaximum;
                    }
                }

            }

            Console.WriteLine(longestSeqauance);
        }
    }
}
