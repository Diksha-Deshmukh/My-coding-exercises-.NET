public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        Array.Sort(strs);
        string str1 = strs[0];
        string str2 = strs[^1]; // strs[strs.Length - 1]
        int maxLen = Math.Min(str1.Length, str2.Length);

        int i = 0;
        for (i = 0; i < maxLen; i++)
        {
            if (str1[i] != str2[i])
                break;
        }

        return str1[..i]; // Get i characters
    }
}