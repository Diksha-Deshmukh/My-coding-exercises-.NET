public class Solution {
    public int MaxArea(int[] height) {
        int maxArea = 0;
        int leftI = 0;
        int rightI = height.Length - 1;

        while(leftI < rightI)
        {
            if(height[leftI] <= height[rightI])
            {
                int localArea = height[leftI] * (rightI - leftI);
                maxArea = Math.Max(maxArea, localArea);
                leftI++;
            }
            else
            {
                int localArea = height[rightI] * (rightI - leftI);
                maxArea = Math.Max(maxArea, localArea);
                rightI--;
            }
        }
        return maxArea;
    }
}