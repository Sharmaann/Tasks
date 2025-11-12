// https://www.hackerrank.com/challenges/three-month-preparation-kit-sansa-and-xor/problem

using System;

class SansaXOR
{

    static int CalculateSubarraysXorResult(int arrSize, int[] arr)
    {
        int xorResult = 0;

        for (int i = 0; i < arrSize; i++)
        {
            // containingSubarrays = (i + 1) * (arrSize - i). It should be odd.

            if (i % 2 == 0 && (arrSize - i) % 2 == 1)
                xorResult ^= arr[i];
        }

        return xorResult;
    }

    public static void Run()
    {
        int queryCount = Convert.ToInt32(Console.ReadLine());

        while (queryCount > 0)
        {
            int arrSize = Convert.ToInt32(Console.ReadLine());
            int[] arr = Console.ReadLine()
                            .TrimEnd()
                            .Split(' ')
                            .Select(element => Convert.ToInt32(element))
                            .ToArray();

            int subArraysXorResult = SansaXOR.CalculateSubarraysXorResult(arrSize, arr);

            Console.WriteLine(subArraysXorResult);

            queryCount--;
        }
    }
}