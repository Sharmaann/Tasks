// https://www.hackerrank.com/challenges/three-month-preparation-kit-kangaroo/problem

using System;
using System.Numerics;

class NumberLineJumps
{
    static string CheckIfTheyCoincide(int k1Position, int k1Step, int k2Position, int k2Step)
    {
        string conincide = "NO";

        if (k1Step == k2Step) {
            bool atTheSamePosition = (k1Position == k2Position);
            
            if (atTheSamePosition)
                conincide = "YES";
            
            return conincide;
        }

        /*
         If they coincide it's gonna be at second 't'.
         t =  (k2Position - k1Position) / (k1Step - k2Step)
         */

        if ((k2Position - k1Position) % (k1Step - k2Step) == 0 && (k2Position - k1Position) / (k1Step - k2Step) > 0)
            conincide = "YES";

        return conincide;
    }

    public static void Run()
    {
        int[] inputData = Console.ReadLine()
                    .TrimEnd()
                    .Split(' ')
                    .Select(item => Convert.ToInt32(item))
                    .ToArray();

        int k1Position = inputData[0];
        int k1Step = inputData[1];

        int k2Position = inputData[2];
        int k2Step = inputData[3];

        string coincide = NumberLineJumps.CheckIfTheyCoincide(k1Position, k1Step, k2Position, k2Step);

        Console.WriteLine(coincide);
    }
}