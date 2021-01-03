using System;
using static System.Console;

namespace Ex3_3_FizzBizz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                string result = String.Empty;

                // This is using a tuple pattern matching with the tuple containing 2 boolean
                result = (i % 3 == 0, i % 5 == 0) switch
                {
                    (true, true) => "FizzBuzz",
                    (true, false) => "Fizz",
                    (false, true) => "Buzz",
                    _ => i.ToString()
                };
                Write($"{result}, ");
            }
        }
    }
}
