// See https://aka.ms/new-console-template for more information


using Stack;

var charset = new char[] { 'a', 'b', 'c', 'd', 'e' };
var stack1 = new Stack.Stack<char>();
var stack2 = new Stack.Stack<char>(Stack.StackType.LinkedList);

foreach (var c in charset)
{
    Console.WriteLine(c);
    stack1.Push(c);
    stack2.Push(c);
}

Console.WriteLine("Peek");
Console.WriteLine($"Stack 1: {stack1.Peek()}");
Console.WriteLine($"Stack 2: {stack2.Peek()}");

Console.WriteLine("Count");
Console.WriteLine($"Stack 1: {stack1.Count}");
Console.WriteLine($"Stack 2: {stack2.Count}");

Console.WriteLine("Pop");
Console.WriteLine($"Stack 1: {stack1.Pop()} has been removed");
Console.WriteLine($"Stack 2: {stack2.Pop()} has been removed");

Console.WriteLine("----------------------------------------PostFix--------------");
Console.WriteLine(PostFixExample.Run("231*+9-"));




Console.ReadKey();
