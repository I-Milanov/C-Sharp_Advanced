/*6.	Jagged Array Manipulator
Create a program that populates, analyzes and manipulates the elements of a matrix with unequal
length of its rows.

First you will receive an integer N equal to the number of rows in your matrix.
On the next N lines, you will receive sequences of integers, separated by a single space. 
Each sequence is a row in the matrix.

After populating the matrix, start analyzing it. If a row and the one below it have equal length, 
multiply each element in both of them by 2, otherwise - divide by 2.

Then, you will receive commands. There are three possible commands:
•	"Add {row} {column} {value}" - add {value} to the element at the given indexes, if they are valid
•	"Subtract {row} {column} {value}" - subtract {value} from the element at the given indexes,
if they are valid
•	"End" - print the final state of the matrix (all elements separated by a single space) 
and stop the program

Input
•	On the first line, you will receive the number of rows of the matrix - integer N
•	On the next N lines, you will receive each row - sequence of integers, separated by a single space
•	{value} will always be integer number
•	Then you will be receiving commands until reading "End"

Output
•	The output should be printed on the console and it should consist of N lines
•	Each line should contain a string representing the respective row of the final matrix,
elements separated by a single space

Constraints
•	The number of rows N of the matrix will be integer in the range [2 … 12]
•	The input will always follow the format above
•	Think about data types 

*/
using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = ReadJaggedArray(rows, " ", 4.5);
            for (int i = 0; i < rows - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;
                    }
                    for (int j = 0; j < matrix[i + 1].Length; j++)
                    {
                        matrix[i + 1][j] /= 2;
                    }
                }
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int row = int.Parse(command[1]), col = int.Parse(command[2]), value = int.Parse(command[3]);
                if (AreValidCoordinatesOfJaggedArray(matrix, row, col))
                {
                    if (command[0] == "Add")
                    { matrix[row][col] += value; }
                    else
                    { matrix[row][col] -= value; }
                }
            }


            PrintJaggedArray(matrix);

        }

        static bool AreValidCoordinatesOfJaggedArray(double[][] matrix, int row, int col)
        {
            bool valid = true;
            if ((matrix.Length <= row || row < 0))
            { valid = false; }
            else if (matrix[row].Length <= col || col < 0)
            { valid = false; }

            return valid;
        }

        static void PrintJaggedArray(double[][] matrix, string sepp = " ")
        {
            foreach (var array in matrix)
            {
                Console.WriteLine(String.Join(sepp, array));
            }
        }

        static double[][] ReadJaggedArray(int rows, string sepp, double type)
        {
            double[][] matrix = new double[rows][];
            for (int row = 0; row < matrix.Length; row++)
            {
                double[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                matrix[row] = new double[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }
            return matrix;
        }

    }
}
