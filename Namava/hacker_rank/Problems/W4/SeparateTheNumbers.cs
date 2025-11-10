// https://www.hackerrank.com/challenges/three-month-preparation-kit-separate-the-numbers/problem

using System;
using System.Numerics;

class SeparateTheNumbers
{

    static BigInteger IsBeautiful(string s, Dictionary<string, BigInteger> subarrayAns)
    {
        if (subarrayAns.TryGetValue(s, out BigInteger subAns))
            return subAns;

        if (s.Length == 1)
            return BigInteger.Parse(s);

        for (int i = 1; i < s.Length; i++)
        {
            string prefix = s.Substring(0, i); // consider the first i characters as the sequence start point
            string suffix = s.Substring(i);

            if (suffix[0] == '0')
                continue;

            BigInteger prefixValue = BigInteger.Parse(prefix);

            if (subarrayAns.TryGetValue(s, out BigInteger currentAns) && prefixValue >= currentAns) // We already have a better answer
                continue;

            BigInteger nextValueOfSubstring = IsBeautiful(suffix, subarrayAns);

            /*
             Now we have two options.
             1. Split the suffix part too
             2. Use suffix as a whole
             */


            if (nextValueOfSubstring == prefixValue + 1 || BigInteger.Parse(suffix) == prefixValue + 1)
            {
                subarrayAns[s] = prefixValue;
                return prefixValue;
            }
            
        }

        subarrayAns[s] = BigInteger.Parse(s);
        return BigInteger.Parse(s);

    }

    public static void Run()
    {
        int queryCount = Convert.ToInt32(Console.ReadLine());

        while (queryCount > 0)
        {
            string number = Console.ReadLine();

            var subarrayAns = new Dictionary<string, BigInteger>();


            BigInteger firstNumberOfTheSequence = SeparateTheNumbers.IsBeautiful(number, subarrayAns);


            if (firstNumberOfTheSequence == BigInteger.Parse(number))
                Console.WriteLine("NO");
            else
                Console.WriteLine($"YES {firstNumberOfTheSequence}");

            queryCount--;
        }
    }
}