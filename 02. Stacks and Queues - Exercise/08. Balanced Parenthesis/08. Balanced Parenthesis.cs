using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
         public class StartUp
        {
            static void Main()
            {
                char[] parantheses = Console.ReadLine().ToCharArray();
                Stack<char> stack = new Stack<char>();

                for (int i = 0; i < parantheses.Length; i++)
                {
                    char expectedParantheses = '(';
                    bool isBalanced = false;

                    if (parantheses[i] == ')')
                    {
                        isBalanced = true;
                    }
                    else if (parantheses[i] == ']')
                    {
                        expectedParantheses = '[';
                        isBalanced = true;
                    }
                    else if (parantheses[i] == '}')
                    {
                        expectedParantheses = '{';
                        isBalanced = true;
                    }
                    else
                    {
                        stack.Push(parantheses[i]);
                    }

                    if (isBalanced)
                    {
                        if (stack.Count == 0 || stack.Pop() != expectedParantheses)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }

                Console.WriteLine("YES");
            }
        }
    }