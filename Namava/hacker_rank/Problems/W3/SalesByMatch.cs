// https://www.hackerrank.com/challenges/three-month-preparation-kit-sock-merchant/problem

using System;

class SalesByMatch
{

    static List<int> Initialize(){
        var countMap = new List <int>();

        for (int i = 0; i <= 100; i ++)
            countMap.Add(0);

        return countMap;
    }

    static int CountPairs(int arrSize, List <int> arr){
        List <int> countMap = SalesByMatch.Initialize();
        int count = 0;

        foreach (int number in arr)
            countMap[number] ++;

        for (int i = 1; i <= 100; i ++)
            count += (countMap[i] / 2);

        return count;
    }

    public static void Run(){
        int arrSize = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = SalesByMatch.CountPairs(arrSize, arr);

        Console.WriteLine(result);
    }
}