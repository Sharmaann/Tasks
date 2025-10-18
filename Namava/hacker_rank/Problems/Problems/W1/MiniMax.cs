// https://www.hackerrank.com/challenges/three-month-preparation-kit-mini-max-sum/problem

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

class MiniMax
{
    public static void CalculateMiniMaxSum(List<int> arr)
    {
        long sum = 0;
        int max = -1;
        int min = Int32.MaxValue;

        foreach (int number in arr){
            if (number < min)
                min = number;
            if (number > max)
                max = number;
            sum += number;
        }
        
        long minSum = sum - max;
        long maxSum = sum - min;
        
        Console.WriteLine($"{minSum} {maxSum}");
    }
    public static void Run()
    {
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        MiniMax.CalculateMiniMaxSum(arr);
    }

}