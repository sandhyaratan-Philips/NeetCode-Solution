using Helper;
using System;

namespace balanced_binary_tree
{
    //Given a binary tree, determine if it is  height-balanced
    class Program
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            return isBalanced(root) > 0 ? true : false;
        }
        int isBalanced(TreeNode root)
        {
            if (root == null)
                return 0;
            int lh = isBalanced(root.left);
            if (lh == -1)
                return -1;
            int rh = isBalanced(root.right);
            if (rh == -1)
                return -1;

            if (lh > rh + 1 || rh > lh + 1)
                return -1;
            else
                return Math.Max(lh, rh) + 1;
        }


        static void Main(string[] args)
        {
            CommonHelper helper = new CommonHelper();
            CommonHelper.root = new TreeNode(1);
            CommonHelper.root.left = new TreeNode(2);
            CommonHelper.root.right = new TreeNode(3);
            CommonHelper.root.left.left = new TreeNode(4);
            CommonHelper.root.left.right = new TreeNode(5);

            Program program = new Program();
            Console.WriteLine("IsBalanced: " + program.IsBalanced(CommonHelper.root));
        }
    }
}
