using common;
using System;
using System.Collections.Generic;

namespace linked_list_cycle
{
    class Program
    {
        public bool HasCycle(ListNode head)
        {
            HashSet<ListNode> listNodes = new HashSet<ListNode>();

            while (head != null)
            {
                if (listNodes.Contains(head))
                {
                    return true;
                }
                listNodes.Add(head);
                head = head.next;
            }
            return false;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
