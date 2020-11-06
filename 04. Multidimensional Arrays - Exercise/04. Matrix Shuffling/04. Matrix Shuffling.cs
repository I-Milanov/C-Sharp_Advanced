/*04.	Matrix Shuffling
Write a program which reads a string matrix from the console and performs certain operations with its elements. 
User input is provided in a similar way like in the problems above – first you read the dimensions and then the data. 
Your program should then receive commands in format: "swap row1 col1 row2c col2" where row1, row2, col1, col2 are coordinates in the matrix.
In order for a command to be valid, it should start with the "swap" keyword along with four valid coordinates (no more, no less).
You should swap the values at the given coordinates (cell [row1, col1] with cell [row2, col2]) and print the matrix at each step 
(thus you'll be able to check if the operation was performed correctly). 
If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered or the given coordinates do not exist),
print "Invalid input!" and move on to the next command. Your program should finish when the string "END" is entered.
*/
using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int col = input[1];
            string[,] matrix = ReadDualmetricMatrixString(rows, col);
            string command = Console.ReadLine();
            while (command != "END")
            {
                bool isValid = true;
                string[] test = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if ((test[0]!= "swap"))
                { isValid = false; }
                else if (test.Length != 5)
                { isValid = false; }


                if (isValid)
                {
                int a = int.Parse(test[1]), b = int.Parse(test[2]), c = int.Parse(test[3]), d = int.Parse(test[4]);
                    if (AreValidCoordinatesOfMatrix(matrix, a, b) && AreValidCoordinatesOfMatrix(matrix, c, d))
                    {
                        string box = matrix[a, b];
                        matrix[a, b] = matrix[c, d];
                        matrix[c, d] = box;
                        PrintDuomatricMatrixString(matrix);

                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                    }
                }
                else
                { Console.WriteLine($"Invalid input!"); }
                command = Console.ReadLine();
            }


        }

        static bool AreValidCoordinatesOfMatrix(string[,] matrix, int row, int col)
        {
            bool valid = true;
            if ((matrix.GetLength(0) - 1 < row) || (matrix.GetLength(1) - 1 < col))
            { valid = false; }
            return valid;
        }
        static string[,] ReadDualmetricMatrixString(int rows, int cols, string split = " ")
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(split, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }

            }
            return matrix;
        }
        static void PrintDuomatricMatrixString(string[,] matrix)
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
                int[] rowData = Console.ReadLine().Split(split, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
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
