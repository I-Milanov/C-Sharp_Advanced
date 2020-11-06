/*2.	 2X2 Squares in Matrix
Find the count of 2 x 2 squares of equal chars in a matrix.
Input
•	On the first line, you are given the integers rows and cols – the matrix’s dimensions
•	Matrix characters come at the next rows lines (space separated)
Output
•	Print the number of all the squares matrixes you have found
Input
3 4
A B B D
E B B B
I J B B
Output
2
Comments
Two 2 x 2 squares of equal cells:
A B B D	A B B D
E B B B	E B B B
I J B B	I J B B


*/
using System;
using System.Linq;

namespace _02.__2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int col = input[1];
            char[,] matrix = ReadCharDualmetricMatrix(rows, col);
            int counter = 0;
            if (matrix.GetLength(0) > 1 && matrix.GetLength(1) > 1)
            {
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (matrix[i, j] == matrix[i, j + 1] &&
                             matrix[i, j] == matrix[i + 1, j] &&
                             matrix[i, j] == matrix[i + 1, j + 1])
                        {
                            counter++;
                        }

                    }

                }
            }
            Console.WriteLine(counter);

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
