/*01.	Diagonal Difference
Write a program that finds the difference between the sums of the square matrix diagonals
(absolute value).
Input
•	On the first line, you are given the integer N – the size of the square matrix
•	The next N lines holds the values for every row – N numbers separated by a space
Output
•	Print the absolute difference between the sums of the primary and the secondary diagonal

Examples
Input:	
3
11 2 4
4 5 6
10 8 -12	

Output:
15	

Comments
Primary diagonal: sum = 11 + 5 + (-12) = 4
Secondary diagonal: sum = 4 + 5 + 10 = 19
Difference: |4 - 19| = 15
*/
using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[,] matrix = ReadDualmetricMatrix(N, N, " ");
            int primaryDiag = SumOfPrimaryOrSecondaryDiagonal(matrix);
            int secondDiag = SumOfPrimaryOrSecondaryDiagonal(matrix, 1);
            Console.WriteLine(Math.Abs(primaryDiag-secondDiag));
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
        static void PrintJaggedArray(int[][] matrix, string sepp)
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
        static int SumOfPrimaryOrSecondaryDiagonal(int[,] matrix, byte ZeroIsForPrimaryOneIsSec = 0)
        {
            int sum = 0;
            int counter = 0;
            { }
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                while (counter < matrix.GetLength(1))
                {
                    if (ZeroIsForPrimaryOneIsSec == 0)
                    { sum += matrix[counter, counter]; }
                    else
                    { sum += matrix[counter, matrix.GetLength(0) -1 - counter]; }
                    counter++;
                }
            }
            else
            {
                sum = 0;
            }
            return sum;
        }
        static string FindPosicionOfCharInCharMatrix(char[,] matrix, char symbol)
        {
            string posicion = string.Empty;
            bool flag = true;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        posicion = "(" + row + ", " + col + ")";
                        flag = false;
                        break;
                    }
                    if (flag == false)
                    { break; }
                }
                Console.WriteLine();
            }
            if (flag)
            { posicion = $"{symbol} does not occur in the matrix"; }

            return posicion;
        }


    }
}
