// See https://aka.ms/new-console-template for more information

using SortingAlgorithms;

Console.WriteLine("------------Selection Sort---------------");
var arr = new int[] { 16, 23, 44, 12, 55, 40, 6 };

foreach (var item in arr)
{
    Console.Write($"{item,-5}");
}

Console.WriteLine();
SelectionSort.Sort<int>(arr,BinaryHeap.SortDirection.Descending);
foreach (var item in arr)
{
    Console.Write($"{item,-5}");
}
Console.WriteLine("");
Console.WriteLine("------------Bubble Sort---------------");
var arrBubble = new int[] { 16, 23, 44, 12, 55, 40, 6 };

foreach (var item in arrBubble)
{
    Console.Write($"{item,-5}");
}

Console.WriteLine();
BubbleSort.Sort<int>(arrBubble);
foreach (var item in arrBubble)
{
    Console.Write($"{item,-5}");
}
Console.WriteLine("");
Console.WriteLine("------------Insertion Sort---------------");
var arrIns = new int[] { 16, 23, 44, 12, 55, 40, 6 };

foreach (var item in arrIns)
{
    Console.Write($"{item,-5}");
}

Console.WriteLine();
InsertionSort.Sort<int>(arrIns);
foreach (var item in arrIns)
{
    Console.Write($"{item,-5}");
}




Console.ReadKey();

