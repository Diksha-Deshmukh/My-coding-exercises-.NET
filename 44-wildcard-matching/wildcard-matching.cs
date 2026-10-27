public class Solution {
    public bool IsMatch(string s, string p) {

        var m = s.Length;
        var n = p.Length;
        
        var dp = new bool[m + 1][];

        for(var i = 0; i <= m; i++) dp[i] = new bool[n + 1];
        
        dp[0][0] = true;

        for(var i = 1; i <= n; i++) {
            dp[0][i] = p[i - 1] == '*' ? dp[0][i - 1] : false;
        }
         
        
        for(var i = 1; i <= m; i++) {
            for(var j = 1; j <= n; j++) {
                if(s[i - 1] == p[j - 1] || p[j - 1] == '?') {
                    dp[i][j] = dp[i - 1][j - 1];
                }
                else if(p[j - 1] == '*') {
                    dp[i][j] = dp[i - 1][j] || dp[i][j - 1];
                }
                else {
                    dp[i][j] = false;
                }
            }
        }

        return dp[m][n];
    }
    

}