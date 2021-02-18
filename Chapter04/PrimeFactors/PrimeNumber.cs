using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeFactors
{
    class PrimeNumber
    {
        public static bool IsPrime(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {  
                if (number % i == 0)  
                {  
                    return false;  
                }  
            }  

            if (i == number)  
            {  
                return true;  
            }
            
            return false;  
        }
    }
}
