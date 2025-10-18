// https://www.hackerrank.com/challenges/three-month-preparation-kit-lonely-integer/problem

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

class LonelyInteger
{
    static int FindLonelyInteger(List <int> arr)
    {
        int result = 0;

        foreach (int number in arr)
        {
            result ^= number;
        }

        return result;
    }

    public static void Run()
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = LonelyInteger.FindLonelyInteger(arr);

        Console.WriteLine(result);
    }
}