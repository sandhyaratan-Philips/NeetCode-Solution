using System;

namespace Common
{
    public class Node
    {
        public int data { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        public Node(int val = 0)
        {
            data = val;
            LeftNode = RightNode = null;
        }
    }
    public class Helper
    {

        public Node root;

        public void add(int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                Node prev = current;

                while (current != null)
                {
                    if (value < current.data)
                    {
                        prev = current;
                        current = current.LeftNode;
                    }
                    else if (value > current.data)
                    {
                        prev = current;
                        current = current.RightNode;
                    }
                }

                if (value < prev.data)
                {
                    prev.LeftNode = newNode;
                }
                else
                {
                    prev.RightNode = newNode;
                }

            }
        }

        public int depth(Node node)
        {
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.LeftNode;
            }
            return count;
        }

        public void printNodes(Node node)
        {
            if (node == null)
                return;




            printNodes(node.LeftNode);
            Console.Write(node.data + "-> ");
            printNodes(node.RightNode);

        }
    }
}
