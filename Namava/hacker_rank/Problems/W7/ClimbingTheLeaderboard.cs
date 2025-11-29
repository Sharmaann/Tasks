// https://www.hackerrank.com/challenges/three-month-preparation-kit-climbing-the-leaderboard/problem

using System;

class ClimbingLeaderboard
{
    static int[] PreProcess(int[] rankedScores)
    {
        // It merges neighbor cells with the same score
        
        int previousScore = -1;
        
        int[] preProcessedRankedScores = new int[rankedScores.Length];
        int index = 0;
        
        foreach (int rankedScore in rankedScores)
        {
            if (rankedScore != previousScore){
                preProcessedRankedScores[index ++] = rankedScore;
                previousScore = rankedScore;
            }
        }
        
        Array.Resize(ref preProcessedRankedScores, index);

        return preProcessedRankedScores;
    }
    
    
    static int BinarySearch(int[] arr, int number, int leftId = -1)
    {
        int rightId = arr.Length - 1;
        int ansId = leftId;
        int midId = -1;


        while (leftId <= rightId){
            midId = (leftId + rightId) / 2;

            // Console.WriteLine($"{leftId} {rightId} {number}");

            if (midId < 0)
                return midId;

            if (number < arr[midId])
                rightId = midId - 1;
            else if (number > arr[midId]){
                leftId = midId + 1;
                ansId = midId;
            }
            else
                return midId - 1;
            
        }
        return ansId;
    }

    public static void Run()
    {
        int playersCount = Convert.ToInt32(Console.ReadLine().Trim());

        int[] rankedScores = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();

        rankedScores = ClimbingLeaderboard.PreProcess(rankedScores);

        int uniqueScoreNumbers = rankedScores.Length;

        Array.Reverse(rankedScores);

        int gamesCount = Convert.ToInt32(Console.ReadLine().Trim());

        int[] playerScores = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();
        
        int previousLeftId = -1;

        foreach (int playerScore in playerScores)
        {
            int scoreId = ClimbingLeaderboard.BinarySearch(rankedScores, playerScore, previousLeftId);

            previousLeftId = scoreId;

            int rank = uniqueScoreNumbers - scoreId;
            if (scoreId + 1 < uniqueScoreNumbers && rankedScores[scoreId + 1] == playerScore)
                rank --;

            Console.WriteLine(rank);
        }
    }
}
