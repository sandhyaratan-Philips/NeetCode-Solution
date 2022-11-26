using System;

namespace StringCompressionInConstantSpace
{
    /*
     * input:
     * { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' }
     * { 'a', 'a', 'a', 'b', 'b', 'a', 'a' }
     */
    class Program
    {
        public static int Compress(char[] chars)
        {
            int N = chars.Length;
            int i = 0;
            string occurance = "";
            int character = chars[i] - 'a';
            int count = 0;


            while (N >= 0)
            {
                if (N > 0)
                {
                    if (character != (chars[i] - 'a'))
                    {
                        if (count > 1)
                            occurance = string.Concat(occurance, chars[i - 1], count);
                        else
                            occurance = string.Concat(occurance, chars[i - 1]);
                        if (N != 0)
                        {
                            count = 1;
                            character = chars[i] - 'a';
                        }
                    }
                    else
                    {
                        count++;
                    }
                }
                else
                {
                    if (count > 1)
                        occurance = string.Concat(occurance, chars[i - 1], count);
                    else
                        occurance = string.Concat(occurance, chars[i - 1]);
                }
                i++;
                N--;
            }
            Array.Clear(chars, 0, chars.Length);

            for (int j = 0; j < occurance.Length; j++)
            {
                chars[j] = occurance[j];
            }

            return occurance.Length;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Program.Compress(new char[] { 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h', 'h' }));
        }
    }
}
