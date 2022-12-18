using common;
using System;

namespace add_two_numbers
{
    class Program
    {
        public ListNode AddTwoNumbers(ListNode first, ListNode second)
        {
            int q = 0;
            int r = 0;
            int sum = 0;
            ListNode head = null;
            ListNode temp = null;
            while (first != null || second != null)
            {
                sum =
                    q +
                    (
                        ((first != null) ? first.val : 0) +
                        ((second != null) ? second.val : 0)
                    );
                r = sum % 10;
                q = sum / 10;
                ListNode newNode = new ListNode(r);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    temp = head;
                    while (temp.next != null)
                    {
                        temp = temp.next;
                    }
                    temp.next = newNode;
                    newNode.next = null;
                }
                if (first != null)
                {
                    first = first.next;
                }
                if (second != null)
                {
                    second = second.next;
                }
            }
            if (q > 0)
            {
                ListNode newNode = new ListNode(q);
                temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
                newNode.next = null;
            }
            return head;
        }
        static void Main(string[] args)
        {
            Helper helper = new Helper();

            helper.AddLast(9);
            helper.AddLast(9);
            helper.AddLast(1);

            Helper helper1 = new Helper();
            helper1.AddLast(1);

            Program program = new Program();

            helper.head = program.AddTwoNumbers(helper.head, helper1.head);

            helper.printAllNodes();

            Console.WriteLine("Hello World!");
        }
    }
}
