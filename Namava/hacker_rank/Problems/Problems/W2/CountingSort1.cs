// https://www.hackerrank.com/challenges/three-month-preparation-kit-countingsort1/problem

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

class CountingSort1 
{ 

    static List<int> Initialize()
    {
        var countingList = new List<int>();

        for (int number = 0; number < 100; number++)
        {
            countingList.Add(0);
        }

        return countingList;
    }

    static List<int> Sort(List<int> arr)
    {
        List<int> countingList = CountingSort1.Initialize();

        foreach(int number in arr)
        {
            countingList[number]++;
        }

        return countingList;

    }
    public static void Run()
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = CountingSort1.Sort(arr);

        foreach (int number in result)
        {
            Console.Write(number);
            Console.Write(" ");
        }
    }    
}