// See https://aka.ms/new-console-template for more information
using BinaryHeap;

var heap = new MinHeap<int>(new int[] {4,1,10,7,5,9,3});

Console.WriteLine(heap.DeleteMinMax()+" has been removed.");

foreach (var item in heap)
{
    Console.WriteLine(item);
}


Console.ReadKey();
