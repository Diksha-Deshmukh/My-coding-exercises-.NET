public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> result = new List<IList<int>>();

        BackTrack(new List<int>(), 0, 0);

        void BackTrack(List<int> current, int start, int sum) {
            if (sum == target) {
                result.Add(new List<int>(current));
                return;
            }

            for(int i = start; i < candidates.Length; i++) {
                if (sum + candidates[i] <= target)
                {
                    current.Add(candidates[i]);
                    BackTrack(current, i, sum + candidates[i]);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
        return result;
    }
}