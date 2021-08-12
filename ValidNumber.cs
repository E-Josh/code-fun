public class Solution {
    public bool IsNumber(string s) {
        bool hasAnE = false;
        bool hasADot = false;
        bool hasLeadingDigit = false;
        bool hasTrailingDigit = false;
        bool hasDigitAfterE = false;
        
        // Traverse through the string
        for(int i = 0; i < s.Length; i++)
        {
            // Check if exponent and if only 1 exists
            if(s[i] == 'e' | s[i] == 'E')
            {
                if(false == hasAnE)
                {
                    if(hasLeadingDigit || hasTrailingDigit)
                    {
                        hasAnE = true;
                        continue;
                    }
                    return false;
                }
                return false;
            }
            
            // Sign char at the beginning 
            //     or directly after the exponent e
            else if(s[i] == '+' || s[i] == '-')
            { 
                if (i == 0)
                    continue;
                else if(hasAnE && i - 1 >= 0)
                {
                    if(false == (s[i-1] == 'e' | s[i-1] == 'E'))
                    {
                        return false;
                    }                        
                    continue;
                }
                else return false;
             }
            
            // Check if only one dot exists
            //    a dot is not allowed in the exponent
            else if(s[i] == '.')
            {
                if(hasADot || hasAnE)
                    return false;
                hasADot = true;
                
            }
            
            // Check if character is a number 
            //     or if it is, is it a trailing (after dot)  
            //     or leading number
            //     or if an exponent
            else if(Char.IsDigit(s[i]))
            {
                if(false == hasTrailingDigit 
                           && hasADot 
                           && hasAnE == false)
                {
                    hasTrailingDigit = true;
                }
                else if(false == hasLeadingDigit 
                            && hasAnE == false 
                            && hasADot == false)
                {
                    hasLeadingDigit = true;
                }
                else if(hasAnE && hasDigitAfterE == false)
                {
                    hasDigitAfterE = true;
                }
            }
            else 
            {
                return false;
            }
        }
        
        // Final validation
        bool isADecimal = false;
        bool isAInteger = false;
        
        // Decimal test
        if(hasADot && (hasLeadingDigit || hasTrailingDigit))
            isADecimal = true;
        
        // Integer test
        if(!hasADot && hasLeadingDigit && !hasTrailingDigit)
            isAInteger = true;
        
        // No Exponent, but is a decimal or integer
        if(!hasAnE && !hasDigitAfterE && (isADecimal || isAInteger))
            return true;
        
        // Exponent check
        else if(hasAnE && hasDigitAfterE && (isADecimal || isAInteger))
            return true;        
        
        
        return false;
    }
}