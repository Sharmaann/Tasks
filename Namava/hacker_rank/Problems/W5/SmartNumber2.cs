// https://www.hackerrank.com/challenges/three-month-preparation-kit-smart-number/problem

using System;

class SmartNumber
{
    
    static string CheckIsSmart(int number)
    {
        int sqrt = (int) Math.Sqrt(number);
        
        if (sqrt * sqrt == number)
            return "YES";
        return "NO";
    }

    public static void Run()
    {
        int queryCount = Convert.ToInt32(Console.ReadLine());

        while (queryCount > 0)
        {
            int number = Convert.ToInt32(Console.ReadLine());

            string isSmart = SmartNumber.CheckIsSmart(number);
            
            Console.WriteLine(isSmart);

            queryCount--;
        }
    }
}