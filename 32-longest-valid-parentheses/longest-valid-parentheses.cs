public class Solution {
    public int LongestValidParentheses(string s) {
        if (s.Length <= 1) return 0;

        var indices = new Stack<int>();
        var max = 0;

        indices.Push(-1);

        for (var i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                indices.Push(i);
            }
            else {
                indices.Pop();
                if (indices.Count == 0) {
                    indices.Push(i);
                }
                else {
                    max = Math.Max(max, i - indices.Peek());
                }
            }
        }

        return max;
    }
}