// https://www.hackerrank.com/challenges/three-month-preparation-kit-strings-xor/problem

using System;

class XORString3
{

    static string XOR(string input1, string input2){
        int inputLength = input1.Length;
        string result = "";

        for (int i = 0; i < inputLength; i ++){
            if (input1[i] == input2[i])
                result += "0";
            else
                result += "1";
        }

        return result;
    }

    public static void Run(){
        string input1 = Console.ReadLine();
        string input2 = Console.ReadLine();

        string xor = XORString3.XOR(input1, input2);

        Console.WriteLine(xor);

    }
}