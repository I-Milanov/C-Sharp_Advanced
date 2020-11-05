/*04.Symbol in Matrix
Write a program that reads N, number representing rows and cols of a matrix. 
On the next N lines, you will receive rows of the matrix. 
Each row consists of ASCII characters. After that, you will receive a symbol.
Find the first occurrence of that symbol in the matrix and print its position in the
format: "({row}, {col})".If there is no such symbol print an error message 
"{symbol} does not occur in the matrix "
*/
using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }

            }
            char symbol = char.Parse(Console.ReadLine());

            Console.WriteLine(FindPosicionOfCharInCharMatrix(matrix,symbol));
        }

        static string FindPosicionOfCharInCharMatrix(char[,] matrix, char symbol)
        {
            string posicion=string.Empty;
            bool flag = true;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        posicion="("+row+", "+ col+")";
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
