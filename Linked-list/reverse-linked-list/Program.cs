using common;

namespace reverse_linked_list
{

    class Program
    {
        public ListNode ReverseList(ListNode head)
        {
            return rev(head, null); ;
        }

        public ListNode rev(ListNode node, ListNode pre)
        {
            if (node == null) return pre;

            ListNode temp = node.next;
            node.next = pre;
            return rev(temp, node);
        }
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            Program program = new Program();
            helper.AddFirst(3);
            helper.AddFirst(2);
            helper.AddFirst(1);

            helper.printAllNodes();

            helper.head = program.ReverseList(helper.head);
            helper.printAllNodes();
        }
    }
}
