using Common;
using System;

namespace balanced_binary_tree
{
    class Program
    {
        //time: O(n)
        int isBalanced(Node root)
        {
            if (root == null)
                return 0;
            int lh = isBalanced(root.LeftNode);
            if (lh == -1)
                return -1;
            int rh = isBalanced(root.RightNode);
            if (rh == -1)
                return -1;

            if (lh > rh + 1 || rh > lh + 1)
                return -1;
            else
                return Math.Max(lh, rh) + 1;
        }
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            helper.add(1);
            helper.root.LeftNode = new Node(2);
            helper.root.RightNode = new Node(3);

            helper.root.LeftNode.LeftNode = new Node(4);
            helper.root.LeftNode.RightNode = new Node(5);

            //helper.root.LeftNode.RightNode.LeftNode = new Node(6);


            Program program = new Program();
            Console.WriteLine("is balanced:" + (program.isBalanced(helper.root) > 0 ? "true" : "false"));
        }
    }
}
