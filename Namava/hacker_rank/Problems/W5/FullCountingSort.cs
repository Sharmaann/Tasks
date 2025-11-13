// https://www.hackerrank.com/challenges/three-month-preparation-kit-countingsort4/problem

using System;
using System.Text; 

class FullCountingSort
{

    static StringBuilder GenerateTheSortedResult(string[] allStrings, List<int>[] stringValueIds, int numberOfStrings)
    {
        var res = new StringBuilder(20000000);

        for (int value = 0; value < 100; value ++){
            foreach (int stringIndexWithValue in stringValueIds[value])
                res.Append($"{allStrings[stringIndexWithValue]} ");
        }

        return res;
    }

    static List<int>[] InitializeStringValIdArr()
    {
        List<int>[] stringValueIds = new List<int>[100]; // stringValueIds[i] = all strings which have value = i

        for (int i = 0; i < 100; i ++)
            stringValueIds[i] = new List<int>();

        return stringValueIds;
    }

    public static void Run()
    {
        int numberOfStrings = Convert.ToInt32(Console.ReadLine());

        // Initialize
        List<int>[] stringValueIds = FullCountingSort.InitializeStringValIdArr();

        string[] allStrings = new string[numberOfStrings];

        // Get input
        for (int i = 0; i < numberOfStrings; i ++){
            string[] pairInput = Console.ReadLine()
                                .TrimEnd()
                                .Split(' ')
                                .ToArray();
            
            int strValue = Convert.ToInt32(pairInput[0]);
            
            string str = pairInput[1];
            if (i < numberOfStrings / 2)
                str = "-";
            allStrings[i] = str;

            stringValueIds[strValue].Add(i); // Add the corresponding index of string
        }


        var res = FullCountingSort.GenerateTheSortedResult(allStrings, stringValueIds, numberOfStrings);

        Console.WriteLine(res);
    }
}