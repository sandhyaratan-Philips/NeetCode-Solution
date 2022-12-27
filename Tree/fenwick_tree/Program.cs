using System;

namespace fenwick_tree
{

    //Fenwick Tree / Binary Indexed Tree
    //Consider we have an array arr[0. . .n - 1]. We would like to
    //1. Compute the sum of the first i elements.
    //2. Modify the value of a specified element of the array arr[i] = x where 0 <= i <= n-1.
    //A simple solution is to run a loop from 0 to i-1 and calculate the sum of the elements.To update a value, simply do arr[i] = x.
    //The first operation takes O(n) time and the second operation takes O(1) time.
    //Another simple solution is to create an extra array and store the sum of the first i-th elements at the i-th index in this new array.
    //The sum of a given range can now be calculated in O(1) time, but the update operation takes O(n) time now.
    //This works well if there are a large number of query operations but a very few number of update operations.
    //There are two solutions that can perform both the query and update operations in O(logn) time.
    //1. Fenwick Tree
    //2. Segment Tree
    //Compared with Segment Tree, Binary Indexed Tree requires less space and is easier to implement.

    class Program
    {
        int[] bit_tree = new int[1000];

        void constructBITree(int[] freq, int n)
        {
            //Constructs and returns a Binary Indexed Tree for given array of size n

            //Create and initialize bit_ree[] as 0


            // Store the actual values in bit_ree[] using update() 
            for (int i = 1; i <= n; i++)
                bit_tree[i] = 0;

            // Store the actual values in BITree[]
            // using update()
            for (int i = 0; i < n; i++)
                update_bit(n, i, freq[i]);

        }

        void update_bit(int n, int i, int v)
        {
            // Updates a node in Binary Index Tree (bit_tree) at given index
            // in bit_tree. The given value 'val' is added to bit_tree[i] and all of its ancestors in tree. 

            // index in bit_ree[] is 1 more than the index in arr[] 
            i += 1;

            // Traverse all ancestors and add 'val' 
            while (i <= n)
            {

                // Add 'val' to current node of bit_tree 
                bit_tree[i] += v;

                // Update index to that of parent in update View 
                i += i & (-i);
            }
        }

        int get_sum(int i)
        {
            //Returns sum of arr[0..index]. This function assumes that the array is preprocessed
            //and partial sums of array elements are stored in bit_tree[].

            int s = 0;

            // index in bit_tree[] is 1 more than the index in arr[] 
            i = i + 1;

            // Traverse ancestors of bit_tree[index] 
            while (i > 0)
            {
                // Add current element of bit_tree to sum 
                s += bit_tree[i];

                // Move index to parent node in getSum View 
                i -= i & (-i);
            }
            return s;
        }

        static void Main(string[] args)
        {
            int[] freq = { 2, 1, 1, 3, 2, 3, 4, 5, 6, 7, 8, 9 };
            int n = freq.Length;
            Program tree = new Program();

            // Build fenwick tree from given array
            tree.constructBITree(freq, n);

            Console.WriteLine("Sum of elements in arr[0..5]" +
                            " is " + tree.get_sum(5));

            // Let use test the update operation
            freq[3] += 6;

            // Update BIT for above change in arr[]
            tree.update_bit(n, 3, 6);

            // Find sum after the value is updated
            Console.WriteLine("Sum of elements in arr[0..5]" +
                        " after update is " + tree.get_sum(5));
        }
    }
}
