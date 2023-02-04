using Helper;
using System;

namespace invert_binary_tree
{
    /*
     * Given the root of a binary tree, invert the tree, and return its root.
     */

    class Program
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            TreeNode node = new TreeNode(root.val);
            node.left = InvertTree(root.right);
            node.right = InvertTree(root.left);
            return node;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
