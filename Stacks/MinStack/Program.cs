using System;
using System.Collections.Generic;

namespace MinStack
{
    class Program
    {
        private Stack<int> stack;
        private Stack<int> minStack;
        public Program()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
            int minVal = Math.Min(val, minStack.Count == 0 ? val : minStack.Peek());
            minStack.Push(minVal);
        }

        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
