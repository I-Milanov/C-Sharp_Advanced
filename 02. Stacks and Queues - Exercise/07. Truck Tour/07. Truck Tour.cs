using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<string> circle = new Queue<string> { };
            for (int i = 0; i < N; i++)
            {
                circle.Enqueue($"{Console.ReadLine()} {i}");

            }
            int totalFuel = 0;
        
            for (int i = 0; i < N; i++)
            {
                string currentInfo = circle.Dequeue();
                int[] info = currentInfo.Split(" ").Select(int.Parse).ToArray();

                int fuel = info[0];
                totalFuel += fuel;
                int distance = info[1];
                if (totalFuel >= distance)
                { 
                    totalFuel -= distance; 
                }
                else
                {
                    totalFuel = 0;
                    i = -1;
                }
                circle.Enqueue(currentInfo);

            }
            int[] Numbers = circle.Dequeue().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Numbers[2]);  
         
        }
    }
}
