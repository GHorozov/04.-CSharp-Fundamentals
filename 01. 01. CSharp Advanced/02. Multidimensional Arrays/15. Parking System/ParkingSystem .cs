namespace _15._Parking_System
{
    using System;
    using System.Linq;

    class ParkingSystem
    {
        static void Main(string[] args)
        {
            var demensions = Console.ReadLine().Split().ToArray();
            var rowsNumber = int.Parse(demensions[0]);
            var colsNumber = int.Parse(demensions[1]);
            var matrix = new int[rowsNumber][];

            var input = Console.ReadLine();
            while (input != "stop")
            {
                var parts = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var entryRow = parts[0];
                var parkingRow = parts[1];
                var parkingCol = parts[2];
                var counter = 0;

                if(matrix[parkingRow] == null)
                {
                    matrix[parkingRow] = new int[colsNumber]; 
                }

                if(matrix[parkingRow].Skip(1).All(x => x == 1))
                {
                    Console.WriteLine($"Row {parkingRow} full");
                    input = Console.ReadLine();
                    continue;
                }

                if(matrix[parkingRow][parkingCol] == 1)
                {
                    for (int col = 1; col < colsNumber; col++)
                    {
                        if(parkingCol > col &&  matrix[parkingRow][parkingCol - col] == 0)
                        {
                            parkingCol = parkingCol - col; break;
                        }

                        if(parkingCol + col < colsNumber && matrix[parkingRow][parkingCol + col] == 0)
                        {
                            parkingCol = parkingCol + col; break;
                        }
                    }
                }

                matrix[parkingRow][parkingCol] = 1;

                counter = Math.Abs(entryRow - parkingRow) + 1 + parkingCol;
                Console.WriteLine(counter);

                input = Console.ReadLine();
            }      
        }
    }
}
