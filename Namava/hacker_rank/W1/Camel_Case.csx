using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    public static string ConvertToCamelCase(string input)
    {
        string camelCasedInput = "";

        for (int i = 0; i < input.Length; i++)
        {
            char chr = input[i];

            if (input[i] == ' ')
                continue;
            if (i == 0)
            {
                camelCasedInput += Char.ToLower(chr).ToString();
                continue;
            }
            if (input[i - 1] == ' ')
                chr = Char.ToUpper(chr);

            camelCasedInput += chr.ToString();
        }

        return camelCasedInput;
    }

    public static string ConvertToPascalCase(string input)
    {
        string camelCasedInput = Solution.ConvertToCamelCase(input);
        string pascalCased = Char.ToUpper(camelCasedInput[0]).ToString() + camelCasedInput.Substring(1);
        return pascalCased;
    }

    static string PreProcess(string input)
    {
        string preProcessedInput = "";

        for (int i = 0; i < input.Length; i ++) {
            char chr = input[i];

            if (chr == '(' || chr == ')')
                continue;
            if (i == 0 && char.IsUpper(chr)) {
                preProcessedInput += Char.ToLower(chr).ToString();
                continue;
            }

            preProcessedInput += chr.ToString();
        }

        return preProcessedInput;
    }

    public static string Split(string input)
    {
        input = Solution.PreProcess(input);

        string splittedString = "";
        string temp = "";

        foreach (char chr in input)
        {
            if (char.IsUpper(chr))
            {
                splittedString += temp;
                splittedString += " ";

                temp = Char.ToLower(chr).ToString();

                continue;
            }
            temp += chr;
        }

        if (temp.Length > 0)
            splittedString += temp;

        return splittedString;
    }
}

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
            result = Solution.Split(word);
            Console.WriteLine(result);

            break;

        case "C":
            switch (type)
            {
                case "C":
                    result = Solution.ConvertToPascalCase(word);
                    break;
                case "V":
                    result = Solution.ConvertToCamelCase(word);
                    break;
                case "M":
                    result = Solution.ConvertToCamelCase(word) + "()";
                    break;
            }
            Console.WriteLine(result);

            break;
    }
}