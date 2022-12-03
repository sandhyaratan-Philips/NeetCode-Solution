using System;
using System.Collections.Generic;

namespace ValidParentheses
{
    class Program
    {
        public static bool IsValid(string s)
        {
            Stack<char> parentheses = new Stack<char>();

            Dictionary<char, char> parenthesesDic = new Dictionary<char, char>();

            parenthesesDic.Add(')', '(');
            parenthesesDic.Add('}', '{');
            parenthesesDic.Add(']', '[');

            for (int i = 0; i < s.Length; i++)
            {
                if (parenthesesDic.ContainsKey(s[i]))
                {
                    if (parentheses.Count > 0 && parenthesesDic[s[i]].Equals(parentheses.Peek()))
                        parentheses.Pop();
                    else
                        return false;
                }
                else
                {
                    parentheses.Push(s[i]);
                }
            }

            return parentheses.Count == 0;
        }

        static void Main(string[] args)
        {
            string s = "()[]{}";
            string a = "[";
            string b = "]";
            Console.WriteLine(Program.IsValid(b));
        }
    }
}
