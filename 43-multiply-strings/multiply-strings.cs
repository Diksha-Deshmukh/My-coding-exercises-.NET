public class Solution {
    public string Multiply(string num1, string num2) {
        int len = num1.Length + num2.Length;
        int[] op = new int[len];
        int index = len - 1;
        for (int i = num1.Length - 1; i > -1; i--) {
            if (num1[i] == '0') {
                index--;
                continue;
            }

            int cur = index, carry = 0;
            int j = num2.Length - 1;
            var f = num1[i] - '0';
            while (j > -1 || carry != 0) {
                var s = j > -1 ? num2[j] - '0' : 0;
                var m = (f * s) + carry + op[cur];
                op[cur--] = m % 10;
                carry = m/10;
                j--;
            }
            index--;
        }

        int curIndex = 0;
        while(curIndex < len && op[curIndex++] == 0);
        curIndex--;
        return curIndex >= len ? "0" : string.Join("", op.Skip(curIndex));
     }
}