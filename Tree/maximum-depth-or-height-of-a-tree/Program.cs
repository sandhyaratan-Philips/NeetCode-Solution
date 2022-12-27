using Common;
using System;

namespace maximum_depth_or_height_of_a_tree
{
    class Program
    {
        Node root;
        static void Main(string[] args)
        {
            Program tree = new Program();

            tree.root = new Node(1);
            tree.root.LeftNode = new Node(2);
            tree.root.RightNode = new Node(3);
            tree.root.LeftNode.LeftNode = new Node(4);
            tree.root.LeftNode.RightNode = new Node(5);

            Console.WriteLine("Height of tree is "
                              + tree.maxDepth(tree.root));
        }

        private int maxDepth(Node root)
        {
            if (root == null)
                return 0;
            else
            {
                int LeftLength = maxDepth(root.LeftNode);
                int rightlength = maxDepth(root.RightNode);
                return Math.Max(LeftLength, rightlength) + 1;
            }

        }
    }
}
