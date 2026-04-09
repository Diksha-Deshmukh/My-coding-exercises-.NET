public class Solution {
    public int LengthOfLongestSubstring(string s) {

        //Tracks unique character in current window
        HashSet<char> charSet = new HashSet<char>();
        //left  = Start index of current window
        //right = End index of current window
        //maxLength = Stores the maximum length found
        int left = 0, right = 0, maxLength = 0;

        while(right < s.Length) {
            if(!charSet.Contains(s[right])) {
                //expand window to the right
                charSet.Add(s[right]);
                right++;
                maxLength = Math.Max(maxLength, charSet.Count);
            } else {
                //shrink window from left
                charSet.Remove(s[left]);
                left++;
            }
        }

        return maxLength;
    }
}