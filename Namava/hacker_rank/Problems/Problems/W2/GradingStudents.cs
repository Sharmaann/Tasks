// https://www.hackerrank.com/challenges/three-month-preparation-kit-grading/problem

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

class GradingStudents
{

    static int RoundGrade(int grade)
    {
        /*
         If grade % 5 < 3, the difference of grade and its nearestGreaterMultipleOfFile will be more or equal to 3.
         */
        if (grade < 38 || grade % 5 < 3)
        {
            return grade;
        }

        int roundedNumber = ((grade / 5) + 1) * 5;
        return roundedNumber;
    }

    static List <int> GradeStudents(List <int> grades)
    {
        var finalGrades = new List<int>();

        foreach (int grade in grades)
        {
            finalGrades.Add(GradingStudents.RoundGrade(grade));
        }

        return finalGrades;
    }

    public static void Run()
    {

        int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        List<int> result = GradingStudents.GradeStudents(grades);


        foreach (int grade in result)
        {
            Console.WriteLine(grade);
        }

    }
}