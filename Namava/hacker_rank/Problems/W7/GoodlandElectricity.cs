// https://www.hackerrank.com/challenges/three-month-preparation-kit-pylons/problem

using System;

class GoodLand
{
    static int FindMinNumberOfPlants(int citiesCount, int distanceRange, int[] citiesArr)
    {
        int idOfLastPlant = -1;
        int idOfLastOne = -1;

        int requiredPlantsCount = 0;
        int nextBoundary = distanceRange - 1;

        for (int i = 0; i < citiesCount; i++)
        {
            if (citiesArr[i] == 1)
                idOfLastOne = i;

            if (i == nextBoundary)
            {
                idOfLastPlant = idOfLastOne;

                if (idOfLastOne == -1)
                    return -1;

                requiredPlantsCount++;
                idOfLastOne = -1;

                nextBoundary = idOfLastPlant + 2 * distanceRange - 1;                     
            }
        }

        if (citiesCount - 1 - idOfLastPlant >= distanceRange) {
            if (idOfLastOne == -1 || citiesCount - 1 - idOfLastOne >= distanceRange)
                return -1;
            requiredPlantsCount++;
        }

        return requiredPlantsCount;
    }

    public static void Run()
    {
        int[] input = Console.ReadLine()
                            .TrimEnd()
                            .Split(' ')
                            .Select(element => Convert.ToInt32(element))
                            .ToArray();
        
        int citiesCount = input[0];
        int distanceRange = input[1];

        int[] citiesArr = Console.ReadLine()
                            .TrimEnd()
                            .Split(' ')
                            .Select(element => Convert.ToInt32(element))
                            .ToArray();

        int minRequiredPlantCount = GoodLand.FindMinNumberOfPlants(citiesCount, distanceRange, citiesArr);
        
        Console.WriteLine(minRequiredPlantCount);
    }
}