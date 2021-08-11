public class StringToIntAtoi {
    public int ConvertAtoi(string s) {
        // remove any leading whitespace
        s = s.Trim();
        
        // is the first char a + or -; positive if not present
        bool signIsPresent = false;
        bool signIsPositive = true;
        if (s.Length > 0)
        {
            if (s[0] == '-')
            {
                signIsPresent = true;
                signIsPositive = false;
            }
            else if(s[0] == '+')
                signIsPresent = true;
        }
        
        // obtain all sequencial digit characters
        string digitOnlyInput = "0";
        
        for (int index = signIsPresent ? 1 : 0; index < s.Length; index++)
        {
            if (Char.GetNumericValue(s[index]) < 0)
                break;
            digitOnlyInput += s[index];
        }
        
        // convert the digits to int
        int convertedDigits = 0;
        bool parseDigitOkay = Int32.TryParse(digitOnlyInput, out convertedDigits);
        
        // check if int is beyond bounds of int; if so, return max or min int
        if(parseDigitOkay == false || (convertedDigits < 0 && convertedDigits.ToString() != digitOnlyInput)
            || (convertedDigits > 0 && convertedDigits.ToString() != TrimLeadingZeros(digitOnlyInput)))
        {            
            if(signIsPositive)
                return int.MaxValue;
            else
                return int.MinValue;
        }
        
        // return the result
        if (signIsPositive)
            return convertedDigits;
        return convertedDigits * -1;
    }
    
    private string TrimLeadingZeros(string inputToTrim)
    {
        StringBuilder sb = new StringBuilder();
        bool leadingPassed = false;
        for (int i = 0; i < inputToTrim.Length; i++)
        {
            if (inputToTrim[i] == '0' && !leadingPassed)
                continue;
            sb.Append(inputToTrim[i]);
            leadingPassed = true;
        }
        return sb.ToString();
    }
}