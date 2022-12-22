using common;
using System;
using System.Collections.Generic;

namespace merge_k_sorted_lists
{
    class Program
    {
        //time: O(n*LogK)
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            if (list1.val > list2.val)
            {
                list2.next = MergeTwoLists(list2.next, list1);
                return list2;
            }
            else
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
        }
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;

            int j = 0;

            while (lists.Length > 1)
            {
                List<ListNode> mergedLists = new List<ListNode>();
                for (int i = 0; i < lists.Length; i = i + 2)
                {
                    ListNode list1 = lists[i];
                    ListNode list2 = i + 1 < lists.Length ? lists[i + 1] : null;
                    mergedLists.Add(MergeTwoLists(list1, list2));
                }
                lists = mergedLists.ToArray();
            }
            return lists[0];

        }
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            helper.AddFirst(5);
            helper.AddFirst(4);
            helper.AddFirst(1);

            helper.printAllNodes();

            Helper helper1 = new Helper();
            helper1.AddFirst(4);
            helper1.AddFirst(3);
            helper1.AddFirst(1);

            helper1.printAllNodes();

            Helper helper2 = new Helper();
            helper2.AddFirst(6);
            helper2.AddFirst(2);

            helper2.printAllNodes();

            Program program = new Program();

            helper.head = program.MergeKLists(new ListNode[] { helper.head, helper1.head, helper2.head });

            helper.printAllNodes();
            Console.WriteLine("Hello World!");
        }
    }
}
