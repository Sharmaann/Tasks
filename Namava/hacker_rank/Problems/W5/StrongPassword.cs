// https://www.hackerrank.com/challenges/three-month-preparation-kit-strong-password/problem

using System;

class StrongPassword
{

    static int GetMinRequiredCharacterCountForStrong(int passwordLength, string password)
    {
        int GetNeededCharactersForLengthLimit()
        {
            const int minLength = 6;

            return Math.Max(minLength - passwordLength, 0);
        }

        bool CheckNeedDigit()
        {
            /*
             It checks whether or not the string needs a digit
             */

            return ! password.Any(chr => char.IsDigit(chr));
        }

        bool CheckNeedLowercase()
        {
            /*
             It checks whether or not the string needs a lowercase letter
             */

            return ! password.Any(chr => char.IsLower(chr));
        }

        bool CheckNeedUppercase()
        {
            /*
             It checks whether or not the string needs an uppercase letter
             */

            return ! password.Any(chr => char.IsUpper(chr));
        }

        bool CheckNeedSpecialCharacter()
        {
            /*
             It checks whether or not the string needs a special character
             */

            string specialCharacters = "!@#$%^&*()-+";

            return ! password.Any(chr => specialCharacters.Contains(chr));
        }

        int needDigit = Convert.ToInt32(CheckNeedDigit());
        int needLowercase = Convert.ToInt32(CheckNeedLowercase());
        int needUppercase = Convert.ToInt32(CheckNeedUppercase());
        int needSpecialCharacter = Convert.ToInt32(CheckNeedSpecialCharacter());

        int neededCharacterCategoriesCount = needDigit + needLowercase + needUppercase + needSpecialCharacter;
        int minRequiredCharacterCountForStrong = Math.Max(neededCharacterCategoriesCount, GetNeededCharactersForLengthLimit());

        return minRequiredCharacterCountForStrong;
    }

    public static void Run()
    {
        int passwordLength = Convert.ToInt32(Console.ReadLine());
        string password = Console.ReadLine();

        int minRequiredCharacterCountForStrong = StrongPassword.GetMinRequiredCharacterCountForStrong(passwordLength, password);

        Console.WriteLine(minRequiredCharacterCountForStrong);
    }
}