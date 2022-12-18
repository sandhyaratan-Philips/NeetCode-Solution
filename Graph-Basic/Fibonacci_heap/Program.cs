using System;
using System.Collections.Generic;
using System.Text;

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



                public void print(int level)
                {
                    Node<T> curr = this;
                    T asd = curr.Key;
                    do
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
                        curr = curr.Next;
                    } while (curr != null && !curr.Key.Equals(asd));
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

            public void insert(T key)
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

            public T ExtractMinimum()
            {
                Node<T> extractedMin = _minNode;
                if (extractedMin != null)
                {
                    if (extractedMin.Child != null)
                    {
                        Node<T> child = extractedMin.Child;
                        do
                        {
                            child.Parent = null;
                            child = child.Next;
                        } while (child != extractedMin.Child);
                    }
                    Node<T> nextInRootList = extractedMin.Next == extractedMin ? null : extractedMin.Next;
                    RemoveNodeFromList(extractedMin);
                    Size--;

                    // Merge the children of the minimum node with the root list
                    _minNode = MergeLists(nextInRootList, extractedMin.Child);

                    if (nextInRootList != null)
                    {
                        _minNode = nextInRootList;
                        Consolidate();
                    }
                }
                return extractedMin.Key;
            }

            private void RemoveNodeFromList(Node<T> node)
            {
                Node<T> prev = node.Prev;
                Node<T> next = node.Next;
                prev.Next = next;
                next.Prev = prev;

                node.Next = node;
                node.Prev = node;
            }

            /// <summary>
            /// Merge all trees of the same order together until there are no two trees of the same
            /// order.
            /// </summary>
            private void Consolidate()
            {
                if (_minNode == null)
                    return;

                List<Node<T>> aux = new List<Node<T>>();
                var items = GetRootTrees();

                foreach (var current in items)
                {
                    var top = current;

                    while (aux.Count < top.Degree + 1)
                    {
                        aux.Add(null);
                    }
                    // If there exists another node with the same degree, merge them
                    while (aux[top.Degree] != null)
                    {
                        if (top.CompareTo(aux[top.Degree]) > 0)
                        {
                            Node<T> temp = top;
                            top = aux[top.Degree];
                            aux[top.Degree] = temp;
                        }
                        LinkHeaps(aux[top.Degree], top);
                        aux[top.Degree] = null;
                        top.Degree++;
                    }

                    while (aux.Count <= top.Degree + 1)
                    {
                        aux.Add(null);
                    }
                    aux[top.Degree] = top;
                }

                _minNode = null;
                for (int i = 0; i < aux.Count; i++)
                {
                    if (aux[i] != null)
                    {
                        // Remove siblings before merging
                        aux[i].Next = aux[i];
                        aux[i].Prev = aux[i];
                        _minNode = MergeLists(_minNode, aux[i]);
                    }
                }
            }
            /// <summary>
            /// Links two heaps of the same order together.
            /// </summary>
            /// <param name="max">The heap with the larger root.</param>
            /// <param name="min">The heap with the smaller root.</param>
            private void LinkHeaps(Node<T> max, Node<T> min)
            {
                RemoveNodeFromList(max);
                min.Child = MergeLists(max, min.Child);
                max.Parent = min;
                max.IsMarked = false;
            }

            private IEnumerable<Node<T>> GetRootTrees()
            {
                var items = new Queue<Node<T>>();
                Node<T> current = _minNode;
                do
                {
                    items.Enqueue(current);
                    current = current.Next;
                } while (_minNode != current);
                return items;
            }

            public void print()
            {
                Console.WriteLine("Fibonacci heap:");
                if (_minNode != null)
                {
                    _minNode.print(0);
                }
            }
            /// <summary>
            /// Decreases a key of a node.
            /// </summary>
            /// </param name="node">The node to decrease the key of.</param>
            /// </param name="newKey">The new key to assign to the node.</param>
            public void DecreaseKey(Node<T> node, T newKey)
            {
                if (node == null)
                    throw new ArgumentException("node must be non-null.");

                if (Comparer<T>.Default.Compare(newKey, node.Key) > 0)
                    throw new ArgumentOutOfRangeException("New key is larger than old key.");

                node.Key = newKey;
                Node<T> parent = node.Parent;
                if (parent != null && node.CompareTo(parent) < 0)
                {
                    Cut(node, parent);
                    CascadingCut(parent);
                }
                if (node.CompareTo(_minNode) < 0)
                {
                    _minNode = node;
                }
            }

            /// <summary>
            /// Cut the link between a node and its parent, moving the node to the root list.
            /// </summary>
            /// <param name="node">The node being cut.</param>
            /// <param name="parent">The parent of the node being cut.</param>
            private void Cut(Node<T> node, Node<T> parent)
            {
                parent.Degree--;
                parent.Child = (node.Next == node ? null : node.Next);
                RemoveNodeFromList(node);
                MergeLists(_minNode, node);
                node.IsMarked = false;
            }

            /// <summary>
            /// Perform a cascading cut on a node; mark the node if it is not marked, otherwise cut the
            /// node and perform a cascading cut on its parent.
            /// </summary>
            /// <param name="node">The node being considered to be cut.</param>
            private void CascadingCut(Node<T> node)
            {
                Node<T> parent = node.Parent;
                if (parent != null)
                {
                    if (node.IsMarked)
                    {
                        Cut(node, parent);
                        CascadingCut(parent);
                    }
                    else
                    {
                        node.IsMarked = true;
                    }
                }
            }
            /// <summary>
            /// Deletes a node.
            /// </summary>
            /// <param name="node">The node to delete.</param>
            public void Delete(Node<T> node)
            {
                var casted = node as Node<T>;
                if (casted == null)
                    throw new ArgumentException("node must be a FibonacciHeap.Node");
                // This is a special implementation of decreaseKey that sets the
                // argument to the minimum value. This is necessary to make generic keys
                // work, since there is no MIN_VALUE constant for generic types.
                Node<T> parent = node.Parent;
                if (parent != null)
                {
                    Cut(node, parent);
                    CascadingCut(parent);
                }
                _minNode = node;

                ExtractMinimum();
            }

            /// <summary>
            /// Joins another heap to this heap.
            /// </summary>
            /// <param name="other">The other heap.</param>
            public void Union(FibonacciHeap<T> other)
            {
                if (other == null)
                    throw new ArgumentException("other must be a FibonacciHeap");
                _minNode = MergeLists(_minNode, other._minNode);
                Size += other.Size;
            }
        }

        static void Main(string[] args)
        {
            FibonacciHeap<int> obj = new FibonacciHeap<int>();
            obj.insert(7);
            obj.insert(26);
            obj.insert(30);
            obj.insert(39);
            obj.insert(10);
            obj.insert(6);
            obj.print();
            Console.WriteLine("Min: " + obj.ExtractMinimum());
            obj.print();

        }
    }
}
