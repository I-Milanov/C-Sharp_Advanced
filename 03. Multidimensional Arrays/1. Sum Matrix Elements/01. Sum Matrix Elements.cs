/*01.	Sum Matrix Elements
Write program that reads a matrix from the console and print:
•	Count of rows
•	Count of columns
•	Sum of all matrix elements
On first line you will get matrix sizes in format [rows, columns]
Hints
•	On next [rows] lines you will get elements for each column separated
with coma and whitespace
•	Try to use only foreach for printing

 */
using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }

            }
            Console.WriteLine(SumDuomatricMatrix(matrix));

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
    }
}
