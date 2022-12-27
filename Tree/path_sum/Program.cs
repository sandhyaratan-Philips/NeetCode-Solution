using Common;
using System;
using System.Collections.Generic;

namespace path_sum
{

    //Given a binary tree and a sum, find all root-to-leaf
    //paths where each path's sum equals the given sum.
    //For example:
    //Given the below binary tree and sum = 22,
    //              5
    //             / \
    //            4   8
    //           /   / \
    //          11  13  4
    //         /  \    / \
    //        7    2  5   1
    //return
    //[
    //   [5,4,11,2],
    //   [5,8,4,5]
    //]
    class Program
    {
        IList<IList<int>> list = new List<IList<int>>();
        Node root;
        void path_sum(int sum)
        {
            if (root == null)
                return;
            List<int> path = new List<int>();
            path_sum2(root, sum, 0, path);
        }
        void path_sum2(Node root, int sum, int sum_so_far, List<int> path)
        {
            if (root == null)
            {
                return;
            }



            sum_so_far += root.data;

            // Add the value to path
            path.Add(root.data);

            // Print the required path
            if (sum_so_far == sum)
            {
                Console.WriteLine("Path found: ");
                for (int i = 0; i < path.Count; i++)
                    Console.Write(path[i] + " ");
                Console.WriteLine();
            }

            // If left child exists
            if (root.LeftNode != null)
                path_sum2(root.LeftNode, sum,
                               sum_so_far, path);

            // If right child exists
            if (root.RightNode != null)
                path_sum2(root.RightNode, sum,
                               sum_so_far, path);

            // Remove last element from path
            // and move back to parent
            path.RemoveAt(path.Count - 1);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Node root = new Node(10);
            program.root = root;
            program.root.LeftNode = new Node(28);
            program.root.RightNode = new Node(13);

            program.root.RightNode.LeftNode = new Node(14);
            program.root.RightNode.RightNode = new Node(15);

            program.root.RightNode.LeftNode.LeftNode = new Node(21);
            program.root.RightNode.LeftNode.RightNode = new Node(22);
            program.root.RightNode.RightNode.LeftNode = new Node(23);
            program.root.RightNode.RightNode.RightNode = new Node(24);

            program.path_sum(38);
        }
    }
}
