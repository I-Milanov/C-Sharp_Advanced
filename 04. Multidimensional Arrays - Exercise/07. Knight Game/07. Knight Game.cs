/*7.	Knight Game
Chess is the oldest game, but it is still popular these days. 
For this task we will use only one chess piece – the Knight. 
The knight moves to the nearest square but not on the same row,
column, or diagonal. (This can be thought of as moving two squares horizontally, 
then one square vertically, or moving one square horizontally 
then two squares vertically— i.e. in an "L" pattern.) 

The knight game is played on a board with dimensions N x N and a lot of chess knights 0 <= K <= N2. 

You will receive a board with K for knights and '0' for empty cells.
Your task is to remove a minimum of the knights, 
so there will be no knights left that can attack another knight. 

Input
On the first line, you will receive the N size of the board
On the next N lines, you will receive strings with Ks and 0s.

Output
Print a single integer with the minimum number of knights that needs to be removed
*/
using System;

namespace KnightGame
{
    public class KnightGame
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (int i = 0; i < matrix.Length; i++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                matrix[i] = new char[n];
                matrix[i] = inputRow;
            }

            int currentKnightsInDanger = 0;
            int maxKnightsInDanger = -1;
            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;
            int count = 0;

            while (true)
            {
                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        if (matrix[rowIndex][colIndex].Equals('K'))
                        {
                            // vertical and left
                            if (IsCellInMatrix(rowIndex - 2, colIndex - 1, matrix))
                            {
                                if (matrix[rowIndex - 2][colIndex - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical and right
                            if (IsCellInMatrix(rowIndex - 2, colIndex + 1, matrix))
                            {
                                if (matrix[rowIndex - 2][colIndex + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical and left
                            if (IsCellInMatrix(rowIndex + 2, colIndex - 1, matrix))
                            {
                                if (matrix[rowIndex + 2][colIndex - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical and right
                            if (IsCellInMatrix(rowIndex + 2, colIndex + 1, matrix))
                            {
                                if (matrix[rowIndex + 2][colIndex + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal up and left
                            if (IsCellInMatrix(rowIndex - 1, colIndex - 2, matrix))
                            {
                                if (matrix[rowIndex - 1][colIndex - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal up and right
                            if (IsCellInMatrix(rowIndex - 1, colIndex + 2, matrix))
                            {
                                if (matrix[rowIndex - 1][colIndex + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal down and left
                            if (IsCellInMatrix(rowIndex + 1, colIndex - 2, matrix))
                            {
                                if (matrix[rowIndex + 1][colIndex - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal down and right
                            if (IsCellInMatrix(rowIndex + 1, colIndex + 2, matrix))
                            {
                                if (matrix[rowIndex + 1][colIndex + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = rowIndex;
                            mostDangerousKnightCol = colIndex;
                        }
                        currentKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    matrix[mostDangerousKnightRow][mostDangerousKnightCol] = 'O';
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        public static bool IsCellInMatrix(int row, int col, char[][] matrix)
        {
            if (0 <= row && row < matrix.Length && 0 <= col && col < matrix[row].Length)
            {
                return true;
            }
			
            return false;
        }
    }
}

