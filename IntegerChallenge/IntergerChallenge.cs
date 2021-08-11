public class IntegerChallenge {
    public int Reverse(int x) {
        // Field declarations
        bool isNegative = false;
        int reversedNumber = 0;
        
        // Check for and remove a negative, 
        //   which should be applied at the end result
        if(x < 0)
        {
            isNegative = true;
            x *= -1;
        }
        
        // Assuming positive numbers only due to negative precheck
        while (x > 0)
        {
            if (PositiveNumberMultiply10IsBeyondIntBounds(reversedNumber))
                return 0;
            
            var mod10Result = x%10; // grab the next number
            
            reversedNumber *= 10; // shift reversedNumber to the right

            reversedNumber += mod10Result; // place next value into reversed number

            x /= 10; // shift x to the left
        }
        
        return isNegative ? reversedNumber* -1 : reversedNumber;
    }
    
    private bool PositiveNumberMultiply10IsBeyondIntBounds(int input)
    {
        if (input < 0)
            throw new ArgumentException("input must be > 0");
        
        // input should not go negative when multiplied
        // input should equal the same number when multiplied 
        //     then divided by same value
        if(input *10 < input || input * 10 /10 != input)
        {
            return true;
        }

        return false;
    }
}