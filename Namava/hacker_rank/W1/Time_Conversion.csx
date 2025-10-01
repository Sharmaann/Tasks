// https://www.hackerrank.com/challenges/three-month-preparation-kit-time-conversion/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=three-month-preparation-kit&playlist_slugs%5B%5D=three-month-week-one
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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        string timeSpecifier = s.Substring(8, 2);
        string hour = s.Substring(0, 2);
        string minute = s.Substring(3, 2);
        string second = s.Substring(6, 2);
        if (timeSpecifier == "PM"){
            if (hour != "12")
                hour = (Convert.ToInt32(hour) + 12).ToString();
        }
        else if (hour == "12"){ // AM
            hour = "00";
        }
        string res = $"{hour}:{minute}:{second}";
        return res;
    }

}


string s = Console.ReadLine();
string result = Result.timeConversion(s);
Console.WriteLine(result);