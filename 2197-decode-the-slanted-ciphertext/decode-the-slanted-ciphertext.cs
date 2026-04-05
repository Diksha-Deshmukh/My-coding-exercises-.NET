public class Solution {
    //Diksha
    
    public string DecodeCiphertext(string encodedText, int rows) {
        if (rows == 1) return encodedText;

        int n = encodedText.Length;
        int cols = n / rows;

        var res = new System.Text.StringBuilder(n);

        for (int c = 0; c < cols; c++) {
            int r = 0, j = c;
            while (r < rows && j < cols) {
                res.Append(encodedText[r * cols + j]);
                r++;
                j++;
            }
        }

        int end = res.Length - 1;
        while (end >= 0 && res[end] == ' ') {
            end--;
        }

        return res.ToString(0, end + 1);
    }
}