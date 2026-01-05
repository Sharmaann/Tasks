// https://www.hackerrank.com/challenges/three-month-preparation-kit-hackerland-radio-transmitters/problem

using System;

class HackerlandRadio
{

    static int CalculateMinRequiredPositions(int landsNumber, int[] positions, int coveredRange)
    {
        if (landsNumber == 1)
            return 1;

        int minRequiredPositions = 1;
        int dist = 0;
        int firstSelectedPositionId = -1;

        // find the first selected position id 
        Array.Sort(positions);
        for (int i = 1; i < landsNumber; i ++){
            dist += positions[i] - positions[i - 1];
            if (dist > coveredRange){ // condition for the first selected position
                firstSelectedPositionId = i - 1;
                break;
            }
        }

        if (firstSelectedPositionId == -1) // we didn't enter "condition for the first selected position"
            return 1;

        int previousSelectedPositionId = firstSelectedPositionId;
        int leftmostUncoveredPositionId = -1;
        int distanceFromPreviousSelectedPosition = 0;

        for (int i = firstSelectedPositionId + 1; i < landsNumber; i ++){
            distanceFromPreviousSelectedPosition = positions[i] - positions[previousSelectedPositionId];

            if (distanceFromPreviousSelectedPosition <= coveredRange)
                continue;

            if (leftmostUncoveredPositionId == -1)
                leftmostUncoveredPositionId = i;
            
            int distanceFromLeftmostUncoveredPosition = positions[i] - positions[leftmostUncoveredPositionId];

            if (distanceFromLeftmostUncoveredPosition > coveredRange){
                previousSelectedPositionId = i - 1;
                i = previousSelectedPositionId; // continue from the next position of the selected position
                leftmostUncoveredPositionId = -1;
                minRequiredPositions ++;
            }
        }

        if (leftmostUncoveredPositionId != -1)
            minRequiredPositions ++;

        return minRequiredPositions;
    }

    public static void Run()
    {
        int[] input = Console.ReadLine()
                        .TrimEnd()
                        .Split()
                        .Select(item => Convert.ToInt32(item))
                        .ToArray();

        int landsNumber = input[0];
        int coveredRange = input[1];

        int[] positions = Console.ReadLine()
                            .TrimEnd()
                            .Split()
                            .Select(item => Convert.ToInt32(item))
                            .ToArray();

        int minRequiredPositions = HackerlandRadio.CalculateMinRequiredPositions(landsNumber, positions, coveredRange);
        Console.WriteLine(minRequiredPositions);
    }
}