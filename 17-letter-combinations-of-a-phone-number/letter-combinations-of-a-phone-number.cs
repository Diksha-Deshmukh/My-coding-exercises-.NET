public class Solution
{
    Dictionary<char, string> letters = [];
    List<string> letters2 = [];
    IList<string> res = [];

    public IList<string> LetterCombinations(string digits)
    {
        letters.Add('2', "abc");
        letters.Add('3', "def");
        letters.Add('4', "ghi");
        letters.Add('5', "jkl");
        letters.Add('6', "mno");
        letters.Add('7', "pqrs");
        letters.Add('8', "tuv");
        letters.Add('9', "wxyz");

        for (int i = 0; i < digits.Length; i++)
        {
            letters2.Add(letters[digits[i]]);
        }

        int len = letters2.Count;

        Backtracking("", 0, len);

        return res;
    }

    void Backtracking(string str, int i, int len)
    {
        for (int l = 0; l < letters2[i].Length; l++)
        {
            if (i < len - 1)
            {
                Backtracking(str + letters2[i][l], i + 1, len);
            }
            else
            {
                res.Add(str + letters2[i][l]);
            }
        }
    }
}