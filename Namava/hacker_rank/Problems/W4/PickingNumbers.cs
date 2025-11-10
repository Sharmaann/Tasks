// https://www.hackerrank.com/challenges/three-month-preparation-kit-picking-numbers/problem

using System;

class PickingNumbers
{

    const int MaxNumber = 99;

    static int FindLongestDesiredSubsetLength(int[] arr)
    {
        int[] numberCount = new int[101];
        int longestDesiredSubsetLength = 0;

        for (int i = 0; i < arr.Length; i++)
            numberCount[arr[i]]++;

        for (int number = 2; number <= 99; number++)
        {
            int currentNumberCount = numberCount[number];
            int previousNumberCount = numberCount[number - 1];
            int desiredSubsetLength = currentNumberCount + previousNumberCount;

            longestDesiredSubsetLength = Math.Max(longestDesiredSubsetLength, desiredSubsetLength);
        }

        return longestDesiredSubsetLength;
    }

    public static void Run()
    {
        int arrSize = Convert.ToInt32(Console.ReadLine());

        int[] arr = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();

        int longestDesiredSubsetLength = PickingNumbers
                    .FindLongestDesiredSubsetLength(arr);

        Console.WriteLine(longestDesiredSubsetLength);

    }
}