public class Solution
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 1 && target == nums[0]) return 0;
        if (nums.Length == 1 && target != nums[0]) return -1;

        return FindNextMid(nums,target,0,nums.Length - 1);
    }

    private int FindNextMid(int[] nums, int target, int start, int end)
    {
        if(end < start) return -1;
        int midIndex = start + (end - start) / 2;
        if (start == end && target != nums[start]) return -1;
        if (start == end && target == nums[start]) return start;
        int index = FindNextMid(nums,target,start,midIndex);
        if (index < 0) index = FindNextMid(nums,target,midIndex + 1,end);
        return index;
    }
}