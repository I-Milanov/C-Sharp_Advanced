using System;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int greenCounter = greenLightDuration;
            int freeWindCounter = freeWindowDuration;
            int totalCarsPassed = 0;
            bool Safety = true;
            bool canCross = true;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    greenCounter = greenLightDuration;
                    freeWindCounter = freeWindowDuration;
                    canCross = true;
                }
                else if (canCross)
                {
                    int crossingTime = command.Length;
                    if (greenCounter >= crossingTime)
                    {
                        greenCounter -= crossingTime;
                        totalCarsPassed++;
                        if (greenCounter == 0)
                        { canCross=false;}
                    }
                    else if ((greenCounter + freeWindCounter) >= crossingTime)
                    {
                        totalCarsPassed++;
                        greenCounter = 0;
                        freeWindCounter = 0;
                        canCross = false;
                    }
                    else
                    {
                        Console.WriteLine($"A crash happened!");
                        Console.WriteLine($"{command} was hit at {command.Substring((greenCounter+freeWindCounter),1)}.");
                        Safety = false;
                        break;
                    }
                    


                }
            }
            
            if (Safety)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }


        }
    }
}
