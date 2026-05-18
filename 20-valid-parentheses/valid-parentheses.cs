public class Solution {
    public bool IsValid(string s) {
        if (s.Length == 0)
            return true;

        if (s.Contains("[]") || s.Contains("()") || s.Contains("{}")) {
            return IsValid(
                s.Replace("[]", "")
                 .Replace("()", "")
                 .Replace("{}", "")
            );
        }

        return false;
    }
}