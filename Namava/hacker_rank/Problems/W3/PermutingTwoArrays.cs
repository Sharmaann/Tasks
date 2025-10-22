// https://www.hackerrank.com/challenges/three-month-preparation-kit-two-arrays/problem

using System.Collections.Generic;
using System;

class PermutingTwoArrays
{

    static string CheckMinPairSum(int listLength, int minPairSum, List<int> listA, List<int> listB){
        listA.Sort();
        listB.Sort();

        for (int i = 0; i < listLength; i ++){
            int listAElement = listA[i];
            int listBElement = listB[listLength - 1 - i]; // Pair listA[i] with its corresponding element of listB but in reverse order

            if (listAElement + listBElement < minPairSum)
                return "NO";
        }

        return "YES";
    }

    public static void Run()
    {
        int queryCount = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < queryCount; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            
            int listLength = Convert.ToInt32(firstMultipleInput[0]);
            int minPairSum = Convert.ToInt32(firstMultipleInput[1]);

            List<int> listA = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();
            List<int> listB = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

            string result = PermutingTwoArrays.CheckMinPairSum(listLength, minPairSum, listA, listB);

            Console.WriteLine(result);
        }
    }

}