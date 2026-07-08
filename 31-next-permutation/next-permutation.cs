public class Solution {
    public void NextPermutation(int[] nums) {
        int n = nums.Length;
        
        // Step 1: Find the first index `i` from the right where nums[i] < nums[i + 1]
        int i = n - 2;
        while (i >= 0 && nums[i] >= nums[i + 1]) {
            i--;
        }

        if (i >= 0) {
            // Step 2: Find the smallest number greater than nums[i] to swap with, starting from the end
            int j = n - 1;
            while (nums[j] <= nums[i]) {
                j--;
            }

            // Step 3: Swap nums[i] and nums[j]
            Swap(nums, i, j);
        }

        // Step 4: Reverse the subarray from i+1 to the end
        Reverse(nums, i + 1, n - 1);
    }

    // Helper function to swap elements at indices i and j
    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    // Helper function to reverse the subarray from start to end
    private void Reverse(int[] nums, int start, int end) {
        while (start < end) {
            Swap(nums, start, end);
            start++;
            end--;
        }
    }
}