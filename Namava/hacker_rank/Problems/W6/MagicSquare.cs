// https://www.hackerrank.com/challenges/three-month-preparation-kit-magic-square-forming/problem

using System;
using System.Collections.Generic;
using System.Linq;

class MagicSquare
{

    static List<List<int>> GenerateAllPermutations(int n)
    {
        if (n == 1)
        {
            var onePermutations = new List<int> { 1 };
            var answer = new List<List<int>> { onePermutations };

            return answer;
        }

        List<List<int>> previousPermutations = GenerateAllPermutations(n - 1);
        var currentPermutations = new List<List<int>>();

        foreach (var previousPermutation in previousPermutations)
        {

            for (int i = 0; i < n; i++)
            {

                //Console.WriteLine($"{i} {n}");

                var currentPermutation = new List<int>();

                var prefixPermutation = previousPermutation.GetRange(0, i);
                var suffixPermutation = previousPermutation.GetRange(i, n - 1 - i);

                currentPermutation.AddRange(prefixPermutation);
                currentPermutation.Add(n);
                currentPermutation.AddRange(suffixPermutation);

                currentPermutations.Add(currentPermutation);
            }
        }

        return currentPermutations;
        
    }

    static bool CheckIsMagicPermutation(List<int> permutation)
    {
        int squareSize = 3;
        int maxNumberInSquare = squareSize * squareSize;
        int correctSum = maxNumberInSquare * (maxNumberInSquare + 1) / 2;
        int correctRowSum = correctSum / squareSize;

        int col0Sum = permutation[0] + permutation[3] + permutation[6];
        int col1Sum = permutation[1] + permutation[4] + permutation[7];
        int col2Sum = permutation[2] + permutation[5] + permutation[8];

        if (
             col0Sum != correctRowSum ||
             col1Sum != correctRowSum ||
             col2Sum != correctRowSum
            )
            return false;

        int row0Sum = permutation[0] + permutation[1] + permutation[2];
        int row1Sum = permutation[3] + permutation[4] + permutation[5];
        int row2Sum = permutation[6] + permutation[7] + permutation[8];

        if (
             row0Sum != correctRowSum ||
             row1Sum != correctRowSum ||
             row2Sum != correctRowSum
            )
            return false;


        int diagonal1Sum = permutation[0] + permutation[4] + permutation[8];
        int diagonal2Sum = permutation[2] + permutation[4] + permutation[6];

        if (diagonal1Sum != correctRowSum || diagonal2Sum != correctRowSum)
            return false;

        return true;
    }

    static List<List<int>> GetAllMagicPermutations(List<List<int>> permutations)
    {
        var magicPermutations = new List<List<int>>(); 

        foreach (var permutation in permutations)
        {
            if (MagicSquare.CheckIsMagicPermutation(permutation))
                magicPermutations.Add(permutation);
        }

        return magicPermutations;
    }

    static List<int> InputRow()
    {
        List<int> row1 = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToList();

        return row1;
    }

    static int CalculateSquareDifference(List<List<int>> square1, List<List<int>> square2)
    {
        int difference = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                difference += Math.Abs(square1[i][j] - square2[i][j]);
            }
        }

        return difference;
    }

    static List<List<int>> ConvertPermutationToSquare(List<int> permutation)
    {
        var square = new List<List<int>>();

        var row1 = new List<int> { permutation[0], permutation[1], permutation[2] };
        var row2 = new List<int> { permutation[3], permutation[4], permutation[5] };
        var row3 = new List<int> { permutation[6], permutation[7], permutation[8] };

        square.Add(row1);
        square.Add(row2);
        square.Add(row3);

        return square;
    }

    static int CalculateMinRequiredChanges(List<List<int>> square)
    {
        int minChanges = Int32.MaxValue;

        List<List<int>> permutations = MagicSquare.GenerateAllPermutations(9);
        List<List<int>> allMagicPermutations = MagicSquare.GetAllMagicPermutations(permutations);
        
        foreach (var magicPermutation in allMagicPermutations)
        {
            List<List<int>> magicSquare = MagicSquare.ConvertPermutationToSquare(magicPermutation);
            minChanges = Math.Min(minChanges, MagicSquare.CalculateSquareDifference(square, magicSquare));
        }

        return minChanges;
    }

    public static void Run()
    {
        List<int> row1 = MagicSquare.InputRow();
        List<int> row2 = MagicSquare.InputRow();
        List<int> row3 = MagicSquare.InputRow();

        List<List<int>> square = [row1, row2, row3];

        int minRequiredChanges = MagicSquare.CalculateMinRequiredChanges(square);

        Console.WriteLine(minRequiredChanges);
    }
}