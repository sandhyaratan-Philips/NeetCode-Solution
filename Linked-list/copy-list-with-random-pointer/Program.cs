using System;
using System.Collections.Generic;

namespace copy_list_with_random_pointer
{
    class Program
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
        public Node CopyRandomList(Node head)
        {
            Dictionary<Node, Node> pairs = new Dictionary<Node, Node>();
            Node curr = head;

            //pass 1: make copy
            while (curr != null)
            {
                Node copy = new Node(curr.val);
                pairs.Add(curr, copy);
                curr = curr.next;
            }

            //pass 2: make connections
            curr = head;

            while (curr != null)
            {
                pairs[curr].next = curr.next == null ? null : pairs[curr.next];
                pairs[curr].random = curr.random == null ? null : pairs[curr.random];
                curr = curr.next;
            }
            return head == null ? null : pairs[head];

        }

        public Node head;

        public void AddFirst(int data)
        {
            Node toAdd = new Node(data);
            toAdd.next = head;

            head = toAdd;
        }

        public void AddRandam(int data, int nodeVal)
        {
            Node node = head;
            while (node != null)
            {
                if (node.val == nodeVal)
                {
                    break;
                }
                node = node.next;
            }
            if (data == -1)
            {
                node.random = null;
            }
            else
            {
                Node node2 = head;
                for (int i = 0; i < data; i++)
                {
                    node2 = node2.next;
                }

                node.random = node2;
            }
        }

        static void Main(string[] args)
        {

            Program program = new Program();

            program.AddFirst(1);
            program.AddFirst(10);
            program.AddFirst(11);
            program.AddFirst(13);
            program.AddFirst(7);

            program.AddRandam(0, 1);
            program.AddRandam(2, 10);
            program.AddRandam(4, 11);
            program.AddRandam(0, 13);
            program.AddRandam(-1, 7);

            program.CopyRandomList(program.head);

            Program program1 = new Program();

            Console.WriteLine("Hello World!");
        }
    }
}
