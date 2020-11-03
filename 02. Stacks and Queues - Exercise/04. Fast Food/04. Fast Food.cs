using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantite = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int max = queue.Max();
            while (queue.Count > 0)
            {
                if (quantite >= queue.Peek())
                { quantite -= queue.Dequeue(); }
                else
                    break;

            }
            if (queue.Count > 0)
            {
                Console.WriteLine(max);
                Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine(max);
                Console.WriteLine("Orders complete");
            }
        }
    }
}
