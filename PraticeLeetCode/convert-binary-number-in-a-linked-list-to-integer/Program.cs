using System;

namespace convert_binary_number_in_a_linked_list_to_integer
{
    /*
     * 1290. Convert Binary Number in a Linked List to Integer

        Given head which is a reference node to a singly-linked list. The value of each node in the linked list is either 0 or 1. The linked list holds the binary representation of a number.

        Return the decimal value of the number in the linked list.

        The most significant bit is at the head of the linked list.
        Example 1:

        Input: head = [1,0,1]
        Output: 5
        Explanation: (101) in base 2 = (5) in base 10
    */
    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public int GetDecimalValue(ListNode head)
        {
            if (head == null)
                return 0;
            string str = head.val.ToString();
            while (head.next != null)
            {
                head = head.next;
                str += head.val.ToString();
            }

            return Convert.ToInt32(str, 2);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode node = new ListNode(1, new ListNode(0));
            node.next.next = new ListNode(0);
            Console.WriteLine(program.GetDecimalValue(node));
        }
    }
}
