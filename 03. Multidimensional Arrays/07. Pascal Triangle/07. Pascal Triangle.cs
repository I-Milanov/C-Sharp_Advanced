/*7.	Pascal Triangle
The triangle may be constructed in the following manner: 
In row 0 (the topmost row), there is a unique nonzero entry 1. 
Each entry of each subsequent row is constructed by adding the number
above and to the left with the number above and to the right, treating blank entries as 0.
For example, the initial number in the first (or any other) row is 1 (the sum of 0 and 1),
whereas the numbers 1 and 3 in the third row are added to produce the number
4 in the fourth row.
If you want more info about it: https://en.wikipedia.org/wiki/Pascal's_triangle
Print each row elements separated with whitespace.
Hints
•	The input number n will be 1 <= n <= 60
•	Think about proper type for elements in array
•	Don’t be scary to use more and more arrays

*/
using System;
using System.Linq;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] pascal = new long[rows][];
            int cols = 1;
            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row] = new long[cols];
                pascal[row][0] = 1;
                pascal[row][pascal[row].Length - 1] = 1;
                if (row >1)
                {
                    for (int col = 1; col < pascal[row].Length - 1; col++)
                    {
                        long firstNum = pascal[row - 1][col];
                        long secondNum = pascal[row - 1][col-1];
                        pascal[row][col] = firstNum + secondNum;
                    }
                }
                cols++;
            }
            PrintJaggedArray(pascal, " ");

        }
        static int[][] ReadJaggedArray(int rows, string sepp)
        {
            int[][] matrix = new int[rows][];
            for (int row = 0; row < matrix.Length; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                matrix[row] = new int[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }
            return matrix;
        }
        static void PrintJaggedArray(long[][] matrix, string sepp)
        {
            foreach (var array in matrix)
            {
                Console.WriteLine(String.Join(sepp, array));
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
        static void PrintCharDuomatricMatrix(char[,] matrix)
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
                sumRow += matrix[rowNumber, col];
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
        static char[,] ReadCharDualmetricMatrix(int rows, int cols, string split)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().Split(split).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }

            }
            return matrix;
        }
        static int SumOfPrimaryDiagonal(int[,] matrix)
        {
            int sum = 0;
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, i];
                }
            }
            else
            {
                sum = 0;
            }
            return sum;
        }

    }
}
