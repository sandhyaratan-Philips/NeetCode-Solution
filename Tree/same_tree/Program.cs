using Common;
using System;

namespace same_tree
{
    class Program
    {
        //Given two binary trees, write a function to check
        //if they are equal or not.
        //Two binary trees are considered equal if they are
        //structurally identical and the nodes have the same value.

        bool is_same_tree(Node tree_p, Node tree_q)
        {
            if (tree_p == null && tree_q == null)
            {
                return true;
            }
            if (tree_p != null && tree_q != null && tree_q.data == tree_p.data)
                return is_same_tree(tree_p.LeftNode, tree_q.LeftNode) && is_same_tree(tree_p.RightNode, tree_q.RightNode);
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
