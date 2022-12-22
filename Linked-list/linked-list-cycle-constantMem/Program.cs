using common;
using System;

namespace linked_list_cycle_constantMem
{
    class Program
    {
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
