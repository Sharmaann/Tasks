// https://www.hackerrank.com/challenges/three-month-preparation-kit-breaking-best-and-worst-records/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=three-month-preparation-kit&playlist_slugs%5B%5D=three-month-week-one
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
     * Complete the 'breakingRecords' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY scores as parameter.
     */

    public static List<int> breakingRecords(List<int> scores)
    {
        int max = Int32.MinValue;
        int min = Int32.MaxValue;
        int maxRecordCount = 0;
        int minRecordCount = 0;
        List<int> res = new List<int>();
        foreach (int number in scores){
            if (number < min){
                min = number;
                minRecordCount += 1;
            }
            if (number > max){
                max = number;
                maxRecordCount += 1;
            }
        }
        // First score shouldn't be considered as a record
        res.Add(maxRecordCount - 1 );
        res.Add(minRecordCount - 1);
        return res;
    }

}

int n = Convert.ToInt32(Console.ReadLine().Trim());

List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

List<int> result = Result.breakingRecords(scores);

Console.WriteLine(String.Join(" ", result));