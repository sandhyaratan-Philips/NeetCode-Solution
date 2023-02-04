using Helper;
using System;

namespace same_tree
{
    /*
     * Given the roots of two binary trees p and q, write a function to check if they are the same or not.

        Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
    */
    class Program
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p != null && q != null && p.val == q.val)
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
