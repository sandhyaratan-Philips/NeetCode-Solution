using System;
using System.Collections.Generic;

namespace check_for_balanced_parentheses_in_an_expression
{
    class Program
    {
        bool isValid(string str)
        {
            Dictionary<char, char> pairs = new Dictionary<char, char>();
            pairs.Add('{', '}');
            pairs.Add('(', ')');
            pairs.Add('[', ']');
            Stack<char> stack = new Stack<char>();
            int length = str.Length;
            stack.Push(str[0]);
            for (int i = 1; i < length; i++)
            {
                if (stack.Count > 0 && pairs.ContainsKey(stack.Peek()) && pairs[stack.Peek()] == str[i])
                {
                    stack.Pop();
                }
                else
                    stack.Push(str[i]);
            }

            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("is valid: " + program.isValid("[()]{}{[()()]()}"));

            Console.WriteLine("is valid: " + program.isValid("](])"));
        }
    }
}
