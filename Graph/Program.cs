﻿// See https://aka.ms/new-console-template for more information
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

Console.ReadKey();