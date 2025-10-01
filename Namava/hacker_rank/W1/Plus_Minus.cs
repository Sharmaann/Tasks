
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
        float arrLength = arr.Count;
        float positive_cnt = 0, negative_cnt = 0, zero_cnt = 0;
        for (int i = 0; i < arrLength; i ++){
            int item = arr[i];
            positive_cnt += Convert.ToInt32(item > 0);
            negative_cnt += Convert.ToInt32(item < 0);
            zero_cnt += Convert.ToInt32(item == 0);
        }

        float positive_percentage = positive_cnt / arrLength;
        float negetive_percentage = negative_cnt / arrLength;
        float zero_percentage = zero_cnt / arrLength;
        
        Console.WriteLine(positive_percentage.ToString("F6"));
        Console.WriteLine(negetive_percentage.ToString("F6"));
        Console.WriteLine(zero_percentage.ToString("F6"));
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
