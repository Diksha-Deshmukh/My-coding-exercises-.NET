//Diksha

public class Solution {
    public int Jump(int[] nums) {
        //start with a finding the range we can reach at 0 index,
        //take the largest we number in that range and set new left and right bound
        //left = right +1
        //right = farthest 
        //increase jumps
        //repeast till end of nums

        var left = 0;
        var right = 0;
        var jumps = 0;

        while(right < nums.Length-1){
            //find the largest
            var largest = right;
            //loop over all numbers in range of index 
            for(int i = left; i <= right; i++){
                largest = Math.Max(largest, i+nums[i]);
            }

            left = right+1;
            right = largest;
            jumps++;
        }

        return jumps;
    }
}