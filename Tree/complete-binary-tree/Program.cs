using Common;
using System;

namespace complete_binary_tree
{
    class Program
    {

        /*
        A complete binary tree is a binary tree in which all the levels are completely filled except possibly the lowest one, which is filled from the left.

        A complete binary tree is just like a full binary tree, but with two major differences

        All the leaf elements must lean towards the left.
        The last leaf element might not have a right sibling i.e. a complete binary tree doesn't have to be a full binary tree.
        */


        int countNumNodes(Node root)
        {
            if (root == null)
                return (0);
            return (1 + countNumNodes(root.LeftNode) + countNumNodes(root.RightNode));
        }

        // Check for complete binary tree
        bool checkComplete(Node root, int index, int numberNodes)
        {

            // Check if the tree is empty
            if (root == null)
                return true;

            if (index >= numberNodes)
                return false;

            return (checkComplete(root.LeftNode, 2 * index + 1, numberNodes)
                && checkComplete(root.RightNode, 2 * index + 2, numberNodes));
        }


        static void Main(string[] args)
        {
            Helper helper = new Helper();
            helper.add(1);
            helper.root.LeftNode = new Node(2);
            helper.root.RightNode = new Node(3);

            helper.root.LeftNode.LeftNode = new Node(4);
            helper.root.LeftNode.RightNode = new Node(5);

            //helper.root.RightNode.LeftNode = new Node(6);
            helper.root.RightNode.RightNode = new Node(7);

            Program program = new Program();
            Console.WriteLine("is complete:" + program.checkComplete(helper.root, 0, program.countNumNodes(helper.root)));

        }
    }
}
