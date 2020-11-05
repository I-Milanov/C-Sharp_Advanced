/*06.	Jagged-Array Modification
Write a program that reads a matrix from the console. On the first line you will get matrix rows. On next rows lines you will get elements for each column separated with space. You will be receiving commands in the following format:
•	Add {row} {col} {value} – Increase the number at the given coordinates with the value.
•	Subtract {row} {col} {value} – Decrease the number at the given coordinates by the value.
Coordinates might be invalid. In this case you should print "Invalid coordinates". When you receive "END" you should print the matrix and stop the program.
*/
using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = ReadJaggedArray(rows, " ");
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] com = command.Split(" ").ToArray();
                if (int.Parse(com[1]) < 0 ||
                    int.Parse(com[2]) < 0 ||
                    int.Parse(com[1]) >= matrix.Length ||
                    int.Parse(com[2]) >= matrix[int.Parse(com[1])].Length
                    )
                { Console.WriteLine("Invalid coordinates"); }
                else
                {
                    if (com[0] == "Add")
                    { matrix[int.Parse(com[1])][int.Parse(com[2])] += int.Parse(com[3]); }
                    else
                    { matrix[int.Parse(com[1])][int.Parse(com[2])] -= int.Parse(com[3]); }
                }

            }
            PrintJaggedArray(matrix, " ");



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
