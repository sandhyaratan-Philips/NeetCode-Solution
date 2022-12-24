using Common;
using System;

namespace binary_search_tree
{
    class Program
    {
        //https://www.growingwiththeweb.com/data-structures/binary-search-tree/overview/
        /*
            It is called a search tree because it can be used to search for the presence of a number in O(log(n)) time.
            The properties that separate a binary search tree from a regular binary tree is

            All nodes of left subtree are less than the root node
            All nodes of right subtree are more than the root node
            Both subtrees of each node are also BSTs i.e. they have the above two properties
        */

        Node root = null;

        public void insert(int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return;
            }

            insert(key, root);

        }

        /**
         * Inserts a {@link BinarySearchTreeNode} with a specific key.
         *
         * @param key The key of the node being inserted.
         * @param node The current tree being looked at.
         */
        private void insert(int key, Node node)
        {
            if (node == null)
            {
                node = new Node(key);
                return;
            }

            if (key < node.data)
            {
                if (node.LeftNode != null)
                {
                    insert(key, node.LeftNode);
                }
                else
                {
                    node.LeftNode = (new Node(key));

                }
            }

            if (key > node.data)
            {
                if (node.RightNode != null)
                {
                    insert(key, node.RightNode);
                }
                else
                {
                    node.RightNode = new Node(key);

                }
            }
        }

        bool contains(int key, Node node)
        {
            if (key == node.data)
            {
                return true;
            }

            if (key < node.data)
            {
                if (node.LeftNode == null)
                {
                    return false;
                }
                return contains(key, node.LeftNode);
            }

            if (key > node.data)
            {
                if (node.RightNode == null)
                {
                    return false;
                }
                return contains(key, node.RightNode);
            }

            return false;
        }

        /*
        If the node has no children then it is simply deleted.
        If the node has only a left child node, move the left child to the deleted node’s position.
        If the node has only a right child node, move the right child to the deleted node’s position.
        If the node has both left and right children, the minimum node from the right sub-tree is moved to the deleted node’s position. If the minimum node had a right child, it is moved into the minimum node’s old position.
         */



        Node deleteInternal(int key, Node root)
        {
            if (root == null)
            {
                return root;
            }

            if (key < root.data)
                root.LeftNode = deleteInternal(key, root.LeftNode);
            else if (key > root.data)
                root.RightNode = deleteInternal(key, root.RightNode);
            else
            {
                //case 1: Node to be deleted has no children
                if (root.LeftNode == null && root.RightNode == null)
                {
                    //update root to null
                    root = null;
                }
                //case 2 : node to be deleted has two children
                else if (root.LeftNode != null && root.RightNode != null)
                {
                    Node maxNode = FindMax(root.RightNode);
                    //copy the value
                    root.data = maxNode.data;
                    root.RightNode = deleteInternal(maxNode.data, root.RightNode);
                }
                //node to be deleted has one children
                else
                {
                    var child = root.LeftNode != null ? root.LeftNode : root.RightNode;
                    root = child;
                }

            }
            return root;

        }

        private Node FindMax(Node node)
        {
            while (node.LeftNode != null)
            {
                node = node.LeftNode;
            }
            return node;
        }

        public void delete(int key)
        {
            deleteInternal(key, root);
        }



        static void Main(string[] args)
        {
            Helper helper = new Helper();

            Program program = new Program();
            program.insert(5);
            program.insert(3);
            program.insert(8);
            program.insert(1);
            program.insert(4);
            program.insert(6);
            program.insert(7);
            program.insert(9);

            helper.printNodes(program.root);
            Console.WriteLine("\n has: " + program.contains(56, program.root));

            Console.WriteLine("deletion:");
            program.delete(1);
            helper.printNodes(program.root);

            Console.WriteLine("\n deletion:");
            program.delete(6);
            helper.printNodes(program.root);

            Console.WriteLine("\n deletion:");
            program.delete(5);
            helper.printNodes(program.root);
        }
    }
}
