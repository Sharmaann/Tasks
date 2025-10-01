
// https://www.hackerrank.com/challenges/three-month-preparation-kit-plus-minus/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=three-month-preparation-kit&playlist_slugs%5B%5D=three-month-week-one


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
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
     

    public static void plusMinus(List<int> arr){
        int arrLength = arr.Count;
        float positiveCount = 0, negativeCount = 0, zeroCount = 0;
        foreach (int item in arr){
            positiveCount += Convert.ToInt32(item > 0);
            negativeCount += Convert.ToInt32(item < 0);
            zeroCount += Convert.ToInt32(item == 0);
        }

        float positivePercentage = positiveCount / arrLength,
              negetivePercentage = negativeCount / arrLength,
              zeroPercentage = zeroCount / arrLength;

        string formatString = "{0:F6}\n{1:F6}\n{2:F6}";
        string res = String.Format(formatString, positivePercentage, negetivePercentage, zeroPercentage);
        Console.WriteLine(res);
    }
}

int n = Convert.ToInt32(Console.ReadLine().Trim());

List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

Result.plusMinus(arr);
