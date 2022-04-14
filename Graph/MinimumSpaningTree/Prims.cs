using BinaryHeap;
using Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.MinimumSpaningTree
{
    public class Prims<T, W> where T : IComparable where W : IComparable
    {
        public List<MSTEdge<T, W>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, W>>();

            dfs(graph,
                graph.ReferenceVertex,
                new BinaryHeap.MinHeap<MSTEdge<T, W>>((int)BinaryHeap.SortDirection.Ascending),
                new HashSet<T>(), edges);

            return edges;
        }

        private void dfs(IGraph<T> graph, IGraphVertex<T> currentVertex, MinHeap<MSTEdge<T, W>> spNeighbours, HashSet<T> spVertices, List<MSTEdge<T, W>> spEdges)
        {
            while (true)
            {
                //kenarlar
                foreach (var edge in currentVertex.Edges)
                {
                    var e = new MSTEdge<T, W>(currentVertex.Key, edge.TargetVertexKey, edge.Weight<W>());
                    spNeighbours.Add(e);
                }

                //minEdge
                var minEdge = spNeighbours.DeleteMinMax();

                //var olan kenarları dikkate alma
                while (spVertices.Contains(minEdge.Source) && spVertices.Contains(minEdge.Destination))
                {
                    minEdge = spNeighbours.DeleteMinMax();
                    if (spNeighbours.Count == 0)
                        return;
                }
                //vertex takibi
                if (!spVertices.Contains(minEdge.Source))
                {
                    spVertices.Add(minEdge.Source);
                }
                spVertices.Add(minEdge.Destination);
                spEdges.Add(minEdge);
                currentVertex = graph.GetVertex(minEdge.Destination);
                
            }
        }
    }
}
