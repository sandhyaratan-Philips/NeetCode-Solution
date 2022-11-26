using System;

namespace ArrayRotation
{
    //Block swap algorithm for array rotation

    /*divide the arr in 2 part A n B
     *where A= d and B= N-d
     *repeat below until A=B
     *if A>B then divide Al and Ar such that Al == B and swip Al with B and do rotation and reduce the length of A by B
     *if A<B then divide Bl and Br such that Br == A and swip Br with A and do rotation and reduce the length of B by A
     *
     *block swap A n B
    */

    class Program
    {
        public static void ArrayRotation(int[] arr, int d, int length)
        {
            Rotation(arr, 0, d, length);
        }
        public static void printArray(int[] arr, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }

        public static void Rotation(int[] arr, int start, int d, int length)
        {
            if (d == 0 || d == length)
                return;
            if (d == length - d)
            {
                swap(arr, start, length - d + start, d);
                return;
            }
            if (d < length - d)
            {
                swap(arr, start, length - d + start, d);
                Rotation(arr, start, d, length - d);
            }
            else
            {
                swap(arr, start, d, length - d);
                Rotation(arr, length - d + start, 2 * d - length, d);
            }
        }

        public static void swap(int[] arr, int start, int end, int d)
        {
            int temp = 0;
            for (int i = 0; i < d; i++)
            {
                temp = arr[start + i];
                arr[start + i] = arr[end + i];
                arr[end + i] = temp;
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Program.ArrayRotation(arr, 3, arr.Length);
            printArray(arr, arr.Length);
            //Console.WriteLine("Hello World!");
        }
    }
}
