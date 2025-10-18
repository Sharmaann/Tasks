// https://www.hackerrank.com/challenges/three-month-preparation-kit-plus-minus/problem

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

class PlusMinus
{
    public static void CalculatePlusMinus(List<int> arr){
        int arrLength = arr.Count;
        int positiveCount = 0;
        int negativeCount = 0;
        int zeroCount = 0;
        
        foreach (int item in arr){
            positiveCount += Convert.ToInt32(item > 0);
            negativeCount += Convert.ToInt32(item < 0);
            zeroCount += Convert.ToInt32(item == 0);
        }

        float positivePercentage = (float) positiveCount / arrLength;
        float negativePercentage = (float) negativeCount / arrLength;
        float zeroPercentage = (float) zeroCount / arrLength;

        string formatString = "{0:F6}\n{1:F6}\n{2:F6}";
        string res = String.Format(formatString, positivePercentage, negativePercentage, zeroPercentage);
        Console.WriteLine(res);
    }

    public static void Run()
    {

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        PlusMinus.CalculatePlusMinus(arr);

    }
}