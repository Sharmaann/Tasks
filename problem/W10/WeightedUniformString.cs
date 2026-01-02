// https://www.hackerrank.com/challenges/three-month-preparation-kit-weighted-uniform-string/problem

using System;

class WeightedUniformString
{
    static Dictionary<int, bool> CalculateWeightsOfAllUniformSubstrings(string input)
    {
        char previousChar = '-';
        int weightOfUniformSubstring = 0;

        var allPossibleSubstringUniformWeights = new Dictionary<int, bool>();

        foreach (char chr in input)
        {
            if (previousChar != chr)
            {
                previousChar = chr;
                weightOfUniformSubstring = 0;
            }

            weightOfUniformSubstring += chr - 'a' + 1;
            allPossibleSubstringUniformWeights[weightOfUniformSubstring] = true;
        }

        return allPossibleSubstringUniformWeights;
    }

    public static void Run()
    {
        string input = Console.ReadLine();
        int queryNumbers = Convert.ToInt32(Console.ReadLine());

        Dictionary<int, bool> allPossibleSubstringUniformWeights = WeightedUniformString.CalculateWeightsOfAllUniformSubstrings(input);

        var resultArr = new string[queryNumbers];
        int index = 0;

        while (queryNumbers > 0)
        {
            int weight = Convert.ToInt32(Console.ReadLine());

            string res = allPossibleSubstringUniformWeights.TryGetValue(weight, out bool _)
                ? "Yes"
                : "No" ;
            resultArr[index++] = res;

            queryNumbers--;
        }
        Console.WriteLine(String.Join("\n", resultArr));
    }
}