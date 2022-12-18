using common;

namespace reorder_list
{
    class Program
    {
        public void ReorderList(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode second = slow.next;
            ListNode prv = slow.next = null;
            while (second != null)
            {
                ListNode temp = second.next;
                second.next = prv;
                prv = second;
                second = temp;
            }

            ListNode first = head;
            second = prv;

            while (second != null)
            {
                ListNode temp1 = first.next;
                ListNode temp2 = second.next;

                first.next = second;
                second.next = temp1;

                first = temp1;
                second = temp2;

            }

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
            program.ReorderList(helper.head);
            helper.printAllNodes();

        }
    }
}
