using System;
using System.Collections.Generic;

namespace Fibonacci_heap
{
    //https://www.growingwiththeweb.com/data-structures/fibonacci-heap/overview/
    class Program
    {
        public class FibonacciHeap<T>
        {
            public class Node<T>
            {
                public T Key { get; set; }

                public int Degree { get; set; }
                public Node<T> Parent { get; set; }
                public Node<T> Child { get; set; }
                public Node<T> Prev { get; set; }
                public Node<T> Next { get; set; }
                public bool IsMarked { get; set; }

                /// <summary>
                /// Creates a Fibonacci heap node.
                /// </summary>
                public Node()
                {
                }

                /// <summary>
                /// Creates a Fibonacci heap node initialised with a key and value.
                /// </summary>
                /// <param name="key">The key to use.</param>
                /// <param name="val">The value to use.</param>
                public Node(T key)
                {
                    Key = key;
                    Next = this;
                    Prev = this;
                }

                public int CompareTo(object other)
                {
                    var casted = other as Node<T>;
                    if (casted == null)
                        throw new NotImplementedException("Cannot compare to a non-Node object");
                    return Comparer<T>.Default.Compare(Key, casted.Key);
                }
            }

            private Node<T> _minNode;

            /// <summary>
            /// The size of the heap.
            /// </summary>
            public int Size { get; private set; }

            /// <summary>
            /// Creates a Fibonacci heap.
            /// </summary>
            public FibonacciHeap()
            {
                _minNode = null;
                Size = 0;
            }

            /// <summary>
            /// Clears the heap's data, making it an empty heap.
            /// </summary>
            public void Clear()
            {
                _minNode = null;
                Size = 0;
            }

            public void Insert(T key)
            {
                Node<T> node = new Node<T>(key);
                _minNode = MergeLists(_minNode, node);
                Size++;
            }

            private Node<T> MergeLists(Node<T> a, Node<T> b)
            {
                if (a == null && b == null)
                    return null;
                if (a == null)
                    return b;
                if (b == null)
                    return a;

                Node<T> tempNode = a.Next;
                a.Next = b.Next;
                a.Next.Prev = a;
                b.Next = tempNode;
                b.Next.Prev = b;
                return a.CompareTo(b) < 0 ? a : b;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
