// https://www.hackerrank.com/challenges/three-month-preparation-kit-an-interesting-game-1/problem

using System;

class GamingArray1
{

    static int[] CalculatePrefixMaxElementIdArr(int arrSize, int[] arr)
    {
        int[] prefixMaxElementId = new int[arrSize]; // If prefixMaxElementId[i] = j then the arr[j] is the max number between arr[0], arr[1], ..., arr[i] and j <= i

        prefixMaxElementId[0] = 0;

        for (int i = 1; i < arrSize; i++)
        {
            int lastPrefixMax = arr[prefixMaxElementId[i - 1]]; // value of max element between arr[0], arr[1], ..., arr[i - 1]

            if (lastPrefixMax >= arr[i])
                prefixMaxElementId[i] = prefixMaxElementId[i - 1];
            else
                prefixMaxElementId[i] = i;
        }

        return prefixMaxElementId;
    }


    static string FindWinner(int arrSize, int[] arr)
    {
        int[] prefixMaxElementId = GamingArray1.CalculatePrefixMaxElementIdArr(arrSize, arr);

        int currentPlayerId = 0;

        string[] players = new string[2] { "BOB", "ANDY" };

        int currentMaxId = prefixMaxElementId[arrSize - 1];

        while (currentMaxId > 0)
        {
            currentMaxId = prefixMaxElementId[currentMaxId - 1];

            currentPlayerId = (currentPlayerId + 1) % 2;

        }

        return players[currentPlayerId];
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

            string winner = GamingArray1.FindWinner(arrSize, arr);

            Console.WriteLine(winner);

            gameCount--;
        }
    }
}