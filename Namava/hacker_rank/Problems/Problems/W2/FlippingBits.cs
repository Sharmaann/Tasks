//https://www.hackerrank.com/challenges/three-month-preparation-kit-flipping-bits/problem

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

class FlippingBits
{

    static long FlipBits(long number)
    {
        long maxNumber = (long) Math.Pow(2, 32) - 1;
        return maxNumber - number;
    }

    public static void Run()
    {

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            long n = Convert.ToInt64(Console.ReadLine().Trim());

            long result = FlippingBits.FlipBits(n);

            Console.WriteLine(result);
        }
    }
}