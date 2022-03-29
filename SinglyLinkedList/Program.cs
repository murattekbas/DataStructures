using SinglyLinkedList;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddLast(-5);
            linkedList.AddAfter(linkedList.Head.Next, 32);
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            linkedList.RemoveFirst();


            Console.ReadKey();
        }
    }
}




