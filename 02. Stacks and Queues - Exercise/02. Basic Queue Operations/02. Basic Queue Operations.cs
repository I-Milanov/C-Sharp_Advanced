﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int s = input[1];
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }
            int x = input[2];
            if (queue.Contains(x))
            { Console.WriteLine("true"); }
            else if (queue.Count > 0)
            { Console.WriteLine(queue.Min()); }
            else if (queue.Count == 0)
            { Console.WriteLine("0"); }
        }
    }
}
