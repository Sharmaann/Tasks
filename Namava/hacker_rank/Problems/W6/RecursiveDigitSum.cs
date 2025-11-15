// https://www.hackerrank.com/challenges/three-month-preparation-kit-recursive-digit-sum/problem

using System;

class RecursiveDigitSum
{

    static long CalculateDigitSum(string numberString)
    {
        long sum = 0;

        foreach (char character in numberString)
            sum += (long) char.GetNumericValue(character);

        return sum;
    }

    static long CalculateSuperDigit(string numberString, int repetition)
    {
        long repeatedSum = RecursiveDigitSum.CalculateDigitSum(numberString) * repetition;
        long number = repeatedSum;

        while (number / 10 > 0)
            number = RecursiveDigitSum.CalculateDigitSum(number.ToString());

        return number;
    }

    public static void Run() 
    {
        string[] input = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .ToArray();

        string numberString = input[0];
        int repetition = Convert.ToInt32(input[1]);

        long superDigit = RecursiveDigitSum.CalculateSuperDigit(numberString, repetition);

        Console.WriteLine(superDigit);
    }
}