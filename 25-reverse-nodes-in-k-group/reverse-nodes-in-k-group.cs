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
    public ListNode ReverseKGroup(ListNode head, int k)
     {
        if (head == null || k == 1) return head;

        // Count the number of nodes
        ListNode temp = head;
        int count = 0;
        while (temp != null && count < k) 
        {
            temp = temp.next;
            count++;
        }

        // If we have at least k nodes, reverse them
        if (count == k)
         {
            ListNode prev = null, curr = head, next = null;
            int i = 0;
            while (i < k)
             {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                i++;
            }
            // head is now the tail of the reversed group
            // connect it with the result of next reversed part
            head.next = ReverseKGroup(curr, k);
            return prev; // prev is the new head after reversal
        }

        // If less than k nodes, return as-is
        return head;
    }
}