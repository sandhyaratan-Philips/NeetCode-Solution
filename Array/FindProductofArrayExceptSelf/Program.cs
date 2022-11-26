using System;

namespace FindProductofArrayExceptSelf
{
    /*
     * Input:  X[] = [2, 1, 3, 4], Output: product[] = [12, 24, 8, 6]
     * approch a: with 2 loops     -> O(n^2)
     * approch b: prefixProd and sufixProd array
     * 
     * if prefixProd[i-1]=prefixProd[i-2 to 0]
     * therefore, prefixProd[i]=prefixProd[i-1 to 0]
     *                         =prefixProd[i-1]*arr[i-1]
     * 
     * if sufixProd[i+1]=sufixProd[i+2 to n-1]
     * therefore, sufixProd[i]=sufixProd[i+1 to n-1]
     *                         =sufixProd[i+1]*arr[i+1]
     *                         
     * FinalProduct=prefixProd[i]*sufixProd[*]
     */
    class Program
    {
        public static void FindProductofArrayExceptSelf(int[] arr)
        {
            int N = arr.Length;
            int[] prefixProd = new int[N];
            int[] sufixProd = new int[N];

            //calculate prefixProd
            prefixProd[0] = 1;
            for (int i = 1; i < N; i++)
            {
                prefixProd[i] = prefixProd[i - 1] * arr[i - 1];
            }

            //calculate sufixProd
            sufixProd[N - 1] = 1;
            for (int i = N - 2; i >= 0; i--)
            {
                sufixProd[i] = sufixProd[i + 1] * arr[i + 1];
            }

            //final product
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(sufixProd[i] * prefixProd[i]);
            }


        }


        static void Main(string[] args)
        {
            Program.FindProductofArrayExceptSelf(new int[] { 2, 1, 3, 4 });
            //Console.WriteLine("Hello World!");
        }
    }
}
