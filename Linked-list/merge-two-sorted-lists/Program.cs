using common;

namespace merge_two_sorted_lists
{
    class Program
    {
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
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            helper.AddFirst(3);
            helper.AddFirst(2);
            helper.AddFirst(1);

            helper.printAllNodes();

            Helper helper1 = new Helper();
            helper1.AddFirst(3);
            helper1.AddFirst(2);
            helper1.AddFirst(1);

            helper.printAllNodes();

            Program program = new Program();

            helper.head = program.MergeTwoLists(helper.head, helper1.head);

            helper.printAllNodes();
        }
    }
}
