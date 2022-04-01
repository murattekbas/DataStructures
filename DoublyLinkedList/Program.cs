// See https://aka.ms/new-console-template for more information
using DoublyLinkedList;

Console.WriteLine("Hello, World!");

var list = new DoublyLinkedList<int>();
list.AddFirst(12);
list.AddFirst(23);
//23 12

list.AddLast(44);
list.AddLast(55);
//23 12 44 55
Console.ReadKey();
