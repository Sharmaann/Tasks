//https://www.hackerrank.com/challenges/three-month-preparation-kit-counting-valleys/problem

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

class CountingValleys
{
    static int CountValleys(int stepsCount, string path)
    {
        int distanceFromSeaLevel = 0;
        int valleyCount = 0;
        bool belowSeaLevel = false;

        var seaLevelChange = new Dictionary<char, int> {
            { 'U', 1 },
            { 'D', -1 }
        };

        for (int i = 0; i < stepsCount; i++)
        {
            char step = path[i];
            
            distanceFromSeaLevel += seaLevelChange[step];

            if (distanceFromSeaLevel < 0 && !belowSeaLevel)
                belowSeaLevel = true;
            if (distanceFromSeaLevel == 0 && belowSeaLevel)
            {
                valleyCount += 1;
                belowSeaLevel = false;
            }

        }

        return valleyCount;
    }

    public static void Run()
    {
        int stepsCount = Convert.ToInt32(Console.ReadLine().Trim());
        string path = Console.ReadLine();

        int result = CountingValleys.CountValleys(stepsCount, path);

        Console.WriteLine(result);
    }
}
