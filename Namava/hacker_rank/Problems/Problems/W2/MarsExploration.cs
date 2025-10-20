//https://www.hackerrank.com/challenges/three-month-preparation-kit-mars-exploration/problem

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

class MarsExploration
{

    static int CountMismatch(string input)
    {
        string correctSOS = "SOS";
        int mismatchCount = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char character = input[i];

            if (character != correctSOS[i % 3])
                mismatchCount++;
        }

        return mismatchCount;
    }

    public static void Run()
    {
        string input = Console.ReadLine();

        int result = MarsExploration.CountMismatch(input);

        Console.WriteLine(result);
    }
}