// See https://aka.ms/new-console-template for more information
var graph = new Graph.AdjancencySet.Graph<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' });

graph.AddEdge('A', 'B');
graph.AddEdge('A', 'D');
graph.AddEdge('C', 'D');
graph.AddEdge('C', 'E');
graph.AddEdge('D', 'E');
graph.AddEdge('E', 'F');
graph.AddEdge('F', 'G');

foreach (var vertex in graph)
{
    Console.WriteLine(vertex);
}

Console.WriteLine($"Number of vertex in the graph: {graph.Count}");    


Console.ReadKey();
