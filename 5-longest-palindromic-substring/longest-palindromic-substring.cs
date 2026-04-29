public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length * 2 + 1;
        Span<int> p = n <= 2048 ? stackalloc int[n] : new int[n];

        int center = 0, radius = 0, palindromeCenter = 0, maxLength = 0;

        for (int i = 0; i < n; i++) {
            int mirror = 2 * center - i;

            if (i < radius) {
                p[i] = Math.Min(radius - i, p[mirror]);
            }

            int left = i - p[i] - 1;
            int right = i + p[i] + 1;

            while (left >= 0 && right < n 
                    && GetManacharCharacter(left, s) == GetManacharCharacter(right, s)) {
                        p[i]++;
                        left--;
                        right++;
                }

            if (i + p[i] > radius) {
                center = i;
                radius = i + p[i];
            }

            if (p[i] > maxLength) {
                palindromeCenter = i;
                maxLength = p[i];
            }
        }

        int start = (palindromeCenter - maxLength) / 2;
        return s.Substring(start, maxLength);
    }

    private char GetManacharCharacter(int i, string s) {
        return (i & 1) == 1? s[i >> 1]: '#';
    }

    // O(n^2)
    // public string LongestPalindrome(string s) {
    //     int startIndex = 0;
    //     int maxLength = 0;

    //     for (int index = 0; index < s.Length; index++) {
    //         // Odd Center Search
    //         (startIndex, maxLength) = GetSubStringResult(index, index, s, startIndex, maxLength);

    //         // Even Center Search
    //         (startIndex, maxLength) = GetSubStringResult(index, index + 1, s, startIndex, maxLength);
    //     }

    //     return s.Substring(startIndex, maxLength);
    // }

    // private (int, int) GetSubStringResult(int i, int j, string s, int startIndex, int maxLength) {
    //     while (i >= 0 && j < s.Length && s[i] == s[j]) {
    //         i--; 
    //         j++;
    //     }

    //     int length = j - i - 1;
    //     if (length > maxLength) {
    //         startIndex = i + 1;
    //         maxLength = length;
    //     }

    //     return (startIndex, maxLength);
    // }

    // O(n^3)
    // public string LongestPalindrome(string s) {
    //     int length = s.Length;

        // for (int size = length; size > 0; size--) {
        //     for (int ch = 0; ch < length; ch++) {
        //         if (size + ch <= length) {
        //             string subString = s.Substring(ch, size);
        //             if (IsValidPalindrome(subString)) return subString;
        //         }
        //     }
        // }

    //     return "";
    // }

    // public bool IsValidPalindrome(string word) {
    //     int i = 0;
    //     int j = word.Length - 1;

    //     while (i <= j) 
    //         if (word[i++] != word[j--]) return false;

    //     return true;
    // }
}