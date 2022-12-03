using System;
using System.Collections.Generic;

namespace GenerateParentheses
{
    class Program
    {
        // only add open '(' when open <n
        // only add close ')' when close <n
        // open==close==n is valid
        private List<string> result = new List<string>();
        private Stack<char> stack = new Stack<char>();
        public IList<string> GenerateParenthesis(int n)
        {
            backtrack(0, 0, n);
            return result;
        }

        public void backtrack(int open, int closed, int n)
        {
            if (open == closed && open == n)
            {
                result.Add(string.Join("", stack));
            }
            if (closed < n)
            {
                stack.Push(')');
                backtrack(open, closed + 1, n);
                stack.Pop();
            }
            if (closed > open)
            {
                stack.Push('(');
                backtrack(open + 1, closed, n);
                stack.Pop();
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.GenerateParenthesis(3));
        }
    }
}
