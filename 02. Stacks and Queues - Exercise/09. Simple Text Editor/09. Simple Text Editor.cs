using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> stack = new Stack<string> { };
            for (int i = 0; i < N; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (int.Parse(commands[0]))
                {
                    case 1:
                        text = ConcatTwoStrings(text, commands[1]);
                        stack.Push($"{commands[0]} {commands[1]}");
                        break;
                    case 2:
                        stack.Push($"{commands[0]} {text.Substring((text.Length - int.Parse(commands[1])), int.Parse(commands[1]))}");
                        text = text.Remove(text.Length - int.Parse(commands[1]));
                        break;
                    case 3:
                        Console.WriteLine(text[int.Parse(commands[1]) - 1]);
                        break;
                    default:
                        string[] Undo = stack.Pop().Split();
                        if (Undo[0] == "1")
                        {
                            text = text.Remove(text.Length - Undo[1].Length);
                        }
                        else
                        { text = ConcatTwoStrings(text, Undo[1]); }
                        break;
                }

            }
        }
        static string ConcatTwoStrings(string a, string b) => a += b;


    }
}
