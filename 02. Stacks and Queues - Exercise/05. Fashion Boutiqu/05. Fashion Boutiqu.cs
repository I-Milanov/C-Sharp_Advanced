using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutiqu
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capasity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothes);
            int rackCounter = 1;
            int sum = 0;
            while (stack.Count > 0)
            {
                var current = stack.Peek();
                if (sum + current > capasity)
                {
                    rackCounter++;
                    sum = 0;
                }
                else
                {
                    sum += stack.Pop();
                }
            }
            Console.WriteLine(rackCounter);
        }
    }
}
