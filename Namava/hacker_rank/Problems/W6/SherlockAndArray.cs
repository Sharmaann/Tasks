// https://www.hackerrank.com/challenges/three-month-preparation-kit-sherlock-and-array/problem

using System;

class SherlockAndArray
{

    static string HasBalancedElement(int arrSize, int[] arr)
    {
        int sum = 0;
        int prefixSum = 0;

        foreach (int element in arr)
            sum += element;

        if (arr[0] == sum)
            return "YES";

        for (int i = 0; i < arrSize - 1; i++)
        {
            int possibleBalancedElement = arr[i + 1];

            prefixSum += arr[i];
            
            if (prefixSum * 2 + possibleBalancedElement == sum)
                return "YES";
        }

        return "NO";
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

            string hasBalancedElement = SherlockAndArray.HasBalancedElement(arrSize, arr);

            Console.WriteLine(hasBalancedElement);

            queryCount--;
        }

    }

}
