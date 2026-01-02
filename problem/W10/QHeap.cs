// https://www.hackerrank.com/challenges/three-month-preparation-kit-qheap1/problem

using System;

class QHeap
{
    public static void Run()
    {
        int queryNumbers = Convert.ToInt32(Console.ReadLine());

        var pq = new PriorityQueue<int, int>();
        var numberOccurrenceCount = new Dictionary<int, int>();

        while (queryNumbers > 0)
        {
            string[] inputQuery = Console.ReadLine()
                .TrimEnd()
                .Split();

            string queryType = inputQuery[0];
            int number;
            int minNumber;

            switch (queryType)
            {
                case "1":
                    number = Convert.ToInt32(inputQuery[1]);
                    pq.Enqueue(number, number);

                    int occurrenceCount = 0;
                    numberOccurrenceCount.TryGetValue(number, out occurrenceCount);

                    occurrenceCount++;
                    numberOccurrenceCount[number] = occurrenceCount;
                    break;

                case "2":
                    number = Convert.ToInt32(inputQuery[1]);

                    numberOccurrenceCount[number]--;
                    break;

                case "3":

                    int candidateMinNumber = pq.Peek();

                    while (numberOccurrenceCount[candidateMinNumber] == 0)
                    {
                        pq.Dequeue();
                        candidateMinNumber = pq.Peek();
                    }

                    Console.WriteLine(candidateMinNumber);
                    break;
            }

            queryNumbers--;
        }
    }
}