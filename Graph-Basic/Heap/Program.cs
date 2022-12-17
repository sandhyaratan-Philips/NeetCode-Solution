using System;
using System.Collections.Generic;

namespace Heap
{
    /*
     * https://www.hackerearth.com/practice/data-structures/trees/heapspriority-queues/tutorial/
     * https://www.growingwiththeweb.com/data-structures/binary-heap/overview/
     */
    class Program
    {

        int extract_maximum(List<int> Arr)
        {
            int current_heap_size = Arr.Count;
            if (current_heap_size <= 0)
            {
                return int.MaxValue;
            }

            if (current_heap_size == 1)
            {
                current_heap_size--;
                return Arr[0];
            }

            // Store the minimum value, 
            // and remove it from heap 
            int root = Arr[0];

            Arr[0] = Arr[current_heap_size - 1];
            current_heap_size--;
            Arr.RemoveAt(current_heap_size);
            max_heapify(Arr, 0);

            return root;
        }

        void min_heapify(List<int> hT, int i)
        {
            int size = hT.Count;
            int smallest = i;
            int l = 2 * i + 1; //can be l=2i and r=2l+1 if in insert  i start with >1 instead of >=0
            int r = 2 * i + 2;
            if (l < size && hT[l] < hT[smallest])
                smallest = l;
            if (r < size && hT[r] < hT[smallest])
                smallest = r;

            if (smallest != i)
            {
                int temp = hT[smallest];
                hT[smallest] = hT[i];
                hT[i] = temp;

                max_heapify(hT, smallest);
            }
        }
        void max_heapify(List<int> hT, int i) //O(log N)
        {
            int size = hT.Count;
            int largest = i;
            int l = 2 * i + 1; //can be l=2i and r=2l+1 if in insert  i start with >1 instead of >=0
            int r = 2 * i + 2;
            if (l < size && hT[l] > hT[largest])
                largest = l;
            if (r < size && hT[r] > hT[largest])
                largest = r;

            if (largest != i)
            {
                int temp = hT[largest];
                hT[largest] = hT[i];
                hT[i] = temp;

                max_heapify(hT, largest);
            }
        }

        void insert(List<int> hT, int newNum) //  the insert functions O(N) runs only  N/2
        {
            int size = hT.Count;
            if (size == 0)
            {
                hT.Add(newNum);
            }
            else
            {
                hT.Add(newNum);
                for (int i = size / 2 - 1; i >= 0; i--)
                {
                    max_heapify(hT, i);
                }
            }
        }
        void printArray(List<int> array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();
        }
        void deleteNode(List<int> hT, int num)
        {
            int size = hT.Count;
            int i;
            for (i = 0; i < size; i++)
            {
                if (num == hT[i])
                    break;
            }

            int temp = hT[i];
            hT[i] = hT[size - 1];
            hT[size - 1] = temp;

            hT.Remove(size - 1);
            size--;
            for (int j = size / 2 - 1; j >= 0; j--)
            {
                max_heapify(hT, j);
            }
        }

        static void Main(string[] args)
        {
            List<int> array = new List<int>();

            Program h = new Program();
            h.insert(array, 3);
            h.insert(array, 4);
            h.insert(array, 9);
            h.insert(array, 5);
            h.insert(array, 2);

            Console.WriteLine("Max-Heap array: ");
            h.printArray(array);

            h.deleteNode(array, 4);
            Console.WriteLine("After deleting an element: ");
            h.printArray(array);
            Console.WriteLine("Max element: ");
            Console.WriteLine(h.extract_maximum(array));
            Console.WriteLine("After extracting max element: ");
            h.printArray(array);

            //   Console.WriteLine("Hello World!");
        }
    }
}
