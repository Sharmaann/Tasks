// https://www.hackerrank.com/challenges/three-month-preparation-kit-counter-game/problem

using System;

class CounterGame
{

    static long FindPreviousPowerOfTwo(long number)
    {
        int log2Number = (int) Math.Log2(number);

        return (long) Math.Pow(2, log2Number);
    }

    static long UpdateNumber(long number)
    {
        long previousPowerOfTwo = CounterGame.FindPreviousPowerOfTwo(number);

        if (number == previousPowerOfTwo)
            return number / 2;

        return number - previousPowerOfTwo;

    }

    static string DetermineTheWinner(long number)
    {
        string[] players = new string[2] { "Louise", "Richard" };
        int currentPlayerId = 0;

        if (number == 1)
            return players[1];

        while (number > 1)
        {
            number = CounterGame.UpdateNumber(number);
            currentPlayerId = (currentPlayerId + 1) % 2;
        }

        currentPlayerId = (currentPlayerId + 1) % 2;
        string winner = players[currentPlayerId];

        return winner;
    }

    public static void Run()
    {
        int queryCount = Convert.ToInt32(Console.ReadLine());

        while (queryCount > 0)
        {
            long number = Convert.ToInt64(Console.ReadLine());

            string winner = CounterGame.DetermineTheWinner(number);

            Console.WriteLine(winner);

            queryCount--;
        }
    }
}