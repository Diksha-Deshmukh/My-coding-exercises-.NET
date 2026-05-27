public class Solution {
    public IList<string> GenerateParenthesis(int n) {
      IList<string> result = new List<string>();
      void Helper(string current, int open , int close)
      {
        if(current.Length == 2 * n)
        {
            result.Add(current);
            return;
        }

        if(open < n)
        {
            Helper(current + "(", open +1 , close);
        }

        if(close < open)
        {
        Helper(current + ")", open,close +1);
        }
      }  
      Helper("",0,0);
      return result;
    }
}