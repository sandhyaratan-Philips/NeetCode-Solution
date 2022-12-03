using System;
using System.Collections.Generic;

namespace EvaluateReversePolishNotation
{
    class Program
    {
        public static int EvalRPN(string[] tokens)
        {
            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "+")
                {
                    nums.Push(nums.Pop() + nums.Pop());
                }
                else if (tokens[i] == "-")
                {
                    int a = nums.Pop();
                    int b = nums.Pop();
                    nums.Push(b - a);
                }
                else if (tokens[i] == "*")
                {
                    nums.Push(nums.Pop() * nums.Pop());
                }
                else if (tokens[i] == "/")
                {
                    int a = nums.Pop();
                    int b = nums.Pop();
                    nums.Push(b / a);
                }
                else
                {
                    nums.Push(Convert.ToInt32(tokens[i]));
                }
            }
            return nums.Peek();

        }
        static void Main(string[] args)
        {
            string[] tokens = { "2", "1", "+", "3", "*" }; //9
            Console.WriteLine(Program.EvalRPN(tokens));
        }
    }
}
