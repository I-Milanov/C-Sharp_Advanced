/*3.	Maximal Sum
Write a program that reads a rectangular integer matrix of size N x M and finds 
in it the square 3 x 3 that has maximal sum of its elements.
Input
•	On the first line, you will receive the rows N and columns M.
On the next N lines you will receive each row with its columns
Output
•	Print the elements of the 3 x 3 square as a matrix, along with their sum
Input
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
Output
Sum = 75
1 4 14
7 11 2
8 12 16

 
*/
using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = ReadDualmetricMatrix(input[0], input[1]);
            int BiggestSum = int.MinValue;
            int BestRow = 0;
            int BestCol = 0;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int[,] littleMatrix = new int[3, 3];
                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            littleMatrix[row, col] = matrix[i + row, j + col];
                        }
                    }
                    int sum = SumDuomatricMatrix(littleMatrix);
                    if (BiggestSum < sum)
                    {
                        BiggestSum = sum;
                        BestRow = i;
                        BestCol = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {BiggestSum}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[BestRow+i,BestCol+j]} ");
                }
                Console.WriteLine();
            }


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
        static int[,] ReadDualmetricMatrix(int rows, int cols, string split = " ")
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(split,StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }

            }
            return matrix;
        }
        static char[,] ReadCharDualmetricMatrix(int rows, int cols, string split = " ")
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().Split(split, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
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
                    { sum += matrix[counter, matrix.GetLength(0) - 1 - counter]; }
                    counter++;
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
