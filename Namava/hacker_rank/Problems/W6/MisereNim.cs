// https://www.hackerrank.com/challenges/three-month-preparation-kit-misere-nim-1/problem

using System;

class MisereNim
{
    static string FindWinner(int arrSize, int[] arr)
    {
        int oneStonePilesCount = 0;
        int totalXor = 0;

        foreach (int stoneCount in arr)
        {
            if (stoneCount == 1)
                oneStonePilesCount++;

            totalXor ^= stoneCount;
        }

        if (oneStonePilesCount == arrSize)
        {
            if (arrSize % 2 == 0)
                return "First";
            return "Second";
        }

        if (totalXor == 0)
            return "Second";

        foreach (int stoneCount in arr)
        {
            int target = stoneCount ^ totalXor;
            if (target < stoneCount)
                return "First";
        }

        return "Second";
    }

    public static void Run() 
    {
        int gameCount = Convert.ToInt32(Console.ReadLine());

        while (gameCount > 0)
        {
            int arrSize = Convert.ToInt32(Console.ReadLine());
            int[] arr = Console.ReadLine()
                            .TrimEnd()
                            .Split(' ')
                            .Select(element => Convert.ToInt32(element))
                            .ToArray();

            string winner = MisereNim.FindWinner(arrSize, arr);

            Console.WriteLine(winner);

            gameCount--;
        }
    }
}