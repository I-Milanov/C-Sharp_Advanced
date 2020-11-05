/*02.	Sum Matrix Columns
Write program that read a matrix from console and print the sum for each column. 
On first line you will get matrix rows. On the next rows lines, you will get elements 
for each column separated with a space. 
Hints
•	Read matrix sizes.
•	On the next row lines read the columns.
•	Traverse the matrix and sum all elements in each column.
•	Print the sum and continue with the other columns.
*/
using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = ReadDualmetricMatrix(size[0], size[1]," ");

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.WriteLine(SumColumnDuomatricMatrix(matrix, col));
            }


        }
        static void PrintDuomatricMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        static int SumDuomatricMatrix(int[,] matrix)
        {
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }
            return sum;
        }
        static int SumColumnDuomatricMatrix(int[,] matrix, int colNumber)
        {
            int sumCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumCol += matrix[row, colNumber];
            }

            return sumCol;
        }
        static int SumRowDuomatricMatrix(int[,] matrix, int rowNumber)
        {
            int sumRow = 0;

            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                sumRow += matrix[rowNumber,col];
            }

            return sumRow;
        }
        static int[,] ReadDualmetricMatrix(int rows, int cols, string split)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(split).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }

            }
            return matrix;
        }
    }

}
