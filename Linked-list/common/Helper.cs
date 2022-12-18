using System;

namespace common
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
    public class Helper
    {
        public ListNode head;

        public void AddFirst(int data)
        {
            ListNode toAdd = new ListNode(data);
            toAdd.next = head;

            head = toAdd;
        }
        public void printAllNodes()
        {
            Console.WriteLine("The List: ");
            ListNode current = head;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
        }

        public void AddLast(int data)
        {
            if (head == null)
            {
                head = new ListNode();

                head.val = data;
                head.next = null;
            }
            else
            {
                ListNode toAdd = new ListNode();
                toAdd.val = data;

                ListNode current = head;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
        }
    }
}
