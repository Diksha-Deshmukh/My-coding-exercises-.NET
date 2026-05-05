public class Solution
{
    public int MyAtoi(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }

        (long number, int length, int i) = (0, s.Length, 0);
        bool isNegative = false;
        // whitespace
        while (i < length)
        {
            if (s[i] == ' ' || s[i] == '\n' || s[i] == '\t')
            {
                i++;
                continue;
            }
            else if (s[i] >= 48 && s[i] <= 57)
            {
                goto conversion;
            }
            else if (s[i] == '+' || s[i] == '-')
            {
                goto plusMinus;
            }
            else
            {
                return 0;
            }
        }

        // plus or minus
    plusMinus:
        if (i < length && (s[i] == '+' || s[i] == '-'))
        {
            isNegative = s[i] == '-';
            i++;
        }

        // conversion
    conversion:
        while (i < length)
        {
            if (s[i] >= 48 && s[i] <= 57)
            {
                number = number * 10 + (s[i] - '0');
                if ((isNegative && number > int.MaxValue) || number > int.MaxValue)
                {
                    goto rounding;
                }
            }
            else
            {
                break;
            }

            i++;
        }

        return isNegative ? (int)-number : (int)number;

        // rounding
    rounding:
        return isNegative ? int.MinValue : int.MaxValue;
    }
}