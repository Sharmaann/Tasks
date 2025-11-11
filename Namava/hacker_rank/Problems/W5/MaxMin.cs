// https://www.hackerrank.com/challenges/three-month-preparation-kit-angry-children/problem

using System;

class MaxMin
{

    static int CalculateMinUnfairness(int arrSize, int subarrayLength, int[] arr)
    {
        int minUnfairness = Int32.MaxValue;

        Array.Sort(arr, 0, arrSize);

        for (int i = subarrayLength - 1; i < arrSize; i++)
        {
            int subarrayUnfairness = arr[i] - arr[i - subarrayLength + 1];
            minUnfairness = Math.Min(minUnfairness, subarrayUnfairness);
        }

        return minUnfairness;
    }

    public static void Run()
    {
        int arrSize = Convert.ToInt32(Console.ReadLine());
        int subarrayLength = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[arrSize + 1];
        for (int i = 0; i < arrSize; i++)
            arr[i] = Convert.ToInt32(Console.ReadLine().Trim());

        int minUnfairness = MaxMin.CalculateMinUnfairness(arrSize, subarrayLength, arr);
        
        Console.WriteLine(minUnfairness);
    }
}