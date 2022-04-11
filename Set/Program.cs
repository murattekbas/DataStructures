// See https://aka.ms/new-console-template for more information


using Set;

var disjointSet =new DisjointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });

disjointSet.Union(5, 6);
disjointSet.Union(1, 2);
disjointSet.Union(0, 2);
for (int i = 0; i < 7; i++)
{
    Console.WriteLine($"Find({i}) = {disjointSet.FindSet(i)}");
}
Console.ReadKey();
