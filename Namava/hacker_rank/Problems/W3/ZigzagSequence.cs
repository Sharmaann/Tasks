//https://www.hackerrank.com/challenges/three-month-preparation-kit-zig-zag-sequence/problem

using System;

class ZigzagSequence
{

    static List<int> GetTheLexicalSmallestZigzagSequence(int arrSize, List<int> arr)
    {
        arr.Sort();

        int k = (arrSize + 1) / 2;
        var result = new List<int>();

        for (int i = 0; i < k - 1; i++)
            result.Add(arr[i]);
        for (int i = arrSize - 1; i >= k - 1; i--)
            result.Add(arr[i]);

        return result;
    }

    public static void Run()
    {
        int testCaseNumbers = Convert.ToInt32(Console.ReadLine().Trim());
        
        for (int i = 0; i < testCaseNumbers; i++)
        {
            int arrSize = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

            List<int> result = ZigzagSequence.GetTheLexicalSmallestZigzagSequence(arrSize, arr);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}