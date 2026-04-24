public class Solution {
    public string LongestPalindrome(string s) {
        if (string.IsNullOrEmpty(s) || s.Length < 1) {
            return "";
        }

        int start = 0;
        int maxLength = 1;

        for (int i = 0; i < s.Length; i++) {
            // Case 1: Odd-length palindrome (center is at i)
            int len1 = ExpandFromCenter(s, i, i);
            
            // Case 2: Even-length palindrome (center is between i and i+1)
            int len2 = ExpandFromCenter(s, i, i + 1);

            int len = Math.Max(len1, len2);
            if (len > maxLength) {
                // The start position is i minus half of the length of the palindrome found.
                // (len - 1) / 2 handles both odd and even cases correctly.
                start = i - (len - 1) / 2;
                maxLength = len;
            }
        }

        return s.Substring(start, maxLength);
    }

    private int ExpandFromCenter(string s, int left, int right) {
        // Expand as long as the pointers are in bounds and the characters match.
        while (left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }
        
        // Return the length of the palindrome found.
        // The final positions are (left+1) and (right-1).
        // Length = (right-1) - (left+1) + 1 = right - left - 1.
        return right - left - 1;
    }
}