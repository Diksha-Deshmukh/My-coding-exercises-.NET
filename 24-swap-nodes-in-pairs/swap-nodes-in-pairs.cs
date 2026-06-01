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
public class Solution {
    public ListNode SwapPairs(ListNode head) {
       if(head == null) return null;
        if(head.next == null) return head;
                
        ListNode node = head.next;
      
        if(head.next != null){
            ListNode temp = node.next;

            head.next = temp;
            node.next = head;

            var result = SwapPairs(head.next);
            
            head.next = result;
        }
        
        return node;        
    }
}