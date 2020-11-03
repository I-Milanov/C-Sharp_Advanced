using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", ").ToArray());
            string command = Console.ReadLine();
            while (queue.Count > 0)
            {
                switch (command)
                {
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", queue));
                        break;
                    default:
                        string song = command.Substring(4, command.Length - 4);
                        if (!queue.Contains(song))
                            queue.Enqueue(song);
                        else
                        { Console.WriteLine($"{song} is already contained!"); }
                        break;

                }
                command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
