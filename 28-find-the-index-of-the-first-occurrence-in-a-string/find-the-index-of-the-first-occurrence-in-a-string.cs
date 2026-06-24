public class Solution {
    public int StrStr(string haystack, string needle) {
       int index = -1;
bool found = false;
if (string.IsNullOrWhiteSpace(needle) || string.IsNullOrWhiteSpace(haystack))
{
    return -1;
}
if (haystack.Length < needle.Length)
{
    return -1;
}

for (int i = 0; i < haystack.Length; i++)
{ 
    index = i;
    if (needle[0] == haystack[i] && (needle.Length <= haystack.Length - i))
    {
        if (needle.Length > 1)
        {
            for (int j = 1; j < needle.Length; j++)
            {
                if (needle[j] == haystack[i + j])
                {
                    index = i;
                    found = true;
                }
                else
                {
                    found = false;
                    break;
                }
            }
        }
        else return index;
    }
    if (found)
    {
        return index;
    }
}
return -1;
    }
}