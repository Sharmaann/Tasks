// https://www.hackerrank.com/challenges/three-month-preparation-kit-migratory-birds/problem

// using System.Collections.Generic;
using System;

class MigratoryBirds{

    static int FindMostFrequentNumber(List <int> arr){
        var numberCountMap = new Dictionary <int, int>();
        
        int maxFrequencyCount = 0;
        int minNumberWithMaxFrequency = Int32.MaxValue;

        foreach (int number in arr){
            int numberFrequencyCount = numberCountMap.GetValueOrDefault(number, 0);
            
            numberCountMap[number] = numberFrequencyCount + 1;
            
            if (numberCountMap[number] > maxFrequencyCount)
                maxFrequencyCount = numberCountMap[number];
        }

        foreach (int number in arr){
            if (numberCountMap[number] == maxFrequencyCount){
                if (number < minNumberWithMaxFrequency)
                    minNumberWithMaxFrequency = number;
            }
        }

        return minNumberWithMaxFrequency;
    }

    public static void Run(){
        int arrSize = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = MigratoryBirds.FindMostFrequentNumber(arr);
        
        Console.WriteLine(result);
    }
}