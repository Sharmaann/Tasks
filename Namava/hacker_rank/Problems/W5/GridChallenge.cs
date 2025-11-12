// https://www.hackerrank.com/challenges/three-month-preparation-kit-grid-challenge/problem

using System;

class GridChallenge
{

    static string CheckItCanBeOrdered(int rowsCount, int colsCount, char[][] rows)
    {
        // It checks if we can order the grid alphabetically only by changing characters in rows

        for (int col = 0; col < colsCount; col++)
        {
            char previousCharacter = ' ';

            for (int row = 0; row < rowsCount; row++)
            {
                if (rows[row][col] < previousCharacter)
                    return "NO";

                previousCharacter = rows[row][col];
            }
        }

        return "YES";
    }

    public static void Run()
    {
        int queryCount = Convert.ToInt32(Console.ReadLine());

        while (queryCount > 0)
        {
            // number of rows == number of  cols
            int rowsCount = Convert.ToInt32(Console.ReadLine());
            int colsCount = 0;

            char[][] rows = new char[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                char[] chars = Console.ReadLine()
                                .Trim()
                                .ToCharArray();

                colsCount = chars.Length;

                rows[i] = new char[colsCount];

                Array.Sort(chars);
                Array.Copy(chars, rows[i], colsCount);
            }


            string canBeOrderedAlphabetically = GridChallenge.CheckItCanBeOrdered(rowsCount, colsCount, rows);

            Console.WriteLine(canBeOrderedAlphabetically);

            queryCount--;
        }
    }
}