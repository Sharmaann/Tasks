// https://www.hackerrank.com/challenges/three-month-preparation-kit-dynamic-array/problem

using System;

class DynamicArray
{

    static void AppendQuery(int elementY, int arrIndex, List<int>[] arrayOfLists)
    {
        arrayOfLists[arrIndex].Add(elementY);
    }

    static void UpdateLastAnswer(int arrIndex, int listIndex, ref int lastAnswer, List<int>[] arrayOfLists)
    {
        lastAnswer = arrayOfLists[arrIndex][listIndex];
    }

    static void ProcessQuery(int arrSize, int[] query, List<int>[] arrayOfLists, ref int lastAnswer, List<int> answerList)
    {
        int queryType = query[0];
        int elementX = query[1];
        int elementY = query[2];

        int arrIndex = (elementX ^ lastAnswer) % arrSize; // for example the arrIndex=2 means the 2nd list

        switch (queryType)
        {
            case 1:
                DynamicArray.AppendQuery(elementY, arrIndex, arrayOfLists);

                break;

            case 2:
                int listIndex = elementY % arrayOfLists[arrIndex].Count;

                DynamicArray.UpdateLastAnswer(arrIndex, listIndex, ref lastAnswer, arrayOfLists);
                answerList.Add(lastAnswer);

                break;
        }
    }

    public static void Run()
    {
        int[] input = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();

        int arrSize = input[0];
        int queryCount = input[1];

        List<int>[] arrayOfLists = new List<int>[arrSize];
        for (int i = 0; i < arrSize; i++)
            arrayOfLists[i] = new List<int>();

        var answerList = new List<int>();
        int lastAnswer = 0;

        while (queryCount > 0)
        {
            int[] query = Console.ReadLine()
                        .TrimEnd()
                        .Split(' ')
                        .Select(element => Convert.ToInt32(element))
                        .ToArray();

            DynamicArray.ProcessQuery(arrSize, query, arrayOfLists, ref lastAnswer, answerList);

            queryCount--;
        }

        foreach (int answerElement in answerList)
            Console.WriteLine(answerElement);
    }
}