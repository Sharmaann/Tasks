// https://www.hackerrank.com/challenges/three-month-preparation-kit-divisible-sum-pairs/problem

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class DivisibleSum
{
    public static int CountDivisibleSumPairs(int n, int k, List<int> arr)
    {
        int count = 0;
        Dictionary < int, int > remainderCounterMap = new Dictionary < int, int > ();
        for (int i = 0; i < n; i ++){
            int remainder = arr[i] % k;
            int remainderCounter = remainderCounterMap.GetValueOrDefault(remainder, 0);
            remainderCounterMap[remainder] = remainderCounter + 1;
        }

        for (int remainder = 0; remainder <= k / 2; remainder ++){
            int remainderCounter = remainderCounterMap.GetValueOrDefault(remainder, 0);
            if (remainder == 0 || remainder * 2 == k){
                count += remainderCounter * (remainderCounter - 1) / 2; // a number cannot be pair with another number with the same remainder to k
                continue;
            }
            int inverseRemainderCounter = remainderCounterMap.GetValueOrDefault(k - remainder, 0);
            count += (remainderCounter * inverseRemainderCounter);
        }
        return count;
    }

    public static void Run()
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = DivisibleSum.CountDivisibleSumPairs(n, k, arr);
        Console.WriteLine(result.ToString());
    }

}
