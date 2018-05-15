using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new char[matrixSize][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                matrix[row] = currentRow;
            }

            var max = int.MinValue;
            var r = 0;
            var c = 0;
            var count = 0;
            
            var hit = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                   
                   if(matrix[row][col] == 'K')
                    {
                        hit = 0;

                        if (row-2 >= 0)
                        {
                            if(col+1 < matrixSize)
                            {
                                if (matrix[row - 2][col + 1] == 'K')
                                {
                                    hit++;
                                }
                               
                            }
                            if(col - 1 >= 0)
                            {
                                if(matrix[row-2][col-1] == 'K')
                                {
                                    hit++;
                                }
                            }
                        }

                        if(row +2 < matrixSize)
                        {
                            if(col+1 < matrixSize)
                            {
                                if(matrix[row+2][col+1] == 'K')
                                {
                                    hit++;
                                }
                            }
                            if(col -1 >= 0)
                            {
                                if (matrix[row + 2][col - 1] == 'K')
                                {
                                    hit++;
                                }
                            }
                        }

                        if(col -2 >= 0)
                        {
                            if (row - 1 >= 0)
                            {
                                if (matrix[row -1][col -2] == 'K')
                                {
                                    hit++;
                                }
                            }
                            if (row + 1 < matrixSize)
                            {
                                if (matrix[row + 1][col - 2] == 'K')
                                {
                                    hit++;
                                }
                            }
                        }
                        if(col+2 < matrixSize)
                        {
                            if (row + 1 < matrixSize)
                            {
                                if (matrix[row + 1][col + 2] == 'K')
                                {
                                    hit++;
                                }
                            }
                            if (row - 1 >= 0)
                            {
                                if (matrix[row - 1][col +2] == 'K')
                                {
                                    hit++;
                                }
                            }   
                        }

                        if(hit > max)
                        {
                            max = hit;
                            r = row;
                            c = col;
                           
                        }
                        count++;
                    }
                    
                }

                Console.WriteLine();
            }

            matrix[r][c] = '0';

            Console.WriteLine(1);

        }
    }
}
