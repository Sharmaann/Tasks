//https://www.hackerrank.com/challenges/three-month-preparation-kit-drawing-book/problem

using System;


class DrawingBook
{
    static int GetPagesTurnCountFromLastPage(int numberOfPages, int goalPage)
    {
        int pagesTurnCount = 0;
        int pageDistance = numberOfPages - goalPage;

        if (numberOfPages % 2 == 0)
            pagesTurnCount = (pageDistance + 1) / 2;
        else
            pagesTurnCount = pageDistance / 2;

        return pagesTurnCount;
    }

    static int GetPagesTurnCountFromFirstPage(int goalPage)
    {
        int pageDistance = goalPage - 1;
        int pagesTurnCount = (pageDistance + 1) / 2;

        return pagesTurnCount;
    }

    static int GetMinPagesTurnCount(int numberOfPages, int goalPage)
    {
        int pagesTurnCountFromFirst = DrawingBook.GetPagesTurnCountFromFirstPage(goalPage);
        int pagesTurnCountFromLast = DrawingBook.GetPagesTurnCountFromLastPage(numberOfPages, goalPage);

        return Math.Min(pagesTurnCountFromFirst, pagesTurnCountFromLast);
    }

    public static void Run()
    {
        int numberOfPages = Convert.ToInt32(Console.ReadLine().Trim());
        int goalPage = Convert.ToInt32(Console.ReadLine().Trim());

        int result = DrawingBook.GetMinPagesTurnCount(numberOfPages, goalPage);

        Console.WriteLine(result);
    }
}