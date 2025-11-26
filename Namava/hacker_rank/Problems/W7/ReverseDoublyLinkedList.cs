// https://www.hackerrank.com/challenges/three-month-preparation-kit-reverse-a-doubly-linked-list/problem

using System;


class NodeDoubly
{
    public int data;
    public NodeDoubly? next;
    public NodeDoubly? prev;

    public NodeDoubly(int NodeDoublyData)
    {
        this.data = NodeDoublyData;
        this.next = null;
        this.prev = null;
    }
}

class DoublyLinkedList
{
    public NodeDoubly? head;
    public NodeDoubly? tail;

    public DoublyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertNodeDoubly(int NodeDoublyData)
    {
        NodeDoubly newNode = new NodeDoubly(NodeDoublyData);

        if (this.head == null)
            this.head = newNode;
        else if (this.tail != null)
        {
            this.tail.next = newNode;
            newNode.prev = this.tail;

        }

        this.tail = newNode;
    }

    public static void PrintDoublyLinkedList(NodeDoubly? node)
    {
        while (node != null)
        {
            Console.Write($"{node.data} ");

            node = node.next;
        }
    }
}

class ReverseDoublyLinkedList
{
    static NodeDoubly? reverse(NodeDoubly? head)
    {
        NodeDoubly? previousNodeDoubly = null;
        NodeDoubly? currentNodeDoubly = head;
        NodeDoubly? nextNodeDoubly = null;

        while (currentNodeDoubly != null)
        {
            nextNodeDoubly = currentNodeDoubly.next;
            currentNodeDoubly.next = previousNodeDoubly;
            currentNodeDoubly.prev = nextNodeDoubly;
            previousNodeDoubly = currentNodeDoubly;
            currentNodeDoubly = nextNodeDoubly;
        }

        return previousNodeDoubly;
    }

    public static void Run()
    {
        int testCaseNumber = Convert.ToInt32(Console.ReadLine());

        while (testCaseNumber > 0)
        {
            int doublyLinkedListLength = Convert.ToInt32(Console.ReadLine());

            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            for (int i = 0; i < doublyLinkedListLength; i++)
            {
                int nodeData = Convert.ToInt32(Console.ReadLine());
                doublyLinkedList.InsertNodeDoubly(nodeData);
            }

            NodeDoubly? res = reverse(doublyLinkedList.head);
            DoublyLinkedList.PrintDoublyLinkedList(res);

            testCaseNumber--;
        }
    }
}