using Common;
using System;

namespace FullBinaryTree
{
    class Program
    {
        //A full Binary tree is a special type of binary tree in which every parent node/internal node has either two or no children.
        bool isFullBinaryTree(Node node)
        {
            if (node == null)
                return true;

            if (node.RightNode == null && node.LeftNode == null)
                return true;

            if (node.RightNode != null && node.LeftNode != null)
                return isFullBinaryTree(node.RightNode) && isFullBinaryTree(node.LeftNode);

            return false;
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
            //  helper.root.RightNode.RightNode = new Node(7);

            Program program = new Program();

            Console.WriteLine("isFullBinaryTree: " + program.isFullBinaryTree(helper.root));
        }
    }
}
