using System;

namespace PrimeFactors
{
    public class PrimeFactor
    {
        public static string PrimeFactors(int number, int factor = 2)
        {
            if (number == 1)
            {
                return "";
            }

            if ((number % factor) == 0 && PrimeNumber.IsPrime(number))
            {
                return $"{PrimeFactors(number/factor,factor)},{number}";
            }
            else
            {
                return $"{PrimeFactors(number,factor+1)}";
            }
        }
    }
}
