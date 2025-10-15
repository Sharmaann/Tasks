// https://www.hackerrank.com/challenges/three-month-preparation-kit-divisible-sum-pairs/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=three-month-preparation-kit&playlist_slugs%5B%5D=three-month-week-one
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

class Result
{

    /*
     * Complete the 'divisibleSumPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER_ARRAY arr
     */

    public static int divisibleSumPairs(int n, int k, List<int> arr)
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

}

string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

int n = Convert.ToInt32(firstMultipleInput[0]);

int k = Convert.ToInt32(firstMultipleInput[1]);

List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

int result = Result.divisibleSumPairs(n, k, arr);
Console.WriteLine(result.ToString());
