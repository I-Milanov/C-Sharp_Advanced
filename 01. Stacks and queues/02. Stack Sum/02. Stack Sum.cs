using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                var splitted = command.Split(' ');
                if (splitted[0] == "add")
                {
                    stack.Push(int.Parse(splitted[1]));
                    stack.Push(int.Parse(splitted[2]));
                }
                else if (splitted[0] == "remove")
                {
                    if (int.Parse(splitted[1]) <= stack.Count)
                    {
                        for (int i = 0; i < int.Parse(splitted[1]); i++)
                        { stack.Pop(); }
                    }
                }
            command = Console.ReadLine().ToLower();
            }
            int sum = 0;
            while (stack.Count > 0)
            { sum += stack.Pop(); }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
