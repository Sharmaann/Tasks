// https://www.hackerrank.com/challenges/three-month-preparation-kit-minimum-absolute-difference-in-an-array/problem

using System;

class MinAbsoluteDifference
{
    static int FindClosestDifference(int arrSize, int[] arr)
    {
        Array.Sort(arr);

        int minAbsoluteDifference = Int32.MaxValue;

        for (int i = 1; i < arrSize; i++)
        {
            int absDifference = Math.Abs(arr[i] - arr[i - 1]);

            minAbsoluteDifference = Math.Min(minAbsoluteDifference, absDifference);
        }

        return minAbsoluteDifference;
    }

    public static void Run()
    {
        int arrSize = Convert.ToInt32(Console.ReadLine());

        int[] arr = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();

        int minAbsoluteDifference = MinAbsoluteDifference.FindClosestDifference(arrSize, arr);
        
        Console.WriteLine(minAbsoluteDifference);
    }
}