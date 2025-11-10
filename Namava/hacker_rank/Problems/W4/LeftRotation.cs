// https://www.hackerrank.com/challenges/three-month-preparation-kit-array-left-rotation/problem

using System;

class LeftRotation
{

    static int[] RotateLeft(int arrSize, int[] arr, int rotationStep)
    {
        int[] rotatedArr = new int[arrSize];

        rotationStep %= arrSize;

        for (int i = 0; i < arrSize; i++)
        {
            int rotatedIndex = (i + rotationStep) % arrSize;

            rotatedArr[i] = arr[rotatedIndex];
        }

        return rotatedArr;
    }
        
    public static void Run()
    {
        int[] inputData = Console.ReadLine()
                    .TrimEnd()
                    .Split(' ')
                    .Select(item => Convert.ToInt32(item))
                    .ToArray();

        int arrSize = inputData[0];
        int rotationStep = inputData[1];

        int[] arr = Console.ReadLine()
                    .TrimEnd()
                    .Split(' ')
                    .Select(item => Convert.ToInt32(item))
                    .ToArray();

        int[] rotatedArr = LeftRotation.RotateLeft(arrSize, arr, rotationStep);

        foreach (int number in rotatedArr)
        {
            Console.Write($"{number} ");

        }
    }
}