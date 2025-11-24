// https://www.hackerrank.com/challenges/three-month-preparation-kit-reverse-a-linked-list/problem

//namespace ReverseLinkedList;

using System;
using System.Text;


class Node
{
    public int data;
    public Node? next;

    public static Node CreateNode(int data)
    {
        return new Node() { data = data };
    }


}

class LinkedList
{
    Node? head;

    public void UpdateHead(Node newHead)
    {
        this.head = newHead;
    }

    public void AddNode(Node newNode)
    {
        if (this.head is null)
        {
            this.head = newNode;
            return;
        }

        Node currentNode = this.head;


        while (true)
        {
            Node? nextNode = currentNode.next;

            if (nextNode is null)
                break;

            currentNode = nextNode;
        }

        currentNode.next = newNode;
    }

    public StringBuilder Iterate()
    {
        Node currentNode = this.head;

        StringBuilder res = new StringBuilder();

        while (true)
        {
            res.Append($"{currentNode.data} ");

            Node? nextNode = currentNode.next;

            if (nextNode is null)
                break;

            currentNode = nextNode;
        }

        return res;
    }

    public static LinkedList ReverseLinkedList(LinkedList linkedList)
    {
        Node? previousNode = null;
        Node currentNode = linkedList.head;
        Node? nextNode = null;

        LinkedList reversedLinkedList = new LinkedList();


        while (true)
        {
            nextNode = currentNode.next;
            currentNode.next = previousNode;
            previousNode = currentNode;
            reversedLinkedList.UpdateHead(currentNode);
            currentNode = nextNode;


            if (nextNode is null)
                break;

        }
        return reversedLinkedList;
    }
}

class ReverseLinkedList
{
    public static void Run()
    {
        int testCaseNumber = Convert.ToInt32(Console.ReadLine());

        while (testCaseNumber > 0)
        {
            int linkedListLength = Convert.ToInt32(Console.ReadLine());
            var myLinkedList = new LinkedList();

            
            for (int i = 0; i < linkedListLength; i++)
            {
                int nodeData = Convert.ToInt32(Console.ReadLine());

                myLinkedList.AddNode(Node.CreateNode(nodeData));
            }
            LinkedList reversedLinkedList = LinkedList.ReverseLinkedList(myLinkedList);

            StringBuilder res =  reversedLinkedList.Iterate();
            Console.WriteLine(res);

            testCaseNumber--;
        }
    }
}