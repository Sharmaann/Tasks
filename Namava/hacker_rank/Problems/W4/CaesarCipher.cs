//https://www.hackerrank.com/challenges/three-month-preparation-kit-caesar-cipher-1/problem

using System;

class CaesarCipher
{

    static char RotateCharacter(char chr, int rotationStep)
    {
        if (!char.IsLetter(chr))
            return chr;

        int asciiNumberOfRotatedChar = (int)chr + rotationStep;

        if (char.IsUpper(chr) && asciiNumberOfRotatedChar > (int)'Z')
            asciiNumberOfRotatedChar = asciiNumberOfRotatedChar - (int)'Z' - 1 + (int)'A';
        if (char.IsLower(chr) && asciiNumberOfRotatedChar > (int)'z')
            asciiNumberOfRotatedChar = asciiNumberOfRotatedChar - (int)'z' - 1 + (int)'a';

        return (char)asciiNumberOfRotatedChar;
    }

    static string Cipher(string inputString, int rotationStep)
    {
        string cipheredString = "";

        rotationStep %= 26;

        foreach (char chr in inputString)
        {
            char rotatedChar = CaesarCipher.RotateCharacter(chr, rotationStep);
            cipheredString += rotatedChar.ToString();
        }

        return cipheredString;
    }

    public static void Run()
    {
        int stringLength = Convert.ToInt32(Console.ReadLine());
        string inputString = Console.ReadLine();

        int rotationStep = Convert.ToInt32(Console.ReadLine());

        string cipheredString = CaesarCipher.Cipher(inputString, rotationStep);

        Console.WriteLine(cipheredString);
    }
}