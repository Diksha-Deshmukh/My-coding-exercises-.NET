public class Solution {
    public int Trap(int[] height) {
        int res = 0;
        int maxI = 0;
        int left = 0;
        int right = 0;
        for(int i = 1; i < height.Length; i++)
        {
            if(height[i] > height[maxI])
            {
                maxI = i;
            }
        }
        for(int i = 0; i < maxI; i++)
        {
            if(height[i] > left)
            {
                left = height[i];
            }
            else
            {
                res += left - height[i];
            }
        }
        for(int i = height.Length - 1; i > maxI; i--)
        {
            if(height[i] > right)
            {
                right = height[i];
            }
            else
            {
                res += right - height[i];
            }
        }
        return res;
    }
}