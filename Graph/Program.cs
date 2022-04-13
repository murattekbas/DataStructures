// See https://aka.ms/new-console-template for more information
var graph = new Graph.AdjancencySet.Graph<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' });

graph.AddEdge('A', 'B');
graph.AddEdge('A', 'D');
graph.AddEdge('C', 'D');
graph.AddEdge('C', 'E');
graph.AddEdge('D', 'E');
graph.AddEdge('E', 'F');
graph.AddEdge('F', 'G');

foreach (var key in graph)
{
    Console.WriteLine(key);
    foreach (var vertex in graph.GetVertex(key).Edges)
    {
        Console.WriteLine("   {0}", vertex);
    }
}

Console.WriteLine("Is there an edge between A and B? {0}", graph.HasEdge('A','B')?"Yes":"No");

Console.WriteLine($"Number of vertex in the graph: {graph.Count}");

Console.WriteLine("-----------------Weighted Graph----------------");
var graphWeighted = new Graph.AdjancencySet.WeightedGraph<char, double>(new char[] { 'A', 'B', 'C', 'D' });

foreach (var vertex in graphWeighted)
{
    Console.WriteLine("   {0}", vertex);
}


Console.WriteLine("Is there an edge between A and B? {0}", graphWeighted.HasEdge('A', 'B') ? "Yes" : "No");
graphWeighted.AddEdge('A', 'B', 1.2);
graphWeighted.AddEdge('A', 'D', 2.3);
graphWeighted.AddEdge('D', 'C', 5.5);
Console.WriteLine("Is there an edge between A and B? {0}", graphWeighted.HasEdge('A', 'B') ? "Yes" : "No");

foreach (var vertex in graphWeighted)
{
    Console.WriteLine(vertex);
    foreach (char key in graphWeighted.GetVertex(vertex))
    {
        var node = graphWeighted.GetVertex(key);
        Console.WriteLine($" {vertex} - {node.GetEdge(graphWeighted.GetVertex(vertex)).Weight<double>()} -  {key}");
    }
}


Console.WriteLine("-----------------Directed Graph----------------");
var graphDirected = new Graph.Concretes.DiGraph<char>(new char[] { 'A', 'B', 'C', 'D','E' });

foreach (var vertex in graphDirected)
{
    Console.WriteLine("   {0}", vertex);
}


graphDirected.AddEdge('B', 'A');
graphDirected.AddEdge('A', 'D');
graphDirected.AddEdge('D', 'E');
graphDirected.AddEdge('C', 'D');
graphDirected.AddEdge('C', 'E');
graphDirected.AddEdge('C', 'A');
graphDirected.AddEdge('C', 'B');
Console.WriteLine("Is there an edge between A and B? {0}", graphDirected.HasEdge('A', 'B') ? "Yes" : "No");

Console.WriteLine("Is there an edge between A and B? {0}", graphDirected.HasEdge('B', 'A') ? "Yes" : "No");

foreach (var key in graphDirected)
{
    Console.WriteLine(key);
    foreach (char item in graphDirected.GetVertex(key))
    {
        Console.WriteLine($" {item}");
    }
}

Console.WriteLine("-----------------Directed Weighted Graph----------------");
var graphWeightedDirected = new Graph.Concretes.WeightedDiGraph<char,int>(new char[] { 'A', 'B', 'C', 'D', 'E' });

foreach (var vertex in graphWeightedDirected)
{
    Console.WriteLine("   {0}", vertex);
}


graphWeightedDirected.AddEdge('A', 'C',12);
graphWeightedDirected.AddEdge('A', 'D', 60);
graphWeightedDirected.AddEdge('B', 'A', 10);
graphWeightedDirected.AddEdge('C', 'D', 32);
graphWeightedDirected.AddEdge('C', 'B', 20);
graphWeightedDirected.AddEdge('E', 'A', 7);

Console.WriteLine("Is there an edge between A and B? {0}", graphWeightedDirected.HasEdge('A', 'B') ? "Yes" : "No");
Console.WriteLine("Is there an edge between A and B? {0}", graphWeightedDirected.HasEdge('B', 'A') ? "Yes" : "No");

foreach (var vertexKey in graphWeightedDirected)   
{
    Console.WriteLine(vertexKey);
    foreach (char key in graphWeightedDirected.GetVertex(vertexKey))
    {
        var nodeU = graphWeightedDirected.GetVertex(vertexKey);
        var nodeV = graphWeightedDirected.GetVertex(key);
        var w = nodeU.GetEdge(nodeV).Weight<int>();

        Console.WriteLine($"  {vertexKey} - "+
            $"({w}) - "+$"{key}");
    }
}

Console.WriteLine("---------------DFS Algorithm-----------------");
var graphDfs = new Graph.AdjancencySet.Graph<int>();
for (int i = 0; i < 12; i++)
{
    graphDfs.AddVertex(i);
}
graphDfs.AddEdge(0, 1);
graphDfs.AddEdge(1, 4);
graphDfs.AddEdge(0, 4);
graphDfs.AddEdge(0, 2);

graphDfs.AddEdge(2, 5);
graphDfs.AddEdge(2, 10);
graphDfs.AddEdge(10, 11);
graphDfs.AddEdge(11, 9);
graphDfs.AddEdge(2, 9);

graphDfs.AddEdge(5, 7);
graphDfs.AddEdge(7, 8);
graphDfs.AddEdge(5, 8);
graphDfs.AddEdge(5, 6);

var algorithm = new Graph.Search.DepthFirst<int>();
Console.WriteLine("{0}", algorithm.Find(graphDfs, 110)?"Yes":"No");


Console.WriteLine("---------------BFS Algorithm-----------------");
var graphBfs = new Graph.AdjancencySet.Graph<int>();
for (int i = 0; i < 12; i++)
{
    graphBfs.AddVertex(i);
}

graphBfs.AddEdge(0, 1);
graphBfs.AddEdge(1, 4);
graphBfs.AddEdge(0, 4);
graphBfs.AddEdge(0, 2);

graphBfs.AddEdge(2, 5);
graphBfs.AddEdge(2, 10);
graphBfs.AddEdge(10, 11);
graphBfs.AddEdge(11, 9);
graphBfs.AddEdge(2, 9);

graphBfs.AddEdge(5, 7);
graphBfs.AddEdge(7, 8);
graphBfs.AddEdge(5, 8);
graphBfs.AddEdge(5, 6);

var algorithmBfs = new Graph.Search.BreadthFirst<int>();
Console.WriteLine("{0}", algorithmBfs.Find(graphBfs, 110) ? "Yes" : "No");

Console.ReadKey();
