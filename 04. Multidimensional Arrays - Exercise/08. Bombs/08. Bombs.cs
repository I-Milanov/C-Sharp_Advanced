/*8.	*Bombs
You will be given a square matrix of integers, each integer separated by a single space,
and each row on a new line. Then on the last line of input you will receive indexes
- coordinates to several cells separated by a single space, in the following format:
row1,column1  row2,column2  row3,column3… 
On those cells there are bombs. You have to proceed every bomb, 
one by one in the order they were given. 
When a bomb explodes deals damage equal to its own integer value,
to all the cells around it(in every direction and in all diagonals). 
One bomb can't explode more than once and after it does, its value becomes 0.
When a cell’s value reaches 0 or below, it dies. Dead cells can't explode.
You must print the count of all alive cells and their sum. Afterwards, print the matrix with all of
its cells (including the dead ones). 

Input
•	On the first line, you are given the integer N – the size of the square matrix.
•	The next N lines holds the values for every row – N numbers separated by a space.
•	On the last line you will receive the coordinates of the cells with the bombs in
the format described above.

Output
•	On the first line you need to print the count of all alive cells in the format: 
“Alive cells: {aliveCells}”
•	On the second line you need to print the sum of all alive cell in the format: 
“Sum: {sumOfCells}”
•	In the end print the matrix. The cells must be separated by a single space.

Constraints
•	The size of the matrix will be between [0…1000].
•	The bomb coordinates will always be in the matrix.
•	The bomb’s values will always be greater than 0.
•	The integers of the matrix will be in range [1…10000]. 
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        int[,] field = new int[fieldSize, fieldSize];
        ReadFieldFromConsole(field);
        string[] coordinatesValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        ExplodeTheBombs(field, coordinatesValues);
        int aliveCells = 0;
        int sumAliveCells = 0;
        foreach (int cell in field)
        {
            if (cell > 0)
            {
                aliveCells++;
                sumAliveCells += cell;
            }
        }
        Console.WriteLine($"Alive cells: {aliveCells}");
        Console.WriteLine($"Sum: {sumAliveCells}");
        PrintField(field);
    }

    private static void PrintField(int[,] field)
    {
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                Console.Write(field[row, col] + " ");

            }
            Console.WriteLine();
        }
    }

    private static void ExplodeTheBombs(int[,] field, string[] coordinatesValues)
    {
        foreach (string rowColPair in coordinatesValues)
        {
            int[] currentBombCoordinates = rowColPair
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int currentBombRow = currentBombCoordinates[0];
            int currentBombCol = currentBombCoordinates[1];
            int currentBomb = field[currentBombRow, currentBombCol];


            for (int row = currentBombRow - 1; row <= currentBombRow + 1; row++)
            {
                for (int col = currentBombCol - 1; col <= currentBombCol + 1; col++)
                {
                    if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
                    {
                        if (field[row, col] <= 0 || currentBomb < 0)
                        {
                            continue;
                        }
                        field[row, col] -= currentBomb;
                    }

                }

            }

        }
    }

    private static void ReadFieldFromConsole(int[,] field)
    {
        for (int row = 0; row < field.GetLength(0); row++)
        {
            int[] currentRow = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int col = 0; col < field.GetLength(1); col++)
            {
                field[row, col] = currentRow[col];
            }
        }
    }
}