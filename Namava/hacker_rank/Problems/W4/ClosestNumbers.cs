// https://www.hackerrank.com/challenges/three-month-preparation-kit-closest-numbers/problem

using System;
using System.Collections.Generic;

class ClosestNumbers
{

    static int FindClosestDifference(int arrSize, int[] arr)
    {
        int minAbsoluteDifference = Int32.MaxValue;

        for (int i = 1; i < arrSize; i++)
        {
            int absDifference = Math.Abs(arr[i] - arr[i - 1]);

            minAbsoluteDifference = Math.Min(minAbsoluteDifference, absDifference);
        }

        return minAbsoluteDifference;
    }

    static List<int> FindAllClosestPairs(int arrSize, int[] arr)
    {
        Array.Sort(arr);

        int minAbsoluteDifference = ClosestNumbers.FindClosestDifference(arrSize, arr);

        var AllClosestPairs = new List<int>();

        for (int i = 1; i < arrSize; i++)
        {
            int absDifference = Math.Abs(arr[i] - arr[i - 1]);

            if (absDifference == minAbsoluteDifference)
            {
                AllClosestPairs.Add(arr[i - 1]);
                AllClosestPairs.Add(arr[i]);
            }
        }

        return AllClosestPairs;
    }


    public static void Run()
    {
        int arrSize = Convert.ToInt32(Console.ReadLine());

        int[] arr = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();

        List<int> AllClosestPairs = ClosestNumbers.FindAllClosestPairs(arrSize, arr);

        Console.WriteLine(String.Join(" ", AllClosestPairs));
    }
}