public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int i=0;
        for(i=0;i<=nums.Length-1;i++){
            if(nums[i] <= target){
                if(nums[i] == target){
                    return i;
                }
            }
            else{
                return i;
            }
        }
        return i;
    }
}