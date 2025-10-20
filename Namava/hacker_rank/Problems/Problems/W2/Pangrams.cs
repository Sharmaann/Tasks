//https://www.hackerrank.com/challenges/three-month-preparation-kit-pangrams/problem

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Pangrams
{

    static string PreProcess(string input)
    {
        // Convert all characters to lowercase
        return input.ToLower();
    }

    static bool CheckPangram(string input)
    {
        var characterSet = new HashSet<char>();

        input = Pangrams.PreProcess(input);

        foreach (char character in input)
        {
            characterSet.Add(character);
        }

        int characterCount = characterSet.Count;

        if (characterCount == 27) // 26 English alphabet + space
            return true;

        return false;
    }

    public static void Run()
    {
        string input = Console.ReadLine();

        bool isPangram = Pangrams.CheckPangram(input);

        if (isPangram)
            Console.WriteLine("pangram");
        else
            Console.WriteLine("not pangram");
    }
}