using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MyLinkedList
    {
        MyNode root;
        public void AddAtEnd(int data)
        {
            var newNode = new MyNode(data);
            newNode.next = null;
            if(root == null)
            {
                root = newNode;
                return;
            }
            var temp = root;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
            return;

        }
        public void AddFirst(int data)
        {
            MyNode newNode = new MyNode(data);
            newNode.next = null;
            if(root == null)
            {
                root = newNode;
                return;
            }
            newNode.next = root;
            root = newNode;
        }
        public void DeleteNode(int data)
        {
            var temp = root;
            if (temp == null)
                return;
            if(temp.data == data)
            {
                root = null;
                return;
            }
            MyNode prev = null;

            while (temp!=null && temp.data != data)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
                return;

            prev.next = temp.next;
        }
        public void PrintList()
        {
            var temp = root;
            while (temp != null)
            {
                Console.Write(temp.data + "->");
                temp = temp.next;
            }
            Console.WriteLine();
        }

    }
    class MyNode
    {
        public int data;
        public MyNode next;
        public MyNode prev;
        public MyNode(int data)
        {
            this.data = data;
        }
    }
}
