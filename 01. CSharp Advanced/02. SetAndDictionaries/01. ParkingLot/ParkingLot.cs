using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var carsLeft = new SortedSet<string>();

            while(input != "END")
            {
                var line = input.Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                var direcrion = line[0];
                var carNumber = line[1];

                if(direcrion == "IN")
                {
                    carsLeft.Add(carNumber);
                }
                else if(direcrion == "OUT")
                {
                    //if car number is in carsLeft.
                    if (carsLeft.Contains(carNumber))
                    {
                        carsLeft.Remove(carNumber);
                    }
                }

                input = Console.ReadLine();
            }

            if (carsLeft.Any())
            {
                Console.WriteLine(string.Join("\n", carsLeft));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
       }
    }
}
