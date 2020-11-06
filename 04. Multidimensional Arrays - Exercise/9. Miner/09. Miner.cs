/*9.	*Miner
We get as input the size of the field in which our miner moves. 
The field is always a square. After that we will receive the commands which represent the directions 
in which the miner should move. The miner starts from position – ‘s’. The commands will be: left, 
right, up and down. If the miner has reached a side edge of the field and the next command 
indicates that he has to get out of the field, he must remain on his current possition and
ignore the current command. The possible characters that may appear on the screen are:
•	* – a regular position on the field.
•	e – the end of the route. 
•	c  - coal
•	s - the place where the miner starts
Each time when the miner finds a coal, he collects it and replaces it with '*'.
Keep track of the count of the collected coals. If the miner collects all of the coals in the field, 
the program stops and you have to print the following message: 
"You collected all coals! ({rowIndex}, {colIndex})".
If the miner steps at 'e' the game is over (the program stops) and you have to print the following
message: "Game over! ({rowIndex}, {colIndex})".
If there are no more commands and none of the above cases had happened, 
you have to print the following message: "{remainingCoals} coals left. ({rowIndex}, {colIndex})".

Input
•	Field size – an integer number.
•	Commands to move the miner – an array of strings separated by " ".
•	The field: some of the following characters (*, e, c, s), separated by whitespace (" ");

Output
•	There are three types of output:
o	If all the coals have been collected, print the following output: 
"You collected all coals! ({rowIndex}, {colIndex})"
o	If you have reached the end, you have to stop moving and print the 
following line: "Game over! ({rowIndex}, {colIndex})"
o	If there are no more commands and none of the above cases had happened,
you have to print the following message: "{totalCoals} coals left. ({rowIndex}, {colIndex})"

Constraints
•	The field size will be a 32-bit integer in the range [0 … 2 147 483 647].
•	The field will always have only one’s’.
*/
using System;
using System.Linq;

class Bombs
{
    static int[,] matrix;

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int j = 0; j < row.Length; j++)
            {
                matrix[i, j] = row[j];
            }
        }

        string[] coordinates = Console.ReadLine().Split(' ');

        if (size > 1)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] coordinate = coordinates[i].Split(',');
                int row = int.Parse(coordinate[0]);
                int column = int.Parse(coordinate[1]);

                if (row == 0)
                {
                    if (column == 0)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row + 1, column + 1);
                            ChangeCell(row, column, row + 1, column);
                            matrix[row, column] = 0;
                        }
                    }
                    else if (column == size - 1)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row + 1, column);
                            ChangeCell(row, column, row + 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                    else
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row + 1, column + 1);
                            ChangeCell(row, column, row + 1, column);
                            ChangeCell(row, column, row + 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                }
                else if (row == size - 1)
                {
                    if (column == 0)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column + 1);
                            ChangeCell(row, column, row, column + 1);
                            matrix[row, column] = 0;
                        }
                    }
                    else if (column == size - 1)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                    else
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column + 1);
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row, column - 1);
                            ChangeCell(row, column, row - 1, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                }
                else
                {
                    if (column == 0)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column + 1);
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row + 1, column + 1);
                            ChangeCell(row, column, row + 1, column);
                            matrix[row, column] = 0;
                        }
                    }
                    else if (column == size - 1)
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            ChangeCell(row, column, row + 1, column - 1);
                            ChangeCell(row, column, row + 1, column);
                            matrix[row, column] = 0;
                        }
                    }
                    else
                    {
                        if (matrix[row, column] > 0)
                        {
                            ChangeCell(row, column, row - 1, column);
                            ChangeCell(row, column, row - 1, column + 1);
                            ChangeCell(row, column, row, column + 1);
                            ChangeCell(row, column, row + 1, column + 1);
                            ChangeCell(row, column, row + 1, column);
                            ChangeCell(row, column, row + 1, column - 1);
                            ChangeCell(row, column, row, column - 1);
                            ChangeCell(row, column, row - 1, column - 1);
                            matrix[row, column] = 0;
                        }
                    }
                }
            }
        }

        int cellsAliveCount = 0;
        int cellsAliveSum = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (matrix[i, j] > 0)
                {
                    cellsAliveCount++;
                    cellsAliveSum += matrix[i, j];
                }
            }
        }

        Console.WriteLine($"Alive cells: {cellsAliveCount}");
        Console.WriteLine($"Sum: {cellsAliveSum}");

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }

            Console.WriteLine();
        }
    }

    static void ChangeCell(int bombRow, int bombColumn, int row, int column)
    {
        if (matrix[row, column] > 0)
        {
            matrix[row, column] -= matrix[bombRow, bombColumn];
        }
    }
}