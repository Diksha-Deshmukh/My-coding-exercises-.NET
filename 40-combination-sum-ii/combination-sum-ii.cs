public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates, (a, b) => a - b);
        IList<IList<int>> output = new List<IList<int>>();
        findSum(0, new List<int>(), target);
        return output;
        
        void findSum(int i, List<int> lst, int t) {
            if (t == 0) {
                output.Add(new List<int>(lst));
                return;
            }
            
            if (t < 0 || i >= candidates.Length)
                return;
            
            int c = lst.Count();
            lst.Add(candidates[i]);
            findSum(i + 1, lst, t - candidates[i]);
            i++;
            lst.RemoveAt(c);
            while (i < candidates.Length && candidates[i - 1] == candidates[i])
                i++;
            
            findSum(i, lst, t);
        }
    }
}