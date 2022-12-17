using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinomialHeap
{
    //https://www.growingwiththeweb.com/data-structures/binomial-heap/overview/

    public class BinomialHeap<T>
    {
        public class Node<T>
        {
            public T Key { get; set; }
            public int Degree { get; set; }
            public Node<T> Parent { get; set; }
            public Node<T> Child { get; set; }
            public Node<T> Sibling { get; set; }

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
            }

            public int CompareTo(object other)
            {
                var casted = other as Node<T>;
                if (casted == null)
                    throw new NotImplementedException("Cannot compare to a non-Node object");
                return Comparer<T>.Default.Compare(Key, casted.Key);
            }

            public void print(int level)
            {
                Node<T> curr = this;
                while (curr != null)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < level; i++)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(curr.Key.ToString());
                    Console.WriteLine(sb.ToString());
                    if (curr.Child != null)
                    {
                        curr.Child.print(level + 1);
                    }
                    curr = curr.Sibling;
                }
            }
        }
        private Node<T> head;

        public BinomialHeap()
        {
            head = null;
        }

        public BinomialHeap(Node<T> head)
        {
            this.head = head;
        }
        public bool isEmpty()
        {
            return head == null;
        }

        public void clear()
        {
            head = null;
        }

        public void insert(T key)
        {
            Node<T> node = new Node<T>(key);
            BinomialHeap<T> tempHeap = new BinomialHeap<T>(node);
            head = union(tempHeap);
        }

        // Merge two binomial trees of the same order
        private void linkTree(Node<T> minNodeTree, Node<T> other)
        {
            other.Parent = minNodeTree;
            other.Sibling = minNodeTree.Child;
            minNodeTree.Child = other;
            minNodeTree.Degree++;
        }

        private static Node<T> merge(
            BinomialHeap<T> heap1, BinomialHeap<T> heap2)
        {
            if (heap1.head == null)
            {
                return heap2.head;
            }
            else if (heap2.head == null)
            {
                return heap1.head;
            }
            else
            {
                Node<T> head;
                Node<T> heap1Next = heap1.head;
                Node<T> heap2Next = heap2.head;

                if (heap1.head.Degree <= heap2.head.Degree)
                {
                    head = heap1.head;
                    heap1Next = heap1Next.Sibling;
                }
                else
                {
                    head = heap2.head;
                    heap2Next = heap2Next.Sibling;
                }

                Node<T> tail = head;

                while (heap1Next != null && heap2Next != null)
                {
                    if (heap1Next.Degree <= heap2Next.Degree)
                    {
                        tail.Sibling = heap1Next;
                        heap1Next = heap1Next.Sibling;
                    }
                    else
                    {
                        tail.Sibling = heap2Next;
                        heap2Next = heap2Next.Sibling;
                    }

                    tail = tail.Sibling;
                }

                if (heap1Next != null)
                {
                    tail.Sibling = heap1Next;
                }
                else
                {
                    tail.Sibling = heap2Next;
                }

                return head;
            }
        }

        public void print()
        {
            Console.WriteLine("Binomial heap:");
            if (head != null)
            {
                head.print(0);
            }
        }


        // Union two binomial heaps into one and return the head
        public Node<T> union(BinomialHeap<T> heap)
        {
            Node<T> newHead = merge(this, heap);

            head = null;
            heap.head = null;

            if (newHead == null)
            {
                return null;
            }

            Node<T> prev = null;
            Node<T> curr = newHead;
            Node<T> next = newHead.Sibling;

            while (next != null)
            {
                if (curr.Degree != next.Degree || (next.Sibling != null &&
                        next.Sibling.Degree == curr.Degree))
                {
                    prev = curr;
                    curr = next;
                }
                else
                {
                    if (curr.CompareTo(next) < 0)
                    {
                        curr.Sibling = next.Sibling;
                        linkTree(curr, next);
                    }
                    else
                    {
                        if (prev == null)
                        {
                            newHead = next;
                        }
                        else
                        {
                            prev.Sibling = next;
                        }

                        linkTree(next, curr);
                        curr = next;
                    }
                }

                next = curr.Sibling;
            }

            return newHead;
        }

        public T findMinimum()
        {
            if (head == null)
            {
                return default;
            }
            else
            {
                Node<T> min = head;
                Node<T> next = min.Sibling;

                while (next != null)
                {
                    if (next.CompareTo(min) < 0)
                    {
                        min = next;
                    }
                    next = next.Sibling;
                }

                return min.Key;
            }
        }

        // Implemented to test delete/decrease key, runs in O(n) time
        public Node<T> search(T key)
        {
            List<Node<T>> nodes = new List<Node<T>>();
            nodes.Add(head);
            while (!nodes.Any())
            {
                Node<T> curr = nodes[0];
                nodes.RemoveAt(0);
                if (curr.Key.Equals(key))
                {
                    return curr;
                }
                if (curr.Sibling != null)
                {
                    nodes.Add(curr.Sibling);
                }
                if (curr.Child != null)
                {
                    nodes.Add(curr.Child);
                }
            }
            return null;
        }
        private Node<T> bubbleUp(Node<T> node, bool toRoot)
        {
            Node<T> parent = node.Parent;
            while (parent != null && (toRoot || node.CompareTo(parent) < 0))
            {
                T temp = node.Key;
                node.Key = parent.Key;
                parent.Key = temp;
                node = parent;
                parent = parent.Parent;
            }
            return node;
        }
        public void decreaseKey(Node<T> node, T newKey)
        {
            node.Key = newKey;
            bubbleUp(node, false);
        }

        public void delete(Node<T> node)
        {
            node = bubbleUp(node, true);
            if (head == node)
            {
                removeTreeRoot(node, null);
            }
            else
            {
                Node<T> prev = head;
                while (prev.Sibling.CompareTo(node) != 0)
                {
                    prev = prev.Sibling;
                }
                removeTreeRoot(node, prev);
            }
        }

        public T extractMin()
        {
            if (head == null)
            {
                return default;
            }

            Node<T> min = head;
            Node<T> minPrev = null;
            Node<T> next = min.Sibling;
            Node<T> nextPrev = min;

            while (next != null)
            {
                if (next.CompareTo(min) < 0)
                {
                    min = next;
                    minPrev = nextPrev;
                }
                nextPrev = next;
                next = next.Sibling;
            }

            removeTreeRoot(min, minPrev);
            return min.Key;
        }

        private void removeTreeRoot(Node<T> root, Node<T> prev)
        {
            // Remove root from the heap
            if (root == head)
            {
                head = root.Sibling;
            }
            else
            {
                prev.Sibling = root.Sibling;
            }

            // Reverse the order of root's children and make a new heap
            Node<T> newHead = null;
            Node<T> child = root.Child;
            while (child != null)
            {
                Node<T> next = child.Sibling;
                child.Sibling = newHead;
                child.Parent = null;
                newHead = child;
                child = next;
            }
            BinomialHeap<T> newHeap = new BinomialHeap<T>(newHead);

            // Union the heaps and set its head as this.head
            head = union(newHeap);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            BinomialHeap<int> obj = new BinomialHeap<int>();
            obj.insert(7);
            obj.insert(26);
            obj.insert(30);
            obj.insert(39);
            obj.insert(10);
            obj.insert(6);
            obj.print();
            Console.WriteLine("Min: " + obj.extractMin());
            obj.print();
        }
    }
}
