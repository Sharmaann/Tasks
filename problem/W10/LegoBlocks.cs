// https://www.hackerrank.com/challenges/three-month-preparation-kit-lego-blocks/problem

using System;

class LegoBlocks
{
    const long MOD = (long)1e9 + 7;
    const int MAX_WIDTH = 1000;
    const int MAX_HEIGHT = 1000;


    static long[] rowAns = new long[MAX_WIDTH + 1];
    static long[,] allStructuresAns = new long[MAX_HEIGHT + 1, MAX_WIDTH + 1];

    public static void PreProcess()
    {
        LegoBlocks.CalculateNumberOfRowStructures();
        LegoBlocks.CalculateNumberOfAllPossibleStructures();
    }

    static void CalculateNumberOfRowStructures()
    {
        LegoBlocks.rowAns[0] = 1;
        LegoBlocks.rowAns[1] = 1;

        for (int currentWidth = 2; currentWidth <= MAX_WIDTH; currentWidth++)
        {
            for (int i = 1; i <= 4; i++)
            {
                int candidateSubProblemWidth = currentWidth - i;

                if (candidateSubProblemWidth < 0) continue;

                LegoBlocks.rowAns[currentWidth] += LegoBlocks.rowAns[candidateSubProblemWidth];

                LegoBlocks.rowAns[currentWidth] %= LegoBlocks.MOD;
            }
        }
    }

    static void CalculateNumberOfAllPossibleStructures()
    {
        for (int width = 1; width <= MAX_WIDTH; width++)
        {
            LegoBlocks.allStructuresAns[1, width] = LegoBlocks.rowAns[width];

            for (int power = 2; power <= MAX_HEIGHT; power++)
            {
                LegoBlocks.allStructuresAns[power, width] =
                    LegoBlocks.allStructuresAns[power - 1, width] * LegoBlocks.rowAns[width];

                LegoBlocks.allStructuresAns[power, width] %= LegoBlocks.MOD;
            }
        }

    }

    static long CalculateNumberOfBadStructures(int height, int width, long[] ans)
    {
        long numberOfBadStructures = 0;

        for (int leftmostCrackPoint = 1; leftmostCrackPoint < width; leftmostCrackPoint++)
        {
            numberOfBadStructures +=
                ans[leftmostCrackPoint] * LegoBlocks.allStructuresAns[height, width - leftmostCrackPoint];
            numberOfBadStructures %= LegoBlocks.MOD;
        }

        return numberOfBadStructures;
    }

    public static long CalculateNumberOfSolidStructures(int height, int width)
    {
        var ans = new long[width + 1]; // ans[i] = number of solid structures for a height*i rectangle

        ans[1] = 1; // only one solid structure for height*1 rectangle

        for (int currentWidth = 1; currentWidth <= width; currentWidth++)
        {
            long numberOfBadStructures = LegoBlocks.CalculateNumberOfBadStructures(height, currentWidth, ans);
            ans[currentWidth] = LegoBlocks.allStructuresAns[height, currentWidth] - numberOfBadStructures + LegoBlocks.MOD;

            ans[currentWidth] %= LegoBlocks.MOD;
        }

        return ans[width];
    }


    public static void Run()
    {
        int queryNumbers = Convert.ToInt32(Console.ReadLine());

        LegoBlocks.PreProcess();

        while (queryNumbers > 0)
        {
            int[] input = Console.ReadLine()
                            .TrimEnd()
                            .Split()
                            .Select(element => Convert.ToInt32(element))
                            .ToArray();
            int height = input[0];
            int width = input[1];

            long ans = CalculateNumberOfSolidStructures(height, width);

            Console.WriteLine(ans);

            queryNumbers--;
        }
    }
}