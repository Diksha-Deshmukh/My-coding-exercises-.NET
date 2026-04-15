public class Solution {
    public bool IsPalindrome(int x) {
        if(x<0) return false;
        var remList = new List<int>();
        var quote=x;
        while(quote > 0){
            remList.Add(quote%10);
            quote=quote/10;
        }
        for(int i=0 ; i <remList.Count/2 ;i++){
            if(remList[i]!= remList[remList.Count -1-i]) return false;
        
        }
        return true;
    }
}