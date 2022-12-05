using System;

namespace Search_a_2DMatrix
{
    class Program
    {
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int row = matrix.Length;
            int col = matrix[0].Length - 1;

            int top = 0;
            int bottom = matrix.Length - 1;
            while (top <= bottom)
            {
                row = (top + bottom) / 2;
                if (target > matrix[row][col])
                    top = row + 1;
                else if (target < matrix[row][0])
                    bottom = row - 1;
                else
                    break;
            }

            if (top > bottom)
                return false;
            row = (top + bottom) / 2;
            return Binary_Search(matrix[row], 0, col, target);
        }


        public static bool Binary_Search(int[] arr, int start, int end, int target)
        {
            if (end >= start)
            {
                int mid = (start + end) / 2;

                if (arr[mid] == target)
                    return true;

                if (arr[mid] < target)
                    return Binary_Search(arr, mid + 1, end, target);

                if (arr[mid] > target)
                    return Binary_Search(arr, start, mid - 1, target);
            }
            return false;
        }

        static void Main(string[] args)
        {
            int[][] num = { new int[] { 1 } };
            int target = 0;
            Console.WriteLine(Program.SearchMatrix(num, target));
        }
    }
}
