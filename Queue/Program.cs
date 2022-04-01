// See https://aka.ms/new-console-template for more informatio


var numbers = new int[] { 10, 20, 30 };
var q1=new Queue.Queue<int>();  
var q2=new Queue.Queue<int>(Queue.QueueType.LinkedList);  

foreach (var number in numbers)
{
    Console.WriteLine(number);
    q1.EnQueue(number);
    q2.EnQueue(number);
}

Console.WriteLine($"q1 count: { q1.Count}");
Console.WriteLine($"q2 count: { q2.Count}");


Console.WriteLine($"q1: {q1.DeQueue()} has been removed");
Console.WriteLine($"q2: {q2.DeQueue()} has been removed");

Console.WriteLine($"q1 count: { q1.Count}");
Console.WriteLine($"q2 count: { q2.Count}");


Console.ReadKey();
