// See https://aka.ms/new-console-template for more information
using DoublyLinkedList;

var list = new DoublyLinkedList<int>();
list.AddFirst(12);
list.AddFirst(23);
//23 12

list.AddLast(44);
list.AddLast(55);
//23 12 44 55

list.AddAfter(list.Head.Next, new DoublyLinkedListNode<int>(13));
//23 12 13 44 55

foreach (var item in list)
{
    Console.Write(item.ToString() + " ");
}


var list2=new DoublyLinkedList<char>(new List<char>() { 'a','b','c','d'});
Console.WriteLine();
list2.RemoveFirst();
list2.RemoveLast();
list2.Delete('c');
foreach (var item in list2)
{
    Console.Write(item.ToString() + " ");
}

Console.ReadKey();
