using common;
using System;

namespace reverse_nodes_in_k_group
{
    class Program
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode cur = head;
            int count = 0;
            while (cur != null && count != k)
            {
                cur = cur.next;
                count++;
            }
            if (count == k)
            {
                cur = ReverseKGroup(cur, k);
                while (count-- > 0)
                {
                    ListNode temp = head.next;
                    head.next = cur;
                    cur = head;
                    head = temp;
                }
                head = cur;
            }
            return head;
        }
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            helper.AddFirst(5);
            helper.AddFirst(4);
            helper.AddFirst(3);
            helper.AddFirst(2);
            helper.AddFirst(1);
            Program program = new Program();
            helper.head = program.ReverseKGroup(helper.head, 2);


            Console.WriteLine("Reversed:");
            helper.printAllNodes();

        }
    }
}
