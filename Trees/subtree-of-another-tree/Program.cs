using Helper;
using System;

namespace subtree_of_another_tree
{
    /*
     * Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.

        A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.

    */
    class Program
    {
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null)
                return true;

            if (root == null || subRoot == null)
                return false;
            if (isSameTree(root, subRoot))
                return true;

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }
        private bool isSameTree(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null)
            {
                return true;
            }
            if (root == null || subRoot == null)
            {
                return false;
            }
            if (root.val == subRoot.val)
            {
                return (
                    isSameTree(root.left, subRoot.left) &&
                    isSameTree(root.right, subRoot.right)
                );
            }

            return false;
        }
        static void Main(string[] args)
        {
            CommonHelper helper = new CommonHelper();
            CommonHelper.root = new TreeNode(1);
            CommonHelper.root.left = new TreeNode(2);
            CommonHelper.root.right = new TreeNode(3);
            CommonHelper.root.left.left = new TreeNode(4);
            CommonHelper.root.left.right = new TreeNode(5);
            Console.WriteLine("Hello World!");
        }
    }
}
