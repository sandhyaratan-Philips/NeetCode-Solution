using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidSudoku
{
    class Program
    {
        public static bool IsValidSudoku(char[][] board)
        {
            Dictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
            Dictionary<int, HashSet<char>> cols = new Dictionary<int, HashSet<char>>();
            Dictionary<string, HashSet<char>> squares = new Dictionary<string, HashSet<char>>(); // key is {r/3,c/3}

            for (int row = 0; row < board.Length; row++)
            {
                rows.Add(row, new HashSet<char> { });
                for (int col = 0; col < board.Length; col++)
                {
                    if (!cols.ContainsKey(col))
                    {
                        cols.Add(col, new HashSet<char> { });
                    }
                    if (!squares.ContainsKey((row / 3, col / 3).ToString()))
                    {
                        squares.Add((row / 3, col / 3).ToString(), new HashSet<char> { });
                    }
                    if (board[row][col] == '.')
                    {
                        continue;
                    }
                    if (rows[row].Any(x => x == board[row][col]) || cols[col].Any(x => x == (board[row][col])) || squares[(row / 3, col / 3).ToString()].Any(x => x == (board[row][col])))
                    {
                        return false;
                    }
                    else
                    {
                        rows[row].Add(board[row][col]);
                        cols[col].Add(board[row][col]);
                        squares[(row / 3, col / 3).ToString()].Add(board[row][col]);
                    }
                }
            }

            return true;
        }
        static void Main(string[] args)
        {
            char[][] arr = new char[][]{
                 new char[]{'5', '3', '.', '.', '7', '.', '.', '.', '.'}
                ,new char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.'}
                ,new char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'}
                ,new char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'}
                ,new char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'}
                ,new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'}
                ,new char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'}
                ,new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'}
                ,new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };

            Console.WriteLine("is valid: " + Program.IsValidSudoku(arr));
        }
    }
}
