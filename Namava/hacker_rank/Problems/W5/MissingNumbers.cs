// https://www.hackerrank.com/challenges/three-month-preparation-kit-missing-numbers/problem

using System;
using System.Collections.Generic;

class MissingNumbers
{

    static int[] GetInput()
    {
        int arrSize = Convert.ToInt32(Console.ReadLine());
        int[] arr = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();
        
        return arr;
    }

    static Dictionary<int, int> GetArrayNumbersCount(int[] arr)
    {
        var numberOccurrenceCount = new Dictionary<int, int>();

        foreach (int number in arr)
        {
            if (numberOccurrenceCount.TryGetValue(number, out int occurrenceCount))
                numberOccurrenceCount[number] = occurrenceCount + 1;
            else
                numberOccurrenceCount[number] = 1;
        }

        return numberOccurrenceCount;
    }

    static List<int> FindExtraElements(int[] arr1, int[] arr2)
    {
        var missingNumbers = new List<int>();

        Dictionary<int, int> arr1NumberSet = MissingNumbers.GetArrayNumbersCount(arr1);
        Dictionary<int, int> arr2NumberSet = MissingNumbers.GetArrayNumbersCount(arr2);

        var numberAlreadyChecked = new HashSet<int>();

        foreach (var arr2Pair in arr2NumberSet)
        {
            int number = arr2Pair.Key;
            int occurrenceCountInArr2 = arr2Pair.Value;

            if (numberAlreadyChecked.Contains(number))
                continue;

            numberAlreadyChecked.Add(number);

            if (arr1NumberSet.TryGetValue(number, out int occurrenceCountInArr1) &&
                    occurrenceCountInArr1 == occurrenceCountInArr2)
                continue;

            missingNumbers.Add(number);
        }

        missingNumbers.Sort();
        return missingNumbers;
    }

    public static void Run()
    {
        int[] arr1 = MissingNumbers.GetInput();
        int[] arr2 = MissingNumbers.GetInput();

        List<int> missingNumbers = MissingNumbers.FindExtraElements(arr1, arr2);

        Console.WriteLine(string.Join(" ", missingNumbers));
    }
}