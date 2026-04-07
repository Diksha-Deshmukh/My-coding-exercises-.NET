public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || s.Length <= numRows)
            return s;

        // Create a list of StringBuilders for each row
        var rows = new List<System.Text.StringBuilder>();
        for (int i = 0; i < numRows; i++)
            rows.Add(new System.Text.StringBuilder());

        int currentRow = 0;
        bool goingDown = false;

        foreach (char c in s)
        {
            rows[currentRow].Append(c);

            // Change direction if we hit top or bottom
            if (currentRow == 0 || currentRow == numRows - 1)
                goingDown = !goingDown;

            currentRow += goingDown ? 1 : -1;
        }

        // Combine all rows
        var result = new System.Text.StringBuilder();
        foreach (var row in rows)
            result.Append(row);

        return result.ToString();
    }
}