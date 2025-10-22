// https://www.hackerrank.com/challenges/three-month-preparation-kit-the-birthday-bar/problem

using System.Collections.Generic;
using System;

class SubarrayDivision2
{

    static int CountSegmentWithSpecificSum(int listLength, List<int> inputList, int segmentLength, int desiredSegmentSum){
        int count = 0;
        var partialSum = new List<int> ();

        partialSum.Add(inputList[0]);

        for (int i = 1; i < listLength; i ++){
            partialSum.Add(partialSum[i - 1] + inputList[i]);

            int segmentSum = 0;

            if (i == segmentLength - 1)
                segmentSum = partialSum[i];
            else if (i > segmentLength - 1)
                segmentSum = partialSum[i] - partialSum[i - segmentLength];

            if (segmentSum == desiredSegmentSum)
                count ++;
        }

        if (segmentLength == 1 && inputList[0] == desiredSegmentSum)
            count ++;

        return count;
    }

    public static void Run()
    {
        int listLength = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> inputList = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int desiredSegmentSum = Convert.ToInt32(firstMultipleInput[0]);
        int segmentLength = Convert.ToInt32(firstMultipleInput[1]);

        int result = SubarrayDivision2.CountSegmentWithSpecificSum(listLength, inputList, segmentLength, desiredSegmentSum);
        
        Console.WriteLine(result);
    } 
}