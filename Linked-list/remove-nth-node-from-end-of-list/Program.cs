using common;

namespace remove_nth_node_from_end_of_list
{
    class Program
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode node = new ListNode(0, head);
            ListNode leftNode = node;
            ListNode rightNode = head;
            while (n > 0 && rightNode != null)
            {
                rightNode = rightNode.next;
                n -= 1;
            }

            while (rightNode != null)
            {
                leftNode = leftNode.next;
                rightNode = rightNode.next;
            }

            // remove node
            leftNode.next = leftNode.next.next;
            return node.next;

        }
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            Program program = new Program();
            helper.AddFirst(5);
            helper.AddFirst(4);
            helper.AddFirst(3);
            helper.AddFirst(2);
            helper.AddFirst(1);
            program.RemoveNthFromEnd(helper.head, 2);
            helper.printAllNodes();

        }
    }
}
