// https://www.hackerrank.com/challenges/three-month-preparation-kit-sparse-arrays/problem

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

class SparseArray
{
    public static List<int> CountMatchingStrings(List<string> strings, List<string> queries)
    {
        var mapStringsCount = new Dictionary<string, int>();
        foreach (string stringItem in strings)
        {
            int stringCount = mapStringsCount.GetValueOrDefault(stringItem, 0);
            mapStringsCount[stringItem] = stringCount + 1;
        }

        var result = new List<int>();
        foreach (string queryStrings in queries)
        {
            result.Add(mapStringsCount.GetValueOrDefault(queryStrings, 0));
        }

        return result;
    }
    public static void Run()
    {

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

        List<int> result = SparseArray.CountMatchingStrings(strings, queries);
        foreach (int count in result)
        {
            Console.WriteLine(count.ToString());
        }
    }

}