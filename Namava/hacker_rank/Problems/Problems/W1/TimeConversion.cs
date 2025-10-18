// https://www.hackerrank.com/challenges/three-month-preparation-kit-time-conversion/problem

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

class TimeConversion
{
    public static string ConvertTime(string s)
    {
        string timeSpecifier = s.Substring(8, 2);
        string hour = s.Substring(0, 2);
        string minute = s.Substring(3, 2);
        string second = s.Substring(6, 2);

        if (timeSpecifier == "PM" && hour != "12")
            hour = (Convert.ToInt32(hour) + 12).ToString();
        if (timeSpecifier == "AM" && hour == "12")
            hour = "00";

        string res = $"{hour}:{minute}:{second}";
        return res;
    }
    public static void Run()
    {
        string s = Console.ReadLine();
        string result = TimeConversion.ConvertTime(s);
        Console.WriteLine(result);
    }

}