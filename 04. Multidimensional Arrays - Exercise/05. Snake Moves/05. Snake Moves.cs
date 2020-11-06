using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char> { };
            for (int i = 0; i < snake.Length; i++)
            {
                queue.Enqueue(snake[i]);
            }
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = queue.Dequeue();
                        queue.Enqueue(matrix[row, col]);
                    }
                }
                else
                {
                    for (int col = cols-1; col >=0; col--)
                    {
                        matrix[row, col] = queue.Dequeue();
                        queue.Enqueue(matrix[row, col]);
                    }
                }
            }
            PrintDuomatricMatrix(matrix);

        }

        static void PrintDuomatricMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
      
    }
}
