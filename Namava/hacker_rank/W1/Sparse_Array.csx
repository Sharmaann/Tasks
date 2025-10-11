// https://www.hackerrank.com/challenges/three-month-preparation-kit-sparse-arrays/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=three-month-preparation-kit&playlist_slugs%5B%5D=three-month-week-one
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
     * Complete the 'matchingStrings' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY strings
     *  2. STRING_ARRAY queries
     */

    public static List<int> matchingStrings(List<string> strings, List<string> queries)
    {
        var mapStringsCount = new Dictionary<string, int>();
        foreach (string stringItem in strings){
            int stringCount = mapStringsCount.GetValueOrDefault(stringItem, 0);
            mapStringsCount[stringItem] = stringCount + 1;
        }

        var res = new List <int>();
        foreach (string queryStrings in queries){
            res.Add(mapStringsCount.GetValueOrDefault(queryStrings, 0));
        }

        return res;
    }

}

int stringsCount = Convert.ToInt32(Console.ReadLine().Trim());

var strings = new List<string>();

for (int i = 0; i < stringsCount; i++)
{
    string stringsItem = Console.ReadLine();
    strings.Add(stringsItem);
}

int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

var queries = new List<string>();

for (int i = 0; i < queriesCount; i++)
{
    string queriesItem = Console.ReadLine();
    queries.Add(queriesItem);
}

List<int> res = Result.matchingStrings(strings, queries);
foreach (int count in res){
    Console.WriteLine(count.ToString());
}