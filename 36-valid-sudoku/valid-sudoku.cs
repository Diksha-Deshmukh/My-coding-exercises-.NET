public class Solution {
    const int boardLength=9;

    public bool IsValidSudoku(char[][] board) {
        if(!ValidRowCol(board, true))
            return false;
        if(!ValidRowCol(board, false))
            return false;
        if(!Valid3by3(board))
            return false;

        return true;
    }

    private bool ValidRowCol(char[][] board, bool fRow)
    {
        bool[] columnRowTracker = new bool[boardLength];
        for(int i = 0; i < columnRowTracker.Length; i++)
        {
            columnRowTracker[i]=false;
        }
        
        for(int i = 0; i<boardLength; i++)
        {
            for(int j = 0; j<boardLength; j++)
            {
                int digit = fRow ? board[i][j] - '0' : board[j][i] - '0';
                //Console.WriteLine("Digit at "+i+","+j+": "+digit);
                if (digit > 0 && digit <=9)
                {
                    // Indeed a digit
                    if(columnRowTracker[digit-1])
                        return false;
                    else
                        columnRowTracker[digit-1]=true;
                }
            }
            // Clear tracker
            for(int x = 0; x < columnRowTracker.Length; x++)
                columnRowTracker[x]=false;
        }
        return true;
    }

   

    private bool Valid3by3(char[][] board)
    {
        // Iterate through each 3x3 board
        int top = 0;
        int bottom = 2;
        int right = 2;
        int left =0;

        bool[] columnRowTracker = new bool[boardLength];
        for(int i = 0; i < columnRowTracker.Length; i++)
        {
            columnRowTracker[i]=false;
        }

        // iterate through each board
        while (top<boardLength)
        {
            while(right<boardLength)
            {
                for(int i = top; i <= bottom; i++)
                {
                    for(int j = left; j <= right; j++)
                    {
                        int digit = board[i][j] - '0';
                        //Console.WriteLine("Digit at "+i+","+j+": "+board[i][j]);
                        if (digit > 0 && digit <=9)
                        {
                            // Indeed a digit
                            if(columnRowTracker[digit-1])
                                return false;
                            else
                            {
                                //Console.WriteLine("Setting "+digit+" to true");
                                columnRowTracker[digit-1]=true;
                            }
                        }
                    }
                }
                // Out of the board. 
                // Erase tracker
                //Console.WriteLine("Erasing board");
                for(int x = 0; x < columnRowTracker.Length; x++)
                {
                    columnRowTracker[x]=false;
                }
                // Shift left and right by 3
                left+=3;
                right+=3;
            }
            // Out of the row of boards
            // Erase shift top and bottom by 3
            left = 0;
            right = 2;
            top += 3;
            bottom += 3;
        }

        return true;
    }
}