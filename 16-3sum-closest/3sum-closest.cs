public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        if(nums.Length<3) return 0;
        Array.Sort(nums);
        int closestSum = nums[0]+nums[1]+nums[2];

        for(int i=0;i<nums.Length;i++){
            if(i>0 && nums[i]== nums[i-1]) continue;
            int j=i+1;
            int k= nums.Length-1;
            while(j<k){
                var sum = nums[i]+nums[j]+nums[k];
                if(sum==target)return sum;
                
                if(Math.Abs(target-sum)<Math.Abs(target-closestSum)){
                    closestSum = sum;
                }
                if(sum>target){
                    k--;
                }else{
                    j++;
                }
            }
        }

        return closestSum;
    }
}