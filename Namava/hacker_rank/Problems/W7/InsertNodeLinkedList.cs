// https://www.hackerrank.com/challenges/three-month-preparation-kit-insert-a-node-at-a-specific-position-in-a-linked-list/problem

using System;

class InsertNodeLinkedList
{

    class Node
    {
        public int data;
        public Node? next;

        public Node(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public Node? head;
        public Node? tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            Node node = new Node(nodeData);

            if (this.head == null)
                this.head = node;
            else
                this.tail.next = node;

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(Node? node)
    {
        while (node != null)
        {
            Console.Write($"{node.data} ");
            node = node.next;
        }
    }


    static Node InsertNodeAtPosition(Node? head, int data, int position)
    {
        Node? currentNode = head;

        int id = 0;
        Node? previousNode = null;

        Node newNode = new Node(data);

        while (currentNode != null)
        {
            if (id == position)
            {
                previousNode.next = newNode;
                newNode.next = currentNode;
                return head;
            }

            previousNode = currentNode;
            currentNode = currentNode.next;
            id++;
        }
        return newNode;
    }

    public static void Run()
    {
        int linkedListLength = Convert.ToInt32(Console.ReadLine());

        SinglyLinkedList myLinkedList = new SinglyLinkedList();

        for (int i = 0; i < linkedListLength; i++)
        {
            int nodeData = Convert.ToInt32(Console.ReadLine());
            myLinkedList.InsertNode(nodeData);
        }

        int newNodeData = Convert.ToInt32(Console.ReadLine());
        int newNodePosition = Convert.ToInt32(Console.ReadLine());

        Node newLinkedListHead = InsertNodeAtPosition(myLinkedList.head, newNodeData, newNodePosition);

        PrintSinglyLinkedList(newLinkedListHead);
        Console.WriteLine();
    }
}
