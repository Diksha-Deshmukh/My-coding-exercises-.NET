//Diksha

public class Solution {
    public int MaximumAmount(int[][] coins) {
        int m = coins.Length;
        int n = coins[0].Length;

        // dp[i][j][k] = max coins at (i,j) using k neutralizations
        int[,,] dp = new int[m, n, 3];

        // Initialize with very small values
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < 3; k++) {
                    dp[i, j, k] = int.MinValue;
                }
            }
        }

        // Starting cell
        for (int k = 0; k < 3; k++) {
            if (coins[0][0] >= 0) {
                dp[0, 0, k] = coins[0][0];
            } else {
                // Use neutralization if possible
                if (k > 0)
                    dp[0, 0, k] = 0;
                else
                    dp[0, 0, k] = coins[0][0];
            }
        }

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) continue;

                for (int k = 0; k < 3; k++) {
                    int bestPrev = int.MinValue;

                    if (i > 0)
                        bestPrev = Math.Max(bestPrev, dp[i - 1, j, k]);
                    if (j > 0)
                        bestPrev = Math.Max(bestPrev, dp[i, j - 1, k]);

                    if (bestPrev != int.MinValue) {
                        // Normal case
                        dp[i, j, k] = Math.Max(dp[i, j, k], bestPrev + coins[i][j]);
                    }

                    // Use neutralization if negative
                    if (coins[i][j] < 0 && k > 0) {
                        int bestPrevNeutral = int.MinValue;

                        if (i > 0)
                            bestPrevNeutral = Math.Max(bestPrevNeutral, dp[i - 1, j, k - 1]);
                        if (j > 0)
                            bestPrevNeutral = Math.Max(bestPrevNeutral, dp[i, j - 1, k - 1]);

                        if (bestPrevNeutral != int.MinValue) {
                            dp[i, j, k] = Math.Max(dp[i, j, k], bestPrevNeutral);
                        }
                    }
                }
            }
        }

        int result = int.MinValue;
        for (int k = 0; k < 3; k++) {
            result = Math.Max(result, dp[m - 1, n - 1, k]);
        }

        return result;
    }
}