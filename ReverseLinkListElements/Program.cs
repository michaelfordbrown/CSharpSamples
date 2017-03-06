using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkListElements
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
        public void Print()
        {
            Console.WriteLine(" | " + data + " | -> ");
            if (next != null)
            {
                next.Print();
            }
        }
        public void AddSorted(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else if (data < next.data)
            {
                Node temp = new Node(data);
                temp.next = this.next;
                this.next = temp;
            }
            else
            {
                next.AddSorted(data);
            }
        }
        public void AddToEnd(int data)
        {
            if (next == null)
            {
                // At the end of the list
                next = new Node(data);
            }
            else
            {
                // Pass responsibility of adding data down the chain
                next.AddToEnd(data);
            }
        }
    }
    public class MyList
    {
        public Node headNode;

        public MyList()
        {
            headNode = null;
        }
        public void AddToEnd(int data)
        {
            if (headNode == null)
            {
                // At the end of the list
                headNode = new Node(data);
            }
            else
            {
                // Pass responsibility of adding data down the chain
                headNode.AddToEnd(data);
            }
        }

        public void AddSorted(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else if (data < headNode.data)
            {
                AddToBeginning(data);
            }
            else
            {
                headNode.AddSorted(data);
            }
        }
        public void AddToBeginning(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                Node temp = new Node(data);
                temp.next = headNode;
                headNode = temp;
            }
        }

        public void Print()
        {
            if (headNode != null)
            {
                headNode.Print();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Node myNode = new Node(7);
            //myNode.next = new Node(5);
            //myNode.next.next = new Node(3);
            //myNode.next.next.next = new Node(9);

            //myNode.AddToEnd(5);
            //myNode.AddToEnd(3);
            //myNode.AddToEnd(9);
            // myNode.Print();

            MyList list = new MyList();

            //list.AddToEnd(7);
            //list.AddToEnd(5);
            //list.AddToEnd(3);
            //list.AddToEnd(9);

            //list.AddToBeginning(7);
            //list.AddToBeginning(5);
            //list.AddToBeginning(3);
            //list.AddToBeginning(9);

            list.AddSorted(7);
            list.AddSorted(5);
            list.AddSorted(3);
            list.AddSorted(9);

            list.Print();


            Console.WriteLine("Press Any Key to Continue . .");
            Console.ReadKey();
        }
    }
}