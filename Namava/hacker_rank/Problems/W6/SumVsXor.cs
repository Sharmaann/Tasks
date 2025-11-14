//https://www.hackerrank.com/challenges/three-month-preparation-kit-sum-vs-xor/problem

using System;

class SumVsXor
{
    static long CountDesiredValues(long n)
    {
        long cnt = 1;

        while (n > 1)
        {
            if (n % 2 == 0)
                cnt *= 2;

            n /= 2;
        }
        return cnt;
    }

    public static void Run()
    {
        long number = Convert.ToInt64(Console.ReadLine());

        long result = SumVsXor.CountDesiredValues(number);

        Console.WriteLine(result);

    }
}
