public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return kSum(nums, target, 0, 4);
        }

        public List<IList<int>> kSum(int[] nums, long target, int start, int k) {
            List<IList<int>> res = new List<IList<int>>();

            // If we have run out of numbers to add, return res.
            if (start == nums.Length)
            {
                return res;
            }

            // There are k remaining values to add to the sum. The 
            // average of these values is at least target / k.
            long average_value = target / (long)k;

            // We cannot obtain a sum of target if the smallest value
            // in nums is greater than target / k or if the largest 
            // value in nums is smaller than target / k.
            if (nums[start] > average_value || average_value > nums[nums.Length - 1])
            {
                return res;
            }

            if (k == 2)
            {
                return twoSum(nums, target, start);
            }

            for (int i = start; i < nums.Length; ++i)
            {
                if (i == start || nums[i - 1] != nums[i])
                {

                    foreach (var subset in kSum(nums, target - nums[i], i + 1, k - 1)) {
                        var tmp = new List<int> { nums[i] };
                        tmp.AddRange(subset);
                        res.Add(tmp);
                    }
                }
            }

            return res;
        }

        public List<IList<int>> twoSum(int[] nums, long target, int start) {
            List<IList<int>> res = new List<IList<int>>();
            int lo = start;
            int hi = nums.Length - 1;
            while (lo < hi) {
                int currSum = nums[lo] + nums[hi];
                if (currSum < target || (lo > start && nums[lo] == nums[lo - 1]))
                {
                    ++lo;
                }
                else if (currSum > target || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
                {
                    --hi;
                }
                else {
                    res.Add(new List<int>() { nums[lo++], nums[hi--] });
                }
            }

            return res;
        }
}