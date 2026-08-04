public class Solution {
    public string CountAndSay(int n) {
        string prev = "1";

        for (int i = 2; i <= n; i++)
        {
            int idx = 0;
            int count = 1;
            var s = new StringBuilder();
            while (idx < prev.Length)
            {
                while (idx < prev.Length - 1 && prev[idx] == prev[idx + 1])
                {
                    count++;
                    idx++;
                }

                s.Append(count).Append(prev[idx]);
                count = 1;
                idx++;
            }

            prev = s.ToString();
        }
        return prev;
    }
}