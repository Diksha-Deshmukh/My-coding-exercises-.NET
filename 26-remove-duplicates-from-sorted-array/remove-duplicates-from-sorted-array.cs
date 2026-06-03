public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var n = nums.Length;
        var k = 0;
        
        for (var i = 0; i < n; ++i)
        {
            var j = i + 1;

            while (j < n && nums[j] == nums[i]) ++j;
            
            nums[k++] = nums[i];
            
            i = j - 1;
        }

        return k;
    }
}