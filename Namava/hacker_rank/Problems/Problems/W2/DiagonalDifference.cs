// https://www.hackerrank.com/challenges/three-month-preparation-kit-diagonal-difference/problem

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

class DiagonalDifference
{
    static int calculateDiagonalDifference(List<List<int>> arr)
    {
        int n = arr.Count;
        int lrDiagonalSum = 0; // left-to-right diangonal sum
        int rlDiagonalSum = 0; // right-to-left diagonal sum

        for (int row = 0; row < n; row++)
        {
            lrDiagonalSum += arr[row][row];
            rlDiagonalSum += arr[row][n - 1 - row];
        }

        return Math.Abs(lrDiagonalSum - rlDiagonalSum);

    }

    public static void Run()
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = DiagonalDifference.calculateDiagonalDifference(arr);

        Console.WriteLine(result);
    }
}