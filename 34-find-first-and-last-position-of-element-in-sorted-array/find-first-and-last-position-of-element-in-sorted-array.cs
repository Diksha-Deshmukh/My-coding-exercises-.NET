public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        var emptyArray = new int[2] {-1, -1};
        if (nums.Length == 0)
            return emptyArray;
        var firstIndex = Array.FindIndex(nums, x => x == target);
        var secondIndex = Array.FindLastIndex(nums, x => x == target);
        return new int[2] {firstIndex, secondIndex};
    }
}