using Common;
using System;

namespace perfect_binary_tree
{
    class Program
    {
        //A perfect binary tree is a type of binary tree in which every internal node has exactly two child nodes and all the leaf nodes are at the same level.

        int depth(Node node)
        {
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.LeftNode;
            }
            return count;
        }

        bool is_Perfect(Node node, int depth, int level)
        {
            if (node == null)
                return true;

            if (node.RightNode == null && node.LeftNode == null)
                return depth == (level + 1);

            if ((node.RightNode == null && node.LeftNode != null) || (node.LeftNode == null && node.RightNode != null))
                return false;

            return is_Perfect(node.RightNode, depth, level + 1) && is_Perfect(node.LeftNode, depth, level + 1);

        }

        void is_Perfect(Node node)
        {
            Console.WriteLine("Is perfect:" + is_Perfect(node, depth(node), 0));
        }


        static void Main(string[] args)
        {
            Helper helper = new Helper();
            helper.add(1);
            helper.root.LeftNode = new Node(2);
            helper.root.RightNode = new Node(3);

            helper.root.LeftNode.LeftNode = new Node(4);
            helper.root.LeftNode.RightNode = new Node(5);

            helper.root.RightNode.LeftNode = new Node(6);
            //helper.root.RightNode.RightNode = new Node(7);

            Program program = new Program();
            program.is_Perfect(helper.root);

        }
    }
}
