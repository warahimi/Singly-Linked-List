using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Linked List Data Structure.
            MyLinkedList list= new MyLinkedList();
            list.insertAtEnd(10);
            list.insertAtEnd(20);
            list.insertAtEnd(30);
            list.insertAtEnd(40);
            list.insertAtEnd(50);
            
            list.reverse();
            list.insertAtEnd(200);
            list.insertAtBeginning(33);
            //Console.WriteLine(list.getIndex(900));
            //list.deleteDuplicates();

            //bool filterEvens(int data)
            //{
            //    return data % 2 == 0;
            //}
            //bool filterOdds(int data)
            //{
            //    return data % 2 != 0;
            //}
            //list.DeleteByCondition((data) => data > 0);


            list.print();
            Console.WriteLine("Size: "+ list.size());
            Console.WriteLine("Length: "+ list.length());
        }
    }
}