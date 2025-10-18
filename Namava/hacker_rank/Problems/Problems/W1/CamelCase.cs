// https://www.hackerrank.com/challenges/three-month-preparation-kit-camel-case/problem

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
class CamelCase
{
    public static string ConvertToCamelCase(string input)
    {
        StringBuilder camelCasedInput = new StringBuilder(50);

        for (int i = 0; i < input.Length; i++)
        {
            char chr = input[i];

            if (input[i] == ' ')
                continue;
            if (i == 0)
            {
                camelCasedInput.Append(Char.ToLower(chr));
                continue;
            }
            if (input[i - 1] == ' ')
                chr = Char.ToUpper(chr);

            camelCasedInput.Append(chr);
        }

        return camelCasedInput.ToString();
    }

    public static string ConvertToPascalCase(string input)
    {
        string camelCasedInput = CamelCase.ConvertToCamelCase(input);
        string pascalCased = Char.ToUpper(camelCasedInput[0]).ToString() + camelCasedInput.Substring(1);
        return pascalCased;
    }

    static string PreProcess(string input)
    {
        StringBuilder preProcessedInput = new StringBuilder(50);

        for (int i = 0; i < input.Length; i++)
        {
            char chr = input[i];

            if (chr == '(' || chr == ')')
                continue;
            if (i == 0 && char.IsUpper(chr))
            {
                preProcessedInput.Append(Char.ToLower(chr));
                continue;
            }

            preProcessedInput.Append(chr);
        }

        return preProcessedInput.ToString();
    }

    public static string Split(string input)
    {
        input = CamelCase.PreProcess(input);

        StringBuilder splittedString = new StringBuilder(50);
        StringBuilder temp = new StringBuilder(50);

        foreach (char chr in input)
        {
            if (char.IsUpper(chr))
            {
                splittedString.Append(temp);
                splittedString.Append(" ");

                temp.Clear();
                temp.Append(Char.ToLower(chr));

                continue;
            }
            temp.Append(chr);
        }

        if (temp.Length > 0)
            splittedString.Append(temp);

        return splittedString.ToString();
    }

    public static void Run()
    {
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            string[] splittedLine = line.Split(';');

            string operation = splittedLine[0];
            string type = splittedLine[1];
            string word = splittedLine[2];

            string result = "";

            switch (operation)
            {
                case "S":
                    result = CamelCase.Split(word);
                    Console.WriteLine(result);

                    break;

                case "C":
                    switch (type)
                    {
                        case "C":
                            result = CamelCase.ConvertToPascalCase(word);
                            break;
                        case "V":
                            result = CamelCase.ConvertToCamelCase(word);
                            break;
                        case "M":
                            result = CamelCase.ConvertToCamelCase(word) + "()";
                            break;
                    }
                    Console.WriteLine(result);

                    break;
            }
        }
    }
}