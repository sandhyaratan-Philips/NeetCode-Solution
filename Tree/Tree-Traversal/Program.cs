using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree_Traversal
{
    // time:O(n)
    //space: O(log n)
    //https://www.interviewkickstart.com/learn/tree-traversals-inorder-preorder-and-postorder
    class Program
    {
        /*
        First, visit all the nodes in the left subtree
        Then the root node
        Visit all the nodes in the right subtree
        */
        void InOrder(Node node)
        {
            if (node == null)
                return;

            InOrder(node.LeftNode);
            Console.Write("->" + node.data);
            InOrder(node.RightNode);
        }


        /*
        Visit root node
        Visit all the nodes in the left subtree
        Visit all the nodes in the right subtree
        */
        void PreOrder(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.data + "->");
            PreOrder(node.LeftNode);
            PreOrder(node.RightNode);

        }

        /*
        Visit all the nodes in the left subtree
        Visit all the nodes in the right subtree
        Visit the root node
        */
        void PostOrder(Node node)
        {
            if (node == null)
                return;


            PostOrder(node.LeftNode);
            PostOrder(node.RightNode);
            Console.Write("->" + node.data);
        }


        void LevelOrder(Node node)
        {
            LinkedList<Node> queue = new LinkedList<Node>();
            queue.AddLast(node);

            while (queue.Any())
            {
                node = queue.First();
                if (node != null)
                {
                    Console.Write(node.data + " ");

                    queue.AddLast(node.LeftNode);
                    queue.AddLast(node.RightNode);
                }
                queue.RemoveFirst();
            }
        }



        static void Main(string[] args)
        {
            Helper helper = new Helper();
            helper.add(4);
            helper.add(1);
            helper.add(2);
            helper.add(5);
            helper.add(3);

            Program program = new Program();

            Console.WriteLine("Inorder Traversal");
            program.InOrder(helper.root);

            Console.WriteLine("\n PreOrder Traversal");
            program.PreOrder(helper.root);

            Console.WriteLine("\n PostOrder Traversal");
            program.PostOrder(helper.root);

            Console.WriteLine("\n LevelOrder Traversal");
            program.LevelOrder(helper.root);

        }
    }
}
