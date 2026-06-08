public class Solution {
    public int RemoveElement(int[] nums, int val) {
        //sort wont matter
        int lIndex = 0;
        int rIndex = nums.Length - 1;

        //lIndex should find val accurs
        //rIndex should find nonVal accurs to trade it with lIndex

        while(lIndex < rIndex && lIndex < nums.Length && rIndex >= 0){
            if(nums[lIndex] != val){
                lIndex++;
                continue;
            }
            if(nums[rIndex] == val){
                rIndex--;
                continue;
            }

            //#No need for swapping the val
            nums[lIndex] = nums[rIndex];
            nums[rIndex] = val;
            lIndex++;
            rIndex--;
        }
        if(lIndex >= nums.Length) return nums.Length;
        return nums[lIndex] == val ? lIndex : lIndex + 1;
    }
}