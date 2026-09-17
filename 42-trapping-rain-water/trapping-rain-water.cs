/*
1. Identify the pointer with the lesser value
2. Is this pointer value greater than or equal to max on that side
  yes -> update max on that side
  no -> get water for pointer, add to total
3. move pointer inwards
4. repeat for other pointer
 */

public class Solution {
    public int Trap(int[] height) {
        var totalWater = 0;
        var maxRight = 0;
        var maxLeft = 0;
        var left = 0;
        var right = height.Length - 1;

        while (left < right)
        {
            if (height[right] > height[left])
            {
                if (height[left] > maxLeft)
                    maxLeft = height[left];
                else
                {
                    var currentWater = maxLeft - height[left];
                    if (currentWater >= 0)
                        totalWater += currentWater;
                }
                left++;
            }
            else
            {
                if (height[right] > maxRight)
                    maxRight = height[right];
                else
                {
                    var currentWater = maxRight - height[right];
                    if (currentWater >= 0)
                        totalWater += currentWater;
                }
                right--;
            }
        }

        return totalWater;
    }
}