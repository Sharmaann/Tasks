// https://www.hackerrank.com/challenges/three-month-preparation-kit-sherlock-and-valid-string/problem

using System;

class SherlockAndValidString
{

    static Dictionary<char, int> GetCharacterOccurrenceCountDict(string input)
    {
        var characterOccurrenceCountDict = new Dictionary<char, int>();

        foreach (char chr in input)
        {
            int charOccurrence = 0;
            characterOccurrenceCountDict.TryGetValue(chr, out charOccurrence);
            characterOccurrenceCountDict[chr] = charOccurrence + 1;
        }

        return characterOccurrenceCountDict;
    }

    static bool ValidateString(string input)
    {
        var characterOccurrenceCountDict = SherlockAndValidString.GetCharacterOccurrenceCountDict(input);

        var occurrenceCount = new Dictionary<int, int>(); // occurrenceCount[i] = number of characters with i occurrences

        int maxOccurrenceCount = Int32.MinValue;
        int minOccurrenceCount = Int32.MaxValue;

        foreach (var occurrence in characterOccurrenceCountDict.Values)
        {
            int temp = 0;
            occurrenceCount.TryGetValue(occurrence, out temp);
            occurrenceCount[occurrence] = temp + 1 ;

            maxOccurrenceCount = Math.Max(maxOccurrenceCount, occurrence);
            minOccurrenceCount = Math.Min(minOccurrenceCount, occurrence);
        }

        int numberOfCharactersWithDifferentOccurrenceCount = occurrenceCount.Count;

        bool isValid = (numberOfCharactersWithDifferentOccurrenceCount  == 1);
        bool canBecomeValid = (numberOfCharactersWithDifferentOccurrenceCount == 2 
                                && (
                                    (maxOccurrenceCount - minOccurrenceCount == 1 && occurrenceCount[maxOccurrenceCount] == 1) ||
                                    (minOccurrenceCount == 1 && occurrenceCount[minOccurrenceCount] == 1))
                                )
                                ? true
                                : false;

        return (isValid || canBecomeValid);
    }
    
    public static void Run()
    {
        string input = Console.ReadLine();
        bool isValid = SherlockAndValidString.ValidateString(input);

        string ans = isValid ? "YES" : "NO";

        Console.WriteLine(ans);
    }
}