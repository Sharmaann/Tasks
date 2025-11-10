// https://www.hackerrank.com/challenges/three-month-preparation-kit-tower-breakers-1/problem

using System;

class TowerBreakers
{

    static int GetWinner(int towersCount, int towersHeight)
    {
        if (towersCount % 2 == 0 || towersHeight == 1)
            return 2;
        return 1;
    }

    public static void Run()
    {

        int queryCount = Convert.ToInt32(Console.ReadLine());

        while (queryCount > 0)
        {
            int[] inputData = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();

            int towersCount = inputData[0];
            int towersHeight = inputData[1];

            int winner = TowerBreakers.GetWinner(towersCount, towersHeight);

            Console.WriteLine(winner);

            queryCount--;
        }
    }
}