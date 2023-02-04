using System;

namespace zigzag_conversion
{
    /*
     * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

        P   A   H   N
        A P L S I I G
        Y   I   R
        And then read line by line: "PAHNAPLSIIGYIR"

        Write the code that will take a string and make this conversion given a number of rows:

        string convert(string s, int numRows);

    T(o)=O(s.length)
    */
    class Program
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;
            string res = "";

            for (int row = 0; row < numRows; row++)
            {
                int increment = 2 * (numRows - 1);
                for (int i = row; i < s.Length; i += increment)
                {
                    res += s[i];
                    if (row > 0 && row < numRows - 1 && i + increment - 2 * row < s.Length)
                    {
                        res += s[i + increment - 2 * row];
                    }
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.Convert("PAYPALISHIRING", 3));
        }
    }
}
