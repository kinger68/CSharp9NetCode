using System;
using static System.Console;

namespace WritingFunctions
{
    class Program
    {
        static void TimesTable(byte number)
        {
            WriteLine($"This is the {number} times table");

            for (int row = 0; row < 12; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            }
            WriteLine();
        }

        public static void RunTimesTable()
        {
            bool isNumber;

            do
            {
                Write("Enter a number between 0 and 255: ");

                isNumber = byte.TryParse(ReadLine(), out byte number);

                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            }
            while (isNumber);
        }

        static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    int lastDigit = number % 10;

                    string suffix = lastDigit switch
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th"
                    };
                    return $"{number}{suffix}";
            }
        }

        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                Write($"{CardinalToOrdinal(number)} ");
            }
            WriteLine();
        }

        static int FibFunction(int term) =>
            term switch
            {
                1 => 0,
                2 => 1,
                _ => FibFunction(term - 1) + FibFunction(term - 2)
            };

        static void RunFibFunction()
        {
            for (int i = 1; i < 30; i++)
            {
                WriteLine("The {0} term of the Fibonacci sequence is {1:N0}", CardinalToOrdinal(i), FibFunction(i));
            }
        }

        static void Main(string[] args)
        {
//            RunTimesTable();
//            RunCardinalToOrdinal();
              RunFibFunction();
        }
    }
}
