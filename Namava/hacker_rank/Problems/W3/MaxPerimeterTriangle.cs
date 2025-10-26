//https://www.hackerrank.com/challenges/three-month-preparation-kit-maximum-perimeter-triangle/problem

using System;
using System.Runtime.InteropServices.Marshalling;

class MaxPerimeterTriangle
{
    static int BinarySearch(int left, int right, List<int> arr,  int value)
    {
        int mid = (left + right) / 2;

        if (left + 1 >= right)
            return (arr[right] <= value) ? arr[right] : arr[left];

        if (arr[mid] < value)
            left = mid;
        else if (arr[mid] > value)
            right = mid;
        else
            return arr[mid];

        return MaxPerimeterTriangle.BinarySearch(left, right, arr, value);
    }

    static int CalculatePerimeter(List <int> triangleEdgesLength)
    {
        int perimeter = 0;
        
        foreach (int edgeLength in triangleEdgesLength)
            perimeter += edgeLength;

        return perimeter;
    }

    static List <List<int>> GetBestValidTriangles(int arrSize, List <int> arr)
    {
        /*
         For example if we have:
            3 5 6 7
         After fixing (3, 5), I only choose 7 as the thirdEdgeLength and not 6, since its perimeter is greater.
         */
        var bestValidTriangles = new List<List<int>>();

        arr.Sort();

        // O(n**2 * log(n))
        for (int i = 0; i < arrSize; i++)
        {
            for (int j = i + 1; j < arrSize - 1; j++)
            {
                int firstEdgeLength = arr[i];
                int secondEdgeLength = arr[j];
                int thirdEdgeLengthUpperBound = firstEdgeLength + secondEdgeLength - 1;

                int bestThirdEdgeLength = MaxPerimeterTriangle.BinarySearch(j + 1, arrSize - 1, arr, thirdEdgeLengthUpperBound);

                if (bestThirdEdgeLength > thirdEdgeLengthUpperBound)
                    continue;

                bestValidTriangles.Add(new List<int> { firstEdgeLength, secondEdgeLength, bestThirdEdgeLength }); // This tuple is always in non-decreasing order
            }
        }

        return bestValidTriangles;
    }

    static List<List<int>> FindAllTrianglesWithMaxPerimeter(int arrSize, List<int> arr)
    {
        List<List<int>> bestValidTriangles = MaxPerimeterTriangle.GetBestValidTriangles(arrSize, arr);
        var bestTrianglesPerimeterList = new List<int>();
        /*
         best != max perimiter
         It's the best perimiter we can get after fixing the first and the second edges.
         */

        var allTrianglesWithMaxPerimeter = new List<List<int>> ();
        int maxPerimeter = Int32.MinValue;

        // Calculate the max perimeter
        foreach (List <int> triangleEdgesLength in bestValidTriangles)
        {
            int trianglePerimeter = MaxPerimeterTriangle.CalculatePerimeter(triangleEdgesLength);

            bestTrianglesPerimeterList.Add(trianglePerimeter);

            if (trianglePerimeter > maxPerimeter)
                maxPerimeter = trianglePerimeter;
        }

        // Find all valid triangles with max perimeter
        for (int triangleId = 0; triangleId < bestValidTriangles.Count; triangleId++)
        {
            if (bestTrianglesPerimeterList[triangleId] == maxPerimeter)
                allTrianglesWithMaxPerimeter.Add(bestValidTriangles[triangleId]);
        }

        return allTrianglesWithMaxPerimeter;
    }

    static (int minEdgeLength, int maxEdgeLength) getMinMaxEdgeOfTriangle(List <int> triangleEdgesLength)
    {
        return (triangleEdgesLength[0], triangleEdgesLength[2]);
    }

    static (List<int>? theBestTriangle, bool success) FindTheBestTriangleWithMaxPerimeter(int arrSize, List <int> arr)
    {
        List<List<int>> allTrianglesWithMaxPerimeter = MaxPerimeterTriangle.FindAllTrianglesWithMaxPerimeter(arrSize, arr);

        //Console.WriteLine("salam");

        //foreach (List<int> triangleWithMaxPerimeter in allTrianglesWithMaxPerimeter)
        //{
        //    Console.WriteLine($"{string.Join(' ', triangleWithMaxPerimeter)}: {MaxPerimeterTriangle.CalculatePerimeter(triangleWithMaxPerimeter)}");

        //}

        int numberOfTrianglesWithMaxPerimeter = allTrianglesWithMaxPerimeter.Count;

        if (numberOfTrianglesWithMaxPerimeter == 0)
            return (null, false);

        if (numberOfTrianglesWithMaxPerimeter > 1)
        {
            int maxEdgeLength = Int32.MinValue; // max edge length of all triangles
            int minEdgeLength = Int32.MaxValue; // min edge length of all triangles

            var minMaxEdgesOfTrianglesWithMaxPerimiter = new List<List<int>>();

            foreach (List<int> triangleWithMaxPerimeter in allTrianglesWithMaxPerimeter)
            {
                // minMaxEdgesOfTriangle.minEdgeLength: min edge length of a single triangle
                // minMaxEdgesOfTriangle.maxEdgeLength: max edge length of a single triangle

                var minMaxEdgesOfTriangle = MaxPerimeterTriangle.getMinMaxEdgeOfTriangle(triangleWithMaxPerimeter);
                
                if (minMaxEdgesOfTriangle.minEdgeLength < minEdgeLength)
                    minEdgeLength = minMaxEdgesOfTriangle.minEdgeLength;
                if (minMaxEdgesOfTriangle.maxEdgeLength > maxEdgeLength)
                    maxEdgeLength = minMaxEdgesOfTriangle.maxEdgeLength;

                minMaxEdgesOfTrianglesWithMaxPerimiter.Add(new List<int> { minMaxEdgesOfTriangle.minEdgeLength, minMaxEdgesOfTriangle.maxEdgeLength });

            }

            var trianglesWithMaxPerimiterAndEdge = new List<List<int>>();

            for (int i = 0; i < numberOfTrianglesWithMaxPerimeter; i++)
            {
                int minTriangleEdgeLength = minMaxEdgesOfTrianglesWithMaxPerimiter[i][0]; // min edge length of a single triangle
                int maxTriangleEdgeLength = minMaxEdgesOfTrianglesWithMaxPerimiter[i][1]; // max edge length of a single triangle

                if (maxEdgeLength == maxTriangleEdgeLength)
                    trianglesWithMaxPerimiterAndEdge.Add(allTrianglesWithMaxPerimeter[i]);
                if (maxEdgeLength == maxTriangleEdgeLength && minEdgeLength == minTriangleEdgeLength)
                    return (allTrianglesWithMaxPerimeter[i], true);
            }

            return (trianglesWithMaxPerimiterAndEdge[0], true);
        }

        return (allTrianglesWithMaxPerimeter[0], true);
    }

    public static void Run()
    {
        int arrSize = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        var result = MaxPerimeterTriangle.FindTheBestTriangleWithMaxPerimeter(arrSize, arr);

        if (!result.success)
            Console.WriteLine(-1);
        else
            Console.WriteLine(string.Join(" ", result.theBestTriangle));
    }
}