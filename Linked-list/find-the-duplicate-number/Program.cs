using System;

namespace find_the_duplicate_number
{
    class Program
    {
        //Fast and slow pointer approach
        // Time Complexity: O(n)
        // Space Complexity: O(1)

        public int FindDuplicate(int[] nums)
        {
            int slow = nums[0];
            int fast = nums[0];

            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
                if (slow == fast) break;
            } while (slow != fast);

            int slow2 = nums[0];

            while (slow2 != slow)
            {
                slow2 = nums[slow2];
                slow = nums[slow];
                if (slow2 == slow) return slow;
            }
            return slow;

        }
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("repeated: " + program.FindDuplicate(new int[] { 3, 1, 3, 4, 2 }));


        }
    }
}
