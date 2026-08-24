public class Solution {
    public int FirstMissingPositive(int[] nums) {
        HashSet<int> set = new HashSet<int>(nums);
        int i = 1;
        while (set.Contains(i)) i++;
        return i;
    }
}