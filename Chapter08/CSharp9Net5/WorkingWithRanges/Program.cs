using System;
using static System.Console;

namespace WorkingWithRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Larry King";

            int lengthOfFirst = name.IndexOf(' ');
            int lengthOfLast = name.Length - lengthOfFirst - 1;

            string firstName = name.Substring(0, lengthOfFirst);
            string lastName = name.Substring(name.Length - lengthOfLast, lengthOfLast);

            WriteLine($"First name: {firstName}, Last name: {lastName}");

            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            var firstNameSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameSpan = nameAsSpan[^lengthOfLast..^0];

            WriteLine("Span -> First name: {0}, Last name: {1}", firstNameSpan.ToString(), lastNameSpan.ToString());
        }
    }
}
