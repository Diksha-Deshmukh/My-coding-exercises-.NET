/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        ListNode output = new ListNode(0);
        ListNode current = output;
        int minIndex, minValue;

        while (true)
        {
            minIndex = -1;
            minValue = int.MaxValue;

            for (int index = 0; index < lists.Length; index++)
            { 
                if (lists[index] != null && lists[index].val <= minValue)
                {
                    minValue = lists[index].val;
                    minIndex = index;
                }
            }

            if (minValue == int.MaxValue)
            {
                return output.next;
            }

            current.next = new ListNode(lists[minIndex].val);
            current = current.next;
            lists[minIndex] = lists[minIndex].next;
        }
    }

    private void PrintList(ListNode head)
    {
        Console.WriteLine("Printing list...");
        ListNode current = head;

        while (current != null)
        {
            Console.WriteLine(current.val);
            current = current.next;
        }
        Console.WriteLine("Done!");
    }
}
